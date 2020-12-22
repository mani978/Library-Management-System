using System;
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
    public partial class issue_book : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");
        

        public issue_book()
        {
            InitializeComponent();
        }

        private void issue_book_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            
            
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_roll_no ='"+rolltextBox.Text+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());


                if (i == 0)
                {
                    MessageBox.Show("No Data Found");

                }
                else
                {
                
                foreach (DataRow dr in dt.Rows)
                    {
                        nametextBox.Text = dr["student_name"].ToString();
                        semtextBox.Text = dr["student_sem"].ToString();
                        sectextBox.Text = dr["student_section"].ToString();
                        contextBox.Text = dr["student_contact_no"].ToString();
                        mailtextBox.Text = dr["student_email"].ToString();
                    }

                    
                }

                
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int books_qty=0;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from books_info where books_name='" + booktextBox.Text + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2); 
            foreach(DataRow dr2 in dt2.Rows )
            {
                books_qty = Convert.ToInt32(dr2["availability"].ToString());
            }

            if ( books_qty > 0)
            {


                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into issue_info values('" + rolltextBox.Text + "','" + nametextBox.Text + "','" + semtextBox.Text + "','" + sectextBox.Text + "','" + contextBox.Text + "','" + mailtextBox.Text + "','" + dateTimePicker1.Value + "','" + booktextBox.Text + "','')";
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update books_info set availability=availability-1 where books_name='" + booktextBox.Text + "'";
                cmd1.ExecuteNonQuery();



                MessageBox.Show("Issued Successfully ...!");
            }
            else
            {
                MessageBox.Show("Books Unavailable");
            }
            }


        private void booktextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int Count = 0;

            if(e.KeyCode !=Keys.Enter)
            {
                listBox1.Items.Clear();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_name like('%"+ booktextBox.Text +"%') ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Count = Convert.ToInt32(dt.Rows.Count.ToString());

                if(Count > 0)
                {
                    listBox1.Visible = true;
                    foreach(DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["books_name"].ToString());

                    }
                }

            }
        }

        private void booktextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                booktextBox.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            booktextBox.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }
    }
}
