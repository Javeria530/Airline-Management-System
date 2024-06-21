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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace airplane_management_system
{
    public partial class Form6 : Form
    {
        OracleConnection con;
        public Form6()
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE = localhost:1521/xe;USER ID=system;Password=12345s");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox7.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox6.Text) ||
                dateTimePicker1.Value == DateTimePicker.MinimumDateTime ||
                dateTimePicker2.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Please fill in all the required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();

                OracleCommand insertFlight = con.CreateCommand();
                insertFlight.CommandText = "INSERT INTO Flight (FLIGHTID, DEPARTURE, DESTINATION, DEPARTURE_TIME, ARRIVAL_TIME, AIRCRAFTID, TOTALSEATS, STATUS, FARE_PRICE) " +
                    "VALUES (:flightNumber, :departure, :destination, :departureTime, :arrivalTime, :aircraftID, :totalSeats, :status, :fare_price)";

                insertFlight.Parameters.Add(":flightNumber", OracleDbType.Varchar2).Value = textBox8.Text;
                insertFlight.Parameters.Add(":departure", OracleDbType.Varchar2).Value = textBox1.Text;
                insertFlight.Parameters.Add(":destination", OracleDbType.Varchar2).Value = textBox2.Text;
                insertFlight.Parameters.Add(":departureTime", OracleDbType.Date).Value = dateTimePicker1.Value;
                insertFlight.Parameters.Add(":arrivalTime", OracleDbType.Date).Value = dateTimePicker2.Value;
                insertFlight.Parameters.Add(":aircraftID", OracleDbType.Varchar2).Value = textBox5.Text;
                insertFlight.Parameters.Add(":totalSeats", OracleDbType.Int32).Value = int.Parse(textBox7.Text);
                insertFlight.Parameters.Add(":status", OracleDbType.Varchar2).Value = textBox4.Text;
                insertFlight.Parameters.Add(":fare_price", OracleDbType.Varchar2).Value = textBox6.Text;
                int rows = insertFlight.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("DATA INSERTED SUCCESSFULLY..!");
                    ClearTextBoxes();
                }

                con.Close();
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
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Please Enter ID...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "DELETE FROM FLIGHT WHERE FLIGHTID =" + textBox8.Text.ToString();
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data DELETED Successfully!");

                }
                else
                {
                    MessageBox.Show("Record not found !");
                }
                ClearTextBoxes();
                con.Close();
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
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Please Enter ID...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand updateFlight = con.CreateCommand();
                updateFlight.CommandType = CommandType.Text;
                updateFlight.CommandText = "UPDATE Flight SET DEPARTURE = :departure, DESTINATION = :destination, DEPARTURE_TIME = :departureTime, ARRIVAL_TIME = :arrivalTime, AIRCRAFTID = :aircraftID, TOTALSEATS = :totalSeats, STATUS = :status, FARE_PRICE = :fare_price WHERE FLIGHTID = :flightNumber";

                updateFlight.Parameters.Add(":departure", OracleDbType.Varchar2).Value = textBox1.Text;
                updateFlight.Parameters.Add(":destination", OracleDbType.Varchar2).Value = textBox2.Text;
                updateFlight.Parameters.Add(":departureTime", OracleDbType.Date).Value = dateTimePicker1.Value;
                updateFlight.Parameters.Add(":arrivalTime", OracleDbType.Date).Value = dateTimePicker2.Value;
                updateFlight.Parameters.Add(":aircraftID", OracleDbType.Varchar2).Value = textBox5.Text;
                updateFlight.Parameters.Add(":totalSeats", OracleDbType.Int32).Value = int.Parse(textBox7.Text);
                updateFlight.Parameters.Add(":status", OracleDbType.Varchar2).Value = textBox4.Text;
                updateFlight.Parameters.Add(":flightNumber", OracleDbType.Varchar2).Value = int.Parse(textBox8.Text);
                updateFlight.Parameters.Add(":fare_price", OracleDbType.Varchar2).Value = textBox6.Text;
                int rows = updateFlight.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Data Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Data Updated Successfully!");
                }
                ClearTextBoxes();
                con.Close();
                ClearTextBoxes();
                con.Close();
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
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Please Enter ID...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButton1.Checked = false;
            }
            else
            {
                con.Open();
                OracleCommand selectEmp = con.CreateCommand();
                selectEmp.CommandText = "SELECT * FROM FLIGHT WHERE FLIGHTID = " + textBox8.Text.ToString();
                selectEmp.CommandType = CommandType.Text;
                OracleDataReader empReader = selectEmp.ExecuteReader();

                if (empReader.Read())
                {
                    textBox1.Text = empReader["DEPARTURE"].ToString();
                    textBox2.Text = empReader["DESTINATION"].ToString();
                    dateTimePicker1.Text = empReader["DEPARTURE_TIME"].ToString();
                    dateTimePicker2.Text = empReader["ARRIVAL_TIME"].ToString();
                    textBox5.Text = empReader["AIRCRAFTID"].ToString();
                    textBox7.Text = empReader["TOTALSEATS"].ToString();
                    textBox4.Text = empReader["STATUS"].ToString();
                    textBox6.Text = empReader["FARE_PRICE"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found!");
                }

                empReader.Close();
                con.Close();
                radioButton1.Checked = false;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
