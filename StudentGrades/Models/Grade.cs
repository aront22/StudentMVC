using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentGrades.Models
{
    public class Grade
    {
        [Required]
        [Range(1,5, ErrorMessage = "Mark must be between 1 and 5.")]
        public int Mark { get; set; } = 1;
        public List<Student> Students { get; set; }
        public int StudentId { get; set; }
    }
}
