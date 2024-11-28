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
using System.Data.SqlClient;
using System.Collections;


namespace SenOtelFr
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        public static string constring = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti = new SqlConnection(constring);
        StringBuilder mailBody = new StringBuilder();

        private void Form13_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            



            MailMessage mm = new MailMessage("gorselproje28@gmail.com", textBox1.Text);
            mm.Subject = textBox2.Text;
            mm.Body = textBox3.Text + Environment.NewLine + mailBody.ToString();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("gorselproje28@gmail.com", "xxwr ktjq rwce umnm");
            smtpClient.Credentials = nc;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mm);
            label4.Text = "Mail bu adrese gönderilmiştir : " + textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            string sql = "Select * From Personel";
            SqlCommand command = new SqlCommand(sql, baglanti);
            SqlDataReader reader = command.ExecuteReader();
            mailBody.AppendLine("Tablodaki Veriler:");
            while (reader.Read())
            {
                mailBody.AppendLine("PersonelNo: " + reader["PersonelNo"]);
                mailBody.AppendLine("Ad: " + reader["Ad"]);
                mailBody.AppendLine("Soyad: " + reader["Soyad"]);
                mailBody.AppendLine("Sifre: " + reader["Sifre"]);
                mailBody.AppendLine("Maas: " + reader["Maasi"]);
                mailBody.AppendLine("İsBaslangicTarihi: " + reader["IsBaslangicTarihi"]);
                mailBody.AppendLine("Telefon: " + reader["TelefonNumarasi"]);
                mailBody.AppendLine("TCKimlik: " + reader["TCKimlik"]);
                mailBody.AppendLine("Bolum: " + reader["Bolum"]);
                mailBody.AppendLine("Adres: " + reader["Adres"]);
                mailBody.AppendLine("Cinsiyet: " + reader["Cinsiyet"]);
                mailBody.AppendLine("Rol: " + reader["Rol"]);

            }
            reader.Close();
            label5.Text = "Personel Bilgileri Maile Eklendi";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
    }
}
