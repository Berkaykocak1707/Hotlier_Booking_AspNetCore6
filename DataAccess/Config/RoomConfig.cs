using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.RoomID);
            builder.Property(e => e.RoomName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RoomDetail).IsRequired();
            builder.Property(e => e.RoomPrice).HasColumnType("decimal(18,2)");
            builder.Property(e => e.IsRoomActive).HasDefaultValue(true);
            builder.HasData(
            new Room { RoomID = 1, RoomName = "Standart Oda", RoomPhotoUrl= "/images/room-1.jpg",  RoomDetail = "Deniz Manzaralı", RoomBed = "Çift Kişilik Yatak", RoomBath = "1 Banyo", RoomPrice = 100.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 2, RoomName = "Deluxe Oda", RoomPhotoUrl = "/images/room-2.jpg", RoomDetail = "Bahçe Manzaralı", RoomBed = "İki Tek Kişilik Yatak", RoomBath = "1 Banyo", RoomPrice = 150.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 3, RoomName = "Aile Odası", RoomPhotoUrl = "/images/room-3.jpg", RoomDetail = "Orman Manzaralı", RoomBed = "Bir Çift ve İki Tek Kişilik Yatak", RoomBath = "2 Banyo", RoomPrice = 200.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 4, RoomName = "Süit Oda", RoomPhotoUrl = "/images/room-1.jpg", RoomDetail = "Havuz Manzaralı", RoomBed = "Çift Kişilik Yatak", RoomBath = "1 Banyo", RoomPrice = 180.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 5, RoomName = "Lüks Villa", RoomPhotoUrl = "/images/room-2.jpg", RoomDetail = "Deniz Manzaralı", RoomBed = "İki Çift Kişilik Yatak", RoomBath = "2 Banyo", RoomPrice = 300.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 6, RoomName = "Tek Kişilik Oda", RoomPhotoUrl = "/images/room-3.jpg", RoomDetail = "Şehir Manzaralı", RoomBed = "Tek Kişilik Yatak", RoomBath = "1 Banyo", RoomPrice = 80.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 7, RoomName = "Balayı Süiti", RoomPhotoUrl = "/images/room-1.jpg", RoomDetail = "Havuz ve Deniz Manzaralı", RoomBed = "Çift Kişilik Yatak", RoomBath = "1 Banyo", RoomPrice = 250.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true },
            new Room { RoomID = 8, RoomName = "Jakuzili Oda", RoomPhotoUrl = "/images/room-2.jpg", RoomDetail = "Dağ Manzaralı", RoomBed = "Çift Kişilik Yatak", RoomBath = "1 Banyo", RoomPrice = 170.00m, RoomAvailableDate = DateTime.Now, IsRoomActive = true }

    );
        }
    }
}
