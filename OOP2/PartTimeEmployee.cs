using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class PartTimeEmployee:Employee
    {
        public int HoursWorked { get; set; }
        public override double calSalary()
        {
            return HoursWorked * 100000; // 100000 is the hourly rate
        }

    }
}
