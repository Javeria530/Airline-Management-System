using iTextSharp.text.pdf;
using iTextSharp.text;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace airplane_management_system
{
    public partial class Form3 : Form
    {
        OracleConnection con;
        public Form3()
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE=localhost:1521/xe;USER ID=system;Password=12345");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand getSeats = con.CreateCommand();
                getSeats.CommandText = "SELECT * FROM users WHERE UserId = 1";
                getSeats.CommandType = CommandType.Text;
                OracleDataReader seatDR = getSeats.ExecuteReader();
                DataTable seatDT = new DataTable();
                seatDT.Load(seatDR);
                dataGridView1.DataSource = seatDT;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\n Thank You for using \n Good Bye!");

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM FLIGHT";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
       
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "select feedback from USERS";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "select * from crew";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();

            con.Open();
            OracleCommand getEmps1 = con.CreateCommand();
            getEmps.CommandText = "select* from users where usertype = 'PASSENGER'"; 
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR1 = getEmps.ExecuteReader();
            DataTable empDT1 = new DataTable();
            empDT1.Load(empDR1);
            dataGridView2.DataSource = empDT1;
            con.Close();

         
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
         
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}