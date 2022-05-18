using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentGrades.DAL;
using StudentGrades.Models;
using System.Collections.Generic;

namespace StudentGrades.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        public GradeController(IGradeRepository gradeRepository, IStudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            Grade grade = new Grade()
            {
                Students = new List<Student>(_studentRepository.List())
            };
            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Grade grade)
        {
            if(ModelState.IsValid)
            {
                _gradeRepository.AddGrade(grade.StudentId, grade.Mark);
                return RedirectToAction("Grades", "Student");
            }
            return View(grade);
        }
    }
}
