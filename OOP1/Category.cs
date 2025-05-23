using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Category 
        //internal class là tất cả các class trong 1 namespace có thể truy xuất
    {
        public int Id;
        public string Name;
        public void printInfor()
        {
            string msg = $"{Id}\t{Name}"; // /t là tab; /r là xuống dòng; $ là string interpolation (biến trong chuỗi)
            Console.WriteLine(msg);
        }
    }
}
