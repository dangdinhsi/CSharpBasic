using System;
using System.Collections.Generic;

namespace TestCRUD_LIST
{
    class Program
    {
        private static List<Hotel> list = new List<Hotel>();
        static void Main(string[] args)
        {
            Console.Write("So khach san can them:");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Hotel hotel = new Hotel();
                Console.WriteLine("Khach san thu {0}", i + 1);
                hotel.input();
                list.Add(hotel);
            }
            foreach (Hotel items in list)
            {
                Console.WriteLine(items.ToString());
            }

            Console.Write("Nhap ten khach san can xoa:");
            string str = Console.ReadLine();
            if (checkExistHotel(str))
            {
               for(int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name.Equals(str))
                    {
                        list.RemoveAt(i);
                        Console.WriteLine("thanh cong!!!");
                    }
                }
            }
            foreach (Hotel items in list)
            {
                Console.WriteLine(items.ToString());
            }

            /*  while (true)
              {
                  Console.Write("Nhap ten khach san can sua:");
                  string str = Console.ReadLine();
                  if (checkExistHotel(str))
                  {
                      Console.Write("Ten moi:");
                      string newName = Console.ReadLine();
                      Console.Write("Dia chi moi:");
                      string newAddress = Console.ReadLine();
                      Console.Write("Gia moi:");
                      float newPrice = float.Parse(Console.ReadLine());
                      foreach(Hotel hotel in list)
                      {
                          if (hotel.Name.Equals(str))
                          {
                              hotel.Name = newName;
                              hotel.Address = newAddress;
                              hotel.Price = newPrice;
                          }
                      }
                      Console.WriteLine("Danh sach khach san moi nhat:");
                      foreach (Hotel items in list)
                      {
                          Console.WriteLine(items.ToString());
                      }
                      break;
                  }
                  if(str == "exit")
                  {
                      Console.WriteLine("Ban da thoat");
                      break;
                  }
                  else
                  {
                      Console.WriteLine("Ten ban nhap khong hop le,vui long nhap lai!!!!");
                  }
              }
              */
        }
        static Boolean checkExistHotel(string str)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
