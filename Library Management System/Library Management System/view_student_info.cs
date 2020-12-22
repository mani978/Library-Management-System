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
    public partial class view_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");

        public view_student_info()
        {
            InitializeComponent();
            
        }

        private void view_student_info_Load(object sender, EventArgs e)
        {
            disp_student();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_name like('%" + nameSearchtextBox.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;
                con.Close();


                if (i == 0)
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nameSearchtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_name like('%" + nameSearchtextBox.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;
                con.Close();


                if (i == 0)
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           


                panel2.Visible = true;
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                try
                {


                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where id=" + i + "";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        stNametextBox.Text = dr["student_name"].ToString();
                        stRolltextBox.Text = dr["student_roll_no"].ToString();
                        stSemtextBox.Text = dr["student_sem"].ToString();
                        stSectextBox.Text= dr["student_section"].ToString();
                        stContextBox.Text = dr["student_contact_no"].ToString();
                        stMailtextBox.Text = dr["student_email"].ToString();

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name='" + stNametextBox.Text + "',student_roll_no='" + stRolltextBox.Text + "',student_sem='" + stSemtextBox.Text + "',student_section='" + stSectextBox.Text + "',student_contact_no='" + stContextBox.Text + "',student_email='" + stMailtextBox.Text + "' where Id=" + i + "";
                cmd.ExecuteNonQuery();
                con.Close();
                disp_student();
                MessageBox.Show("Updated Successfully");
                panel2.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void disp_student()

        {
            try
            {


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    
}
