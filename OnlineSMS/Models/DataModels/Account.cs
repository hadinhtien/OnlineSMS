using System;
using System.Collections.Generic;

namespace OnlineSMS.Models.DataModels
{
    public partial class Account
    {
        public Account()
        {
            AccountInfo = new HashSet<AccountInfo>();
            FriendAcc = new HashSet<Friend>();
            FriendAccIdFriendNavigation = new HashSet<Friend>();
            Post = new HashSet<Post>();
        }

        public int AccId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<AccountInfo> AccountInfo { get; set; }
        public ICollection<Friend> FriendAcc { get; set; }
        public ICollection<Friend> FriendAccIdFriendNavigation { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
