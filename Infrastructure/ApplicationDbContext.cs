using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions) { }

        public DbSet<Student> Student => Set<Student>();

        public DbSet<Course> Course => Set<Course>();

        public async Task savechanges()
        {
           await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(builder =>
            {
                builder.HasKey(s => s.Id);
            });        

            modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithOne(c => c.Student)
            .HasForeignKey(c => c.StudentId);


            modelBuilder.Entity<Course>()
                .HasKey(c=>c.Id);

        }
    }
}
