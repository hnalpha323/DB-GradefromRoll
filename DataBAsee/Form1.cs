
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataBAsee
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\db1.accdb;
Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                label4.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }


       

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Table1 where Username ='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";

            OleDbDataReader reader = command.ExecuteReader();
            


            int count = 0;
            while (reader.Read())
            {
                count++;

            }

            if (count == 1)
            {
                MessageBox.Show("Username and Password are Correct");
                connection.Close();
                connection.Dispose();
                this.Hide();
                Form2 f2 = new Form2();



                f2.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }
            else
            {
                MessageBox.Show("InCorrect Username and Password!");
            }
            connection.Close();
        }

        
    }
}
