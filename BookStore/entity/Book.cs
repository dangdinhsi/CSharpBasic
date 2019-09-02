using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.entity
{
    class Book
    {
        public string TenSach { get; set; }
        public string NgayXuatBan { get; set; }
        public string ButDanh { get; set; }

        public Book()
        {
        }

        public Book(string tenSach, string ngayXuatBan, string butDanh)
        {
            TenSach = tenSach;
            NgayXuatBan = ngayXuatBan;
            ButDanh = butDanh;
        }
        public void inputBook()
        {
       
            Console.Write("Nhap ten sach:");
            TenSach = Console.ReadLine();
            Console.Write("Ngay xuat ban:");
            NgayXuatBan = Console.ReadLine();
            Console.Write("But danh tac gia:");
            ButDanh = Console.ReadLine();
        }
        public void displayBook()
        {
            Console.WriteLine("{0, -20} {1, -20} {2, -20}",TenSach, NgayXuatBan, ButDanh);
        }
        public void displayBookNoButDanh()
        {
            Console.WriteLine("{0, -20} {1, -20}", TenSach, NgayXuatBan);
        }
    }
}
