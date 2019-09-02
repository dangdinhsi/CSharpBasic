using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Room
    {
        public string RoomName { get; set; }
        public float Price { get; set; }
        public int Floor { get; set; }
        public int MaxContain { get; set; }
        public string RoomID { get; set; }

        public Room()
        {
        }

        public Room(string roomName, float price, int floor, int maxContain, string roomID)
        {
            RoomName = roomName;
            Price = price;
            Floor = floor;
            MaxContain = maxContain;
            RoomID = roomID;
        }

        public void inputRoom()
        {
            Console.Write("Nhập tên phòng:");
            RoomName = Console.ReadLine();
            Console.Write("Giá tiền:");
            Price = float.Parse(Console.ReadLine());
            Console.Write("Vị trí tầng:");
            Floor = Int32.Parse(Console.ReadLine());
            Console.Write("Số người tối đa:");
            MaxContain = Int32.Parse(Console.ReadLine());
            Console.Write("Mã phòng:");
            RoomID = Console.ReadLine();
        }
        public void displayRoom()
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", RoomName, Price, Floor, MaxContain, RoomID);
        }
    }
}
