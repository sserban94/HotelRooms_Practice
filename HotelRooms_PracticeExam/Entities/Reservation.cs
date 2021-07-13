using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRooms_PracticeExam.Entities
{
    public class Reservation
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Persons { get; set; }

        public override string ToString()
        {
            return $"Reservation Id - {Id}, Room Id - {RoomId}, Check-In Date - {CheckInDate}, " +
                $"Check-Out Date - {CheckOutDate}, Number of Guests: {Persons}";
        }
    }
}
