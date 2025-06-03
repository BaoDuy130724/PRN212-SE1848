using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2ObjectModelClass
{
    public class Product
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{ID} \t {Name} \t {Quantity} \t {Price}";
        }
        public Product Clone()
        {
            return MemberwiseClone() as Product; // MemberwiseClone() dùng để tạo ra bản sao nông (shallow copy) của đối tượng hiện đại 
        }
    }
}
