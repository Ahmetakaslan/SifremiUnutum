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

namespace SifremiUnutum
{
    public partial class HomePage : Form
    {
          string myUserName;
          string myPassword;
        SqlConnection sql=new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sifrem;Integrated Security=True");
       
        public HomePage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Verify verify = new Verify();
            verify.ShowDialog();
            this.Show();

        }

        private void button1_Click(object sender , EventArgs e)
        {

            sql.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Sifrem" , sql);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                myUserName = dr[1].ToString();
                myPassword = dr[2].ToString();
             
            }
           
            if (tbxUserName.Text.Equals(myUserName) && tbxEnterPassword.Text.Equals(myPassword))
            {
                MessageBox.Show("Giriş başarılı");
            }
            else
            {
                MessageBox.Show("Giriş Hatalı");
            }
    

            sql.Close();
            dr.Close();
            

        }

        private void tbxEnterPassword_TextChanged(object sender , EventArgs e)
        {

        }

        private void HomePage_Load(object sender , EventArgs e)
        {

        }
    }
}
