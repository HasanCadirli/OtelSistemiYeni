using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Form1
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read()) 
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriId"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["TcKimlik"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);  
            }
            baglanti.Close();

        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

       


        private void FrmMusteriler_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        int id= 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txt_adi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_soyAdi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            combox_cinsiyet.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txt_telefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txt_tcKimlik.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txt_odaNo.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txt_ucret.Text = listView1.SelectedItems[0].SubItems[7].Text;
            dtp_giris.Text = listView1.SelectedItems[0].SubItems[8].Text;
            dtp_cikis.Text = listView1.SelectedItems[0].SubItems[9].Text;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (txt_odaNo.Text == "101")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda101", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "102")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda102", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "103")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda103", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "104")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda104", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "105")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda105", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "106")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda106", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "107")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda107", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "108")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda108", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "109")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda109", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "110")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda110", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "111")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda111", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }

            if (txt_odaNo.Text == "112")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda112", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();
            }



        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_adi.Clear();
            txt_soyAdi.Clear();
            combox_cinsiyet.Text = "";
            txt_telefon.Clear();
            txt_tcKimlik.Clear();
            txt_odaNo.Clear();
            txt_ucret.Clear();
            dtp_giris.Text = "";
            dtp_cikis.Text = "";
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update MusteriEkle set Adi='" + txt_adi.Text + "',Soyadi='" + txt_soyAdi.Text + "',Cinsiyet='"+combox_cinsiyet.Text+"',Telefon='"+txt_telefon.Text+"',TcKimlik='"+txt_tcKimlik.Text+"',OdaNo='"+txt_odaNo.Text+"',Ucret='"+txt_ucret.Text+"',GirisTarihi='"+ dtp_giris.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='"+ dtp_cikis.Value.ToString("yyyy-MM-dd") +"' where MusteriId="+id+"",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriEkle where Adi like '%"+txt_arananIsim.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriId"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["TcKimlik"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }
    }
}
