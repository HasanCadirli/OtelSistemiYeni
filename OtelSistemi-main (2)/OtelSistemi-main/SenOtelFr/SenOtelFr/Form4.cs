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
using Form1;

namespace SenOtelFr
{
    public partial class Form4 : Form
    {

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            }
        }

        private void YenidenVeriYukle()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Personel";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme işlemi başarısız oldu: " + ex.Message);
            }
        }






        private void SilmeIslemi(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Personel WHERE PersonelNo = @PersonelNo";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PersonelNo", id);
                        command.ExecuteNonQuery();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız oldu: " + ex.Message);
            }
        }




















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




        










            public Form4()
        {
            

            InitializeComponent();
        }

     



        public static string constring2 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti2 = new SqlConnection(constring2);
        public static string constring4 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti4 = new SqlConnection(constring4);
        public string sorgu = "SELECT * FROM Personel";
        private void Form4_Load(object sender, EventArgs e)
        {
            PersonelVerileriniYukle();
        }


        private void PersonelVerileriniYukle()
        {
            try
            {
                // Bağlantı kapalıysa açın
                if (baglanti4.State == ConnectionState.Closed)
                    baglanti4.Open();

                // Veritabanından veri almak için bir veri adaptörü oluşturun
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti4);

                // Veriyi tutmak için bir DataTable oluşturun
                DataTable dt = new DataTable();

                // DataTable'ı veri adaptörüyle doldurun
                da.Fill(dt);

                // DataTable'ı DataGridView'e bağlayın
                dataGridView1.DataSource = dt;

                // Bağlantıyı kapatın
                baglanti4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel verileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btn_personeleklesil_Click(object sender, EventArgs e)
        {


            try
            {


                Form5 personelEkleSil = new Form5();
                personelEkleSil.Show();
                this.Hide();


            }
            catch (Exception)
            {

                throw;
            }


        }

        private void btn_personelGoruntule_Click(object sender, EventArgs e)
        {

            Form6 personelGoruntule = new Form6();
            personelGoruntule.Show();
            this.Hide();



        }

        private void btn_personel_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void btn_personelolustur_Click(object sender, EventArgs e)
        {




            try
            {


                if (baglanti2.State == ConnectionState.Closed)
                    baglanti2.Open();

                string kayit = "insert into Personel (Ad,Soyad,TCKimlik,Adres,TelefonNumarasi,Sifre,Cinsiyet,Bolum,IsBaslangicTarihi,Maasi,Rol) values  (@Ad,@Soyad,@TCKimlik,@Adres,@TelefonNumarasi,@Sifre,@Cinsiyet,@Bolum,@IsBaslangicTarihi,@Maasi,@Rol) ";
                SqlCommand komut1 = new SqlCommand(kayit, baglanti2);

                komut1.Parameters.AddWithValue("@Ad", txt_pAd.Text.Trim());
                komut1.Parameters.AddWithValue("@Soyad", txt_pSoyad.Text.Trim());
                // komut1.Parameters.AddWithValue("@Maasi", txt_maas.Text.Trim());
                //komut1.Parameters.AddWithValue("@TCKimlik", txt_pTCKimlik.Text.Trim());
                // komut1.Parameters.AddWithValue("@TelefonNumarasi", txt_pTelNumarasi.Text.Trim());
                komut1.Parameters.AddWithValue("@Adres", txt_pAdres.Text.Trim());
                komut1.Parameters.AddWithValue("@Cinsiyet", cmb_cinsiyet.Text);
               // komut1.Parameters.AddWithValue("@IsBaslangicTarihi", dtp_isBaglangicTarihi.Value);
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

                




                if (baglanti2.State == ConnectionState.Closed)
                { baglanti2.Open(); }
                if (txt_pYenisifre.Text == txt_pSifreTekrar.Text)
                {

                    DateTime bugün = DateTime.Today;
                    DateTime giristarihi = dtp_isBaglangicTarihi.Value;
                    if (giristarihi > bugün)
                    {
                        komut1.Parameters.AddWithValue("@IsBaslangicTarihi", dtp_isBaglangicTarihi.Value);
                        komut1.ExecuteNonQuery();
                        baglanti2.Close();


                        MessageBox.Show("Personel Eklendi");
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir tarih girin");
                    }


                   
                    //Form4 admindonus = new Form4();
                    //admindonus.Show();
                    //this.Hide();



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

        

        private void tabPage2_Click(object sender, EventArgs e)
        {




            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["PersonelNo"].Value);

                SilmeIslemi(id);
                MessageBox.Show("Silme Gerçekleştirildi");
                YenidenVeriYukle();
            }





        }

        private void button3_Click(object sender, EventArgs e)
        {
            RezerveEtme rezerve = new RezerveEtme();
            rezerve.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 yedekle=new Form9();
            yedekle.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 git = new Form10();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txt_bolum_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            this.Hide();
            form13.Show();  
        }
    }



















}

