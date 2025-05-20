(int, double) sumAndAver(params int[] arr)
{
    int sum = 0;
    double avg = 0;
    foreach ( var item in arr)
    {
        sum += item;
    }
    avg = (double) sum/arr.Length;
    return (sum, avg);
}
int[] arr = new int[10];
void create_arr(int[] arr)
{
    Random rd = new Random();
    for ( int i = 0; i < arr.Length; i++)
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
create_arr(arr);
print_arr(arr);
Console.WriteLine($"\nAVG = {sumAndAver(arr).Item2}");
(int s, double avg) = sumAndAver(arr);
Console.WriteLine($"Sum = {s}");
Console.WriteLine($"AVG = {avg}");