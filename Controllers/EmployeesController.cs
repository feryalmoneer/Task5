using Microsoft.AspNetCore.Mvc;
using Task5.Data;
using Task5.Models;

namespace Task5.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var employees = context.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
            return View("Index", employees);
        }
        //لعرض الداتا
        public IActionResult Create()
        {


            return View();
        }
        //لاضافة الداتا
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            context.Add(e);
            context.SaveChanges();
            return RedirectToAction("Index");
            // return  Content($"{e.Name} ..... {e.Email}....{e.password}");
        }

        public IActionResult Delete(int id)
        {
            var emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
