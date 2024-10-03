using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Entities;

namespace MvcCv.DAL.Context
{
    public class MvcCvContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E7MGKIP;initial Catalog=MvcCvDb;integrated Security=true;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Sertificate> Sertificates { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
