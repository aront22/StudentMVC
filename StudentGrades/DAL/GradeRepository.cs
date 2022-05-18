using StudentGrades.DAL.efDBContext;

namespace StudentGrades.DAL
{
    public class GradeRepository : IGradeRepository
    {
        private readonly StudentsDbContext _db;
        private readonly IStudentRepository _studentRepository;
        public GradeRepository(StudentsDbContext db, IStudentRepository studentRepository)
        {
            _db = db;
            _studentRepository = studentRepository;
        }
        public void AddGrade(int studentId, int mark)
        {
            var student = _studentRepository.Get(studentId);
            if (student == null)
                throw new System.Exception("Student not found.");

            DbGrade newGrade = new DbGrade()
            {
                Mark = mark,
                StudentId = studentId,
                Student = student
            };

            _db.Grades.Add(newGrade);
            student.Grades.Add(newGrade);

            _db.SaveChanges();
        }
    }
}
