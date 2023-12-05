using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class BookingManager : IBookingService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BookingManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateBooking(BookingDtoForCreation dtoBookingCreate)
        {
            Booking booking = _mapper.Map<Booking>(dtoBookingCreate);
            _repository.bookingRepository.CreateBooking(booking);
            _repository.Save();
        }

        public void DeleteBooking(int bookingId)
        {
            var booking = _repository.bookingRepository.GetBookingById(bookingId);
            _repository.bookingRepository.DeleteBooking(booking);
        }

        public void Done(int id)
        {
            _repository.bookingRepository.Done(id);
            _repository.Save();
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _repository.bookingRepository.GetAllBookings();
        }

        public Booking GetBookingById(int bookingId)
        {
            return _repository.bookingRepository.GetBookingById(bookingId);
        }

        public IQueryable<Booking> GetBookingWithRoomName(bool trackChanges)
        {
            return _repository.bookingRepository.GetBookingWithRoomName(trackChanges);
        }

        public void UpdateBooking(BookingDtoForUpdate dtoBookingUpdate)
        {
            Booking booking = _mapper.Map<Booking>(dtoBookingUpdate);
            _repository.bookingRepository.UpdateBooking(booking);
        }
    }
}
