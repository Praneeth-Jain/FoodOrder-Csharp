//Develop a C sharp Console App to manage food order Application.

//Operational flow of the system is as follows

//Owner of the shops will add food details such as

//name, catagory, price, description and quantity. Customers will check and order food Order will be placed only after doing the payment.

//Customer can check the order history with payment details in future.

//Preferred tables: Customer, Food, Order, Payment

//Backend: MSSQL

//Implementation should contain Database connection class that implement opers

//connection logic.


using System.Data.SqlClient;
using FoodOrderApp.Connection;
using FoodOrderApp.UI;
using FoodOrderApp.User;
using FoodOrderApp.Food;
using FoodOrderApp.Order;
internal class Program
{
        static void Main(string[] args)
        {
        bool usrLogin,adminLogin = false;
        UI ui= new UI();
        Connection c = new Connection();
        User u=new User();
        Food f=new Food();
        Order o=new Order();
        bool exit = false;
        while (!exit)
        {
        ui.displayAuthMenu();
        int choice=ui.getUserChoice();
        switch (choice)
        {
            case 1:
                u.createAccount();
                break;
            case 2:
                usrLogin=u.UserLogin();
                    if (usrLogin)
                    {
                        bool usrmenuexit = false;
                        while (!usrmenuexit)
                        {

                        ui.UserMenuDisplay();
                        int usrmenuChoice=ui.getUserChoice();
                        switch (usrmenuChoice)
                        {
                            case 1:
                                f.ViewFood();
                                break;
                            case 2:
                                o.getOrderDetails(u);
                                break;
                            case 3:
                                o.ViewOrders(u);
                                break;
                            case 4:
                                usrmenuexit=true;
                                break;
                            default:
                                Console.WriteLine("invalid key");
                                break;
                        }
                        }
                    }
                break;
            case 3:
                 adminLogin=u.adminLogin();
                    if (adminLogin)
                    {
                        bool adminexit = false;
                        while (!adminexit)
                        {

                        ui.AdminMenuDisplay();
                        int adminChoice=ui.getUserChoice();
                        switch (adminChoice)
                        {
                            case 1:f.AddFood(); break; 
                            case 2:adminexit=true; break;
                            default :Console.WriteLine("Invalid key"); break;
                        }
                        }
                    }
                 break;
            case 4:
                exit= true;
                break;
            default:
                Console.WriteLine("Invalid Key");
                break;
        }

        }

    }
}
