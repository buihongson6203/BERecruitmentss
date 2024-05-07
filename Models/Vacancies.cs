namespace BERecruitmentss.Models
{
    public class Vacancies:Base
    {
        public int? RecruitmentCode { get; set; }
        public int? Status { get; set; }
        public string? Title { get; set; }
        public string? Describe { get; set; }
        public int? NumberOfCandidates { get; set; }
        public int? Department { get; set; }
        public DateTime? RecruitmentClosingDate { get; set; }
        //public int? RecruitmentCode { get; set; }
        public string? CandidateStaffID { get; set; }



    }
}
