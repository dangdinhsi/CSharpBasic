using BT67.util;
using System;
using System.Collections.Generic;

namespace BT67
{
    class Program
    {
        private static List<Customer> listCustomer = new List<Customer>();
        private static List<Book> listBook = new List<Book>();
        private static List<Hotel> listHotel = new List<Hotel>();
        static void Main(string[] args)
        {
            int choose;
            do
            {
                GenerateMenu();
                Console.Write("Nhập lựa chọn của bạn:");
                choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        addHotel();
                        break;
                    case 2:
                        getListHotel();
                        break;
                    case 3:
                        booking();
                        break;
                    case 4:
                        ShowRoomAvaiable();
                        break;
                    case 5:
                        ThongKeDoanhThu();
                        break;
                    case 6:
                        SearchCustomerExist();
                        break;
                    case 7:
                        Console.WriteLine("Good bye!!!");
                        break;
                    default:
                        Console.WriteLine("Bạn nhập 1 lựa chọn không hợp lệ!!");
                        break;
                }

            } while (choose!=7);

        }

        static Hotel getHotelbyId(string cmt)
        {
            foreach(Hotel hotel in listHotel)
            {
                if (hotel.HotelID.Equals(cmt))
                {
                    return hotel;
                }
            }
            return null;
        }
        static void SearchCustomerExist()
        {
            if(listHotel == null || listHotel.Count==0)
            {
                Console.WriteLine("Danh sách khách sạn đang còn trống, không thể thực hiện chức năng này!!");
                return;
            }
            Console.Write("Nhập chứng minh thư nhân dân cần tìm kiếm:");
            string cmtnd = Console.ReadLine();
            Console.WriteLine("Khách hàng đã đi qua các khách sạn sau:");
            foreach(Book book in listBook)
            {
                if (book.IdCardOrder.Equals(cmtnd))
                {
                    Hotel hotel = getHotelbyId(cmtnd);
                    if(hotel != null)
                    {
                        hotel.displayNameHotel();
                    }
                }
            }
        }
        static void ThongKeDoanhThu()
        {
            if (listHotel == null || listHotel.Count == 0)
            {
                Console.WriteLine("Danh sách khách sạn đang còn trống, không thể thực hiện chức năng này!!");
                return;
            }
            Console.WriteLine("1.Danh sach booking");
            foreach(Book book in listBook)
            {
                book.getOrder();
            }
            Console.WriteLine("2.Doanh thu");
            foreach(Hotel hotel in listHotel)
            {
                float tien = DoanhThu(hotel);
                Console.WriteLine("{0}-Doanh thu:{1}",hotel.Name,tien);
            }
        }
        static float DoanhThu(Hotel hotel)
        {
            float total = 0;
            foreach (Book book in listBook)
            {
                
                if (book.HotelID.Equals(hotel.HotelID))
                {
                    float price = getMoney(hotel.listRoom, book.RoomID);
                    total += price * (book.DateOut.Day - book.DateOn.Day);
                }
            }
            return total;
        }

        static float getMoney(List<Room> listRoom, string idRoom)
        {
      
            foreach (Room room in listRoom)
            {
                if (room.RoomID.Equals(idRoom)){
                    return room.Price;
                }
            }

            return 0;
        }

        static void ShowRoomAvaiable()
        {
            if (listHotel == null || listHotel.Count == 0)
            {
                Console.WriteLine("Danh sách khách sạn đang còn trống, không thể thực hiện chức năng này!!");
                return;
            }
            // người dùng nhập vào ngày muốn vào và muốn ra ==> hiện thị ra danh sách phòng thỏa mãn.
            Console.WriteLine("Nhap ngay dat phong (dd-mm-yyyy) : ");
            DateTime checkin = Utils.ConvertStringToDatetime(Console.ReadLine());
            Console.WriteLine("Nhap ngay tra phong (dd-mm-yyyy) : ");
            DateTime checkout = Utils.ConvertStringToDatetime(Console.ReadLine());
            Console.WriteLine("Danh sách những khách sạn và phòng thỏa mãn:");
            foreach(Hotel hotel in listHotel)
            {
                Console.WriteLine("Tên KS:{0}, Mã KS:{1}",hotel.Name,hotel.HotelID);
                foreach(Room room in hotel.listRoom)
                {
                    Boolean isChecked = true;
                    foreach(Book book in listBook)
                    {
                        if(book.HotelID ==hotel.HotelID && room.RoomID == book.RoomID)
                        {
                            if (!book.CheckAvailable(checkin, checkout)){
                                isChecked = false;
                                break;
                            }
                        }
                    }
                    if (isChecked)
                    {
                        room.displayRoom();
                    }
                }
            }
        }
        static void booking()
        {
            Book book = new Book();
            book.Order(listHotel,listCustomer,listBook);
            listBook.Add(book);
        }
        static void addHotel()
        {
            int n = 0;
            Console.Write("Nhập số lượng khách sạn cần thêm:");
            n = Int32.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Hotel hotel = new Hotel();
                Console.WriteLine("Khách sạn {0}", i + 1);
                hotel.inputHotel();
                listHotel.Add(hotel);
            }
        }
        static void getListHotel()
        {
            foreach(Hotel hotel in listHotel)
            {
                hotel.displayHotel();
            }
        }
        static void GenerateMenu()
        {
            Console.WriteLine("1.Nhap thong tin khach san");
            Console.WriteLine("2.Hien thi thong tin khach san");
            Console.WriteLine("3.Dat phong nghi");
            Console.WriteLine("4.Tim phong con trong");
            Console.WriteLine("5.Thong ke doanh thu");
            Console.WriteLine("6.Tim kiem thong tin khach hang");
            Console.WriteLine("7.Thoat chuong trinh.");
        }
    }
}
