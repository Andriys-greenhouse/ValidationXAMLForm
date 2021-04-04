using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace ValidationXAMLForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static int curentIndex = 0;
        public static List<Employee> employeeList = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            employeeList.Add(new Employee("Martina", "Nováková", "1983", "Základní vzdělání", "Pokladní", "30000"));
            employeeList.Add(new Employee("Pavel", "Svobodný", "1995", "Maturitní zkouška", "Manager prodeje", "39000"));
            employeeList.Add(new Employee("Martin", "Pálava", "1958", "Maturitní zkouška", "Výkonný ředitel", "75000"));
            employeeList.Add(new Employee());

            this.DataContext = this;
            NameBox.DataContext = employeeList[curentIndex];
            LastNameBox.DataContext = employeeList[curentIndex];
            BirthYearBox.DataContext = employeeList[curentIndex];
            JobBox.DataContext = employeeList[curentIndex];
            WageBox.DataContext = employeeList[curentIndex];
            
            PropertyChanged(this, new PropertyChangedEventArgs("curentIndex"));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public static string HeadlineText
        {
            get
            {
                if (curentIndex == employeeList.Count - 1) { return "Nový zaměstnanec"; }
                else { return $"Zaměstnanec {curentIndex + 1}"; }
            }
        }

        public int nameErrHeight = 2;
        public string nameErrText = "";
        public Visibility nameErrVis = Visibility.Hidden;
        public static bool NameCheck()
        {
            if (true) { return true; } 
        }

        public Visibility LeftButtonVisibility
        {
            get
            {
                if (curentIndex == 0 || curentIndex == employeeList.Count - 1) { return Visibility.Hidden; }
                else { return Visibility.Visible; }
            }
        }

        public Visibility RightButtonVisibility
        {
            get
            {
                if (curentIndex < employeeList.Count - 2) { return Visibility.Visible; }
                else { return Visibility.Hidden; }
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            curentIndex--;
            PropertyChanged(this, new PropertyChangedEventArgs("curentIndex"));
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            curentIndex--;
            PropertyChanged(this, new PropertyChangedEventArgs("curentIndex"));
        }
    }
}
