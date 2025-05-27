using OOP2;
using OOP4_ReuseOOP2;

Console.OutputEncoding = System.Text.Encoding.UTF8;
FullTimeEmployee employee = new FullTimeEmployee();
employee.Id = 1;
employee.Name = "putin";
employee.IdCard = "123";
employee.Birthday = new DateTime(1980, 1, 1);
Console.WriteLine(employee);
Console.WriteLine("=>>>Age: "+employee.Tuoi());

bool check = employee.IsBirthdayMonth();
if (check)
{
    Console.WriteLine("Tháng này có sinh nhận của nhân viên");
}
else
{
    Console.WriteLine("Tháng này không có sinh nhận của nhân viên");
}