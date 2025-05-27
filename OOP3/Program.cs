using OOP3_ExtensionMethod;

Console.OutputEncoding = System.Text.Encoding.UTF8;
int n1 = 5;
int n2 = 10;
Console.WriteLine($"Tổng từ 1 đến {n1} là: {n1.TongTu1toiN()}");
Console.WriteLine($"Tổng từ 1 đến {n2} là: {n2.TongTu1toiN()}");
Console.WriteLine("Tổng từ 1 tới 8 là: " + 8.TongTu1toiN());
Console.WriteLine("8+7="+8.Cong(7));

int[] M = new int[10];
M.TaoMang();
Console.WriteLine("Mảng M sau khi tạo ngẫu nhiên:");
M.XuatMang();
M.SapXepTangDan();
Console.WriteLine("Mảng M sau khi sắp xếp tăng dần:");
M.XuatMang();
int[] M2 = M.SapXepGiamDan();
Console.WriteLine("Mảng M sau khi sắp xếp giảm dần:");
M2.XuatMang();