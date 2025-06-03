class Program
{
    public delegate int MyDelegate(int x, int y); // class giúp một biến có thể được sử dụng như 1
                                                  // method nếu method đó có cùng biểu mẫu với biểu mẫu delegate 
    public delegate int[] YourDelegate (int n);
    static int Add(int a, int b)
    {
        return a + b;
    }
    static int Minus(int a, int b)
    {
        return a - b;
    }
    static int[] DanhSachSoChan(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i < n; i += 2)
        {
            list.Add(i);
        }
        return list.ToArray();
    }
    static int[] DanhSachSoNgTo(int n)
    {
        List<int> ints = new List<int>();
        for(int i=2;i <= n; i++)
        {
            int count = 0;
            for(int j=1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                ints.Add(i);
            }
        }
        return ints.ToArray();
    }
    public static void Main(string[] args)
    {
        MyDelegate m= new MyDelegate(Add);
        Console.WriteLine("5+8="+m(5,8));
        m= new MyDelegate(Minus);
        Console.WriteLine("10-5=" + m(10, 5));
        YourDelegate y = new YourDelegate(DanhSachSoChan);
        int[] list = y(10); // <=> DanhSachSoChan(10)
        foreach (var item in list)
        {
            Console.WriteLine(item + "\t");
        }
        Console.WriteLine("Danh sach so ngto");
        y = new YourDelegate(DanhSachSoNgTo);
        int[] ints = y(20);
        foreach (var item in ints)
        {
            Console.WriteLine(item + "\t");
        }
    }
}