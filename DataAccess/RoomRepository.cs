using DataAccess.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return FindAll();
        }


        public Room GetRoomById(int roomId)
        {
            var room = FindByCondition(room => room.RoomID == roomId);
            return room.FirstOrDefault();
        }

        public void CreateRoom(Room room)
        {
            Create(room);
        }


        public void UpdateRoom(Room room)
        {
            Update(room);
        }


        public void DeleteRoom(Room room)
        {
            Delete(room);
        }

    }
}
