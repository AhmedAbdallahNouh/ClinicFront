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
        public virtual DbSet<DoctorService> DoctorServices { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
