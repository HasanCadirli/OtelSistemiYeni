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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using SenOtelFr;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Form1
{
	public partial class RezerveEtme : Form
	{
		public RezerveEtme()
		{
			InitializeComponent();
		}

		SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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

		private void RezerveEt()
		{
			if (baglanti.State == ConnectionState.Closed)
				baglanti.Open();


			for (int i = 101; i < 110; i++)
			{
				string a = Convert.ToString(i);

				if (txt_odaNo.Text == a)
				{
					Button[] odalar = { btn_101, btn_102, btn_103, btn_104, btn_105, btn_106, btn_107, btn_108, btn_109, };


					SqlCommand komutDurumGuncelle = new SqlCommand("UPDATE Oda SET Durum = 0 WHERE OdaNo = @OdaNo", baglanti);
					komutDurumGuncelle.Parameters.AddWithValue("@OdaNo", i);

					komutDurumGuncelle.ExecuteNonQuery();

					odalar[i - 101].BackColor = Color.Red;
					odalar[i - 101].Text = txt_adi.Text;
					odalar[i - 101].Enabled = false;

					baglanti.Close();

					MessageBox.Show("İşlem Başarılı");
				}
			}
		}

		private void verileriGoster()
		{
			listView1.Items.Clear();
			if (baglanti.State==ConnectionState.Closed)
			{
				baglanti.Open();
			}

			SqlCommand komut = new SqlCommand("select * from Rezarvasyonn", baglanti);
			SqlDataReader oku = komut.ExecuteReader();

			while (oku.Read())
			{
				ListViewItem ekle = new ListViewItem();
				ekle.Text = oku["RezNo"].ToString();
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

		int id = 0;
		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
			txt_RezNo.Text = listView1.SelectedItems[0].SubItems[0].Text;
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

			if (baglanti.State == ConnectionState.Closed)
				baglanti.Open();
			for (int i = 101; i < 110; i++)
			{
				string a = Convert.ToString(i);

				if (txt_odaNo.Text == a)
				{
					Button[] odalar = { btn_101, btn_102, btn_103, btn_104, btn_105, btn_106, btn_107, btn_108, btn_109, };


					SqlCommand komutDurumGuncelle = new SqlCommand("UPDATE Oda SET Durum = 1 WHERE OdaNo = @OdaNo", baglanti);
					komutDurumGuncelle.Parameters.AddWithValue("@OdaNo", i);

					komutDurumGuncelle.ExecuteNonQuery();

					odalar[i - 101].BackColor = Color.LimeGreen;
					odalar[i - 101].Text = a;
					odalar[i - 101].Enabled = true;

					baglanti.Close();

					MessageBox.Show("İşlem Başarılı");
				}
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
			if (baglanti.State == ConnectionState.Closed)
				baglanti.Open();

			string[] array1 = new string[10];
			array1[0] = txt_adi.Text.Trim();
			array1[1] = txt_soyAdi.Text.Trim();
			array1[2] = combox_cinsiyet.Text.Trim();
			array1[3] = txt_telefon.Text.Trim();
			array1[4] = txt_tcKimlik.Text.Trim();
			array1[5] = txt_odaNo.Text.Trim();
			array1[6] = txt_ucret.Text.Trim();


			array1[7] = dtp_giris.Text.Trim();
			array1[8] = dtp_cikis.Text.Trim();
			array1[9] = txt_RezNo.Text.Trim();


			foreach (var item in array1)
			{

				if (string.IsNullOrEmpty(item))
				{
					MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
					return;
				}


			}

			SqlCommand komut = new SqlCommand("UPDATE Rezarvasyonn SET Adi=@Adi, Soyadi=@Soyadi, Cinsiyet=@Cinsiyet, Telefon=@Telefon, TcKimlik=@TcKimlik, OdaNo=@OdaNo, Ucret=@Ucret, GirisTarihi=@GirisTarihi, CikisTarihi=@CikisTarihi WHERE RezNo=@RezNo", baglanti);

			komut.Parameters.AddWithValue("@Adi", txt_adi.Text);
			komut.Parameters.AddWithValue("@Soyadi", txt_soyAdi.Text);
			komut.Parameters.AddWithValue("@Cinsiyet", combox_cinsiyet.Text);
			komut.Parameters.AddWithValue("@Telefon", txt_telefon.Text);
			komut.Parameters.AddWithValue("@TcKimlik", txt_tcKimlik.Text);
			komut.Parameters.AddWithValue("@OdaNo", txt_odaNo.Text);
			komut.Parameters.Add("@Ucret", SqlDbType.SmallMoney).Value = decimal.Parse(txt_ucret.Text);

			komut.Parameters.AddWithValue("@GirisTarihi", dtp_giris.Value.ToString("yyyy-MM-dd"));
			komut.Parameters.AddWithValue("@CikisTarihi", dtp_cikis.Value.ToString("yyyy-MM-dd"));
			komut.Parameters.AddWithValue("@RezNo", id);


			//   SqlCommand komut = new SqlCommand("update Rezarvasyonn set Adi='" + txt_adi.Text + "',Soyadi='" + txt_soyAdi.Text + "',Cinsiyet='" + combox_cinsiyet.Text + "',Telefon='" + txt_telefon.Text + "',TcKimlik='" + txt_tcKimlik.Text + "',OdaNo='" + txt_odaNo.Text + "',Ucret='" + txt_ucret.Text + "',GirisTarihi='" + dtp_giris.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + dtp_cikis.Value.ToString("yyyy-MM-dd") + "' where RezNo=" + id + "", baglanti);
			komut.ExecuteNonQuery();
			baglanti.Close();
			verileriGoster();

		}

		private void btn_ara_Click(object sender, EventArgs e)
		{

			listView1.Items.Clear();
			baglanti.Open();
			SqlCommand komut = new SqlCommand("select * from Rezarvasyonn where Adi like '%" + txt_arananIsim.Text+"%'", baglanti);
			SqlDataReader oku = komut.ExecuteReader();

			while (oku.Read())
			{
				ListViewItem ekle = new ListViewItem();
				ekle.Text = oku["RezNo"].ToString();
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

		private void btn_101_Click(object sender, EventArgs e)
		{
			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '101'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State==ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "101";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly=true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}

		}

		private void btn_102_Click(object sender, EventArgs e)
		{
			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '102'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "102";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}
		}

		private void btn_103_Click(object sender, EventArgs e)
		{
			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '103'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "103";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}
		}

		private void btn_104_Click(object sender, EventArgs e)
		{
			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '104'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "104";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}
		}

		private void btn_105_Click(object sender, EventArgs e)
		{

			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '105'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "105";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}
		}

		private void btn_106_Click(object sender, EventArgs e)
		{

			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '106'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "106";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}
		}

		private void btn_107_Click(object sender, EventArgs e)
		{

			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '107'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "107";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}

		}

		private void btn_108_Click(object sender, EventArgs e)
		{


			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '108'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "108";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}

		}

		private void btn_109_Click(object sender, EventArgs e)
		{

			string query = "SELECT Fiyat FROM Oda WHERE OdaNo = '109'";

			using (SqlCommand command = new SqlCommand(query, baglanti))
			{
				if (baglanti.State == ConnectionState.Closed)
				{
					baglanti.Open();
				}
				object result = command.ExecuteScalar();

				if (result != null)
				{
					txt_odaNo.Text = "109";
					txt_ucret.Text = result.ToString();
					txt_ucret.ReadOnly = true;
				}
				else
				{
					MessageBox.Show("Veri bulunamadı.");
				}
				baglanti.Close();
			}


		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			RezerveEt();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{


			if (baglanti.State==ConnectionState.Closed)
			{
				baglanti.Open();
			}
			SqlCommand komutEkle = new SqlCommand("INSERT INTO Rezarvasyonn (RezNo,Adi, Soyadi, Cinsiyet, Telefon, TcKimlik, OdaNo, Ucret, GirisTarihi, CikisTarihi) VALUES (@RezNo,@Adi, @Soyadi, @Cinsiyet, @Telefon, @TcKimlik, @OdaNo, @Ucret, @GirisTarihi, @CikisTarihi)", baglanti);
			komutEkle.Parameters.AddWithValue("@RezNo", txt_RezNo.Text);

			komutEkle.Parameters.AddWithValue("@Adi", txt_adi.Text);
			komutEkle.Parameters.AddWithValue("@Soyadi", txt_soyAdi.Text);
			komutEkle.Parameters.AddWithValue("@Cinsiyet", combox_cinsiyet.Text);
			komutEkle.Parameters.AddWithValue("@Telefon", txt_telefon.Text);
			// komutEkle.Parameters.AddWithValue("@TcKimlik", txt_tcKimlik.Text);
			komutEkle.Parameters.AddWithValue("@OdaNo", txt_odaNo.Text);
			komutEkle.Parameters.AddWithValue("@Ucret", txt_ucret.Text);
			komutEkle.Parameters.AddWithValue("@GirisTarihi", dtp_giris.Value.ToString("yyyy-MM-dd"));
			komutEkle.Parameters.AddWithValue("@CikisTarihi", dtp_cikis.Value.ToString("yyyy-MM-dd"));


			string[] array1 = new string[10];
			array1[0] = txt_RezNo.Text;
			array1[2] = txt_adi.Text.Trim();
			array1[1] = txt_soyAdi.Text.Trim();

			array1[3] = combox_cinsiyet.Text.Trim();
			array1[4] = txt_telefon.Text.Trim();
			array1[5] = txt_tcKimlik.Text.Trim();
			array1[6] = txt_odaNo.Text.Trim();
			array1[7] = txt_ucret.Text.Trim();
			array1[8] = dtp_giris.Value.ToString("yyyy-MM-dd");

			array1[9] = dtp_cikis.Value.ToString("yyyy-MM-dd");

			foreach (var item in array1)
			{

				if (string.IsNullOrEmpty(item))
				{
					MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
					return;
				}
			}

			if (IsValidPhoneNumber(txt_telefon.Text.Trim()))
			{

				komutEkle.Parameters.AddWithValue("@TelefonNumarasi", txt_telefon.Text.Trim());
			}
			else
			{
				MessageBox.Show("Geçerli bir telefon numarası girin.");
				return;
			}
			if (IsValidTCKimlik(txt_tcKimlik.Text.Trim()))
			{
				komutEkle.Parameters.AddWithValue("@TCKimlik", txt_tcKimlik.Text.Trim());
			}
			else
			{
				MessageBox.Show("Geçerli bir TC Kimlik numarası girin.");
				return;
			}

			DateTime girisTarihi = dtp_giris.Value;
			DateTime cikisTarihi = dtp_cikis.Value;


			DateTime bugun = DateTime.Today;

			if (girisTarihi > bugun && cikisTarihi > girisTarihi && girisTarihi != cikisTarihi)
			{
				komutEkle.ExecuteNonQuery();
				baglanti.Close();


				verileriGoster();

				RezerveEt();

				MessageBox.Show("Yeni kayıt başarıyla eklendi.");

			}
			else
			{
				MessageBox.Show("Geçerli bir tarih aralığı değil.");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Form4 form = new Form4();
			form.Show();
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (baglanti.State == ConnectionState.Closed)
					baglanti.Open();

				int toplamOda = 0, doluOda = 0;

				SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Oda", baglanti);
				toplamOda = (int)command.ExecuteScalar();

				SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM dbo.Oda WHERE MusteriId IS NOT NULL", baglanti);
				doluOda = (int)command1.ExecuteScalar();


				double dolulukOrani = toplamOda > 0 ? (double)doluOda / toplamOda * 100 : 0;

				// Grafik oluşturma
				CreatePieChart(doluOda, toplamOda - doluOda);

				MessageBox.Show($"Doluluk Oranı: {dolulukOrani:0.00}%", "Otel Doluluk Oranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Hata: {ex.Message}");
			}
		}

		private void CreatePieChart(int doluOda, int bosOda)
		{
			// Pasta grafiği kontrolü
			var pieChart = new LiveCharts.WinForms.PieChart
			{
				Dock = DockStyle.Fill
			};

			pieChart.Series = new LiveCharts.SeriesCollection
			{
				new PieSeries
				{
					Title = "Dolu Odalar",
					Values = new ChartValues<double> { doluOda },
					DataLabels = true,
					Fill = System.Windows.Media.Brushes.Green
				},
				new PieSeries
				{
					Title = "Boş Odalar",
					Values = new ChartValues<double> { bosOda },
					DataLabels = true,
					Fill = System.Windows.Media.Brushes.Gray
				}
			};

			// Var olan kontrolü temizleyip grafiği ekle
			this.Controls.Clear();
			this.Controls.Add(pieChart);
		}

		private void CreatePdf(int doluOda, int toplamOda, double dolulukOrani)
		{
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OtelDolulukOrani.pdf");

			using (PdfWriter writer = new PdfWriter(filePath))
			{
				PdfDocument pdf = new PdfDocument(writer);
				Document document = new Document(pdf);

				// Başlık
				document.Add(new Paragraph("Otel Doluluk Orani Raporu")
					.SetFontSize(20)
					.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

				document.Add(new Paragraph("\n")); // Boşluk

				// İçerik
				document.Add(new Paragraph($"Toplam Oda Sayisi: {toplamOda}")
					.SetFontSize(12));
				document.Add(new Paragraph($"Dolu Oda Sayisi: {doluOda}")
					.SetFontSize(12));
				document.Add(new Paragraph($"Doluluk Orani: {dolulukOrani:0.00}%")
					.SetFontSize(12));

				// PDF'i kapat
				document.Close();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				if (baglanti.State == ConnectionState.Closed)
					baglanti.Open();

				int toplamOda = 0, doluOda = 0;

				SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Oda", baglanti);
				toplamOda = (int)command.ExecuteScalar();

				SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM dbo.Oda WHERE MusteriId IS NOT NULL", baglanti);
				doluOda = (int)command1.ExecuteScalar();


				double dolulukOrani = toplamOda > 0 ? (double)doluOda / toplamOda * 100 : 0;

				CreatePdf(doluOda, toplamOda, dolulukOrani);

				MessageBox.Show("PDF masaüstüne başarıyla indirildi.");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Hata: {ex.Message}");
			}
		}
	}
}
