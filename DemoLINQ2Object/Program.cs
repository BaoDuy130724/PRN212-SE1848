Console.OutputEncoding = System.Text.Encoding.UTF8;
int[] array = { 100, 50, 120, 130, 80, 70, 123, 17, 237 };
/*
 * Q1: dung LINQ to Object để lấy ra các phần tử trong mảng array có giá trị chẵn
 */
//Method Syntax
var evenNumbers = array.Where(x => x % 2 == 0);
// Query Syntax
var evenNumbersQUery = from x in array
                       where x % 2 == 0
                       select x;
Console.WriteLine("Các phần tử trong mảng array có giá trị chẵn:");
evenNumbers.ToList().ForEach(x => Console.WriteLine(x));
/*
 * Q2: Sắp xếp tăng dần
 */
var sortedArray = array.OrderBy(x => x);
var sortedArrayQuery = from x in array
                       orderby x 
                       select x;
foreach (var item in sortedArray)
{
    Console.WriteLine(item);
}
/*
 * Q3: Giảm dần
 */
var sortedArrayDescending = array.OrderByDescending(x => x);
var sortedArrayDescendingQuery = from x in array
                                 orderby x descending
                                 select x;
sortedArrayDescending.ToList().ForEach(x => Console.WriteLine(x));
/*
 * Q4: Đếm số lượng các số lẻ
 */
int count = array.Where(x=> x%2!=0).Count();
Console.WriteLine(count);