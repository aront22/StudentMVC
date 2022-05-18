using System.ComponentModel.DataAnnotations.Schema;
namespace StudentGrades.DAL.efDBContext
{
    [Table("Grades")]
    public class DbGrade
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public DbStudent Student { get; set; }
    }
}
