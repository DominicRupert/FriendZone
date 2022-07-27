using System;
using System.Collections.Generic;
using FriendZone.Interfaces;

namespace FriendZone.Models
{
    public class Profile : ICreated
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public string CreatorId { get; set; }
        public Profile Creator { get; set; }

    }
    public class Account : Profile
    {
        public string Email { get; set; }
    }

    public class SubscriberProfileViewModel : Profile
    {
        public string SubscriberId { get; set; }
   
    }

}