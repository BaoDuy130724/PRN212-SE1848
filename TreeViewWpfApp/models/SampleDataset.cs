using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class SampleDataset
    {
        public static Dictionary<int, Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category c1 = new Category() { Id = 1, Name = "Nước ngọt" };
            Category c2 = new Category() { Id = 2, Name = "Bia" };
            Category c3 = new Category() { Id = 3, Name = "Thức ăn nhanh" };
            categories.Add(c1.Id,c1);
            categories.Add(c2.Id, c2);
            categories.Add(c3.Id, c3);
            Product p1 = new Product() { Id=1, Name="Coca", Quantity = 12, Price=201};
            Product p2 = new Product() { Id = 2, Name = "Sting", Quantity = 12, Price = 202 };
            Product p3 = new Product() { Id = 3, Name = "7Up", Quantity = 31, Price = 203};
            Product p4 = new Product() { Id = 4, Name = "Xá Xị", Quantity =421, Price = 204 };
            Product p5 = new Product() { Id = 5, Name = "Sài Gòn", Quantity = 21, Price = 205 };
            Product p6 = new Product() { Id = 6, Name = "Tiger", Quantity = 21, Price = 203 };
            Product p7 = new Product() { Id = 7, Name = "333", Quantity = 11, Price = 202 };
            Product p8 = new Product() { Id = 8, Name = "Sư Tử", Quantity = 31, Price = 201 };
            Product p9 = new Product() { Id = 9, Name = "Khoai tây chiên", Quantity = 51, Price = 205 };
            Product p10 = new Product() { Id = 10, Name = "Bắp Nướng", Quantity = 71, Price = 201 };
            Product p11 = new Product() { Id = 11, Name = "Snack", Quantity = 231, Price = 206 };
            Product p12 = new Product() { Id = 12, Name = "Coca2", Quantity = 31, Price = 202 };
            Product p13 = new Product() { Id = 13, Name = "Coca4", Quantity = 21, Price = 260 };
            Product p14 = new Product() { Id = 14, Name = "Coca5", Quantity = 11, Price = 207 };
            Product p15 = new Product() { Id = 15, Name = "Coca6", Quantity = 51, Price = 200 };
            c1.Products.Add(p1.Id, p1);
            c1.Products.Add(p2.Id, p2);
            c1.Products.Add(p3.Id, p3);
            c1.Products.Add(p4.Id, p4);
            c1.Products.Add(p15.Id, p15);

            c2.Products.Add(p5.Id, p5);
            c2.Products.Add(p6.Id, p6);
            c2.Products.Add(p7.Id, p7);
            c2.Products.Add(p8.Id, p8);
            c2.Products.Add(p14.Id, p14);

            c3.Products.Add(p9.Id, p9);
            c3.Products.Add(p10.Id, p10);
            c3.Products.Add(p11.Id, p11);
            c3.Products.Add(p12.Id, p12);
            c3.Products.Add(p13.Id, p13);
            return categories;
        }
    }
}
