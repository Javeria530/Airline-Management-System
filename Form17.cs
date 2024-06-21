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
    public partial class Form17 : Form
    {
        OracleConnection con;
        string userName = " ";
        string password = " ";

        public Form17(string password, string userName)
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE=localhost:1521/xe;USER ID=system;Password=12345");
            this.password = password;
            this.userName = userName;
        }

        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("THANK YOU DEAR EMPLOYEE FOR USING THE SYSTEM....!");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand getSeats = con.CreateCommand();
                getSeats.CommandText = "SELECT * FROM crew WHERE USERID = '" + userName + "' AND PASSWORD = '" + password + "'";
                getSeats.CommandType = CommandType.Text;
                OracleDataReader seatDR = getSeats.ExecuteReader();
                DataTable seatDT = new DataTable();
                seatDT.Load(seatDR);
                dataGridView1.DataSource = seatDT;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(userName,password);
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM Crew";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
