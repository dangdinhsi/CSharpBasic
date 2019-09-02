using System;
using System.Collections.Generic;
using System.Text;

namespace BT83
{
    class AptechBook:Book
    {
        public string Language { get; set; }
        public int Semester { get; set; }

        public AptechBook()
        {
        }

        public AptechBook(string name, string author, string producer, int yearPublish, float price,string language, int semester):base(name, author,producer, yearPublish, price)
        {
            Language = language;
            Semester = semester;
        }
        public override void input()
        {
            base.input();
            Console.Write("Nhap ngon ngu:");
            Language = Console.ReadLine();
            Console.Write("Nhap hoc ki:");
            Semester = Int32.Parse(Console.ReadLine());
        }
        public override void display()
        {
            base.display();
            Console.WriteLine("Language:" + Language);
            Console.WriteLine("Semester:" + Semester);

        }
    }
}
