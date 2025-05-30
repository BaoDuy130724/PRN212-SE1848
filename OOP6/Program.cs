using OOP6_Dictionary;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nước ngọt";
Product p1 = new Product();
p1.Id = 1;
p1.Name = "Coca";
p1.Quantity = 10;
p1.Price = 30000000;
c1.AddProduct(p1);
Product p2 = new Product();
p2.Id = 2;
p2.Name = "Pepsi";
p2.Quantity = 5;
p2.Price = 35000000;
c1.AddProduct(p2);
Product p3 = new Product();
p3.Id = 3;
p3.Name = "7Up";
p3.Quantity = 12;
p3.Price = 40000000;
c1.AddProduct(p3);
Product p4 = new Product();
p4.Id = 4;
p4.Name = "C2";
p4.Quantity = 8;
p4.Price = 45000000;
c1.AddProduct(p4);
Product p5 = new Product();
p5.Id = 5;
p5.Name = "Xá xị";
p5.Quantity = 15;
p5.Price = 30000000;
c1.AddProduct(p5);
Console.WriteLine("Thong tin danh muc");
Console.WriteLine(c1);
Console.WriteLine("Danh sach san pham");
c1.PrintAllProducts();
double min_price = 30000000;
double max_price = 50000000;
Dictionary<int, Product> products_by_price = c1.FilterProductsByPrice(min_price, max_price);
Console.WriteLine($"Danh sach san pham co gia tu {min_price} den {max_price}");
foreach (KeyValuePair<int, Product> kvp in products_by_price)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}
Dictionary<int, Product> sorted_complex_products = c1.SortComplex();
Console.WriteLine("Danh sach san pham sap xep theo gia tang dan");
foreach(KeyValuePair<int, Product> kvp in sorted_complex_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}
p5.Name = "Fanta";
p5.Price = 80000000;
p5.Quantity = 17;
bool ret =c1.UpdateProduct(p5);
Console.WriteLine("sau khi chỉnh");
c1.PrintAllProducts();

int id = 5;
ret = c1.RemoveProduct(id);
if (ret)
{
    Console.WriteLine($"Tim thay ma {id}");
    Console.WriteLine($"sau khi xoa san pham co id = {id}");
    c1.PrintAllProducts();
}
else
{
    Console.WriteLine($"Khong tim thay ma {id}");
    
}
double min = 30000000;
double max = 40000000;
Console.WriteLine("Danh sach truoc khi xoa");
c1.PrintAllProducts();
c1.RemoveProductsByPrice2(min, max);
Console.WriteLine("Danh sach sau khi xoa");
c1.PrintAllProducts();
LinkedList<Category> categories = new LinkedList<Category>();
categories.AddLast(c1);

Category c2 = new Category();
c2.Id = 2;
c2.Name = "Bia";
c2.AddProduct(new Product { Id = 6, Name = "Tiger", Quantity = 20, Price = 20000000 });
c2.AddProduct(new Product { Id = 7, Name = "Ken", Quantity = 15, Price = 25000000 });
c2.AddProduct(new Product { Id = 8, Name = "333", Quantity = 8, Price = 26700000 });
categories.AddFirst(c2);
Console.WriteLine("Danh sach toan bo san pham theo danh muc");
foreach(Category c in categories)
{
    Console.WriteLine(c);
    Console.WriteLine("-----------------------------------------");
    c.PrintAllProducts();
    Console.WriteLine("-----------------------------------------");
}