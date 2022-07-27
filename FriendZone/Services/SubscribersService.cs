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
        internal void Delete(int id, string userId)
        {
            Subscriber found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Subscriber not found");
            }
            if (found.AccountId != userId)
            {
                throw new Exception("You can only delete your own subscriptions");
            }
            _repo.Delete(id);
        }

        internal List<SubscriberProfileViewModel> GetBySubscriberId(int id)
        {
            return _repo.GetBySubscriberId(id);
        }

        internal List<SubscriberProfileViewModel> GetByAccountId(string id)
        {
            return _repo.GetByAccountId(id);
        }
       
        
    }
}