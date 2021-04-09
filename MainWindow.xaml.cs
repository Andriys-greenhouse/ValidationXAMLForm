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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListButtonVisibility"));

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



        public int NameErrHeight { get; set; }
        public string NameErrText { get; set; }
        public Visibility NameErrVis { get; set; }
        public bool NameCheckOK()
        {
            if (NameBox.Text.Length < 2) 
            { 
                NameErrHeight = 20;
                NameErrText = "Jméno musí mít minimálně dvě písmena.";
                NameErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrVis"));
                return false;
            }
            
            else if (NameBox.Text.Length > 20)
            {
                NameErrHeight = 20;
                NameErrText = "Jméno musí mít maximálně dvacet písmen.";
                NameErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrVis"));
                return false;
            }

            else
            {
                NameErrHeight = 2;
                NameErrVis = Visibility.Hidden;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameErrVis"));
                return true;
            }
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameCheckOK();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddButtonVisibility"));
        }


        public int LastNameErrHeight { get; set; }
        public string LastNameErrText { get; set; }
        public Visibility LastNameErrVis { get; set; }
        public bool LastNameCheckOK()
        {
            if (LastNameBox.Text.Length < 2)
            {
                LastNameErrHeight = 20;
                LastNameErrText = "Přijmení musí mít minimálně dvě písmena.";
                LastNameErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrVis"));
                return false;
            }

            else if (LastNameBox.Text.Length > 20)
            {
                LastNameErrHeight = 20;
                LastNameErrText = "Přijmení musí mít maximálně dvacet písmen.";
                LastNameErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrVis"));
                return false;
            }

            else
            {
                LastNameErrHeight = 2;
                LastNameErrVis = Visibility.Hidden;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastNameErrVis"));
                return true;
            }
        }

        private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LastNameCheckOK();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddButtonVisibility"));
        }


        public int JobErrHeight { get; set; }
        public string JobErrText { get; set; }
        public Visibility JobErrVis { get; set; }
        public bool JobCheckOK()
        {
            if (JobBox.Text.Length < 2)
            {
                JobErrHeight = 20;
                JobErrText = "Pracovní pozice musí mít minimálně dvě písmena.";
                JobErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrVis"));
                return false;
            }

            else if (JobBox.Text.Length > 20)
            {
                JobErrHeight = 20;
                JobErrText = "Pracovní pozice musí mít maximálně dvacet písmen.";
                JobErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrVis"));
                return false;
            }

            else
            {
                JobErrHeight = 2;
                JobErrVis = Visibility.Hidden;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobErrVis"));
                return true;
            }
        }

        private void JobBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            JobCheckOK();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddButtonVisibility"));
        }



        public int BirthYearErrHeight { get; set; }
        public string BirthYearErrText { get; set; }
        public Visibility BirthYearErrVis { get; set; }
        public bool BirthYearCheckOK()
        {
            if (!int.TryParse(BirthYearBox.Text, out int notNeeded))
            {
                BirthYearErrHeight = 20;
                BirthYearErrText = "Rok narození musí být celé číslo.";
                BirthYearErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthYearErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthYearErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthYearErrVis"));
                return false;
            }

            else
            {
                BirthYearErrHeight = 2;
                BirthYearErrVis = Visibility.Hidden;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthYearErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthYearErrVis"));
                return true;
            }
        }

        private void BirthYearBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BirthYearCheckOK();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddButtonVisibility"));
        }


        public int WageErrHeight { get; set; }
        public string WageErrText { get; set; }
        public Visibility WageErrVis { get; set; }
        public bool WageCheckOK()
        {
            if (!int.TryParse(WageBox.Text, out int EmployeesWage) || EmployeesWage < 0)
            {
                WageErrHeight = 20;
                WageErrText = "Plat musí být celé a kladné číslo.";
                WageErrVis = Visibility.Visible;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WageErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WageErrText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WageErrVis"));
                return false;
            }

            else
            {
                WageErrHeight = 2;
                WageErrVis = Visibility.Hidden;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WageErrHeight"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WageErrVis"));
                return true;
            }
        }

        private void WageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WageCheckOK();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftButtonVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddButtonVisibility"));
        }




        public Visibility LeftButtonVisibility
        {
            get
            {
                if (_CurentIndex == 0 || _CurentIndex == employeeList.Count - 1 || !CompletCheckOk()) 
                { return Visibility.Hidden; }
                else { return Visibility.Visible; }
            }
        }

        public Visibility RightButtonVisibility
        {
            get
            {
                if (_CurentIndex < employeeList.Count - 2 && CompletCheckOk()) { return Visibility.Visible; }
                else { return Visibility.Hidden; }
            }
        }

        public Visibility ListButtonVisibility
        {
            get
            {
                if (_CurentIndex == employeeList.Count - 1) { return Visibility.Visible; }
                else { return Visibility.Hidden; }
            }
        }

        public Visibility AddButtonVisibility
        {
            get
            {
                if (CompletCheckOk()) { return Visibility.Visible; }
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurentIndex != employeeList.Count - 1) 
            { 
                CurentIndex = employeeList.Count - 1; 
            }
            else if (CompletCheckOk())
            {
                employeeList.Add(new Employee());
                CurentIndex = employeeList.Count - 2;
            }
            else { MessageBox.Show("Nesprávná hodnota polí."); }
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            CurentIndex = 0;
            employeeList.Add(new Employee());
            employeeList.RemoveAt(employeeList.Count - 2);
        }

        public bool CompletCheckOk() 
        { return NameCheckOK() && LastNameCheckOK() && BirthYearCheckOK() && JobCheckOK() && WageCheckOK(); }
    }
}
