using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentGrades.DAL.efDBContext
{
    [Table("Students")]
    public class DbStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Year { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<DbGrade> Grades { get; set; }
    }
}
