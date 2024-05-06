using System.ComponentModel.DataAnnotations.Schema;

namespace BERecruitmentss.Models
{
    public class Product : Base
    {
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public string? ImageProduct { get; set; }
        public string? BarCode { get; set; }
    }
}
