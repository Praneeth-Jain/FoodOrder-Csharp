
using System.Data.SqlClient;


namespace FoodOrderApp.Connection
{
    public class Connection
    {

        string dataSource = @"LAPTOP-M86ENGOL";
        string database = @"FoodOrderDB";
        SqlConnection conn;
        public void DbConnection()
        {

            var ConnString = @"Data Source=" + dataSource + ";Initial Catalog=" + database + ";Trusted_Connection=True;";
            Console.WriteLine(ConnString);

            SqlConnection con = new SqlConnection(ConnString);


            try
            {
                //Console.WriteLine("Establishing Connection");
                con.Open();
                //Console.WriteLine("Connection is established");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            this.conn = con;
        }
        public void CloseDbConnection()
        {
            conn.Close();
            //Console.WriteLine("Connection is closed");
        }
        public SqlConnection getConn()
        {
            return this.conn;
        }
    }
}
