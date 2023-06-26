using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineSMS.Models.DataModels;
using OnlineSMS.Models.ViewModels;

namespace OnlineSMS.Controllers
{
    public class AccountController : Controller
    {

        private OnlineSMSContext DB;

        public AccountController(OnlineSMSContext DB) => this.DB = DB;

        public IActionResult Index()
        {
            var AccId = HttpContext.Session.GetInt32("AccId");

            if (AccId != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string phone,string password)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(phone))
            {
                TempData["phone"] = "Please enter phone";
                check = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                TempData["password"] = "Please enter passwrod";
                check = false;
            }

            var account = DB.Account.FirstOrDefault(x => x.Phone == phone && x.Password == password);
            if (check == true)
            {
                if (account != null)
                {
                    HttpContext.Session.SetInt32("AccId", account.AccId);
                    return Redirect("/Home/Index");
                }
                else
                {
                    TempData["err"] = "Incorrect account information";
                }
            }      
            return View();
        }

        public IActionResult Register()
        {
            var AccId = HttpContext.Session.GetInt32("AccId");

            if (AccId != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountViewModel accountViewModel)
        {
            Boolean check = true;
            var accphone = DB.Account.FirstOrDefault(x => x.Phone == accountViewModel.Phone); var accemail = DB.Account.FirstOrDefault(x => x.Phone == accountViewModel.Phone);
            if (accphone != null)
            {
                TempData["phone"] = "This mobile numer had been registered already";
                check = false;
            }
            if (accemail != null)
            {
                TempData["email"] = "This email had been registered already";
                check = false;
            }
            DateTime now = DateTime.Now;
            if (ModelState.IsValid && check == true)
            {
                Account account = new Account();
                account.AccId = 0;
                account.FullName = accountViewModel.FullName;
                account.Email = accountViewModel.Email;
                account.Phone = accountViewModel.Phone;
                account.Password = accountViewModel.Password;
                account.CreatedAt = now;
                DB.Account.Add(account);
                DB.SaveChanges();
                return Redirect("/Account/Index");
            }
            return View();
        }

        public IActionResult Signout()
        {
           HttpContext.Session.Clear();
            return Redirect("/Account/Index");
        }
    }
}