using System.Data;
using System.Data.SqlClient;

namespace Form_Task_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string currentTable = ""; if (radCustomers.Checked)
            {
                currentTable = "Customers";
            }
            else if (radEmployee.Checked)
            {
                currentTable = "Employees";
            }
            else if (radOrders.Checked)
            {
                currentTable = "Orders";
            }

            dataGridView1.DataSource = null;
            try
            {
                SqlCommand command = new SqlCommand();
                //SqlConnection connection = new SqlConnection(@"Data 
                var datasource = @"DESKTOP-5Q4M5SH\SQLEXPRESS"; var database = "Northwind";
                var thisUsername = frmLogin.Username; var thisPassword = frmLogin.Password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection conn = new SqlConnection(connString); conn.Open();
                txtMessageText.Text = "Retrieving Records..."; command.Connection = conn;
                command.CommandText = "select * from " + currentTable;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable(); da.Fill(dt);

                dataGridView1.DataSource = dt;
                txtMessageText.Text = "Retrieval Successful!"; conn.Close();
            }
            catch (Exception ex)
            {
                txtMessageText.Text = "Error, " + ex;
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"DESKTOP-5Q4M5SH\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (CustomerID, CompanyName) values('" +
           txtID.Text + "','" + txtCompanyName.Text + "')";
            command.ExecuteNonQuery();
            txtMessageText.Text = "Record Inserted...";
            connection.Close();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"DESKTOP-5Q4M5SH\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            txtMessageText.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            txtMessageText.Text = "Number of records: " + count;
            connection.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMessageText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            txtMessageText.Text = "Startup...";
            try
            {
                /* 
                System.Diagnostics.Debug.WriteLine("within the try"); 
                SqlConnection connection = new SqlConnection(@"Data 
                Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");                 connection.Open(); 
                txtMessageText.Text = "Connection Successful";                 connection.Close(); 
                */
                var datasource = @"DESKTOP-5Q4M5SH\SQLEXPRESS";
                var database = "Northwind";
                var thisUsername = frmLogin.Username;
                var thisPassword = frmLogin.Password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection conn = new SqlConnection(connString); 
                conn.Open();
                txtMessageText.Text = "Connection Successful on Startup"; conn.Close();

            }

            catch (Exception ex)
            {
                txtMessageText.Text = "Error, " + ex;
            }

        }
    }
}