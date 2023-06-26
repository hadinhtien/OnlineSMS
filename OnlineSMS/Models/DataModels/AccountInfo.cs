using System;
using System.Collections.Generic;

namespace OnlineSMS.Models.DataModels
{
    public partial class AccountInfo
    {
        public int Id { get; set; }
        public int? AccId { get; set; }
        public string Avatar { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string Interests { get; set; }
        public string Dislike { get; set; }
        public string Degree { get; set; }
        public string Schools { get; set; }
        public string JobStatus { get; set; }

        public Account Acc { get; set; }
    }
}
