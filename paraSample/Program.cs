int sum(params int[] arr) //params cho phép truyền vào số lượng tham số không xác định
{
    int s = 0;
    foreach (var item in arr)
    {
        s =s + item;
    }
    return s;
}
int s0 = sum();
int s1 = sum(100);
int s2 = sum(100, 200);
int sn = sum(1, 2, 3, 4, 5, 4, 76, 2, 3, 4);