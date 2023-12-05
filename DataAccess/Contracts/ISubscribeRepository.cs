using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ISubscribeRepository : IRepositoryBase<Subscribe>
    {
        IEnumerable<Subscribe> GetAllSubscriptions();
        Subscribe GetSubscriptionById(int subscriptionId);
        void CreateSubscribe(Subscribe subscribe);
        void DeleteSubscribe(int id);
    }
}
