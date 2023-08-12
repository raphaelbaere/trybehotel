using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var specificHotel = _context.Hotels.First(hotel => hotel.HotelId == HotelId);
            var rooms = _context.Rooms.Where(room => room.HotelId == HotelId).Select(room => new RoomDto
            {
                RoomId = room.RoomId,
                Name = room.Name,
                Capacity = room.Capacity,
                Image = room.Image,
                Hotel = new HotelDto
                {
                    HotelId = specificHotel.HotelId,
                    Name = specificHotel.Name,
                    Address = specificHotel.Address,
                    CityId = specificHotel.CityId,
                    CityName = _context.Cities.First(city => city.CityId == specificHotel.CityId).Name
                }
            }).ToList();
            return rooms;
        }
        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room) {
            throw new NotImplementedException(); 
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId) {
            throw new NotImplementedException();
        }
    }
}