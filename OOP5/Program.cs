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
    Id = 2,
    IdCard = "169",
    Name = "Nguyen Van A",
    Birthday = new DateTime(1990, 1, 1)
};
employees.Add(fe2);
FullTimeEmployee fe3 = new FullTimeEmployee()
{
    Id = 3,
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
//Các tính năng xóa và sửa thông tin nhân viên 
Console.WriteLine("------------------------------------------------");
int choice;
Console.WriteLine("Chọn chức năng bạn muốn thực hiện:");
Console.WriteLine("1. Sửa thông tin nhân viên");
Console.WriteLine("2. Xóa thông tin nhân viên");
Console.WriteLine("3. Thoát chương trình");
Console.WriteLine("Nhập lựa chọn của bạn (1-3):");
while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
{
    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một số từ 1 đến 3:");
}
switch (choice)
{
    case 1:
        // Sửa thông tin nhân viên
        Console.WriteLine("Bạn đã chọn chức năng sửa thông tin nhân viên.");
        #region Chức năng sửa thông tin của nhân viên
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Danh sách nhân viên hiện tại:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
        int idtoUpdate = -1;
        Console.WriteLine("\nNhập ID nhân viên cần sửa thông tin:");
        if (int.TryParse(Console.ReadLine(), out idtoUpdate))
        {
            if (idtoUpdate > 0)
            {
                Employee? empToUpdate = employees.FirstOrDefault(e => e.Id == idtoUpdate);
                if (empToUpdate != null)
                {
                    Console.WriteLine("Nhập tên mới cho nhân viên (hiện tại là: " + empToUpdate.Name + "):");
                    string? newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        empToUpdate.Name = newName;
                    }
                    else
                    {
                        Console.WriteLine("Tên không được để trống. Giữ nguyên tên cũ.");
                    }
                    Console.WriteLine("Nhập ngày sinh mới cho nhân viên (hiện tại là: " + empToUpdate.Birthday.ToString("dd/MM/yyyy") + "):");
                    string? newBirthdayInput = Console.ReadLine();
                    if (DateTime.TryParse(newBirthdayInput, out DateTime newBirthday))
                    {
                        empToUpdate.Birthday = newBirthday;
                    }
                    else
                    {
                        Console.WriteLine("Ngày sinh không hợp lệ. Giữ nguyên ngày sinh cũ.");
                    }
                    Console.WriteLine("Nhập ID_card mới cho nhân viên (hiện tại là: " + empToUpdate.IdCard + "):");
                    string? newIdCard = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newIdCard))
                    {
                        empToUpdate.IdCard = newIdCard;
                    }
                    else
                    {
                        Console.WriteLine("ID_card không được để trống. Giữ nguyên ID_card cũ.");
                    }
                    Console.WriteLine("Thông tin nhân viên sau khi cập nhật:");
                    foreach (Employee emp in employees)
                    {
                        Console.WriteLine(emp);
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy nhân viên với ID: " + idtoUpdate);
                }
            }
            else
            {
                Console.WriteLine("ID phải lớn hơn 0.");
            }
        }
        else
        {
            Console.WriteLine("ID không hợp lệ. Vui lòng nhập một số nguyên.");
        }
        #endregion
        break;
    case 2:
        // Xóa thông tin nhân viên
        Console.WriteLine("Bạn đã chọn chức năng xóa thông tin nhân viên.");
        #region Chức năng xóa thông tin của nhân viên
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("\nDanh sách nhân viên hiện tại:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
        int idToDelete = -1;
        Console.WriteLine("\nNhập ID nhân viên cần xóa:");
        if (int.TryParse(Console.ReadLine(), out idToDelete))
        {
            if (idToDelete > 0)
            {
                Employee? empToDelete = employees.FirstOrDefault(e => e.Id == idToDelete);
                if (empToDelete != null)
                {
                    employees.Remove(empToDelete);
                    Console.WriteLine("Đã xóa nhân viên với ID: " + idToDelete);
                }
                else
                {
                    Console.WriteLine("Không tìm thấy nhân viên với ID: " + idToDelete);
                }
            }
            else
            {
                Console.WriteLine("ID phải lớn hơn 0.");
            }
        }
        else
        {
            Console.WriteLine("ID không hợp lệ. Vui lòng nhập một số nguyên.");
        }
        Console.WriteLine("Danh sách nhân viên sau khi xóa:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
        #endregion
        break;
    default:
        // Thoát chương trình
        Console.WriteLine("Bạn đã chọn thoát chương trình.");
        return; // Kết thúc chương trình
}
