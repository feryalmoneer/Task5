using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task5.Data;
using Task5.Models;
namespace Task5.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        public AccountsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult AccountIndex()
        {

            var accounts = context.Accounts.Where(u => !u.IsActive).ToList();

            return View(accounts);
            

            /* var users = context.Accounts.ToList();
             foreach (var user in users)
             {
                 Console.WriteLine(user.UserName );
             }
             return View("Index", users);*/
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Account c)
        {
            context.Add(c);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            var Check = context.Accounts.Where(x => x.UserName == account.UserName && x.Password == account.Password);
            if (Check.Any())
            {
                return RedirectToAction("Index" , "Employees");

            }
            ViewBag.Error = "Invalid Data - plz check pass / username";
            return View(account);
        }
   
        public IActionResult InActive(Guid id)
        {
            var n = context.Accounts.Find(id);
            if (n != null)
            {
                n.IsActive = true;
                context.SaveChanges();
            }

            return RedirectToAction("AccountIndex"); 



        }

    }
}
