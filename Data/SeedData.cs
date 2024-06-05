using BERecruitmentss.Models;
using System.Security.Cryptography;
using System.Text;

namespace BERecruitmentss.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            // Kiểm tra nếu không có nhân viên nào
                
                var s1 = new Staff() { EmployeeCode = "V10011", StaffName = "son1232", Password = ComputeMD5Hash("123456"), Role = 1, Email = "son.bh.22161@aptechlearning.edu.vn" };
                var s2 = new Staff() { EmployeeCode = "V10021", StaffName = "buihongson6203", Password = ComputeMD5Hash("1234567"), Role = 2, Email = "buihongson6203@gmail.com" };
                var s3 = new Staff() { EmployeeCode = "V10031", StaffName = "Alice Johnson", Password = ComputeMD5Hash("password789"), Role = 3, Email = "1alice@example.com" };
                var s4 = new Staff() { EmployeeCode = "V10041", StaffName = "Bob Brown", Password = ComputeMD5Hash("passwordabc"), Role = 1, Email = "bob1@example.com" };
                var s5 = new Staff() { EmployeeCode = "V10051", StaffName = "Eva Martinez", Password = ComputeMD5Hash("passworddef"), Role = 2, Email = "ev1a@example.com" };
                _context.Staff.AddRange(s1, s2, s3, s4, s5);
                _context.SaveChanges();
           
        }

        private string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
