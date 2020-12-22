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
    public partial class studentlogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");
        int count = 0;
        public studentlogin()
        {
            InitializeComponent();
        }

        private void studentlogin_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_login where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Invalid Username or Password");
                studentlogin sl = new studentlogin();
                sl.Show();
            }
            else
            {
                this.Hide();
                mdi_student ms = new mdi_student();
                ms.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentreg sr = new studentreg();
            sr.Show();
        }
    }
}
