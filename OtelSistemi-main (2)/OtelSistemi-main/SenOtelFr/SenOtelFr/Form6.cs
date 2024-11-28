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
namespace SenOtelFr
{
    public partial class Form6 : Form
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








        public Form6()
        {
            InitializeComponent();
        }
        public static string constring4 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti4 = new SqlConnection(constring4);
        public string sorgu = "SELECT * FROM Personel";

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti4);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

              


            }
            catch (Exception)
            {

                throw;
            }
         


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 admindonus = new Form4();
            admindonus.Show();
            this.Hide();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
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
    }
}
