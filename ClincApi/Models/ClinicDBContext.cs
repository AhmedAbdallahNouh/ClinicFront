using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClincApi.Models
{
    public class ClinicDBContext : IdentityDbContext<AppUser>
    {
        public ClinicDBContext(DbContextOptions<ClinicDBContext> options) : base(options) { }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DoctorService> DoctorServices { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<ConsultationImage> ConsultationImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctorService>().HasKey(ds => new { ds.Service_Id, ds.Doctor_Id });
            base.OnModelCreating(builder);
        }
    }
}
