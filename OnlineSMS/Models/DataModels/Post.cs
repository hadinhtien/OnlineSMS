using System;
using System.Collections.Generic;

namespace OnlineSMS.Models.DataModels
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int? AccId { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Account Acc { get; set; }
    }
}
