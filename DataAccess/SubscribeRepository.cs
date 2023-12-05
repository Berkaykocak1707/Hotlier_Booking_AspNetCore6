using DataAccess.Contracts;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class SubscribeRepository : RepositoryBase<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Subscribe> GetAllSubscriptions()
        {
            return FindAll();
        }

        public Subscribe GetSubscriptionById(int subscriptionId)
        {
            var subscribe = FindByCondition(s => s.SubscribeID == subscriptionId);
            return subscribe.FirstOrDefault();
        }

        public void CreateSubscribe(Subscribe subscribe)
        {
            Create(subscribe);
        }

        public void DeleteSubscribe(int id)
        {
            var subs = GetSubscriptionById(id);
            Delete(subs);
        }

    }
}
