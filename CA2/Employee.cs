using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public abstract decimal CalculateMonthlyPay();
    }
}
