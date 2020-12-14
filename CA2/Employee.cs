using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public abstract class Employee
    {
        //Properties
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public abstract decimal CalculateMonthlyPay();
    }

    public class FullTimeEmployee:Employee
    {
        public decimal Salary { get; set; }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = Salary / 12;
            return MonthlyPay;
        }
    }

    public class PartTimeEmployee:Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public override decimal CalculateMonthlyPay()
        {
            decimal decHoursWorked = Convert.ToDecimal(HoursWorked);
            decimal MonthlyPay = decHoursWorked * HourlyRate;
            return MonthlyPay;
        }
    }
}