using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineSMS.Models.DataModels;
using MongoDB.Driver;

namespace OnlineSMS.Controllers
{
    public class MessageController : Controller
    {
        private OnlineSMSContext DB;

        public MessageController(OnlineSMSContext DB) => this.DB = DB;

        public IActionResult Index(int toAccount,string name)
        {
            var AccId = HttpContext.Session.GetInt32("AccId");

            if(AccId == null)
            {
                return Redirect("/Account/Index");
            }

            List<Message> messages = DB.Message.Where(x => x.FromAccId == AccId || x.ToAccId == AccId).OrderByDescending(x=>x.Id).ToList();

            

           
            List<Account> accounts = new List<Account>();
            List<int> accId = new List<int>();

            if (!string.IsNullOrEmpty(name))
            {
                var A = DB.Friend.Where(x => x.AccId == AccId);
                List<Account> listaccounts = new List<Account>();
                foreach (var item in A)
                {
                    Account account = DB.Account.FirstOrDefault(x => x.AccId == item.AccIdFriend);
                    listaccounts.Add(account);
                }
                accounts = listaccounts.Where(x => x.FullName.Contains(name)).ToList();
            }
            else
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    int id = 0;
                    for (int j = i + 1; j < messages.Count; j++)
                    {
                        if (messages[i].FromAccId == messages[j].FromAccId && messages[i].ToAccId == messages[j].ToAccId || messages[i].FromAccId == messages[j].ToAccId && messages[i].ToAccId == messages[j].FromAccId)
                        {
                            id += 1;
                        }

                    }
                    if (id == 0)
                    {
                        if (messages[i].FromAccId == AccId)
                        {
                            accId.Add(messages[i].ToAccId);
                        }
                        else
                        {
                            accId.Add(messages[i].FromAccId);
                        }
                    }

                }
                foreach (var item in accId)
                {
                    Account account = DB.Account.FirstOrDefault(x => x.AccId == item);
                    accounts.Add(account);
                }
            }
           
         
            if (toAccount != null)
            {
                var listMessage = DB.Message.Where(x => x.FromAccId == toAccount && x.ToAccId == AccId || x.FromAccId == AccId && x.ToAccId == toAccount);
                ViewBag.message = listMessage;
                var toAcc = DB.Account.FirstOrDefault(x => x.AccId == toAccount);  
                if(toAcc != null)
                {
                    ViewBag.toacc = toAcc.FullName;
                    ViewBag.toaccid = toAcc.AccId;
                }                 
                ViewBag.check = toAccount;
                ViewBag.acc = AccId;
            }
            return View(accounts);
        }

        [HttpPost]
        public IActionResult CreateMessage(int toAccId,string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return Redirect("Index/?toAccount=" + toAccId);
            }
            DateTime now = DateTime.Now;
            var AccId = HttpContext.Session.GetInt32("AccId");
            Message message = new Message();
            message.FromAccId =(int) AccId;
            message.ToAccId = toAccId;
            message.Content = content;
            message.Status = 1;
            message.CreatedAt = now;
            DB.Message.Add(message);
            DB.SaveChanges();
            return Redirect("Index/?toAccount=" + toAccId);
        }
    }
}