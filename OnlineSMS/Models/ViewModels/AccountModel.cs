using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSMS.Models.ViewModels
{
    public class AccountModel
    {
        public int AccId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }

        public AccountModel()
        {

        }

        public AccountModel(int accId, string fullName, string email, string phone, string password, DateTime? createdAt)
        {
            AccId = accId;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Password = password;
            CreatedAt = createdAt;
        }
    }
}
