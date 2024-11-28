using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SenOtelFr
{
    public partial class Kayit : Form
    {
        internal bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.All(char.IsDigit))
            {
                if (phoneNumber.Length == 10 || phoneNumber.Length == 11)
                {
                    if (phoneNumber.Length == 11 && phoneNumber[0] == '0')
                    {
                        return true;
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool IsValidTCKimlik(string tckimlik)
        {
            if (tckimlik.All(char.IsDigit))
            {
                if (tckimlik.Length == 11)
                {
                    return true;
                }
            }

            return false;
        }
        public Kayit()
        {
            InitializeComponent();
        }
        public static string constring1 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti1 = new SqlConnection(constring1);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            try

            {
                if (baglanti1.State == ConnectionState.Closed)
                    baglanti1.Open();

                string kayit = "insert into Musteri (KullaniciAdi,Ad,Soyad,TCKimlik,Adres,TelefonNumarasi,Sifre) values  (@KullaniciAdi,@Ad,@Soyad,@TCKimlik,@Adres,@TelefonNumarasi,@Sifre) ";
                SqlCommand komut = new SqlCommand(kayit, baglanti1);

                komut.Parameters.AddWithValue("@KullaniciAdi", txt_yenikullanici.Text.Trim());
                komut.Parameters.AddWithValue("@Ad", txt_ad.Text.Trim());
                komut.Parameters.AddWithValue("@Soyad", txt_soyad.Text.Trim());
                //komut.Parameters.AddWithValue("@TCKimlik", txt_tckimlik.Text.Trim());
               // komut.Parameters.AddWithValue("@TelefonNumarasi", txt_telnumarasi.Text.Trim());
                komut.Parameters.AddWithValue("@Adres", txt_adres.Text.Trim());
                komut.Parameters.AddWithValue("@Sifre", txt_yenisifre.Text.Trim());
                string[] array1 = new string[7];
                array1[0] = txt_yenikullanici.Text.Trim();
                array1[1]= txt_ad.Text.Trim();
                array1[2]= txt_soyad.Text.Trim();
                array1[3]= txt_tckimlik.Text.Trim();
                array1[4]= txt_telnumarasi.Text.Trim();
                array1[5]=txt_adres.Text.Trim();
                array1[6]= txt_yenisifre.Text.Trim();

                foreach (var item in array1)
                {

                    if (string.IsNullOrEmpty(item))
                    {
                        MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
                        return;
                    }


                }





                if (IsValidPhoneNumber(txt_telnumarasi.Text.Trim()))
                {

                    komut.Parameters.AddWithValue("@TelefonNumarasi", txt_telnumarasi.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Geçerli bir telefon numarası girin.");
                    return;
                }
                if (IsValidTCKimlik(txt_tckimlik.Text.Trim()))
                {
                    komut.Parameters.AddWithValue("@TCKimlik", txt_tckimlik.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Geçerli bir TC Kimlik numarası girin.");
                    return;
                }


                if (txt_yenisifre.Text == txt_sifretekrar.Text)
                {
                    komut.ExecuteNonQuery();

                    baglanti1.Close();

                    MessageBox.Show("Kayıt Eklendi");
                    Form1 donus = new Form1();
                    donus.Show();
                    this.Hide();



                }







            }
            catch (Exception hata)
            {

                MessageBox.Show("Kayıt Başarasız" + hata.Message);
            }
        }

        private void Kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
