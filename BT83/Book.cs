using System;
using System.Collections.Generic;
using System.Text;

namespace BT83
{
    [Serializable]
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Producer { get; set; }
        public int YearPublish { get; set; }
        public float Price { get; set; }

        public Book()
        {
        }

        public Book(string name, string author, string producer, int yearPublish, float price)
        {
            Name = name;
            Author = author;
            Producer = producer;
            YearPublish = yearPublish;
            Price = price;
        }
        public override string ToString()
        {
            return "Ten sach:"+Name +",Author:"+Author+",Producer:"+Producer +",YearPublish:"+YearPublish+",Price:"+Price;
        }

        public virtual void input()
        {
            Console.Write("Nhap ten sach:");
            Name = Console.ReadLine();
            Console.Write("Nhap tac gia:");
            Author = Console.ReadLine();
            Console.Write("Nha san xuat:");
            Producer = Console.ReadLine();
            Console.Write("Nam phat hanh:");
            YearPublish = Int32.Parse(Console.ReadLine());
            Console.Write("Gia tien:");
            Price = float.Parse(Console.ReadLine());
        }

        public void displayTable()
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",Name,Author,Producer,YearPublish,Price);
        }
        public virtual void display()
        {
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Author:" + Author);
            Console.WriteLine("Producer:" + Producer);
            Console.WriteLine("YearPublish:" + YearPublish);
            Console.WriteLine("Price:" +Price);
        }
    }
}