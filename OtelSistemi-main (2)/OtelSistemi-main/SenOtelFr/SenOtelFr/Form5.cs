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
    public partial class Form5 : Form
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





        public Form5()
        {
            InitializeComponent();
        }
        public static string constring3 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti3 = new SqlConnection(constring3);
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_ad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btn_personelolustur_Click(object sender, EventArgs e)
        {


            try
            {


                if (baglanti3.State == ConnectionState.Closed)
                    baglanti3.Open();

                string kayit = "insert into Personel (Ad,Soyad,TCKimlik,Adres,TelefonNumarasi,Sifre,Cinsiyet,Bolum,IsBaslangicTarihi,Maasi,Rol) values  (@Ad,@Soyad,@TCKimlik,@Adres,@TelefonNumarasi,@Sifre,@Cinsiyet,@Bolum,@IsBaslangicTarihi,@Maasi,@Rol) ";
                SqlCommand komut1 = new SqlCommand(kayit, baglanti3);
                
                komut1.Parameters.AddWithValue("@Ad", txt_pAd.Text.Trim());
                komut1.Parameters.AddWithValue("@Soyad", txt_pSoyad.Text.Trim());
               // komut1.Parameters.AddWithValue("@Maasi", txt_maas.Text.Trim());
                //komut1.Parameters.AddWithValue("@TCKimlik", txt_pTCKimlik.Text.Trim());
               // komut1.Parameters.AddWithValue("@TelefonNumarasi", txt_pTelNumarasi.Text.Trim());
                komut1.Parameters.AddWithValue("@Adres", txt_pAdres.Text.Trim());
                komut1.Parameters.AddWithValue("@Cinsiyet", cmb_cinsiyet.Text);
                komut1.Parameters.AddWithValue("@IsBaslangicTarihi", dtp_isBaglangicTarihi.Value);
                komut1.Parameters.AddWithValue("@Sifre", txt_pYenisifre.Text.Trim());
                komut1.Parameters.AddWithValue("@Bolum", txt_bolum.Text.Trim());
                komut1.Parameters.AddWithValue("@Rol", cmb_rol.Text.Trim());




                string[] array2 = new string[10];
                array2[0] = txt_pAd.Text.Trim();
                array2[1] = txt_pSoyad.Text.Trim();
                array2[2] = txt_maas.Text.Trim();
                array2[3] = txt_pTCKimlik.Text.Trim();
                array2[4] = txt_pTelNumarasi.Text.Trim();
                array2[5] = txt_pAdres.Text.Trim();
                array2[6] = cmb_cinsiyet.Text.Trim();
                array2[7] = dtp_isBaglangicTarihi.Text.Trim();
                array2[8] = txt_pYenisifre.Text.Trim();
                array2[9] = cmb_rol.Text.Trim();

                foreach (var item in array2)
                {

                    if (string.IsNullOrEmpty(item))
                    {
                        MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
                        return;
                    }
                }
                
                if (decimal.TryParse(txt_maas.Text.Trim(), out decimal maasValue))
                {
                    
                    komut1.Parameters.AddWithValue("@Maasi", maasValue);
                }
                else
                {
                  
                    MessageBox.Show("Geçerli bir maaş değeri girin.");
                    return;
                }
                if (IsValidPhoneNumber(txt_pTelNumarasi.Text.Trim()))
                {
                   
                    komut1.Parameters.AddWithValue("@TelefonNumarasi", txt_pTelNumarasi.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Geçerli bir telefon numarası girin.");
                    return;
                }
                if (IsValidTCKimlik(txt_pTCKimlik.Text.Trim()))
                {
                    komut1.Parameters.AddWithValue("@TCKimlik", txt_pTCKimlik.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Geçerli bir TC Kimlik numarası girin.");
                    return;
                }



                if (baglanti3.State == ConnectionState.Closed)
                    {   baglanti3.Open(); }
                    if (txt_pYenisifre.Text == txt_pSifreTekrar.Text)
                    {

                      

                        komut1.ExecuteNonQuery();
                        baglanti3.Close();


                        MessageBox.Show("Personel Eklendi");
                        Form4 admindonus = new Form4();
                        admindonus.Show();
                        this.Hide();

                        

                    }

                    else
                    {
                        MessageBox.Show("Şifreler Aynı Değil");
                    }







                
            }
            catch (Exception)
            {

                throw;
            }





        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
