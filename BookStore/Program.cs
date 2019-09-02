using BookStore.entity;
using System;
using System.Collections.Generic;

namespace BookStore
{
    class Program
    {
        private static List<Author> authorList = new List<Author>();
        private static List<Book> bookList = new List<Book>();
        static void Main(string[] args)
        {
            int choose;
            do
            {
                Menu();
                Console.Write("Nhap lua chon cua ban:");
                choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        addBook();
                        break;
                    case 2:
                        displayBook();
                        break;
                    case 3:
                        listAuthor();
                        addAuthor();
                        break;
                    case 4:
                        findListByButDanh();
                        break;
                    case 5:
                        Console.WriteLine("Nhấn Enter để thoát chương trình!!!");
                        break;
                    default:
                        Console.WriteLine("Ban nhap 1 lua chon khong hop le");
                        break;

                }
            } while (choose != 5);
          
        }
        static void listAuthor()
        {
            if (authorList.Count != 0)
            {
            Console.WriteLine("-----------------------------------------List tác giả---------------------------------------");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", "Ten", "Tuoi", "ButDanh", "QuenQuan");
            foreach (Author author in authorList)
            {
                author.displayAuthor();
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            }
        }
        static void findListByButDanh()
        {
            Console.Write("Nhap but danh:");
            string str = Console.ReadLine();
            int dem = 0;
            if (ischecked2(bookList,str))
            {
                Console.WriteLine("{0, -20} {1, -20}", "Ten Sach", "Ngay Xuat Ban");
                foreach (Book book in bookList)
                {
                    dem++;
                    book.displayBookNoButDanh();
                }
                Console.WriteLine("Có {0} cuốn sách phù hợp với tác giả {1}", dem, str);
            }
            else
            {
                Console.WriteLine("Không có sách phù hợp tên tác giả bạn nhập!!!");
            }
        }

        private static bool ischecked2(List<Book> list, string butdanh)
        {
           
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ButDanh.Equals(butdanh))
                {
                    
                    return true;
                }
            }
           
            return false;
        }
        static void displayBook()
        {
            Console.WriteLine("{0, -20} {1, -20} {2, -20}", "Ten Sach", "Ngay Xuat Ban", "But Danh");
            foreach (Book book in bookList)
            {

                book.displayBook();
            }
        }
        static void addAuthor()
        {
            Console.Write("Nhap so luong tac gia can them:");
            int n = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Author author = new Author();
                Console.WriteLine("Thong tin cua tac gia thu {0}", i + 1);
                author.inputAuthor(authorList);
                authorList.Add(author);
            }
        }
        private static bool ischecked(List<Author> list, string butdanh)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ButDanh.Equals(butdanh))
                {
                    return true;
                }
            }
            return false;
        }
        static void addBook()
        {
            Console.Write("Nhap so luong sach can them:");
            int n = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Book book = new Book();
                Console.WriteLine("******Cuon sach thu {0}****", i+1);
                book.inputBook();
                if (!ischecked(authorList,book.ButDanh)){
                    Console.WriteLine("Đây là 1 bút danh mới");
                    Author author = new Author(book.ButDanh);
                    author.inputAuthorWithoutButDanh();
                    authorList.Add(author);
                }
                bookList.Add(book);
            }
        }
         static void Menu()
        {
            Console.WriteLine("*************** Ung Dung Quan Li Sach *******************");
            Console.WriteLine("1.Them sach");
            Console.WriteLine("2.Hien thi sach");
            Console.WriteLine("3.Them tac gia");
            Console.WriteLine("4.Tim kiem sach theo but danh");
            Console.WriteLine("5.Thoat chuong trinh");
            Console.WriteLine("*********************************************************");     
        }
    }
}
