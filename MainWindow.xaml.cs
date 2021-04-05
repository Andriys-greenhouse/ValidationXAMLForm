﻿using System;
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurentIndex"));
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

 
            NameBox.DataContext = employeeList[CurentIndex];
            LastNameBox.DataContext = employeeList[CurentIndex];
            BirthYearBox.DataContext = employeeList[CurentIndex];
            JobBox.DataContext = employeeList[CurentIndex];
            WageBox.DataContext = employeeList[CurentIndex];
        }

        public string HeadlineText
        {
            get
            {
                if (_CurentIndex == employeeList.Count - 1) { return "Nový zaměstnanec"; }
                else { return $"Zaměstnanec {_CurentIndex + 1}"; }
            }
        }

        public int nameErrHeight = 2;
        public string nameErrText = "";
        public Visibility nameErrVis = Visibility.Hidden;
        public static bool NameCheck()
        {
            if (true) { return true; } 
        }

        public static Visibility LeftButtonVisibility
        {
            get
            {
                if (_CurentIndex == 0 || _CurentIndex == employeeList.Count - 1) { return Visibility.Hidden; }
                else { return Visibility.Visible; }
            }
        }

        public static Visibility RightButtonVisibility
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
