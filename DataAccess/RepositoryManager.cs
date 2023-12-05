using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        public IRoomRepository _roomRepository;
        public ISubscribeRepository _subscribeRepository;
        public IBookingRepository _bookingRepository;
        public IContactRepository _contactRepository;

        public RepositoryManager(IRoomRepository roomRepository, RepositoryContext context, ISubscribeRepository subscribeRepository, IBookingRepository bookingRepository, IContactRepository contactRepository)
        {
            _roomRepository = roomRepository;
            _context = context;
            _subscribeRepository = subscribeRepository;
            _bookingRepository = bookingRepository;
            _contactRepository = contactRepository; 
        }

        public IRoomRepository roomRepository => _roomRepository;

        public IBookingRepository bookingRepository => _bookingRepository;

        public IContactRepository contactRepository => _contactRepository;

        public ISubscribeRepository subscribeRepository => _subscribeRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
