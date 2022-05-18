using Microsoft.EntityFrameworkCore;
using System;

namespace StudentGrades.DAL.efDBContext
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<DbStudent> Students { get; set; }
        public DbSet<DbGrade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<DbStudent>()
            .HasData(new[]
            {
                new DbStudent() 
                { 
                    Id = 1, 
                    Name = "Student 1", 
                    BirthDate = new DateTime(2000, 1, 1),
                    Year = 11,
                    Phone = "+36301234567"
                },
                new DbStudent()
                {
                    Id = 2,
                    Name = "Student 2",
                    BirthDate = new DateTime(2000, 2, 2),
                    Year = 12,
                    Phone = "+36307654321"
                },
                new DbStudent()
                {
                    Id = 3,
                    Name = "Student 3",
                    BirthDate = new DateTime(2000, 3, 3),
                    Year = 9,
                    Phone = "+36303333333"
                },
            });

            modelBuilder.Entity<DbGrade>()
            .HasData(new[]
            {
                new DbGrade()
                {
                    Id = 1,
                    Mark = 5,
                    StudentId = 1,
                },
                new DbGrade()
                {
                    Id = 2,
                    Mark = 1,
                    StudentId = 2,
                },
                new DbGrade()
                {
                    Id = 3,
                    Mark = 3,
                    StudentId = 2,
                },
                new DbGrade()
                {
                    Id = 4,
                    Mark = 4,
                    StudentId = 2,
                },
            });
        }
    }
}
