using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentList.Data;
using StudentList.Models;
using StudentList.Models.Domain;
using System.Security.Claims;
using Xamarin.Essentials;

namespace StudentList.Controllers
{

    
    public class StudentController : Controller
    {
        private readonly MvcDemoDbContext mvcDemoDbContext;

        

        public StudentController(MvcDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }
        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
           var students = await mvcDemoDbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpPost]

        public async Task <IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                DateofBirth = addStudentRequest.DateofBirth,
                Tuition = addStudentRequest.Tuition,
                Class = addStudentRequest.Class,

            };

           await mvcDemoDbContext.Students.AddAsync(student);
           await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task <IActionResult> View(Guid id) 
        {
            var student = await mvcDemoDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student != null)
            {
                var viewModel = new UpdateStudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    DateofBirth = student.DateofBirth,
                    Tuition = student.Tuition,
                    Class = student.Class,
                };


                return await Task.Run(()=> View("View",viewModel));
            }
            return RedirectToAction("Index");


        }
        [HttpPost]

        public async Task<IActionResult> View(UpdateStudentViewModel model)
        {
            var student = await mvcDemoDbContext.Students.FindAsync(model.Id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Email = model.Email;
                student.DateofBirth = model.DateofBirth;
                student.Tuition = model.Tuition;
                student.Class = model.Class;
               
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(UpdateStudentViewModel model)
        {
            var student = await mvcDemoDbContext.Students.FindAsync(model.Id);

            if (student != null)
            {
                mvcDemoDbContext.Students.Remove(student);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
