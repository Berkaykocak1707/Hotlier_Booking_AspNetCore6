using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record RoomDto
    {
        public int RoomID
        {
            get; init;
        }

        [Required]
        [StringLength(100)]
        public string RoomName
        {
            get; init;
        }

        public string? RoomPhotoUrl
        {
            get; set;
        }

        [Required]
        public string RoomDetail
        {
            get; init;
        }

        public string RoomBed
        {
            get; init;
        }
        public string RoomBath
        {
            get; init;
        }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal RoomPrice
        {
            get; init;
        }

        public DateTime RoomAvailableDate
        {
            get; init;
        }
        public bool IsRoomActive
        {
            get; init;
        }

    }
}
