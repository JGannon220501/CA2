using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    abstract class Employee
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string WorkType { get; set; }
        public abstract decimal CalculateMonthlyPay();
        public Employee(string firstname, string surname, string worktype)
        {
            FirstName = firstname;
            Surname = surname;
            WorkType = worktype;
        }
        public override string ToString()
        {
            return string.Format($"{Surname}, {FirstName} - {WorkType}");
        }
    }
    public class FullTimeEmployee:Employee
    {
        public decimal Salary { get; set; }
        CalculateMonthlyPay()
        {
            decimal MonthlyPay = Salary / 12;
        }
    }
    public class PartTimeEmployee:Employee
    {
        public double HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        CalculateMonthlyPay()
        {
            decimal decHoursWorked = Convert.ToDecimal(HoursWorked);
            decimal MonthlyPay = decHoursWorked * HourlyRate;
        }
    }
}