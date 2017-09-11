using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            string create1 = "create table users(username varchar(50),password varchar(50))";
            string insert = "select * from  users";
           
            //using keyword to dispose off the connection once we are done implementing evrything.
           using (SQLiteConnection con = new SQLiteConnection("data source=louis.slqite;"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(insert, con);
                //cmd.ExecuteNonQuery();
                SQLiteDataReader rd = cmd.ExecuteReader();

               //select wanted columns by using reader["columnName"]
                while (rd.Read())
                {
                    Console.WriteLine(string.Format("name :{0} , password :{1}", rd["username"], rd["password"]));
                }

                //load datatable from sqlite reader object
                dt.Load(rd);

                var res = from x in dt.AsEnumerable() select x;
                string y = "frerere";
            }

            Console.WriteLine("yes yes");

            Console.Read();
        }
    }
}
