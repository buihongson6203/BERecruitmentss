using System.ComponentModel.DataAnnotations.Schema;

namespace BERecruitmentss.Models
{
    public class BillDetail : Base
    {
        public int? BillId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set;}
        public int? Quantity { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill? Bill { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

    }
}
