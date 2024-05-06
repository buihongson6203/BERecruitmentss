using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BERecruitmentss.Models;

namespace BERecruitmentss.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.SeedData();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }        
        public virtual DbSet<BillDetail> BillDetails { get; set; }

        public virtual DbSet<Users> Users { get; set; }
        private async void SeedData()
        {
            if (this.Users.Count() <= 0)
            {
                var u1 = new Users() { Phone = "123456789", Dob = new DateTime(1990, 5, 15), Email = "user1@example.com", Address = "123 Street, City", Role = 1 };
                var u2 = new Users() { Phone = "987654321", Dob = new DateTime(1985, 10, 20), Email = "user2@example.com", Address = "456 Road, Town", Role = 2 };
                var u3 = new Users() { Phone = "456789123", Dob = new DateTime(1995, 3, 25), Email = "user3@example.com", Address = "789 Avenue, Village", Role = 3 };
                var u4 = new Users() { Phone = "321654987", Dob = new DateTime(1980, 7, 10), Email = "user4@example.com", Address = "987 Lane, District", Role = 1 };
                var u5 = new Users() { Phone = "654321789", Dob = new DateTime(1992, 11, 30), Email = "user5@example.com", Address = "246 Boulevard, County", Role = 2 };


                this.Users.Add(u1);
                this.Users.Add(u2);
                this.Users.Add(u3);
                this.Users.Add(u4);
                this.Users.Add(u5);


                this.SaveChanges();
            }


        }
    }
}