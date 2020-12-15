﻿using System;
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
        public Employee(string firstname, string surname, string worktype)
        {
            FirstName = firstname;
            Surname = surname;
            WorkType = worktype;
        }
        #endregion Constructors

        public override string ToString()
        {
            return string.Format($"{Surname.ToUpper()}, {FirstName} - {WorkType}");
        }

        public abstract decimal CalculateMonthlyPay();
    }

    public class FullTimeEmployee:Employee
    {
        #region Properties
        public decimal Salary { get; set; }
        #endregion Properties

        
        #region Constructors
        public FullTimeEmployee(string firstname, string surname, string worktype, decimal salary):base(firstname, surname, worktype)
        {
            Salary = salary;
        }
        #endregion Constructors

        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = Salary / 12;
            return MonthlyPay;
        }

    }

    public class PartTimeEmployee:Employee
    {
        #region Properties
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        #endregion Properties

        #region Constructors
        public PartTimeEmployee(string firstname, string surname, string worktype, decimal hourlyrate, double hoursworked):base(firstname, surname, worktype)
        {
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }
        #endregion Constructors

        public override decimal CalculateMonthlyPay()
        {
            decimal MonthlyPay = (decimal)HoursWorked * HourlyRate;
            return MonthlyPay;
        }

    }
}