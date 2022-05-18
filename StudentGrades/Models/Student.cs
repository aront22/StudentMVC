using System;
using System.ComponentModel.DataAnnotations;

namespace StudentGrades.Models
{
    public class Student
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [Range(1,12, ErrorMessage = "School year must be between 1 and 12.")]
        public int Year { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int Id { get; set; }
    }
}
