﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQLConnection
{
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        string connectionString = "host=192.168.0.91; database=c#1; user=test1; password=test1";
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT VERSION()";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    string version = Convert.ToString(cmd.ExecuteScalar());
                    //Console.WriteLine("MySQL version : {0}", version);
                    label1.Text = "Connection Established!\n" + "MySQL Version: " + version;

                }
                catch (Exception ex)
                {
                    label1.Text = "Connection Error!\n" + ex.Message;
                }
                //I am using 'using', so wouldn't need the finally block, for the using function 
                //will close the connection automatically.
                //finally
                //{
                //    con.close();
                //}
            }
        }
    }
}
