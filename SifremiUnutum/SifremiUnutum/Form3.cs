using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SifremiUnutum
{
    public partial class renovation : Form
    {
        SqlConnection conn;

        public renovation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender , EventArgs e)
        {
            if (tbxPassord.Text == tbxAgain.Text)
            {
                conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sifrem;Integrated Security=True"); 
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(
                "Update Sifrem set Password=@p1 where Id=@Id" , conn);
                sqlCommand.Parameters.AddWithValue("@p1" , tbxPassord.Text);
                sqlCommand.Parameters.AddWithValue("@Id" ,1);
                sqlCommand.ExecuteNonQuery();
              
                MessageBox.Show("Şifre değiştirildi");
                conn.Close();
            }
            else
            {
                MessageBox.Show("şifreler uyuşmuyor");
            }
        }

        private void renovation_Load(object sender , EventArgs e)
        {

        }
    }
}
