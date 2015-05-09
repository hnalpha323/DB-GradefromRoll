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
    public partial class Form2 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form2()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\db1.accdb;
Persist Security Info=False;";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        List<String> i = new List<String>();
        List<String> g = new List<String>();

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from Table1", connection);


            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                g.Add(reader["Roll_No"].ToString());
                i.Add(reader["Grade"].ToString());

            }
            connection.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int totalItems = g.Count;
                int count = 0;
                while (count < totalItems)
                {
                    if (txt_roll.Text == g[count].ToString())
                    {
                        listBox1.Items.Add(i[count].ToString());
                        count = 100;
                    }
                    else
                    {
                        count++;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        } 

        private void txt_roll_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
