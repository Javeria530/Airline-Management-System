using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace airplane_management_system
{
    public partial class Form12 : Form
    {
        OracleConnection con;
        int o;

        public Form12()
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE=localhost:1521/xe;USER ID=system;Password=12345");
            o = GenerateRandomNumber(1000, 9999);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    con.Open();
                    OracleCommand getFlights = con.CreateCommand();
                    getFlights.CommandText = "SELECT * FROM flight";
                    getFlights.CommandType = CommandType.Text;

                    OracleDataAdapter adapter = new OracleDataAdapter(getFlights);
                    DataTable flightTable = new DataTable();
                    adapter.Fill(flightTable);

                    dataGridView1.DataSource = flightTable;

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving flight details: " + ex.Message);
                }
            }
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please Fill All the boxes...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand insertSeat = con.CreateCommand();
                insertSeat.CommandText = "INSERT INTO BOOK_SEAT (FLIGHTID, NOOFSEATS, PAYMENT_METHOD) VALUES(" + textBox1.Text.ToString() + ", " + textBox2.Text.ToString() + ", '" + textBox3.Text.ToString() + "')";
                insertSeat.CommandType = CommandType.Text;
                int rows = insertSeat.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("TICKET BOOKED SUCCESSFULLY..!");

                    // Retrieve price from the flight table
                    OracleCommand getPrice = con.CreateCommand();
                    getPrice.CommandText = "SELECT FARE_PRICE FROM flight WHERE FLIGHTID = " + textBox1.Text.ToString();
                    getPrice.CommandType = CommandType.Text;
                    decimal price = Convert.ToDecimal(getPrice.ExecuteScalar());
                    OracleCommand insertRevenue = con.CreateCommand();
                    insertRevenue.CommandText = "INSERT INTO Revenu (FLIGHT_ID, BOOKING_DATE, AMOUNT, PAYMENT_METHOD) VALUES(" + textBox1.Text.ToString() + ", SYSDATE, " + (price * Convert.ToInt32(textBox2.Text)).ToString() + ", '" + textBox3.Text.ToString() + "')";
                    insertRevenue.CommandType = CommandType.Text;
                    int revenueRows = insertRevenue.ExecuteNonQuery();
                    if (revenueRows > 0)
                    {
                        MessageBox.Show("REVENUE DATA INSERTED SUCCESSFULLY..!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert into REVENUE table.");
                    }
                   
                   
                    ClearTextBoxes();
                }
                con.Close();
                con.Open();
                OracleCommand getSeats = con.CreateCommand();
                getSeats.CommandText = "SELECT * FROM BOOK_SEAT";
                getSeats.CommandType = CommandType.Text;
                OracleDataReader seatDR = getSeats.ExecuteReader();
                DataTable seatDT = new DataTable();
                seatDT.Load(seatDR);
                dataGridView1.DataSource = seatDT;
                con.Close();
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}