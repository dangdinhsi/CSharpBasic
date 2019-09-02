using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BT83
{
    class Test
    {
        private static List<Book> listBook = new List<Book>();
        public void testMenu()
        {
            Console.WriteLine("*************** Quan Li Book *****************");
            Console.WriteLine("1.Them sach");
            Console.WriteLine("2.Hien thi sach");
            Console.WriteLine("3.Hien thi sach theo nam xuat ban giam dan");
            Console.WriteLine("4.Tim kiem theo ten sach");
            Console.WriteLine("5.Tim kiem theo ten tac gia");
            Console.WriteLine("6.Luu sach da nhap vao file");
            Console.WriteLine("7.Doc noi dung tu file va luu vao mang quan li sach");
            Console.WriteLine("8.Exit chuong trinh");
            Console.WriteLine("***********************************************");
            Console.Write("Nhap lua chon cua ban:");
        }

        /* Ghi dữ liêu ra dưới dạng 1 mảng...

          List<Student> list = new List<Student>();
          for(int i = 0; i < 10; i++)
          {
              list.Add(new Student("Name "+i,"Address "+i));
          }

          using (Stream stream = File.Open("studentlist.dat", FileMode.Create))
          {
              var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
              binaryFormatter.Serialize(stream, list);
          }
          Console.WriteLine("save success!!");
           */

        /* Đọc dữ liệu từ 1 mảng:

        List<Student> list = new List<Student>();
        using (Stream stream = File.Open("studentlist.dat", FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            list = (List<Student>) binaryFormatter.Deserialize(stream);
        }

        if(list != null) {
            foreach(Student std in list) {
                Console.WriteLine(std.ToString());
            }
        }
            */
        public void saveFile()
        {
            if (listBook.Count != 0)
            {
                using (Stream stream = File.Open("listBook.dat", FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, listBook);
                }
                Console.WriteLine("save success!!");
            }
            else
            {
                Console.WriteLine("Chưa có thông tin để lưu!!!");
            }

        }
        public void openFile()
        {
            List<Book> list = new List<Book>();
            try
            {
                using (Stream stream = File.Open("listBook.dat", FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    list = (List<Book>)binaryFormatter.Deserialize(stream);
                }

                if (list != null)
                {
                    foreach (Book book in list)
                    {
                        Console.WriteLine(book.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void SapXepSach() // hien thi sach theo nam xuat ban giam dan.
        {
            string tensach, tacgia, nxb;
            int namxb;
            float giatien;
            for(int i = 0; i < listBook.Count -1; i++)
            {
                for(int j = i + 1; j < listBook.Count; j++)
                {
                    if(listBook[i].YearPublish < listBook[j].YearPublish)
                    {
                        // đổi chỗ tên
                        tensach = listBook[i].Name;
                        listBook[i].Name = listBook[j].Name;
                        listBook[j].Name = tensach;
                        // kết thúc đổi chỗ tên.

                        //2
                        tacgia = listBook[i].Author;
                        listBook[i].Author = listBook[j].Author;
                        listBook[j].Author = tacgia;
                        //2

                        //3
                        nxb = listBook[i].Producer;
                        listBook[i].Producer = listBook[j].Producer;
                        listBook[j].Producer = nxb;
                        //3

                        //4
                        namxb = listBook[i].YearPublish;
                        listBook[i].YearPublish = listBook[j].YearPublish;
                        listBook[j].YearPublish = namxb;
                        //4

                        //5
                        giatien = listBook[i].Price;
                        listBook[i].Price = listBook[j].Price;
                        listBook[j].Price = giatien;
                        //5
                    }

                }
            }
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Name", "Author", "Producer", "YearPublish", "Price");
            foreach (var sach in listBook)
            {
                sach.displayTable();
            }

        }
        public void findBookByName()
        {
            Console.Write("Nhap ten sach can tim kiem:");
            string str = Console.ReadLine();
            int dem = 0;
            for(int i = 0; i < listBook.Count; i++)
            {
                if (listBook[i].Name.Equals(str))
                {
                    listBook[i].display();
                    dem++;
                }
                
            }
            Console.WriteLine("Co {0} cuon sach co ten {1}", dem, str);
        }
        public void findBookByAuthor()
        {
            Console.Write("Nhap ten tac gia can tim kiem:");
            string str = Console.ReadLine();
            int dem = 0;
            for (int i = 0; i < listBook.Count; i++)
            {
                if (listBook[i].Author.Equals(str))
                {
                    listBook[i].display();
                    dem++;
                }
            }
            Console.WriteLine("Co {0} cuon sach co ten {1}", dem, str);
        }
        public void addBook()
        {
            Console.Write("So luong sach can them:");
            int n = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Book book = new Book();
                Console.WriteLine("cuon thu {0}", i + 1);
                book.input();
                listBook.Add(book);
            }
        }
        public void getListBook()
        {
            foreach(Book book in listBook)
            {
                book.display();
            }
        }

    }
}
