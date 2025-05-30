using DemoAliasClone;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Customer c1 = new Customer();
c1.Id = 1;
c1.Name = "Nguyen Van A";
Customer c2 = new Customer();
c2.Id = 2;
c2.Name = "Nguyen Van B";
c1 = c2; // c1 trỏ tới vùng nhớ mà c2 đang quản lý. khôg có nghĩa là c1 = c2
         //Lúc này xảy ra 2 trường hợp:
         // 1. Ô nhớ mà c1 quản lý lúc nãy bây giờ không còn được quản lý nữa => Hệ điều hành sẽ thu hồi ô nhớ này
         // ==>  Gọi là cơ thế gom rác tự động (Automatic Garbage Collection (GC) của .NET)
         // Ta không thể nào lấy được giá trị của ô nhớ này nữa.
         // 2. Lúc này ô nhớ còn lại sẽ có 2 đối tượng tham gia quản lý (ban đầu là c2, sau thêm c1)
         // Trường hợp 1 ô nhớ có 2 đối tượng tham gia quản lý thì gọi là Alias
         // -> bất kì đối tượng nào thay đổi giá trị tại ô nhớ đó thì các đối tượng còn lại cũng thay đổi
c1.Name = "hồ đồ";
// c2 sẽ bị đổi thành "hồ đồ". Vì c1 và c2 đang quản lý cùng một ô nhớ
Console.WriteLine("Ten cua c2: " + c2.Name);

Customer c3 = new Customer();
Customer c4 = c3;
c3 = c1; // c3 trỏ tới vùng nhớ mà c1 đang quản lý
         // không thu hồi ô nhớ mà c3 đã quản lý trước đó (ở line 22)
         // Vì c4 đang quản lý ô nhớ mà c3 đã quản lý trước đó