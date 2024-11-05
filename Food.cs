

namespace FoodOrderApp.Food
{
using System;
using System.Data.SqlClient;
using FoodOrderApp.Connection;
    class Food
    {
        public void ViewFood()
        {
            Connection c3 = new Connection();
            c3.DbConnection();
            SqlConnection conn=c3.getConn();
            string querry = "Select * from food";
            SqlCommand sc = new SqlCommand(querry, conn);
            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"\n\nid : {dr["id"]}");
                Console.WriteLine($"name : {dr["name"]}");
                Console.WriteLine($"category : {dr["category"]}");
                Console.WriteLine($"price : Rs.{dr["price"]}");
                Console.WriteLine($"Description : {dr["description"]}");
            }
            c3.CloseDbConnection();
        }

        public void AddFood()
        {
            Console.WriteLine("____Add Food Items___");
            Console.WriteLine("Enter the Food Name");
            string food=Console.ReadLine();
            Console.WriteLine("Enter the Food Category");
            string category=Console.ReadLine();
            Console.WriteLine("Enter the Price");
            float price=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Quantity");
            int quantity=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Food Description");
            var desc=Console.ReadLine();   
            Connection c = new Connection();
            c.DbConnection();
            SqlConnection conn=c.getConn();
            var querry = "Insert into food values(@name,@category,@price,@quantity,@description)";
            SqlCommand sc = new SqlCommand(querry,conn);
            sc.Parameters.AddWithValue("@name",food);
            sc.Parameters.AddWithValue("@category",category);
            sc.Parameters.AddWithValue("@price",price);
            sc.Parameters.AddWithValue("@quantity",quantity);
            sc.Parameters.AddWithValue("@description",desc);
            int rows=sc.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Food Added Successfully");
            }
            else
            {
                Console.WriteLine("Error while inserting the food try again");
            }
            c.CloseDbConnection();
        }
    }

}
