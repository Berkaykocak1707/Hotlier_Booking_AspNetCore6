using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoomManager : IRoomService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RoomManager(IRepositoryManager repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Room CreateRoom(RoomDtoForCreation dtoRoomCreate)
        {
            Room room = _mapper.Map<Room>(dtoRoomCreate);
            _repository.roomRepository.CreateRoom(room);
            return room;
        }

        public void DeleteRoom(int roomId)
        {
            var room = _repository.roomRepository.GetRoomById(roomId);
            _repository.roomRepository.DeleteRoom(room);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            var rooms = _repository.roomRepository.GetAllRooms();
            return rooms;
        }

        public RoomDtoForUpdate GetOneRoomForUpdate(int id)
        {
            var room = GetRoomById(id);
            var roomDto = _mapper.Map<RoomDtoForUpdate>(room);
            return roomDto;
        }

        public Room GetRoomById(int roomId)
        {
            var room = _repository.roomRepository.GetRoomById(roomId);
            return room;
        }

        public void UpdateRoom(RoomDtoForUpdate dtoRoomUpdate)
        {
            var room = _mapper.Map<Room>(dtoRoomUpdate);
            _repository.roomRepository.UpdateRoom(room);
        }

    }
}
