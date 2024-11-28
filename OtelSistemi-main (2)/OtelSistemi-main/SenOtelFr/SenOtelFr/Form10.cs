using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace SenOtelFr
{
    public partial class Form10 : Form
    {
        public static string constring4 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti4 = new SqlConnection(constring4);

        public Form10()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya=new OpenFileDialog();
            dosya.Title = "Dosya Seç";
            dosya.FileName = textBox1.Text;
            dosya.Filter = "Excel Sheet (*.xlsx)|*xlsx|All Files(*.*)|*.*";
            dosya.FilterIndex = 1;
            dosya.RestoreDirectory = true;
            if (dosya.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = dosya.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string dosyaYolu = textBox1.Text;

                OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{dosyaYolu}';Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1;'");
                baglanti.Open();

                OleDbDataAdapter veriyukle = new OleDbDataAdapter("Select * from [Sayfa1$]", baglanti);
                DataSet sd = new DataSet();
                DataTable dt = new DataTable();
                veriyukle.Fill(dt);
                this.dataGridView1.DataSource = dt.DefaultView;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        void boslukDoldur()
        {
            baglanti4.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Musteri order by MusteriId",baglanti4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti4.Close();
        }
        private void Form10_Load(object sender, EventArgs e)
        {
            boslukDoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti4.Open();
            for (int i = 0; i <dataGridView1.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("insert into Musteri (KullaniciAdi,Ad,Soyad,TCKimlik,Adres,TelefonNumarasi,Sifre) values  ('"+dataGridView1.Rows[i].Cells[0].Value+ "','"+dataGridView1.Rows[i].Cells[1].Value+ "','"+dataGridView1.Rows[i].Cells[2].Value+ "','"+dataGridView1.Rows[i].Cells[3].Value+ "','"+dataGridView1.Rows[i].Cells[4].Value+ "','"+dataGridView1.Rows[i].Cells[5].Value+ "','"+dataGridView1.Rows[i].Cells[6].Value+"')", baglanti4);
                cmd.ExecuteNonQuery();

            }
            baglanti4.Close();
            MessageBox.Show("Müşteri Kaydedildi");
            boslukDoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 donus=new Form4();
            donus.Show();
            this.Hide();




        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            DataObject copydata = dataGridView1.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlwbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlwbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlwbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();
            xlsheet.Columns.ColumnWidth = 15;
            xlsheet.Rows.RowHeight = 20;



            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
