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
    public partial class Form7 : Form
    {


        private void SilmeIslemi(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Musteri WHERE MusteriId = @MusteriId";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MusteriId", id);
                        command.ExecuteNonQuery();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız oldu: " + ex.Message);
            }
        }

        private void YenidenVeriYukle()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Musteri";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView12.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme işlemi başarısız oldu: " + ex.Message);
            }
        }






        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Musteri";

                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView12.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme işlemi başarısız oldu: " + ex.Message);
            }








        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti7 = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand komut = new SqlCommand("AdAra",baglanti7);
                komut.CommandType= CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@ArananAd",txt_adara.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView12.DataSource = dataTable;


                baglanti7.Open();
                komut.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti7 = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand komut = new SqlCommand("SoyadAra", baglanti7);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@ArananSoyad", txt_soyadara.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView12.DataSource = dataTable;


                baglanti7.Open();
                komut.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection baglanti7 = new SqlConnection("Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand komut = new SqlCommand("SearchByID", baglanti7);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@ID", txt_id.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView12.DataSource = dataTable;


                baglanti7.Open();
                komut.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView12.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView12.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["MusteriId"].Value);

                SilmeIslemi(id);
                MessageBox.Show("Silme Gerçekleştirildi");
                YenidenVeriYukle();
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            YenidenVeriYukle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 donus = new Form4();
            donus.Show();
            this.Hide();
           
        }
    }
    }

