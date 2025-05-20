/*
 *Nhap vao 1 so >=0, neu nhap sai thi nhap lai. Neu nhap dung, tinh giai thua 
 */
Console.OutputEncoding = System.Text.Encoding.UTF8;
int n = -1;
while (n < 0)
{
    string s = Console.ReadLine(); 
    if(int.TryParse(s, out n)==false) // bool type.TryParse(string s, out int n)
    {
        Console.WriteLine("Phai nhap so");
    }
    else
    {
        if(n<0)
        {
            Console.WriteLine("Nhap n>=0");
        }
    }
}
int gt = 1;
for (int i = 1; i <= n; i++)
{
    gt *= i;
}
Console.WriteLine($"Giai thua {n} = {gt}");
