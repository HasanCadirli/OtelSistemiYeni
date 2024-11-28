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

namespace SenOtelFr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string admin = "Admin";
        string adminSifre = "6212";

        public static string constring = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti=new SqlConnection(constring);
        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                string sql = "Select * From Musteri Where KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre";
                SqlParameter prmtr1 = new SqlParameter("KullaniciAdi",txt_kullanici.Text.Trim());
                SqlParameter prmtr2 = new SqlParameter("Sifre", txt_sifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql,baglanti);
                komut.Parameters.Add(prmtr1);
                komut.Parameters.Add(prmtr2);
                DataTable dt = new DataTable();
                SqlDataAdapter da=new SqlDataAdapter(komut);
                da.Fill(dt);




				if (txt_kullanici.Text.Trim()==admin && txt_sifre.Text.Trim()==adminSifre)
				{
					Form4 adminsayfasi = new Form4();
					adminsayfasi.Show();
					this.Hide();
				}
				else if (dt.Rows.Count>0)
                {
                    MessageBox.Show("Giriş Başarılı!");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Giriş Başarısız!");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            try { 

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
           
            
                Personel personel = new Personel();
                personel.Show();
                this.Hide();
            }
            catch (Exception)
            {

                throw;

            }


        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            try
            {
                Kayit kayit = new Kayit();
                kayit.Show();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
