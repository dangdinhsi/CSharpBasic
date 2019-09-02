using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Customer
    {
        public string CardID { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public Customer()
        {
        }

        public Customer(string cardID, string fullname, int age, string gender, string address)
        {
            CardID = cardID;
            Fullname = fullname;
            Age = age;
            Gender = gender;
            Address = address;
        }
        public void inputCustomerNoID()
        {
            Console.Write("Nhập tên:");
            Fullname = Console.ReadLine();
            Console.Write("Nhập tuổi:");
            Age = Int32.Parse(Console.ReadLine());
            Console.Write("Nhập giới tính:");
            Gender = Console.ReadLine();
            Console.Write("Địa chỉ:");
            Address = Console.ReadLine();
        }
        public void inputCustomer()
        {
            Console.Write("Nhập tên:");
            Fullname = Console.ReadLine();
            Console.Write("Nhập CMTND:");
            CardID = Console.ReadLine();
            Console.Write("Nhập tuổi:");
            Age = Int32.Parse(Console.ReadLine());
            Console.Write("Nhập giới tính:");
            Gender = Console.ReadLine();
            Console.Write("Địa chỉ:");
            Address = Console.ReadLine();
        }
        public void displayCustomer()
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",Fullname,CardID,Age,Gender,Address);
        }
    }
}
