using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_ReuseOOP2
{
    public static class YourUtils
    {
        public static int Tuoi(this Employee employee)
        {
            return DateTime.Now.Year - employee.Birthday.Year;
        }
        // trả về có phải tháng hiện tại là tháng sinh nhật của nhận viên hay không?
        public static bool IsBirthdayMonth(this Employee emp)
        {
            return emp.Birthday.Month == DateTime.Now.Month;
        }
    }
}
