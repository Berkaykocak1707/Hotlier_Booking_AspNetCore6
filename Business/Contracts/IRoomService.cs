using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int roomId);
        Room CreateRoom(RoomDtoForCreation dtoRoomCreate);
        RoomDtoForUpdate GetOneRoomForUpdate(int id);
        void UpdateRoom(RoomDtoForUpdate dtoRoomUpdate);
        void DeleteRoom(int roomId);
    }
}
