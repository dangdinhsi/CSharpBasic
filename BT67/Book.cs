using BT67.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Book
    {
        public DateTime DateOn { get; set; }
        public DateTime DateOut { get; set; }
        public string IdCardOrder { get; set; }
        public string HotelID { get; set; }
        public string RoomID { get; set; }

        public Book()
        {
        }

        public Book(DateTime dateOn, DateTime dateOut, string idCardOrder, string hotelID, string roomID)
        {
            DateOn = dateOn;
            DateOut = dateOut;
            IdCardOrder = idCardOrder;
            HotelID = hotelID;
            RoomID = roomID;
        }
       private Boolean checkCustomerExist(List<Customer> list, string str)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].CardID.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }

        private Hotel CheckIdHotelExist(List<Hotel> list, string str)
        {
            foreach(Hotel hotel in list)
            {
                if (hotel.HotelID.Equals(str))
                {
                    return hotel;
                }
            }
            return null;
        }

        public Boolean CheckAvailable(DateTime Cin, DateTime cOut)
        {
            if (DateTime.Compare(Cin, DateOut) > 0) return true;
            if (DateTime.Compare(cOut, DateOn) < 0) return true;
            return false;
        }
        public void Order(List<Hotel> hotelList,List<Customer> customerList,List<Book> bookList)
        {
            if (hotelList == null || hotelList.Count == 0)
            {
                Console.WriteLine("Không tồn tại khách sạn để đặt phòng");
                return;
            }
            Console.Write("Nhập số CMTND của khách muốn đặt phòng:");
            IdCardOrder = Console.ReadLine();
            if (!checkCustomerExist(customerList, IdCardOrder))
            {
                Customer customer = new Customer();
                customer.CardID = IdCardOrder;
                customer.inputCustomerNoID();
                customerList.Add(customer);
            }
            // show list mã khách sạn ở đây để khách hàng dễ dàng lựa chọn:
            foreach(Hotel hotel in hotelList)
            {
                Console.WriteLine("Tên KS:{0}, Mã KS:{1}", hotel.Name, hotel.HotelID);
            }
            Hotel currentHotel = null; // khởi tạo 1 khách sạn hiện tại để đổ thông tin vào phục vụ đặt hàng...
            while (true)
            {
                Console.Write("Nhập mã khách sạn:");
                HotelID = Console.ReadLine();
                // kiểm tra sự tồn tại của input mã khách sạn, nếu không đúng bắt nhập đúng mới thoát vòng lặp.
                currentHotel = CheckIdHotelExist(hotelList,HotelID);
                if (currentHotel != null)
                {
                    break; // hàm trả về hotel nếu khác null => người dùng nhập 1 mã ks đã tồn tại trong list => đúng yêu cầu => thoát khỏi vòng lặp.
                }
                else
                {
                    Console.WriteLine("Mã khách sạn bạn nhập không tồn tại, Vui lòng nhập lại:");
                }

            }
            // show list phòng có mã phòng để khách hạng dễ đối chiếu:
            foreach(Room room in currentHotel.listRoom)
            {
                Console.WriteLine("Tên phòng:{0},Mã phòng:{1}", room.RoomName, room.RoomID);
            }
            while (true)
            {
                Console.Write("Nhập mã phòng:");
                RoomID = Console.ReadLine();
                Boolean isFind = false;
                foreach(Room room in currentHotel.listRoom)
                {
                    if (room.RoomID.Equals(RoomID))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Mã phòng không hợp lệ, vui lòng nhập lại:");
                }
            }
            while (true)
            {
                Console.Write("Ngay dat phong:");
                string checkin = Console.ReadLine();
                Console.Write("Ngay tra phong:");
                string checkout = Console.ReadLine();
                DateOn = Utils.ConvertStringToDatetime(checkin);
                DateOut = Utils.ConvertStringToDatetime(checkout);
                Boolean isAvailable = true;
                foreach(Book book in bookList)
                {
                    if(book.HotelID ==HotelID && book.RoomID == RoomID)
                    {
                        if (!CheckAvailable(book.DateOn,book.DateOut))
                        {
                            isAvailable = false;
                            break;
                        }
                    }
                }
                if (isAvailable)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Thời gian đặt phòng không phù hợp!!");
                }
            }

        }

        public void getOrder()
        {
            Console.WriteLine("Mã khách sạn:{0},Mã Phòng:{1},CMTND:{2},DateOn:{3},DateOut:{4}",HotelID,RoomID,IdCardOrder,Utils.ConvertDatetimeToString(DateOn),Utils.ConvertDatetimeToString(DateOut));
        }
    }
}
