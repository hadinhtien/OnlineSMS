using System;
using System.Collections.Generic;

namespace OnlineSMS.Models.DataModels
{
    public partial class Message
    {
        public int Id { get; set; }
        public int FromAccId { get; set; }
        public int ToAccId { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
