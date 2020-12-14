using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public abstract class Employee
    {
        #region Properties
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string WorkType { get; set; }
        #endregion Properties

        #region Constructors
        public Employee(string firstname, string surname)
        {
            FirstName = firstname;
            Surname = surname;
        }
        #endregion Constructors

        public override string ToString()
        {
            return string.Format($"{Surname}, {FirstName}");
        }

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
        public FullTimeEmployee(string firstname, string surname):base(firstname, surname)
        {
        }
    }

    public class PartTimeEmployee:Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = (decimal)HoursWorked * HourlyRate;
            return MonthlyPay;
        }
        public PartTimeEmployee(string firstname, string surname):base(firstname, surname)
        {
        }
    }
}