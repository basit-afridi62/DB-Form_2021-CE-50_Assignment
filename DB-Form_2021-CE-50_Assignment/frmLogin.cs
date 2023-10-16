using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Form_Task_DB
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static string Username = ""; public static string Password = "";
      

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            //SqlConnection connection = new SqlConnection(@"Data 
            //var datasource = @"Source=DESKTOP-FAKFK9U\SQLEXPRESS01"; var database = "Northwind"; Username = txtUsername.Text; Password = txtPassword.Text;
            if (Username == "" || Password == "")
            {
                MessageBox.Show("Please enter your username and password.");
            }
            else
            {
                var datasource = @"DESKTOP-5Q4M5SH\SQLEXPRESS"; 
                var database = "Northwind"; 
                var thisUsername = Username; 
                var thisPassword = Password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + Username + ";Password=" + Password;
                SqlConnection conn = new SqlConnection(connString);

                try
                {
                    conn.Open();
                    //MessageBox.Show("Connection Successful"); 
                    Form1 frm1 = new Form1();
                    frm1.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }

}

