using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Room
    {
        public int RoomID
        {
            get; set;
        }
        public string? RoomName
        {
            get; set;
        }
        public String? RoomPhotoUrl
        {
            get; set;
        }
        public string? RoomDetail
        {
            get; set;
        }
        public string? RoomBed
        {
            get; set;
        }
        public string? RoomBath
        {
            get; set;
        }
        public decimal RoomPrice
        {
            get; set;
        }
        public DateTime RoomAvailableDate
        {
            get; set;
        }
        public bool IsRoomActive
        {
            get; set;
        }
        public ICollection<Booking> Bookings
        {
            get; set;
        }
    }
}
