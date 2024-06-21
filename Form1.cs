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
using Oracle.ManagedDataAccess.Client;

namespace airplane_management_system
{

    public partial class Form1 : Form
    {
        string username = " ";
        string password = " ";
        string userType = " ";
        private string registeredUsername;
        private string registeredPassword;
        OracleConnection con;
        public static Form1 Instance;
        public Form1()
        {
            Form16 form16 = new Form16();
            form16.Hide();
            Instance = this;
            InitializeComponent();
        }

        public void SetRegisteredCredentials(string username, string password)
        {
            registeredUsername = username;
            registeredPassword = password;
            textBox1.Text = registeredUsername;
            textBox2.Text = registeredPassword;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string oradb = @"DATA SOURCE = localhost:1521/xe;USER ID=sysyem;Password=12345";
            con = new OracleConnection(oradb);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
           Form2 form2 = new Form2();
            form2.ShowDialog();
            if (!string.IsNullOrEmpty(form2.RegisteredUsername) && !string.IsNullOrEmpty(form2.RegisteredPassword))
            {
                SetRegisteredCredentials(form2.RegisteredUsername, form2.RegisteredPassword);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter something in all the text boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                username = textBox1.Text;
                password = textBox2.Text;
                con.Open();
                OracleCommand getEmps = con.CreateCommand();
                getEmps.CommandText = "SELECT * FROM users WHERE LOGIN_ID = :username AND PASSWORD = :password";
                getEmps.Parameters.Add(":username", username);
                getEmps.Parameters.Add(":password", password);
                getEmps.CommandType = CommandType.Text;
                OracleDataReader empDR = getEmps.ExecuteReader();
                if (empDR.HasRows)
                {
                    while (empDR.Read())
                    {
                        userType = empDR["UserType"].ToString();
                        check = false;
                    }
                    if (userType == "ADMIN")
                    {
                        check = false;
                        Form3 form3 = new Form3();
                        form3.Show();
                    }
                    else if (userType == "PASSENGER")
                    {
                        check = false;
                        OpenForm10();
                    }
                }
                empDR.Close();
                con.Close();
                username = textBox1.Text;
                password = textBox2.Text;
                userType = " ";
                con.Open();
                OracleCommand getEmpss = con.CreateCommand();
                getEmpss.CommandText = "SELECT * FROM crew WHERE USERID = :username AND PASSWORD = :password";
                getEmpss.Parameters.Add(":username", username);
                getEmpss.Parameters.Add(":password", password);
                getEmpss.CommandType = CommandType.Text;
                OracleDataReader empDRr = getEmpss.ExecuteReader();
                if (empDRr.HasRows)
                {
                    while (empDRr.Read())
                    {
                        userType = "EMPLOYEE";
                        check = false;
                    }
                    OpenForm17();
                }
                else
                {
                    if (check)
                    {
                        MessageBox.Show(" Login failed! \n Wrong credentials entered\n Please check your username and password...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                empDRr.Close();
                con.Close();          
            }
        }

        private void OpenForm10()
        {
            string userName = username;
            string pass = password;

            Form10 form10 = new Form10(pass, userName);
            form10.Show();
        }

        private void OpenForm17()
        {
            string userName = username;
            string pass = password;

            Form17 form17 = new Form17(pass, userName);
            form17.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
