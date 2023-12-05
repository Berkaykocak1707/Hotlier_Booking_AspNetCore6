using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SubscribeManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateSubscription(SubscribeDtoForCreation dtoSubscribeCreate)
        {
            var subscribe = _mapper.Map<Subscribe>(dtoSubscribeCreate);
            _repository.subscribeRepository.CreateSubscribe(subscribe);
        }

        public void DeleteSubscription(int subscriptionId)
        {
            var subscribe = _repository.subscribeRepository.GetSubscriptionById(subscriptionId);
            _repository.subscribeRepository.DeleteSubscribe(subscriptionId);
        }

        public IEnumerable<Subscribe> GetAllSubscriptions()
        {
            return _repository.subscribeRepository.GetAllSubscriptions();
        }

        public Subscribe GetSubscriptionById(int subscriptionId)
        {
            return _repository.subscribeRepository.GetSubscriptionById(subscriptionId);
        }
    }
}
