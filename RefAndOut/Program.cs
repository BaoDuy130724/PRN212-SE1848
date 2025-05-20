using System.Text;

Console.OutputEncoding=Encoding.UTF8;
void ham1(int n)
{
    n = 8;
    Console.WriteLine("n=" + n);
}
int n = 5;
Console.WriteLine("N truoc khi vao ham = " + n);
//Call by Value
ham1(n);    
Console.WriteLine("N sau khi vao ham = "+ n); //n=5
//Call by Reference/Out
// ref: can initialize variable truoc khi truyen vao ham
void ham2(ref int n)
{
    n = 8;
    Console.WriteLine("n=" + n);
}
Console.WriteLine("-------------------");
n = 5;
Console.WriteLine("n truoc vao ham = " + n);
ham2(ref n);
Console.WriteLine("n sau khi vao ham =" + n );
// out: khong can initialize variable truoc khi truyen vao ham
void ham3(out int n)
{
    n=8;   
    Console.WriteLine("n=" + n);
}
Console.WriteLine("-------------------");
int m;
ham3(out m);
Console.WriteLine("m=" + m);
