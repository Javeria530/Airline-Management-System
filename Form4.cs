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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace airplane_management_system
{
    public partial class Form4 : Form
    {
        OracleConnection con;
        public Form4()
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE = localhost:1521/xe;USER ID=system;Password=12345");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox15.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text) ||
                string.IsNullOrEmpty(textBox7.Text) ||
                string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox9.Text) ||
                string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Please Fill All the boxes...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "INSERT INTO Crew (ID, Name, Age, Gender, Phone, Email, Task_Assign, UserID, Password, CNIC) " +
                    "VALUES(" + textBox15.Text.ToString() + ", '" + textBox1.Text.ToString() + "', " + textBox2.Text.ToString() + ", '" + textBox3.Text.ToString() + "', '" + textBox5.Text.ToString() + "', '" + textBox9.Text.ToString() + "', '" + textBox8.Text.ToString() + "', '" + textBox6.Text.ToString() + "', '" + textBox7.Text.ToString() + "', '" + textBox4.Text.ToString() + "')";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
           
                    ClearTextBoxes();
                }
                con.Close();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Please Enter ID...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand updateEmp = con.CreateCommand();
                updateEmp.CommandText = "UPDATE Crew SET Name = '" + textBox1.Text.ToString() + "', Age = " + textBox2.Text.ToString() + ", Gender = '" + textBox3.Text.ToString() + "', Phone = '" + textBox5.Text.ToString() + "', Email = '" + textBox9.Text.ToString() + "', Task_Assign = '" + textBox8.Text.ToString() + "', UserID = '" + textBox6.Text.ToString() + "', Password = '" + textBox7.Text.ToString() + "', CNIC = '" + textBox4.Text.ToString() + "' WHERE ID = " + textBox15.Text.ToString();
                updateEmp.CommandType = CommandType.Text;
                int rows = updateEmp.ExecuteNonQuery();
                if (rows > 0)
                {
              
                }
                else
                {
                    MessageBox.Show("Record not found!");
                }
                ClearTextBoxes();
                con.Close();
                ClearTextBoxes();
                con.Close();
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show(" ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "DELETE FROM Crew WHERE ID =" + textBox15.Text.ToString();
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
  

                }
                else
                {
                    MessageBox.Show("no!");
                }
                ClearTextBoxes();
                con.Close();
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
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show(" .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButton1.Checked = false;
            }
            else
            {
                con.Open();
                OracleCommand selectEmp = con.CreateCommand();
                selectEmp.CommandText = "SELECT * FROM Crew WHERE ID = " + textBox15.Text.ToString();
                selectEmp.CommandType = CommandType.Text;
                OracleDataReader empReader = selectEmp.ExecuteReader();

                if (empReader.Read())
                {
                    textBox1.Text = empReader["Name"].ToString();
                    textBox2.Text = empReader["Age"].ToString();
                    textBox3.Text = empReader["Gender"].ToString();
                    textBox5.Text = empReader["Phone"].ToString();
                    textBox9.Text = empReader["Email"].ToString();
                    textBox8.Text = empReader["Task_Assign"].ToString();
                    textBox6.Text = empReader["UserID"].ToString();
                    textBox7.Text = empReader["Password"].ToString();
                    textBox4.Text = empReader["CNIC"].ToString();
                }
                else
                {
                    MessageBox.Show("no");
                }

                empReader.Close();
                con.Close();
                radioButton1.Checked = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

