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
            Employee e1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 10, 25);
            Employee e2 = new FullTimeEmployee("Joe", "Murphy", "Full Time", 52000);
            Employee e3 = new PartTimeEmployee("John", "Smith", "Part Time", 12, 18);
            Employee e4 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 78000);
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
            decimal salary = Convert.ToDecimal(tbxSalary.Text);
            decimal hourlyrate = Convert.ToDecimal(tbxHourlyRate.Text);
            double hoursworked = Convert.ToDouble(tbxHoursWorked.Text);
            if (rbtnFT.IsChecked == true)
            {
                string worktype = "Full Time";
                Employee employee = new FullTimeEmployee(firstname, surname, worktype, salary);
                employees.Add(employee);
            }
            else if (rbtnPT.IsChecked == true)
            {
                string worktype = "Part Time";
                Employee employee = new PartTimeEmployee(firstname, surname, worktype, hourlyrate, hoursworked);
                employees.Add(employee);
            }
        }

        private void lbxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FullTimeEmployee selectedEmployeeFT = lbxNames.SelectedItem as FullTimeEmployee;
            if(selectedEmployeeFT != null)
            {
                tbxFirstName.Text = selectedEmployeeFT.FirstName;
                tbxSurname.Text = selectedEmployeeFT.Surname;
                tbxSalary.Text = (Convert.ToString(selectedEmployeeFT.Salary));
                rbtnFT.IsChecked = true;
                tbxHourlyRate.Clear();
                tbxHoursWorked.Clear();
            }
            PartTimeEmployee selectedEmployeePT = lbxNames.SelectedItem as PartTimeEmployee;
            if(selectedEmployeePT != null)
            {
                tbxFirstName.Text = selectedEmployeePT.FirstName;
                tbxSurname.Text = selectedEmployeePT.Surname;
                rbtnPT.IsChecked = true;
                tbxHourlyRate.Text = Convert.ToString(selectedEmployeePT.HourlyRate);
                tbxHoursWorked.Text = Convert.ToString(selectedEmployeePT.HoursWorked);
                tbxSalary.Clear();
            }
        }

        private void cbxFT_Checked(object sender, RoutedEventArgs e)
        {
            string worktype = "";
            filteredEmployees.Clear();
            lbxNames.ItemsSource = null;

            if (cbxFT.IsChecked != true && cbxPT.IsChecked != true)
            {
                lbxNames.ItemsSource = employees;
            }
            else
            {
                if (cbxFT.IsChecked == true)
                {
                    worktype = "Full Time";
                }
                else if (cbxPT.IsChecked == true)
                {
                    worktype = "Part Time";
                }
                foreach (Employee employee in employees)
                {
                    if(employee.WorkType == worktype)
                    {
                        filteredEmployees.Add(employee);
                    }    
                }
                lbxNames.ItemsSource = filteredEmployees;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lbxNames.Items.Remove(employees);
        }
    }
}