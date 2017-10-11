using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTestEFCore20.Models;

namespace WebTestEFCore20.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            using (TestDbContext context = new TestDbContext())
            {
                IEnumerable<AccountViewModel> accounts = context.Accounts.Select(a => new AccountViewModel(a)).ToList();
                return View(accounts);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
