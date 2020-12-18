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
        ObservableCollection<FullTimeEmployee> fullTimeEmployees = new ObservableCollection<FullTimeEmployee>();
        ObservableCollection<PartTimeEmployee> partTimeEmployees = new ObservableCollection<PartTimeEmployee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Window Loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Employee e1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 10, 25);
            PartTimeEmployee pt1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 10, 25);
            Employee e2 = new FullTimeEmployee("Joe", "Murphy", "Full Time", 52000);
            FullTimeEmployee ft1 = new FullTimeEmployee("Joe", "Murphy", "Full Time", 52000);
            Employee e3 = new PartTimeEmployee("John", "Smith", "Part Time", 12, 18);
            PartTimeEmployee pt2 = new PartTimeEmployee("John", "Smith", "Part Time", 12, 18);
            Employee e4 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 78000);
            FullTimeEmployee ft2 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 78000);
            employees.Add(e1);
            partTimeEmployees.Add(pt1);
            employees.Add(e2);
            fullTimeEmployees.Add(ft1);
            employees.Add(e3);
            partTimeEmployees.Add(pt2);
            employees.Add(e4);
            fullTimeEmployees.Add(ft2);
            lbxNames.ItemsSource = employees;
        }   //Adds employees to list when the window loads

        //List box loads
        private void lbxNames_Loaded(object sender, RoutedEventArgs e)
        {
            employees.OrderBy(x => x.Surname).ToList();
            fullTimeEmployees.OrderBy(x => x.Surname).ToList();
            partTimeEmployees.OrderBy(x => x.Surname).ToList();
        }   //Sorts the list box alphabetically by surname

        //Text box focus        
        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
        }   //clears text boxes for first name input
        private void tbxSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSurname.Clear();
        }   //clears text boxes for surname input
        private void tbxSalary_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSalary.Clear();
        }   //clears text boxes for salary input
        private void tbxHoursWorked_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxHoursWorked.Clear();
        }   //clears text boxes for hours worked input
        private void tbxHourlyRate_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxHourlyRate.Clear();
        }   //clears text boxes for hourly rate input

        //Listbox
        private void lbxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = lbxNames.SelectedItem as Employee;
            FullTimeEmployee selectedEmployeeFT = lbxNames.SelectedItem as FullTimeEmployee;
            PartTimeEmployee selectedEmployeePT = lbxNames.SelectedItem as PartTimeEmployee;

            if (selectedEmployee != null)
            {
                tbxFirstName.Text = selectedEmployee.FirstName;
                tbxSurname.Text = selectedEmployee.Surname;

                if (selectedEmployee.WorkType == "Full Time")
                {
                    tbxSalary.Text = selectedEmployeeFT.Salary.ToString();
                    tblkMonthlyPay.Text = selectedEmployeeFT.CalculateMonthlyPay().ToString();
                    rbtnFT.IsChecked = true;
                    tbxHourlyRate.Clear();
                    tbxHoursWorked.Clear();
                }
                else if(selectedEmployee.WorkType == "Part Time")
                {
                    rbtnPT.IsChecked = true;
                    tbxHourlyRate.Text = selectedEmployeePT.HourlyRate.ToString();
                    tbxHoursWorked.Text = selectedEmployeePT.HoursWorked.ToString();
                    tblkMonthlyPay.Text = selectedEmployeePT.CalculateMonthlyPay().ToString();
                    tbxSalary.Clear();
                }
            }
        }   //Select employees from listbox
     
        //Checkboxes
        private void cbxFT_Checked(object sender, RoutedEventArgs e)
        {
            if(cbxFT.IsChecked == true)
            {
                lbxNames.ItemsSource = fullTimeEmployees;
            }
        }   //Checked checkbox to show full time employes
        private void cbxFT_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxFT.IsChecked == false)
            {
                lbxNames.ItemsSource = employees;
            }

        }   //Unchecked checkbox to show all employees again
        private void cbxPT_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxPT.IsChecked == true)
            {
                lbxNames.ItemsSource = partTimeEmployees;
            }

        }   //Checked checkbox to show part time employes
        private void cbxPT_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxPT.IsChecked == false)
            {
                lbxNames.ItemsSource = employees;
            }

        }   //Unchecked checkbox to show all employees again

        //Buttons
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string firstname = tbxFirstName.Text;
            string surname = tbxSurname.Text;
            if (rbtnFT.IsChecked == true)
            {
                string worktype = "Full Time";
                decimal salary = Convert.ToDecimal(tbxSalary.Text);
                FullTimeEmployee employeeFT = new FullTimeEmployee(firstname, surname, worktype, salary);
                Employee employee = new FullTimeEmployee(firstname, surname, worktype, salary);
                employees.Add(employee);
                fullTimeEmployees.Add(employeeFT);
            }
            else if (rbtnPT.IsChecked == true)
            {
                string worktype = "Part Time";
                decimal hourlyrate = Convert.ToDecimal(tbxHourlyRate.Text);
                double hoursworked = Convert.ToDouble(tbxHoursWorked.Text);
                PartTimeEmployee employeePT = new PartTimeEmployee(firstname, surname, worktype, hourlyrate, hoursworked);
                Employee employee = new PartTimeEmployee(firstname, surname, worktype, hourlyrate, hoursworked);
                employees.Add(employee);
                partTimeEmployees.Add(employeePT);
            }
        }   //Add button to add emplyees
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
            tbxSurname.Clear();
            tbxSalary.Clear();
            tbxHoursWorked.Clear();
            tbxHourlyRate.Clear();
            rbtnFT.IsChecked = false;
            rbtnPT.IsChecked = false;
            tblkMonthlyPay.Text = "";
        }   //Clear button to clear all text boxes
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Employee Employee = lbxNames.SelectedItem as Employee;                                       
            FullTimeEmployee FullTimeEmployee = lbxNames.SelectedItem as FullTimeEmployee;
            PartTimeEmployee PartTimeEmployee = lbxNames.SelectedItem as PartTimeEmployee;
            string FirstName = tbxFirstName.Text;                                                 
            string Surname = tbxSurname.Text;
            string WorkType;
            if (rbtnFT.IsChecked == true)
            {
                decimal Salary = Convert.ToDecimal(tbxSalary.Text);
                WorkType = "FullTime";
            }
            else if(rbtnPT.IsChecked == true)
            {
                string HoursWorked = tbxHoursWorked.Text;
                string HourlyRate = tbxHourlyRate.Text;
                WorkType = "PartTime";
            }
        }   //Update button to update employee details
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = lbxNames.SelectedItem as Employee;
            FullTimeEmployee selectedEmployeeFT = lbxNames.SelectedItem as FullTimeEmployee;
            PartTimeEmployee selectedEmployeePT = lbxNames.SelectedItem as PartTimeEmployee;
            employees.Remove(selectedEmployee);
            fullTimeEmployees.Remove(selectedEmployeeFT);
            partTimeEmployees.Remove(selectedEmployeePT);
        }   //Delete button to delete employees
    }
}