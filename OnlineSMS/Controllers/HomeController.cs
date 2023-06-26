using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSMS.Models;
using OnlineSMS.Models.DataModels;

namespace OnlineSMS.Controllers
{
    public class HomeController : Controller
    {
        private OnlineSMSContext DB;

        public HomeController(OnlineSMSContext DB) => this.DB = DB;

        public IActionResult Index()
        {
            var AccId = HttpContext.Session.GetInt32("AccId");
            if (AccId == null)
            {
                return Redirect("/Account/Index");
            }
            var Post = DB.Post.Include(a => a.Acc).Where(x=>x.Status == 1).OrderByDescending(x => x.PostId);
            var Account = DB.Account.ToList();


            return View(Post);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });    
        }
    }
}
