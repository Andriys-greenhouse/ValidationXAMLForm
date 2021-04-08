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
        public event PropertyChangedEventHandler PropertyChanged;

        static int _CurentIndex;
        public int CurentIndex
        {
            get { return _CurentIndex; }
            set
            {
                _CurentIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HeadlineText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentName"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentLastName"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentBirthYear"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentJob"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentWage"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentEducationIndex"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightButtonVisibility"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftButtonVisibility"));
            }
        }

        public static List<Employee> employeeList = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            employeeList.Add(new Employee("Martina", "Nováková", "1983", "Základní vzdělání", "Pokladní", "30000"));
            employeeList.Add(new Employee("Pavel", "Svobodný", "1995", "Maturitní zkouška", "Manager prodeje", "39000"));
            employeeList.Add(new Employee("Martin", "Pálava", "1958", "Maturitní zkouška", "Výkonný ředitel", "75000"));
            employeeList.Add(new Employee());

            DataContext = this;
            /*
            NameBox.DataContext = employeeList[CurentIndex];
            LastNameBox.DataContext = employeeList[CurentIndex];
            BirthYearBox.DataContext = employeeList[CurentIndex];
            JobBox.DataContext = employeeList[CurentIndex];
            WageBox.DataContext = employeeList[CurentIndex];
            */

            CurentIndex = 0;
        }

        public string HeadlineText
        {
            get
            {
                if (_CurentIndex == employeeList.Count - 1) { return "Nový zaměstnanec"; }
                else { return $"Zaměstnanec {_CurentIndex + 1}"; }
            }
        }

        public string CurentName 
        { 
            get { return employeeList[CurentIndex].Name; } 
            set { employeeList[CurentIndex].Name = value; } 
        }
        public string CurentLastName 
        { 
            get { return employeeList[CurentIndex].LastName; }
            set { employeeList[CurentIndex].LastName = value; }
        }
        public string CurentBirthYear 
        { 
            get { return employeeList[CurentIndex].BirthYear; }
            set { employeeList[CurentIndex].BirthYear = value; }
        }
        public string CurentJob 
        { 
            get { return employeeList[CurentIndex].Job; }
            set { employeeList[CurentIndex].Job = value; }
        }
        public string CurentWage 
        { 
            get { return employeeList[CurentIndex].Wage; }
            set { employeeList[CurentIndex].Wage = value; }
        }
        public int CurentEducationIndex 
        { 
            get { return employeeList[CurentIndex].EducationIndex; }
            set { employeeList[CurentIndex].EducationIndex = value; }
        }


        public int nameErrHeight { get; set; }
        public string nameErrText { get; set; }
        public Visibility nameErrVis { get; set; }
        public static bool NameCheck()
        {
            if (NameBox.Text.Length < 1) 
            { 
                nameErrHeight = 10;
                nameErrText = "Name must be at least two characters long."
                nameErrVis = Visibility.Visible;
                return false;
            }
            
            else if (NameBox.Text.Length > 20)
            {
                nameErrHeight = 10;
                nameErrText = "Name must be at most twenty characters long."
                nameErrVis = Visibility.Visible;
                return false;
            }

            else
            {
                nameErrHeight = 2;
                nameErrVis = Visibility.Hidden;
                return true;
            }
        }


        public Visibility LeftButtonVisibility
        {
            get
            {
                if (_CurentIndex == 0 || _CurentIndex == employeeList.Count - 1) { return Visibility.Hidden; }
                else { return Visibility.Visible; }
            }
        }

        public Visibility RightButtonVisibility
        {
            get
            {
                if (_CurentIndex < employeeList.Count - 2) { return Visibility.Visible; }
                else { return Visibility.Hidden; }
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            CurentIndex--;
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            CurentIndex++;
        }
    }
}
