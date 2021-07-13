using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRooms_PracticeExam.Entities
{
    public class Room :IComparable<Room>
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public int Beds { get; set; }

        public Room()
        {

        }
        public Room(long id, int number, int beds)
        {
            Id = id;
            Number = number;
            Beds = beds;
        }

        public static Room operator++(Room room)
        {
            room.Beds = room.Beds++;
            return room;
        }

        public int CompareTo(Room other)
        {
            return this.Beds.CompareTo(other.Beds);
        }
    }

    public class RoomAscCompare : IComparer<Room>
    {
        public int Compare(Room x, Room y)
        {
            return x.Beds.CompareTo(y.Beds);
        }
    }

    public class RoomDescCompare : IComparer<Room>
    {
        public int Compare(Room x, Room y)
        {
            return - x.Beds.CompareTo(y.Beds);
        }
    }
}
