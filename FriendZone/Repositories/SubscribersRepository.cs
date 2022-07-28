using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Services;
using System.Data;
using Dapper;

namespace FriendZone.Repositories
{
    public class SubscribersRepository
    {

        private readonly IDbConnection _db;
        public SubscribersRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Subscriber Create(Subscriber subscriberData)
        {
            string sql = @"
            INSERT INTO subscribers
             (subscriberId, accountId)
               VALUES
               (@SubscriberId, @AccountId);
                SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, subscriberData);
            subscriberData.Id = id;
            return subscriberData;

        }

        internal Subscriber Get(int id)
        {
            string sql = "SELECT * FROM subscribers WHERE id = @id";
            return _db.QueryFirstOrDefault<Subscriber>(sql, new { id });
        }
   
        internal List<SubscriberProfileViewModel> GetSubbed(string id)
        {
            string sql = @"
            SELECT 
            a.*,
            s.id AS subscriberId
             FROM subscribers s
                JOIN accounts a ON s.accountId = a.id
                WHERE s.subscriberId = @id";
            
            return _db.Query<SubscriberProfileViewModel>(sql, new { id }).ToList();
        }

   

        internal List<SubscriberProfileViewModel> GetSubscribers(string id)
        {
            string sql = @"
            SELECT 
            a.*,
            s.id AS subscriberId
             FROM subscribers s
                JOIN accounts a ON s.subscriberId = a.id
                WHERE s.accountId = @id";
            return _db.Query<SubscriberProfileViewModel>(sql, new { id }).ToList();
        }

      
    }
}


