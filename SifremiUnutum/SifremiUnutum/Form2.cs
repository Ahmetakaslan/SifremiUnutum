using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SifremiUnutum
{
    public partial class Verify : Form
    {
        string randomCode;

        public Verify()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender , EventArgs e)
        {
            if (!tbxEmail.Text.ToString().Equals("akaslan47yazilim@gmail.com"))
            {
                MessageBox.Show("yanlış e posta");
            }
            try
            {
         
                string myMail, password, message;
                Random random = new Random();
                randomCode = (random.Next(999999)).ToString();
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                myMail =tbxEmail.Text;
                password = "wkevgdjvmmshxgfy";
                message = "Code for restart is " + randomCode +" \n UserName : Akaslan";
                mail.From = new MailAddress(myMail);
                mail.To.Add(tbxEmail.Text.ToString());
                mail.Subject = "Restarting  message";
                mail.Body = message;
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(myMail, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                MessageBox.Show("Göderildi");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Hatalı bir e mail");
                Console.WriteLine(ee.Message);
            }


        }

        private void button1_Click(object sender , EventArgs e)
        {
            if (randomCode == tbxEnterCode.Text.ToString())
            {
               
                this.Hide();
                renovation renovation = new renovation();
                renovation.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Kod hatalı");
            }
        }

        private void Verify_Load(object sender , EventArgs e)
        {


        }
      

    }
}
