using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int roomId);
        void CreateRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(Room room);

    }
}
