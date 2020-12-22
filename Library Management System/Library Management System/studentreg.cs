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
    public partial class studentreg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VJ9P2IU\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;Pooling=False");

        public studentreg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into student_login values('" + stnametextBox.Text + "','" + stusertextBox.Text + "','" + stpasstextBox.Text + "','" + stmailtextBox.Text + "','" + stcontextBox.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            stnametextBox.Text = "";
            stusertextBox.Text = "";
            stpasstextBox.Text = "";
            stmailtextBox.Text = "";
            stcontextBox.Text = "";
            

            MessageBox.Show("Added Successfully ...!");

        }
    }
}
