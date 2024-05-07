namespace BERecruitmentss.Models
{
    public class Ungvientuyendung : Base
    {

        public DateTime? DateStart { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public int CandidateId  { get; set; }
        public int RecruitmentID { get; set; }  

    }
}
