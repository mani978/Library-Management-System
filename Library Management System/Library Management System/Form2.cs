﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class add_book : Form
    
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");

        public add_book()
        {
           

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox6.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = null;
            textBox5.Text = "";
            textBox6.Text = "";

            MessageBox.Show("Added Successfully ...!");



        }
    }
}
