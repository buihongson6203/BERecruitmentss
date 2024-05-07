using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BERecruitmentss.Models
{
    public class Candidate :Base
    {
        public int CandidateCode { get; set; }
        public string Name { get; set;}
        public int Status { get; set; }
       
    }
}
