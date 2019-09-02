using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.entity
{
    class Author
    {
        public string Ten { get; private set; }
        public int Tuoi { get; private set; }
        public string ButDanh { get; private set; }
        public string QuenQuan { get;private set; }

        public Author()
        {
        }

        public Author(string butDanh)
        {
            ButDanh = butDanh;
        }

        public Author(string ten, int tuoi, string butDanh, string quenQuan)
        {
            Ten = ten;
            Tuoi = tuoi;
            ButDanh = butDanh;
            QuenQuan = quenQuan;
        }

        public void inputAuthor(List<Author> list)
        {
            Console.Write("Nhap ten tac gia:");
            Ten = Console.ReadLine();
            Console.Write("Nhap tuoi:");
            Tuoi = Int32.Parse(Console.ReadLine());
            while (true)
            {
                Console.Write("But Danh:");
                ButDanh = Console.ReadLine();
                if (ischecked(list, ButDanh))
                {
                    Console.WriteLine("But danh da duoc su dung,nhap lai but danh");
                }
                else
                {
                    break;

                }
            }
            Console.Write("Que Quan:");
            QuenQuan = Console.ReadLine();
        }
        static bool ischecked(List<Author> list,string butdanh)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].ButDanh.Equals(butdanh))
                {
                    return true;
                }
            }
            return false;
        }
        public void inputAuthorWithoutButDanh()
        {
            Console.Write("Nhap ten tac gia:");
            Ten = Console.ReadLine();
            Console.Write("Nhap tuoi:");
            Tuoi = Int32.Parse(Console.ReadLine());
            Console.Write("Que Quan:");
            QuenQuan = Console.ReadLine();
        }
        public void displayAuthor()
        {
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", Ten, Tuoi, ButDanh, QuenQuan);
        }
    }
}
