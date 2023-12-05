using DataAccess.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Booking> GetAllBookings() => FindAll();

        public Booking GetBookingById(int bookingId) => FindByCondition(booking => booking.BookingID == bookingId).FirstOrDefault();

        public void CreateBooking(Booking booking) => Create(booking);

        public void UpdateBooking(Booking booking) => Update(booking);

        public void DeleteBooking(Booking booking)
        {
            Delete(booking);
        }

        public void Done(int id)
        {
            var Booking =  GetBookingById(id);
            if (Booking is null)
            {
                throw new Exception("Booking is null");
            }
            Booking.IsDone = true;
        }


        public IQueryable<Booking> GetBookingWithRoomName(bool trackChanges)
        {
            return FindInclude(trackChanges, r => r.Room);
        }
    }
}
