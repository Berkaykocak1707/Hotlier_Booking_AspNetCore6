using Entities.Dtos;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ISubscribeService
    {
        IEnumerable<Subscribe> GetAllSubscriptions();
        Subscribe GetSubscriptionById(int subscriptionId);
        void CreateSubscription(SubscribeDtoForCreation dtoSubscribeCreate);
        void DeleteSubscription(int subscriptionId);
    }
}
