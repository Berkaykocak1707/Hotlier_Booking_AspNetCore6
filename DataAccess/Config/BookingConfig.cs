using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(e => e.BookingID);
            builder.Property(e => e.BookingName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BookingEmail).IsRequired().HasMaxLength(100);
            builder.HasData(new Booking { BookingID = 1, RoomID = 1, Adult = 1, BookingEmail = "f@gmail.com", CheckIn = DateTime.Now, CheckOut = DateTime.Now, Child =1, BookingMessage = "falanca", BookingName =" dalanca", IsDone = false },

                new Booking { BookingID = 2, RoomID = 2, Adult = 1, BookingEmail = "f@gmail.com", CheckIn = DateTime.Now, CheckOut = DateTime.Now, Child = 1, BookingMessage = "falanca", BookingName = " dalanca", IsDone = false });
        }
    }
}
