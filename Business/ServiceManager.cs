using Business.Contracts;
using Repositories.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRoomService _roomService;
        private readonly IContactService _contactService;
        private readonly IBookingService _bookingService;
        private readonly ISubscribeService _subscribeService;
        private readonly IAuthService _authService;
        public ServiceManager(IRoomService roomService, IContactService contactService, IBookingService bookingService, ISubscribeService subscribeService, IAuthService authService)
        {
            _roomService = roomService;
            _contactService = contactService;
            _bookingService = bookingService;
            _subscribeService = subscribeService;
            _authService = authService;
        }
        public IRoomService RoomService => _roomService;

        public IBookingService BookingService => _bookingService;

        public ISubscribeService SubscribeService => _subscribeService;

        public IContactService ContactService => _contactService;

        public IAuthService AuthService => _authService;
    }
}
