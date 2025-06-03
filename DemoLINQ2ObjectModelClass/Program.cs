using DemoLINQ2ObjectModelClass;

ListProduct lp = new ListProduct();
lp.gen_Product();
// Q1: loc ra cac san pham co gia tu A toi B
Console.WriteLine("C1:");
var rs = lp.FilterProductByPrice(100, 200);
foreach (var item in rs)
{
    Console.WriteLine(item);
}
Console.WriteLine("C2:");
var rs2 = lp.FilterProductByPrice2(100, 200);
rs2.ForEach(item => Console.WriteLine(item));
// Q2: Sap xep san pham theo gia tang dan
Console.WriteLine("=====================================");
var rs3 = lp.SortProductByPriceAsc();
rs3.ForEach(rs3 => Console.WriteLine(rs3));
//Q3: Sap xep san pham theo gia giam dan
Console.WriteLine("=====================================");
var rs4 = lp.SortProductByPriceDesc();
rs4.ForEach(rs4 => Console.WriteLine(rs4));
//Q4: tinh tong gia tri cac san pham trong kho hang
Console.WriteLine("=====================================");
Console.WriteLine("Tong gia tri kho hang");
var rs5 = lp.SumOfValues();
Console.WriteLine(rs5);
//Q5: tim chi tiet san pham khi biet ma san pham
Console.WriteLine("=====================================");
Product p = lp.FindProductByID(5);
Console.WriteLine(p);
//Q6: loc ra cac san pham co TOP N san pham co gia tri lon nhan
Console.WriteLine("=====================================");
var rs6 = lp.TopNProducts(3);
rs6.ForEach(item => Console.WriteLine(item));