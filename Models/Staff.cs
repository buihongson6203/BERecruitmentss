namespace BERecruitmentss.Models
{
    public class Staff:Base

    {
        public int? EmployeeCode { get; set; } 
        public string? StaffName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set;}
        public string? Email { get; set; }

    }
}
