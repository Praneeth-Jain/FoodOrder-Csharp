using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.UI
{
    public class UI
    {
        public void displayAuthMenu()
        {
            Console.WriteLine("___________  Food ordering App __________");
            Console.WriteLine("1.Create an Acccount ");
            Console.WriteLine("2.User Login");
            Console.WriteLine("3.Admin Login");
            Console.WriteLine("4.Exit");
        }
        public int getUserChoice()
        {
            int choice;
            Console.WriteLine("Enter your choice  : ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public void UserMenuDisplay()
        {
            Console.WriteLine("Welcome User ,Select Your Option");
            Console.WriteLine("1.View Foods");
            Console.WriteLine("2.Place Order");
            Console.WriteLine("3.View Order & PAyment History");
            Console.WriteLine("4.Exit");
        }
        public void AdminMenuDisplay()
        {
            Console.WriteLine("Hello Admin");
            Console.WriteLine("1.Add Food Items");
            Console.WriteLine("2.Exit");
        }
    }

}
