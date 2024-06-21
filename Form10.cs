using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airplane_management_system
{
    public partial class Form10 : Form
    {
        OracleConnection con;

        string userName = " ";
        string password = " ";

        public Form10(string password, string userName)
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE=localhost:1521/xe;USER ID=Plane;Password=123");
            this.password = password;
            this.userName = userName;
        }

        public Form10()
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
                getSeats.CommandText = "SELECT * FROM users WHERE LOGIN_ID = '" + userName + "' AND PASSWORD = '" + password + "'";
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

        private void button4_Click(object sender, EventArgs e)
        {
            OpenForm11();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void OpenForm11()
        {
            string userName1 = userName;
            string passs = password;

            Form11 form11 = new Form11(passs, userName1);
            form11.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand getSeats = con.CreateCommand();
            getSeats.CommandText = "SELECT * FROM BOOK_SEAT_AUDIT";
            getSeats.CommandType = CommandType.Text;
            OracleDataReader seatDR = getSeats.ExecuteReader();
            DataTable seatDT = new DataTable();
            seatDT.Load(seatDR);
            dataGridView1.DataSource = seatDT;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Done");
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}