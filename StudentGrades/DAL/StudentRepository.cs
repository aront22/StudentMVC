using Microsoft.EntityFrameworkCore;
using StudentGrades.DAL.efDBContext;
using StudentGrades.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentGrades.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsDbContext _db;
        public StudentRepository(StudentsDbContext db)
        {
            _db = db;
        }

        public void Add(Student student)
        {
            _db.Students.Add(new DbStudent() 
            {
                Name = student.Name,
                Year = student.Year,
                Phone = student.Phone,
                BirthDate = student.BirthDate
            });
            _db.SaveChanges();
        }

        public DbStudent Get(int studentId)
        {
            return _db.Students.SingleOrDefault(s => s.Id == studentId);
        }

        public IReadOnlyCollection<Student> List()
        {
            return _db.Students
                .Include(s => s.Grades)
                .Select(ToModel).OrderBy(s => s.Name)
                .ToList();
        }

        public IReadOnlyCollection<StudentStatistics> ListStatistics()
        {
            return _db.Students
                .Include(s => s.Grades)
                .Where(s => s.Grades.Count() > 0)
                .Select(ToStatisticsModel)
                .OrderBy(s => s.Average)
                .ToList();
        }

        public Student ToModel(DbStudent student)
        {
            return new Student()
            {
                Name = student.Name,
                BirthDate = student.BirthDate,
                Phone = student.Phone,
                Year = student.Year,
                Id = student.Id,
            };
        }

        public StudentStatistics ToStatisticsModel(DbStudent student)
        {
            return new StudentStatistics()
            {
                Name = student.Name,
                Average = student.Grades.Average(g => g.Mark),
                FailedCount = student.Grades.Count(g => g.Mark == 1),
                BestGrade = student.Grades.Max(g => g.Mark)
            };
        }
    }
}
