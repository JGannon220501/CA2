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
        public abstract decimal CalculateMonthlyPay();
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