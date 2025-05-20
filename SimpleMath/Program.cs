string doMath(double a, double b, string op)
{
    string rs = "";
    switch(op)
    {
        case "+":
            rs += a+"+"+b;
            break;
        case "-":
            rs += a + "+" + b;
            break;
        case "*":
            rs += a + "+" + b;
            break;
        case "/":
            rs += a + "+" + b;
            break;
        default:
            rs = "fuking bullshit";
            break;
    }
    return rs;
}
Console.WriteLine("Enter a:");
double a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter b");
double b = Convert.ToDouble(Console.ReadLine());
string op = Console.ReadLine();
string result = doMath(a, b, op);
Console.WriteLine(result);