using Microsoft.AspNetCore.Mvc;
using Student_Info_App.Models;
using Student_Info_App.Services;

namespace Student_Info_App.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext context;
        public StudentsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var students = context.Students.ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return View(studentDetail);
            }
            Student student = new Student()
            {
                Name = studentDetail.Name,
                Age = studentDetail.Age,
                Gender = studentDetail.Gender,
                Course = studentDetail.Course,
            };
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
        public IActionResult Edit(int id)
        {
            var student = context.Students.Find(id);
                if (student == null)
            {
                return RedirectToAction("Index", "Students");

            }
           var studentDetail = new StudentDetail()
            {
                Name = student.Name,
                Age = student.Age,
                Gender = student.Gender,
                Course = student.Course,
            };
            ViewData["StudentId"] = student.Id;
            return View(studentDetail);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudentDetail studentDetail)
        {
            var student = context.Students.Find(id);
            if (student==null)
            {
                return RedirectToAction("Index", "Students");

            }
            if (!ModelState.IsValid)
            {
                ViewData["StudentId"] = student.Id;
                return View(studentDetail);
            }

            student.Name = studentDetail.Name;
            student.Age = studentDetail.Age;
            student.Gender = studentDetail.Gender;
            student.Course = studentDetail.Course;
            context.SaveChanges();
            return RedirectToAction("Index", "Students");

        }

        public IActionResult Delete(int id)
        {
            var student = context.Students.Find(id);
            if(student==null)
            {
                return RedirectToAction("Index", "Students");
            }
            context.Students.Remove(student);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Students");
        }

        }
}
