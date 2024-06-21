using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace airplane_management_system
{
    public partial class Form2 : Form
    {
        OracleConnection con;
        public string RegisteredUsername { get; private set; }
        public string RegisteredPassword { get; private set; }
        public Form2()
        {
            InitializeComponent();
            con = new OracleConnection(@"DATA SOURCE = localhost:1521/xe;USER ID=Plane;Password=123");
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Please enter something in all the text boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string message = $"NAME: {textBox1.Text}\nUSER_NAME: {textBox6.Text}\nPASSWORD: {textBox7.Text}";
                MessageBox.Show(message, "LOGIN CREDITS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (OracleConnection con = new OracleConnection(@"DATA SOURCE = localhost:1521/xe;USER ID=system;Password=12345"))
                {
                    con.Open();
                    string sql = "INSERT INTO users (USERID,USERTYPE,NAME,EMAIL,PHONE_NUMBER,CNIC,ADDRESS,LOGIN_ID,PASSWORD,FEEDBACK)" +
                                 "VALUES (56, 'PASSENGER', :param1, :param2, :param3, :param4, :param5, :param6, :param7, 'NO')";

                    using (OracleCommand insertEmp = new OracleCommand(sql, con))
                    {
                        insertEmp.Parameters.Add(":param1", textBox1.Text);
                        insertEmp.Parameters.Add(":param2", textBox2.Text);
                        insertEmp.Parameters.Add(":param3", textBox3.Text);
                        insertEmp.Parameters.Add(":param4", textBox4.Text);
                        insertEmp.Parameters.Add(":param5", textBox5.Text);
                        insertEmp.Parameters.Add(":param6", textBox6.Text);
                        insertEmp.Parameters.Add(":param7", textBox7.Text);
                        int rows = insertEmp.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("DATA INSERTED SUCCESSFULLY..!");
                            RegisteredUsername = textBox6.Text;
                            RegisteredPassword = textBox7.Text;
                            this.Close();
                        }
                    }
                }
            }        
    }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

    }
}