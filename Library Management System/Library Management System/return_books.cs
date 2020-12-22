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
    public partial class return_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");

        public return_books()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            fill_grid(textBox1.Text);
        }
        
        public void fill_grid(string roll )
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text; ;
            cmd.CommandText = "select * from issue_info where student_roll_no='" + roll.ToString() + "' and return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void return_books_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
           
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_info where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    label3.Text = dr["book_name"].ToString();
                    label5.Text = Convert.ToString(dr["issues_date"].ToString());


                        

                }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update issue_info set return_date='" + dateTimePicker1.Value.ToString() + "'  where id='"+i+"'";
            cmd.ExecuteNonQuery();
            

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update books_info set availability=availability+1 where books_name='"+label3.Text+"'";
            cmd1.ExecuteNonQuery();
            

            MessageBox.Show("Books Returned successfully");

            panel3.Visible = true;

            fill_grid(textBox1.Text);
        }
    }
}
