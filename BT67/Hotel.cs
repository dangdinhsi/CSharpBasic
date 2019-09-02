using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public List<Room> listRoom = new List<Room>();
        public string HotelID { get; set; }
        public Hotel()
        {
        }

        public Hotel(string name, string address, string type, string hotelID)
        {
            Name = name;
            Address = address;
            Type = type;
            HotelID = hotelID;
        }

        public void inputHotel()
        {
            Console.Write("Nhập tên khách sạn:");
            Name = Console.ReadLine();
            Console.Write("Địa chỉ khách sạn:");
            Address = Console.ReadLine();
            Console.Write("Loại khách sạn:");
            Type = Console.ReadLine();
            Console.Write("Mã khách sạn:");
            HotelID = Console.ReadLine();
            Console.Write("Số phòng cần thêm:");
             int n = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Room room = new Room();
                Console.WriteLine("Phòng thứ {0}", i + 1);
                room.inputRoom();
                listRoom.Add(room);
            }
        }
        public void displayHotel()
        {
            Console.WriteLine("Name:{0}, Address:{1}, Type:{2}, HotelID:{3}",Name,Address,Type,HotelID);
            Console.WriteLine("List room of hotel {0}",Name);
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "RoomName", "Price", "Floor", "MaxContain", "RoomID");
            foreach (var room in listRoom)
            {
                room.displayRoom();
            }
        }
        public void displayNameHotel()
        {
            Console.WriteLine("Tên khách sạn:{0}",Name);
        }
    }
}
