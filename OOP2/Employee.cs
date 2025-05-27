using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Employee
    {
        public int Id { get; set; }
        public string IdCard { get; set; } = string.Empty; // this cannot be null, so we initialize it with an empty string
        public string Name { get; set; } = string.Empty; // this cannot be null, so we initialize it with an empty string
        public DateTime Birthday { get; set; }      
        public virtual double calSalary() // virtual keyword allows derived classes to override this method if neccessary
        {
            return 4000000;
        }
        public override string ToString()
        {
            return Id+"\t"+IdCard + "\t"+ Name + "\t" + Birthday.ToString("dd/MM/yyyy") + "\t" + calSalary();
        }
    }
}
