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
using System.IO;

namespace Library_Management_System
{
    public partial class add_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");

        public add_student_info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into student_info values('" + studentNametextBox.Text + "','" + studentRolltextBox.Text + "','" + studentSemtextBox.Text + "','" + studentSectextBox.Text + "','" + studentContextBox.Text + "','" + studentEmailtextBox.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                studentNametextBox.Text = "";
                studentRolltextBox.Text = "";
                studentSemtextBox.Text = "";
                studentSectextBox.Text = "";
                studentContextBox.Text = "";
                studentEmailtextBox.Text = "";




                MessageBox.Show("Insertion Successful");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
