using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Employee e1 = new PartTimeEmployee("Jane", "Jones");
            Employee e2 = new FullTimeEmployee("Joe", "Murphy");
            Employee e3 = new PartTimeEmployee("John", "Smith");
            Employee e4 = new FullTimeEmployee("Jess", "Walsh");
            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
            employees.Add(e4);

            lbxNames.ItemsSource = employees;
        }

        //clears text boxes for input
        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
        }
        private void tbxSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSurname.Clear();
        }
        private void tbxSalary_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSalary.Clear();
        }
        private void tbxHoursWorked_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxHoursWorked.Clear();
        }
        private void tbxHourlyRate_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxHourlyRate.Clear();
        }

        //clear button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
            tbxSurname.Clear();
            tbxSalary.Clear();
            tbxHoursWorked.Clear();
            tbxHourlyRate.Clear();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string firstname = tbxFirstName.Text;
            string surname = tbxSurname.Text;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtnFT_Checked(object sender, RoutedEventArgs e)
        {
            if(rbtnFT.IsChecked == true)
            {
                string worktype = "FullTime";
            }
            else if(rbtnPT.IsChecked == true)
            {
                string worktype = "PartTime";
            }
        }
    }
}
