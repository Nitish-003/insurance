using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insurance
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Hide();
            button2.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter your user id");
                return;
            }

            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Please enter your Password");
                return;
            }
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(textBox2.Text.Trim());


            string server = "localhost";
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
               
            MySqlDataReader reader =  cmd.ExecuteReader();
            int flag = 0;
            while (reader.Read())
            {
                flag = 1;
            }
            con.Close();

            if (flag ==1)
            {
                Form3 f1 = new Form3();
                f1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username and Password");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in textBox1.Text)
            {
                if (!Char.IsDigit(c))
                {
                    button1.BackColor = Color.FromArgb(128, 255, 255);
                    button2.BackColor = Color.FromArgb(128, 255, 255);
                    button1.Show();
                    button2.Show();
                    break;
                }
                else 
                {
                    button1.Hide();
                    button2.Hide(); 
                    button1.BackColor = Color.White;
                    button2.BackColor = Color.White;
                    break;
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

    }
}
