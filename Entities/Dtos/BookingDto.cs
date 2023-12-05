using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record BookingDto
    {
        public int BookingID
        {
            get; init;
        }

        [Required]
        [StringLength(100)]
        public string BookingName
        {
            get; init;
        }

        [Required]
        [EmailAddress]
        public string BookingEmail
        {
            get; init;
        }

        [Required]
        public DateTime CheckIn
        {
            get; init;
        }

        [Required]
        public DateTime CheckOut
        {
            get; init;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Adult
        {
            get; init;
        }

        [Range(0, int.MaxValue)]
        public int Child
        {
            get; init;
        }

        public int RoomID
        {
            get; init;
        }

        public string? BookingMessage
        {
            get; init;
        }
    }
}
