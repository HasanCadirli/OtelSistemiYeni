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


namespace SenOtelFr
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mailMessage = new MailMessage("gorselproje28@gmail.com", textBox1.Text);
            mailMessage.Subject = textBox2.Text;
            mailMessage.Body = textBox3.Text;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host="smtp.gmail.com";
            smtpClient.Port = 587;
            System.Net.NetworkCredential networkCredential = new NetworkCredential("gorselproje28@gmail.com", "aebh rsra xxoe cycu");
            smtpClient.Credentials = networkCredential;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            label4.Text = "E-postanız şu adrese gönderilmiştir : " + textBox1.Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
