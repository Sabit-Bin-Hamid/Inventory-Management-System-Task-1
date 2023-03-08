using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentModule.Data;
using StudentModule.Models;
using StudentModule.Models.Domain;

namespace StudentModule.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MVCDemoDbContext mvcDbContext;

        public StudentsController(MVCDemoDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult>Index()
        {
            var student = await mvcDbContext.Students.ToListAsync();
            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                UserFirstName = addStudentRequest.UserFirstName,
                UserLastName = addStudentRequest.UserLastName,
                UserName = addStudentRequest.UserName,
                Password = addStudentRequest.Password,
                Email = addStudentRequest.Email,
                Phone = addStudentRequest.Phone,
                Address = addStudentRequest.Address,
            };
            await mvcDbContext.Students.AddAsync(student);
            await mvcDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var student=await mvcDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                var viewModel = new updateStudentViewModel()
                {
                    Id = Guid.NewGuid(),
                    UserFirstName = student.UserFirstName,
                    UserLastName = student.UserLastName,
                    UserName = student.UserName,
                    Password = student.Password,
                    Email = student.Email,
                    Phone = student.Phone,
                    Address = student.Address,

                };
                return await Task.Run(()=>View("View", viewModel));
            }
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(updateStudentViewModel model)
        {
            var student = await mvcDbContext.Students.FindAsync(model.Id);
            if(student != null)
            {
                student.UserName = model.UserName;
                student.Password = model.Password;
                student.Email = model.Email;
                student.Address = model.Address;
                student.UserLastName= model.UserLastName;
                student.UserFirstName  = model.UserFirstName;
                student.Phone = model.Phone;

                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(updateStudentViewModel model)
        {
            var student =await  mvcDbContext.Students.FindAsync(model.Id);
            if(student != null)
            {
                mvcDbContext.Students.Remove(student);
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
    }
}
