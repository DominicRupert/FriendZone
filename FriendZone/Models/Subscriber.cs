using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendZone.Models
{
    public class Subscriber : RepoItem<int>
    {

        public string SubscriberId { get; set; }
        public string AccountId { get; set; }


    }
}