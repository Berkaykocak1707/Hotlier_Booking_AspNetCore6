using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IBookingRepository : IRepositoryBase<Booking>
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        IQueryable<Booking> GetBookingWithRoomName(bool trackChanges);
        void CreateBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
        void Done(int id);
    }
}
