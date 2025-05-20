namespace QuadraticEquation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Quadratic equation: ax^2+bx+c=0");
            Console.WriteLine("Enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter c: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("{0}x^2+{1}x+{2}=0", a, b, c);
            quadratic_solution(a, b, c);
            Console.ReadLine();
            //TestRandom();
            //TestDate();

        }
        /*
         * ax + b = 0
         * a: coefficient of x
         * b: constant
         * if a == 0 && b == 0: infinite solutions
         * if a == 0 && b != 0: no solution
         * else: one solution
         */
        static void first_degree_solution(double a, double b)
        {
            if (a == 0 && b == 0)
            {
                Console.WriteLine("Infinite solutions");
            }
            else if (a == 0 && b != 0)
            {
                Console.WriteLine("No solution");
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("x = {0}", x);
            }
        }
        /*
         * ax^2 + bx + c = 0
         * a: coefficient of x^2
         * b: coefficient of x
         * c: constant
         * delta = b^2 - 4ac
         * if delta < 0: no solution
         * if delta = 0: one solution
         * if delta > 0: two solutions
         */
        static void quadratic_solution(double a, double b, double c)
        {
            if (a == 0)
            {
                //First Degree
                first_degree_solution(b,c);
            }
            else
            {
                var delta = Math.Pow(b,2)- 4 * a * c;
                if (delta < 0)
                {
                    Console.WriteLine("No Solution");
                }
                else if (delta == 0)
                {
                    Console.WriteLine("x = {0}", -b / (2 * a));
                }
                //else 
                //{
                //    var x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                //    var x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                //    Console.WriteLine("x1 = {0}\nx2 = {1}", x1, x2);
                //}
            }
        }
        //static void TestRandom()
        //{
        //    //Random random = new Random();
        //    //int i = random.Next(100); // [0-99]
        //    //Console.WriteLine("x= {0}", i);

        //    Random rd = new Random();
        //    double randomA = rd.NextDouble(); // 0-1
        //    Console.WriteLine("a = {0}", Math.Round(randomA,2));
        //}
        //static void TestDate()
        //{
        //    DateTime dateTime = new DateTime();
        //    //dateTime = DateTime.Now;
        //    string s = Console.ReadLine();
        //    if(string.IsNullOrEmpty(s))
        //    {
        //        dateTime = DateTime.Now;
        //    }
        //    else
        //    {
        //        dateTime = DateTime.Parse(s);
        //    }
        //    Console.WriteLine("Date: {0}", dateTime); 
        //}
    }
}