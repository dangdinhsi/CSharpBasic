using System;
using System.Collections.Generic;
using System.Text;

namespace TestCRUD_LIST
{
    class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public float Price { get; set; }


        public Hotel()
        {
        }

        public void input()
        {
            Console.Write("Nhap ten:");
            Name = Console.ReadLine();
            Console.Write("Nhap dia chi:");
            Address = Console.ReadLine();
            Console.Write("Nhap gia:");
            Price = float.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return "Name:" + Name + "-Address:" + Address + "-Price:" + Price;
        }
    }
}
