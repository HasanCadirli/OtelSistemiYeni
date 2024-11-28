using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SenOtelFr
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }

        public static string constring1 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti4 = new SqlConnection(constring1);

        private void Personel_Load(object sender, EventArgs e)
        {

        }

        private void btn_personelgiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti4.State == ConnectionState.Closed)
                {
                    baglanti4.Open();
                }

                string sql = "SELECT * FROM Personel WHERE Ad=@KullaniciAdi AND Sifre=@Sifre";
                SqlParameter prmtr1 = new SqlParameter("KullaniciAdi", txt_personeladi.Text.Trim());
                SqlParameter prmtr2 = new SqlParameter("Sifre", txt_personelsifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti4);
                komut.Parameters.Add(prmtr1);
                komut.Parameters.Add(prmtr2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string rol = dt.Rows[0]["Rol"].ToString();

                    if (rol == "Yönetici")
                    {
                        MessageBox.Show("Giriş Başarılı! ADMİN");

                        Form4 adminsayfasi1 = new Form4();
                        adminsayfasi1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarılı!");
                    }
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti4.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
