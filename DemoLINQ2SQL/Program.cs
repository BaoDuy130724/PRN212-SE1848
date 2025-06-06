using DemoLINQ2SQL;

Console.OutputEncoding = System.Text.Encoding.UTF8;
// Khai baos chuoi ket noi toi sql
string connectionString = @"server=LAPTOP-C8SETICQ\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);
//Q1:truy van toan bo danh muc
var ds = context.Categories.ToList();
foreach (var item in ds)
{
    Console.WriteLine(item.CategoryID + "\t" + item.CategoryName);
}
//Q2: lay thong tin chi tiet danh muc khi biet ma
Console.WriteLine("-----------------------------------------");
int maDanhMuc = 7;
Category cate = context.Categories.FirstOrDefault(c => c.CategoryID == maDanhMuc);
if(cate == null) 
{
    Console.WriteLine("Khong tim thay danh muc co ma " + maDanhMuc);
}
else
{
    Console.WriteLine("Tim thay danh muc co ma " + maDanhMuc);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}
//Q3: dung query syntax de truy van toan bo san pham
Console.WriteLine("-----------------------------------------");
var dssp = from p in context.Products
            select p;
Console.WriteLine("Danh sach san pham");
foreach (var item in dssp)
{
    Console.WriteLine(item.ProductID + "\t" + item.ProductName + "\t" + item.UnitPrice);
}
//Q4: dung query syntax va anonymous type de loc ra cac san pham nhung chi lay ma san pham va don gia
// Dong thoi sap xep giam dan
Console.WriteLine("-----------------------------------------");
var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new {p.ProductID, p.UnitPrice};
Console.WriteLine("Danh sach san pham (ma san pham va don gia) sap xep giam dan");
foreach (var item in dssp4)
{
    Console.WriteLine(item.ProductID + "\t" + item.UnitPrice);
}
//Q5: sua cau 4 theo method syntax
Console.WriteLine("-----------------------------------------");
var dssp5 = context.Products.OrderByDescending(p => p.UnitPrice).Select(p => new {p.ProductID, p.UnitPrice});
foreach (var item in dssp5)
{
    Console.WriteLine(item.ProductID + "\t" + item.UnitPrice);
}
//Q6: loc ra top 3 san pham co gia lon nhat he thong. Yeu cau dung method syntax
Console.WriteLine("-----------------------------------------");
var dssp6 = context.Products.OrderByDescending(p => p.UnitPrice).Take(3);
foreach (var item in dssp6)
    Console.WriteLine(item.ProductID+ "\t" + item.ProductName + "\t" + item.UnitPrice);
//Q7: sua ten danh muc khi biet ma
Console.WriteLine("-----------------------------------------");
int ma_edit = 6;
var danhMuc = context.Categories.FirstOrDefault(c => c.CategoryID == ma_edit);
if (danhMuc != null)
{
    danhMuc.CategoryName = " hang ton";
    context.SubmitChanges();// xac nhan luu thay doi
}
//Q8: xoa danh muc khi biet ma 
Console.WriteLine("-----------------------------------------");
int ma_xoa = 4;
Category category = context.Categories.FirstOrDefault(c => c.CategoryID == ma_xoa);
if (category != null)
{
    context.Categories.DeleteOnSubmit(category); 
    context.SubmitChanges();
}
//Q9: xoa cac danh muc neu khong co bat ky san pham nao
// luu y: xoa cung luc nhieu danh muc, ma cac danh muc nay khong chua bat ky san pham nao
Console.WriteLine("-----------------------------------------");
var dsdm_empty_product = context.Categories.Where(c => c.Products.Count() == 0).ToList();
context.Categories.DeleteAllOnSubmit(dsdm_empty_product);
context.SubmitChanges();
//Q10: them moi 1 danh muc
Category c_new = new Category();
c_new.CategoryName = "hang lau";
context.Categories.InsertOnSubmit(c_new);
context.SubmitChanges();
//Q11: them moi nhieu danh muc
List<Category> list = new List<Category>();
list.Add(new Category() { CategoryName = "Hang gia dung" });
list.Add(new Category() { CategoryName = "Hang dien tu" });
list.Add(new Category() { CategoryName = "Hang phu kien" });
context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges();
