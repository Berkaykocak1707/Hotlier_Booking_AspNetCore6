using Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IServiceManager
    {
        IRoomService RoomService
        {
            get; 
        }
        IBookingService BookingService
        {
        get; }
        ISubscribeService SubscribeService
        {
        get; }
        IContactService ContactService
        {
        get; }
        IAuthService AuthService
        {
        get; }
    }
}
