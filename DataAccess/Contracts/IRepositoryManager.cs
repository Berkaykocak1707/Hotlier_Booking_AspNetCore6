using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRepositoryManager
    {
        IRoomRepository roomRepository
        {
            get; 
        }
        IBookingRepository bookingRepository
        {
        get; }
        IContactRepository contactRepository
        {
        get; }
        ISubscribeRepository subscribeRepository
        {
        get; }
        void Save();
    }
}
