using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Order
{
    using System.Data.SqlClient;
    using FoodOrderApp.Connection;
    using FoodOrderApp.User;
    internal class Order
    {
 
        public int fid,cid;
        public string payment_type;
        public Decimal price;
        public void MakePayment(User u)
        {
            Connection c3 = new Connection();
            c3.DbConnection();
            SqlConnection conn = c3.getConn();
            var querry = "select price from food where id=@fid";
            SqlCommand sc = new SqlCommand(querry,conn);
            sc.Parameters.AddWithValue("@fid",fid);
            SqlDataReader dr = sc.ExecuteReader();
            if (dr.Read()) {
                price =(decimal) dr["price"];
                dr.Close();
            }
            else
            {
                Console.WriteLine("Operation Failed");
                c3.CloseDbConnection();
            }
            Console.WriteLine($"Payment Amount : {price}");
            Console.WriteLine("Enter the Payment Type");
            payment_type = Console.ReadLine();
            cid=u.GetID();  
            var orderQuerry = "Insert into payment(fid,cid,price,payment_type) values (@fid,@cid,@price,@type)";
            SqlCommand insertOrder=new SqlCommand(orderQuerry,conn);
            insertOrder.Parameters.AddWithValue("@fid", fid);
            insertOrder.Parameters.AddWithValue("@cid", cid);
            insertOrder.Parameters.AddWithValue("@price", price);
            insertOrder.Parameters.AddWithValue("@type", payment_type);
            int row=insertOrder.ExecuteNonQuery();
            if (row > 0) {
                Console.WriteLine("Payment is successfull");
                var placeorder = "insert into orders values (@fid,@cid,@amount)";
                SqlCommand sc2= new SqlCommand(placeorder,conn);
                sc2.Parameters.AddWithValue("@fid", fid);
                sc2.Parameters.AddWithValue("@cid", cid);
                sc2.Parameters.AddWithValue("@amount", price);
                int newRow=sc2.ExecuteNonQuery();
                if (newRow > 0) {
                    var QuantityQuerry = "update food set quantity=quantity-1 where id=@id;";
                    SqlCommand setQuanity=new SqlCommand(QuantityQuerry,conn);
                    setQuanity.Parameters.AddWithValue("@id", fid);
                    int final=setQuanity.ExecuteNonQuery();
                    if (final > 0) {
                        Console.WriteLine("Order Placed Successfully , Thank You..");
                        c3.CloseDbConnection();
                    }
                }

            }
            c3.CloseDbConnection();
        }
        public void getOrderDetails(User u)
        {
            Console.WriteLine("Enter the Food id :");
            fid=int.Parse(Console.ReadLine());
            Connection c = new Connection();
            c.DbConnection();
            SqlConnection conn=c.getConn();
            string querry = "Select * from food where id=@id";
            SqlCommand sc=new SqlCommand(querry,conn);
            sc.Parameters.AddWithValue("@id",fid);
            SqlDataReader sdr2=sc.ExecuteReader();
            if(sdr2.Read())
            {
                c.CloseDbConnection();
                MakePayment(u);
            }
            else
            {
            Console.WriteLine($"Food with {fid} is not available");

            }      

            c.CloseDbConnection();  
        }
        public void ViewOrders(User u)
        {
            Console.WriteLine("____ Order History ____");
            Connection cv= new Connection();
            cv.DbConnection();
            var querry = "select name,category,amount,payment_type,payment_date from orders o join payment p on p.cid=o.cid join food f on f.id=o.fid where o.cid=@cid;";
            SqlCommand sqc=new SqlCommand(querry,cv.getConn());
            sqc.Parameters.AddWithValue("@cid",u.GetID());
      
            SqlDataReader sdr=sqc.ExecuteReader();
            while (sdr.Read()) {
                Console.WriteLine("Deatils : ");
                Console.WriteLine($"\nName : {sdr["name"]} \nCategory : {sdr["category"]} \nPrice : Rs.{sdr["amount"]} \nPayment Type : {sdr["payment_type"]} \nPayment Date : {sdr["payment_date"]} \n");
            }
            cv.CloseDbConnection();
        }
    }
}
