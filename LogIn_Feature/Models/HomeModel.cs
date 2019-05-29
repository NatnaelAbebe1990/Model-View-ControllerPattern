using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogIn_Feature.Models
{
    public class HomeModel
    {
        public string username { get; set; }
        public string password { get; set; }

        private MySqlConnection con;
        private MySqlDataReader reader;

        private IList name = new List<string>();
        private IList pass = new List<string>();
        public bool Validate()
        {
            string s = "datasource = localhost; port = 3306; username = root; password =; database = mvc";
            string query = "SELECT * FROM useraccount";
            con = new MySqlConnection(s);
            MySqlCommand com = new MySqlCommand(query,con);

            try
            {
                con.Open();

                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        name.Add(reader["username"]);
                        pass.Add(reader["userpassword"]);
                    }
                    
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // create the username and password and return their result
            if (username.Equals(name[0]) && password.Equals(pass[0]))
            {
                    return true;
            }

            return false;
        }
    }
}
