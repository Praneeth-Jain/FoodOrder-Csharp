using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FoodOrderApp.User

{
    using FoodOrderApp.Connection;
    using System.Data.SqlClient;

    public class User
    {
        public int id;
        public string name,username,password,contact,email;
        public bool isAdmin,isLoggedIn=false;
        public void createAccount()
        {
            Console.WriteLine("\n\n ____________  Creating New Account  _____________");
            Console.WriteLine("\n Enter your Details \n");
            Console.WriteLine("Enter your name :");
            name = Console.ReadLine();
            Console.WriteLine("Enter your unique username :");
            username = Console.ReadLine();
            Console.WriteLine("Enter password  :");
            password = Console.ReadLine();
            Console.WriteLine("Enter your contact no :");
            contact = Console.ReadLine();
            //Console.WriteLine("Enter your email :");
            //email = Console.ReadLine();
            Connection c1 = new Connection();
            c1.DbConnection();
            string querry = "Insert into customer(name,username,password,contact) values (@name,@username,@password,@contact)";
            SqlCommand sc = new SqlCommand(querry, c1.getConn());
            sc.Parameters.AddWithValue("@name", name);
            sc.Parameters.AddWithValue("@username", username);
            sc.Parameters.AddWithValue("@password", password);
            sc.Parameters.AddWithValue("@contact", contact);
            int rows=sc.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Account created Successfully");
            }
            else {
                Console.WriteLine("Error while creating Account please retry");
            }
            c1.CloseDbConnection();
        }
        public bool UserLogin()
        {
            Console.WriteLine("Login to your Existing Account");
            Console.WriteLine("Enter your username : ");
            string usrname= Console.ReadLine();
            Console.WriteLine("Enter the Password : ");
            string pass= Console.ReadLine();
            Connection c2=new Connection();
            c2.DbConnection();
            string querry = "select * from customer where username=@usrname;";
            SqlCommand sc = new SqlCommand(querry, c2.getConn());
            sc.Parameters.AddWithValue("@usrname", usrname);
            SqlDataReader users= sc.ExecuteReader();
            while (users.Read()) {
            if (pass ==(string)users["password"])
            {
                isLoggedIn = true;
                this.id =(int)users["id"];
                Console.WriteLine("Login Succesfull");
                c2.CloseDbConnection();
                return true;
            }
            else
            {
                Console.WriteLine("Login unsuccessfull please check your credentials");
                c2.CloseDbConnection();
                return false;
                }
            }
            return false;
        }
        public bool adminLogin()
        {
            Console.WriteLine("Admin Window");
            Console.WriteLine("Enter Admin Username");
            string ad_name=Console.ReadLine();
            Console.WriteLine("Enter the password");
            string ad_pass=Console.ReadLine();
            if (ad_pass == "admin123" && ad_name == "admin123")
            {
                isAdmin = true;
                Console.WriteLine("Admin Login Successfull");
                return true;
            }
            else {
                Console.WriteLine("Invalid Credentials Try Again");
                return false;
            }
        }
        public int GetID()
        {
            return this.id;
        }
    }
}
