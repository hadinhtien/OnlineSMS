using System;
using System.Collections.Generic;

namespace OnlineSMS.Models.DataModels
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int? AccId { get; set; }
        public int? AccIdFriend { get; set; }
        public bool Relationship { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Account Acc { get; set; }
        public Account AccIdFriendNavigation { get; set; }
    }
}
