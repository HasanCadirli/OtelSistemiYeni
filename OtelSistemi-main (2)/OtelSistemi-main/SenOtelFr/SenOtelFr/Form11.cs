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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        public static string constring4 = "Data Source=DESKTOP-8KA05UA\\SQLEXPRESS;Initial Catalog=SenOtel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection baglanti4 = new SqlConnection(constring4);
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 donus=new Form4();
            donus.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            baglanti4.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SilinenMusteriLog order by MusteriId", baglanti4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti4.Close();
        }
    }
}
