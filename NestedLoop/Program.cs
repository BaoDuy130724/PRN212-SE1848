void swap (ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}   
void sort_arr(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
        }
    }
}
// descending order - while
void sort_arr1(int[] arr)
{
    int i = 0;
    while (i < arr.Length)
    {
        int j = i + 1;
        while (j < arr.Length)
        {
            if (arr[i] < arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j++;
        }
        i++;
    }
}
//descending order - do-while
void sort_arr2(int[] arr)
{
    int i = 0;
    do
    {
        int j = i + 1;
        do
        {
            if (arr[i] < arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j++;
        } while (j < arr.Length);
        i++;    
    } while (i < arr.Length-1);
}
// nested Loop for drawing
void draw (int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (j == 0 || j == n - 1 || i == j)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}
void create_arr(int[] arr)
{
    Random rd = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rd.Next(100);
    }
}
void print_arr(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write($"{item}\t");
    }
}
int[] arr = new int[5];
create_arr(arr);
print_arr(arr);
sort_arr(arr);
Console.WriteLine("\nAfter Sorting......");
print_arr(arr);
Console.WriteLine("\n--------------------------------");
int[] arr1 = new int[5];
create_arr(arr1);
print_arr(arr1);
sort_arr1(arr1);
Console.WriteLine("\nAfter Sorting Using while.....");
print_arr(arr1);
Console.WriteLine("\n--------------------------------");
int[] arr2 = new int[5];
create_arr(arr2);
print_arr(arr2);
sort_arr2(arr2);
Console.WriteLine("\nAfter Sorting Using do-while.....");
print_arr(arr2);
Console.WriteLine("\n--------------------------------");
draw(7);