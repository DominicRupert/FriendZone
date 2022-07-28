using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
    public class SubscribersService
    {
        private readonly SubscribersRepository _repo;

        public SubscribersService(SubscribersRepository repo)
        {
            _repo = repo;
        }

        internal Subscriber Create(Subscriber subscriberData)
        {
            return _repo.Create(subscriberData);
            
        }

        internal Subscriber Get(int id)
        {
            return _repo.Get(id);
        }

        internal List<SubscriberProfileViewModel> GetSubscribers(string id)
        {
            return _repo.GetSubscribers(id);
        }

        internal List<SubscriberProfileViewModel> GetSubbed(string id)
        {
            return _repo.GetSubbed(id);
        }
      
    

       
        
    }
}