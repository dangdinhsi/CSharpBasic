using System;

namespace BT83
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            int choose = 0;
            do
            {
                test.testMenu();
                choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        test.addBook();
                        break;
                    case 2:
                        test.getListBook();
                        break;
                    case 3:
                        test.SapXepSach();
                        break;
                    case 4:
                        test.findBookByName();
                        break;
                    case 5:
                        test.findBookByAuthor();
                        break;
                    case 6:
                        test.saveFile();
                        break;
                    case 7:
                        test.openFile();
                        break;
                    case 8:
                        Console.WriteLine("Bye bye, please press any key to Exit!!! ");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                        
                }
            } while (choose !=8);
        }
    }
}
