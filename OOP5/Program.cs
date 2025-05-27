/*
 * Sử dụng generic List để quản lý nhân sự đầy đủ 
 * Tính năng CRUD
 * Create => Tạo mới dữ liệu
 * Read => Xem, lọc, tìm kiếm, thống kê dữ liệu
 * Update => Sửa dữ liệu
 * Delete => Xóa dữ liệu
 */
// Câu 1: Tạo 5 nhân viên, trong đó 3 chính thức, 2 thời vụ. Lưu vào Generic List 
using OOP2;
using System.Text;
Console.OutputEncoding = Encoding.UTF8; // Để hiển thị tiếng Việt có dấu trong console
List<Employee> employees = new List<Employee>();
FullTimeEmployee fe1 = new FullTimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Nguyen Van A",
    Birthday = new DateTime(1990, 1, 1)
};
employees.Add(fe1);
FullTimeEmployee fe2 = new FullTimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Nguyen Van A",
    Birthday = new DateTime(1990, 1, 1)
};
employees.Add(fe2);
FullTimeEmployee fe3 = new FullTimeEmployee()
{
    Id = 2,
    IdCard = "456",
    Name = "Nguyen Van B",
    Birthday = new DateTime(1980, 1, 1)
};
employees.Add(fe3);
PartTimeEmployee pe1 = new PartTimeEmployee()
{
    Id = 4,
    IdCard = "135",
    Name = "Nguyen Van D",
    Birthday = new DateTime(1982, 1, 1),
    HoursWorked = 20 // Giả sử nhân viên này làm việc 20 giờ
};
employees.Add(pe1);
PartTimeEmployee pe2 = new PartTimeEmployee()
{
    Id = 5,
    IdCard = "246",
    Name = "Nguyen Van E",
    Birthday = new DateTime(1979, 1, 1),
    HoursWorked = 3
};
employees.Add(pe2);
//Câu 2: Hiển thị danh sách nhân viên
Console.WriteLine("Danh sách nhân viên:");
employees.ForEach(e => Console.WriteLine(e));
//Câu 3: Lọc nhân viên chính thức
List<FullTimeEmployee> fe_list = employees.OfType<FullTimeEmployee>().ToList(); //OfType<T> lọc ra các dữ liệu có kiểu là T
Console.WriteLine("\nDanh sách nhân viên chính thức:");
foreach (FullTimeEmployee fe in fe_list)
{
    Console.WriteLine(fe);
}
//Câu 4: Tính tổng tiền lương phải trả cho nhân viên chính thức
//thời phụ.
//Tổng toàn bộ nhân viên
double fe_SumSalary = fe_list.Sum(fe => fe.calSalary());
Console.WriteLine("\ntổng lương nhân viên chính thức: " + fe_SumSalary);
double pe_SumSalary = employees.OfType<PartTimeEmployee>().Sum(pe => pe.calSalary());
Console.WriteLine("tổng lương nhân viên thời vụ: " + pe_SumSalary);
double sumSalary = fe_SumSalary + pe_SumSalary;
Console.WriteLine("Tổng lương phải trả cho toàn bộ nhân viên: " + sumSalary);
//BTVN
//Các tính năng xóa và sửa 