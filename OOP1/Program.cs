using OOP1;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Category category = new Category(); // xin một ô nhớ, lưu trữ đối tượng category
category.Id = 1;
category.Name = "Nước mắm";
category.printInfor();
// giả sử đổi giá trị trong ô nhớ
category.Name = "Thuốc trị hôi nách";// dù có thay đổi giá trị trong ô nhớ thì vẫn là ô nhớ đó
Console.WriteLine("Sau khi thay đổi tên: ");
category.printInfor();
//Sử dụng class Employee
Console.WriteLine("-----------EMPLOYEE----------- ");
Employee employee = new Employee();
employee.Id = 1; // gọi setter property của Id
employee.Id_card = "001"; // gọi setter property của Id_card
employee.Name = "Nguyễn Văn A"; // gọi setter property của Name
employee.Email = "A@gmail.com"; // gọi setter property của Email
employee.Phone = "0123456789"; // gọi setter property của Phone
employee.printInfor();
Employee employee2 = new Employee()
{
    Id = 2, // gọi setter property của Id
    Id_card = "002", // gọi setter property của Id_card
    Name = "Nguyễn Văn B", // gọi setter property của Name
    Email = "B@gmail.com", // gọi setter property của Email
    Phone = "0123456788" // gọi setter property của Phone
};
employee2.printInfor();

Employee employee3 = new Employee();
Console.WriteLine("--------Employee 3---------");
employee3.printInfor();
Console.WriteLine("-------Employee 4----------");
Employee employee4 = new Employee(4,"004","tủn","tun@gmail.com", "010101010");
Console.WriteLine("cách 1"); 
Console.WriteLine(employee4); // tự động gọi hàm ToString() của class Employee  
Console.WriteLine("cách 2");
employee4.printInfor();

Console.WriteLine("--------Customer 1----------");
Customer customer1 = new Customer()
{
    Id = 1,
    Name = "Nguyễn Văn A",
    Address = "Hà Nội",
    Phone = "0123456789",
    Email = "abc@gmail.com"
};
customer1.printInfor();
customer1.Address = "Hà Giang";
Console.WriteLine("Sau khi thay đổi địa chỉ: ");
customer1.printInfor();
