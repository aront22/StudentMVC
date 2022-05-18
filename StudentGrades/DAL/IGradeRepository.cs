namespace StudentGrades.DAL
{
    public interface IGradeRepository
    {
        void AddGrade(int studentId, int mark);
    }
}
