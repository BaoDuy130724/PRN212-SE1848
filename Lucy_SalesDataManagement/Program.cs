// See https://aka.ms/new-console-template for more information
using Lucy_SalesDataManagement;

Console.WriteLine("Hello, World!");
string connectionString = @"server=LAPTOP-C8SETICQ\SQLEXPRESS;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);
//Q1: loc ra toan bo khach hang
var ds = context.Customers.ToList();
foreach (var d in ds)
{
    Console.WriteLine(d.CustomerID + d.ContactName);
}
//Q2: tim chi tiet khach hang khio biet ma
int ma = 10;
Customer cus = context.Customers.FirstOrDefault(c => c.CustomerID ==  ma);
if(cus != null)
{
    Console.WriteLine(cus.CustomerID + "\t" + cus.ContactName);
}
//Q3: Loc ra danh sach cac hoa don cua khach hang
// cac cot du lieu gom: ma hoa don va ngay hoa don
if (cus != null)
{
    var dshd = cus.Orders.Select(od => new { od.OrderID, od.OrderDate }).ToList();
    foreach (var item in dshd)
    {
        Console.WriteLine(item.OrderID + "\t" + item.OrderDate.ToString("dd/MM/yyyy"));
    }
}
//Q4 tu ket qua cau 3, bo sung them cot tri gia cua don han cua moi hoa don (unitprice)
if (cus != null)
{
    var dshd4 = cus.Orders.
        Select(od => new { od.OrderID, od.OrderDate, TotalValue = od.Order_Details.
        Sum(odd => odd.Quantity * odd.UnitPrice * (1-(decimal)odd.Discount))}).
        ToList();
    foreach (var item in dshd4)
    {
        Console.WriteLine(item.OrderID + "\t" + item.OrderDate.ToString("dd/MM/yyyy" + item.TotalValue));
    }
}