using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Insurance
{
    public partial class Form1 : Form
    {
        Image file;
        private int progressValue = 0;
        private int fvalue = 0;
        private int lvalue = 0;
        private int addvalue = 0;
        private int uname = 0;
        private int pwd = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (richTextBox5.Text == string.Empty)
            {
                MessageBox.Show("Please enter your First Name");
                return;
            }
            if(richTextBox6.Text == string.Empty)
            {
                MessageBox.Show("Please enter your Middle Name");
                return;
            }

            if (richTextBox7.Text == string.Empty)
            {
                MessageBox.Show("Please enter your Last Name!");
                return;
            }
            if (maskedTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter your Phone Number!");
                return;
            }
            if (richTextBox12.Text == string.Empty)
            {
                MessageBox.Show("Please enter your address!");
                return;
            }
            if (richTextBox2.Text == string.Empty)
            {
                MessageBox.Show("Please enter new username!");
                return;
            }
            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter new password!");
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please upload your photo!");
                return;
            }

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(richTextBox12.Text.Trim());

            string server = "localhost";
            string database = "insurance";
            string username = "root";
            string password = "";
            string constring = "Server=" + server + ";" + "Database=" + database + ";" + "Username=" + username + ";" + "Password=" + password + ";";
            MySqlConnection con = new MySqlConnection(constring);
            con.Open();

            String query = "INSERT INTO `user`(`Username`, `Password`) VALUES('"+ richTextBox2.Text +"', '"+ richTextBox1.Text +"')";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Prepare();
            int value = cmd.ExecuteNonQuery();

            String query1 = "INSERT INTO `account`(`fname`, `mname`, `lname`, `dob`, `address`) VALUES ('" + richTextBox5.Text + "','" + richTextBox6.Text + "','" + richTextBox7.Text + "','"+ dateTimePicker1.Value.Date +"','"+ richTextBox12.Text + "')";
            MySqlCommand cmd1 = new MySqlCommand(query1, con);


            cmd1.Prepare();
            int value1 = cmd1.ExecuteNonQuery();


            if (value == 1 && value1 == 1)
            {
                labelOutput.Text = " User Registered Successfully! Kindly Log in";
                richTextBox5.Text = "";
                richTextBox6.Text = "";
                richTextBox7.Text = "";
                maskedTextBox1.Text = "";
                richTextBox12.Text = "";
                richTextBox1.Text = "";
                richTextBox2.Text = "";

                Image iOld = this.pictureBox1.Image;
                this.pictureBox1.Image = null;
                if (iOld != null)
                {
                    iOld.Dispose();
                    progressValue = progressValue - 16;
                    progressBar1.Value = progressValue;
                }
            }
            else
            {
                MessageBox.Show("Error on execution! Kindly try after some time");
            }


            
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox5.Text = "";
            richTextBox6.Text = "";
            richTextBox7.Text = "";
            maskedTextBox1.Text = "";
            richTextBox12.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";

            Image iOld = this.pictureBox1.Image;
            this.pictureBox1.Image = null;
            if (iOld != null)
                iOld.Dispose();
            return;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Insurance#:~:text=Insurance%20is%20a%20means%20of,a%20contingent%20or%20uncertain%20loss.");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2= new Form2();
            f2.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG (*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                file = Image.FromFile(f.FileName);
                pictureBox1.Image = file;
                progressValue = progressValue + 16;
                progressBar1.Value = progressValue;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "JPG (*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                file.Save(f.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image iOld = this.pictureBox1.Image;
            this.pictureBox1.Image = null;
            if (iOld != null)
            {
                iOld.Dispose();
                progressValue = progressValue - 16;
                progressBar1.Value = progressValue;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox5.Text != string.Empty && fvalue==0)
            {
                fvalue = 1;
                progressValue = progressValue + 16;
                progressBar1.Value = progressValue; 
                return;
            }
            else if (richTextBox5.Text == string.Empty && fvalue==1) 
            {
                fvalue=0;
                progressValue = progressValue - 16;
                progressBar1.Value = progressValue;
            }
        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox7.Text != string.Empty && lvalue == 0)
            {
                lvalue = 1;
                progressValue = progressValue + 16;
                progressBar1.Value = progressValue;
                return;
            }
            else if (richTextBox7.Text == string.Empty && lvalue == 1)
            {
                lvalue = 0;
                progressValue = progressValue - 16;
                progressBar1.Value = progressValue;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void richTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox12.Text != string.Empty && addvalue == 0)
            {
                addvalue = 1;
                progressValue = progressValue + 16;
                progressBar1.Value = progressValue;
                return;
            }
            else if (richTextBox12.Text == string.Empty && addvalue == 1)
            {
                addvalue = 0;
                progressValue = progressValue - 16;
                progressBar1.Value = progressValue;
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox2.Text != string.Empty && uname == 0)
            {
                uname = 1;
                progressValue = progressValue + 16;
                progressBar1.Value = progressValue;
                return;
            }
            else if (richTextBox2.Text == string.Empty && uname == 1)
            {
                uname = 0;
                progressValue = progressValue - 16;
                progressBar1.Value = progressValue;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != string.Empty && pwd == 0)
            {
                pwd = 1;
                progressValue = progressValue + 20;
                progressBar1.Value = progressValue;
                return;
            }
            else if (richTextBox1.Text == string.Empty && pwd == 1)
            {
                pwd = 0;
                progressValue = progressValue - 20;
                progressBar1.Value = progressValue;
            }
        }
    }
}
