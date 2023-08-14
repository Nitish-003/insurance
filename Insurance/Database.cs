using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Insurance
{
    internal class Database
    {
/*        static readonly string server = "localhost";
        static readonly string username = "root";
        static readonly string password = "";
        static readonly string database = "insurance";
        //  string constr = "server: localhost;database: insurance;uid=root;pwd=";
        //    public string connection_string = "server='" + server + "'; user= '"+ username + "'; database= '" + database +"'; password= '" + password + ";";
        //    public MySqlConnection con = new MySqlConnection(constring);
        //     MySqlConnection con = new MySqlConnection(co);

        string constring = "Server=" + server + ";" + "Database=" + database + ";" + "Username=" + username + ";" + "Password=" + password + ";";
        MySqlConnection con = new MySqlConnection(constring);


        public bool connect_db()
        {
            try
            {
                MySqlConnection.Open();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool close_db()
        {
            try
            {
                MySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /*   string server = "localhost";
             string database = "insurance";
             string username = "root";
             string password = "";
             string constring = "Server=" + server + ";" + "Database=" + database + ";" + "Username=" + username + ";" + "Password=" + password + ";";

             MySqlConnection con = new MySqlConnection(constring);
             con.Open();

                 String query = "Select uid, password from user where Username = @val1 and Password = @val2";
             MySqlCommand cmd = new MySqlCommand(query, con);
             cmd.Parameters.AddWithValue("@val1", textBox1.Text);
                 cmd.Parameters.AddWithValue("@val2", textBox2.Text);
                 cmd.Prepare();

                 MySqlDataReader reader = cmd.ExecuteReader(); */

    }
}