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

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int id, string userId)
        {
            throw new NotImplementedException();
        }

        internal Subscriber Get(int id)
        {
            string sql = "SELECT * FROM subscribers WHERE id = @id";
            return _db.QueryFirstOrDefault<Subscriber>(sql, new { id });

        }

        internal List<SubscriberProfileViewModel> GetBySubscriberId(int id)
        {
            string sql = @"
            select
            a.*,
            s.id as subscriberId,
            FROM subscribers s
            join accounts a on a.id = s.accountId
            where s.subscriberId = @id";
            return _db.Query<SubscriberProfileViewModel>(sql, new { id }).ToList();
        }

        internal List<SubscriberProfileViewModel> GetByAccountId(string id)
        {
            string sql = @"
            select
            a.*,
            b.*,
            s.id as subscriberId,
            FROM subscribers s
            JOIN accounts b on b.id = s.profileId
            JOIN accounts a on a.id = b.creatorId
            WHERE s.accountId = @id";
            return _db.Query<Account, SubscriberProfileViewModel, SubscriberProfileViewModel>(sql, (prof, spvm) =>
            {
                spvm.Creator = prof;
                return spvm;
            }, new { id }).ToList();




        }
    }
}


