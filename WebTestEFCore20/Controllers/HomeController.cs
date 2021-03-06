﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTestEFCore20.Models;

namespace WebTestEFCore20.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            using (TestDbContext context = new TestDbContext())
            {
                IEnumerable<AccountViewModel> accounts = context
                    .Accounts
                    .Include(a => a.Owner)
                    .Select(a => new AccountViewModel(a)).ToList();
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

        public IActionResult EditOwner()
        {
            using (TestDbContext context = new TestDbContext())
            {
                Account acc5678 = context.Accounts
                    .Include(a => a.Owner).FirstOrDefault(a => a.Number == 5678);
                Account acc7876 = context.Accounts
                    .Include(a => a.Owner).FirstOrDefault(a => a.Number == 7876);

                if (acc5678 != null && acc7876 != null)
                {
                    AccountOwner tmpOwner = acc7876.Owner;
                    acc7876.Owner = acc5678.Owner;
                    acc5678.Owner = tmpOwner;

                    context.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }
    }
}
