namespace FirstDegree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("First degree: ax+b=0");
            Console.WriteLine("Enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("{0}x+{1}=0", a, b);
            first_degree_solution(a, b);
            Console.ReadLine();

        }

        static void first_degree_solution(double a, double b)
        {
            if (a == 0 && b == 0)
            {
                Console.WriteLine("Infinite solutions");
            }
            else if (a==0 && b != 0)
            {
                Console.WriteLine("No solution");
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("x = {0}",x);
            }
        }
    }
}