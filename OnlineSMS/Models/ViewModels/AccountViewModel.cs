using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSMS.Models.ViewModels
{
    public class AccountViewModel
    {
        public int AccId { get; set; }
        [DisplayName("FullName")]
        [Required(ErrorMessage= "Please enter fullname")]
        public string FullName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        [Required(ErrorMessage ="Please enter phone")]
        [StringLength(10,MinimumLength =10,ErrorMessage = "Enter 10 digit mobile phone number")]     
        [RegularExpression(@"^0\d{9}$",ErrorMessage = "Must be a valid phone")]
        public string Phone { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [DisplayName("ConfirmPassword")]
        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [Compare("Password",ErrorMessage = "Confirm password is incorrect")]
        public string ConfirmPassword { get; set; }
        public DateTime? CreatedAt { get; set; }

        public AccountViewModel()
        {

        }

        public AccountViewModel(int accId, string fullName, string email, string phone, string password, string confirmPassword, DateTime? createdAt)
        {
            AccId = accId;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Password = password;
            ConfirmPassword = confirmPassword;
            CreatedAt = createdAt;
        }
    }
}
