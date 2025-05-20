using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;
string ho = "Nguyen";
string tenLot = "Van";
string full_name = ho + "" + tenLot;
Console.WriteLine("Họ và tên: " + full_name);

StringBuilder sb = new StringBuilder(); 
sb.Append(ho); 
sb.Append(" ");
sb.Append(tenLot);
Console.WriteLine(sb.ToString());

