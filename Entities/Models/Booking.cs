using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Booking
    {
        public int BookingID
        {
            get; set;
        }
        public string? BookingName
        {
            get; set;
        }
        public string? BookingEmail
        {
            get; set;
        }
        public DateTime CheckIn
        {
            get; set;
        }
        public DateTime CheckOut
        {
            get; set;
        }
        public int Adult
        {
            get; set;
        }
        public int Child
        {
            get; set;
        }
        public int RoomID
        {
            get; set;
        }
        public virtual Room? Room
        {
        get; set; }
        public string? BookingMessage
        {
            get; set;
        }
        public bool? IsDone
        {
        get; set; }
    }
}
