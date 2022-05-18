using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StudentGrades.DAL;
using StudentGrades.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using StudentGrades.DAL.efDBContext;

namespace StudentGrades.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            IEnumerable<Student> list = _studentRepository.List();
            return View(list);
        }
        public IActionResult Grades()
        {
            IEnumerable<StudentStatistics> list = _studentRepository.ListStatistics();
            return View(list);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
