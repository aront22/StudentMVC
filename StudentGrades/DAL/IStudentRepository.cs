using StudentGrades.Models;
using StudentGrades.DAL.efDBContext;
using System.Collections.Generic;

namespace StudentGrades.DAL
{
    public interface IStudentRepository
    {
        IReadOnlyCollection<Student> List();
        IReadOnlyCollection<StudentStatistics> ListStatistics();
        public Student ToModel(DbStudent student);
        public StudentStatistics ToStatisticsModel(DbStudent student);
        public void Add(Student student);
        public DbStudent Get(int StudentId);
    }
}
