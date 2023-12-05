using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        void CreateBooking(BookingDtoForCreation dtoBookingCreate);
        void UpdateBooking(BookingDtoForUpdate dtoBookingUpdate);
        IQueryable<Booking> GetBookingWithRoomName(bool trackChanges);
        void DeleteBooking(int bookingId);
        void Done(int id);
    }
}
