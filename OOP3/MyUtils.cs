using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3_ExtensionMethod
{
    public static class MyUtils
    {
        public static int TongTu1toiN (this int n) // "this" keyword allows this method to be called on an int instance
        {
            int sum = 0;
            for(int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }
        public static int Cong (this int a, int b) // this method is instance of int a, int b is parameter
        {
            return a + b;
        }
        public static void TaoMang(this int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 100); // Fill the array with random numbers between 1 and 100
            }
        }
        public static void XuatMang(this int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public static void SapXepTangDan(this int[] arr)
        {
            for (int i = 0;i < arr.Length; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        // Swap arr[i] and arr[j]
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        public static int[] SapXepGiamDan(this int[] arr)
        {
            return arr.OrderByDescending(x => x).ToArray();
        }
    }
}
