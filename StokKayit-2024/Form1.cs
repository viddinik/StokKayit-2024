using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;// veritabanı bağlantısı!
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokKayit_2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { // sil
            String t1 = textBox1.Text; // seçilen satırın malzeme kodu..
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler1 WHERE MalzemeKodu=('"+t1+"') " , baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=MERT\\SQLEXPRESS01; Initial Catalog=Stok; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        { //Ekle butonu
            String t1 = textBox1.Text; // malzeme kodu 
            String t2 = textBox2.Text; // malzeme adı 
            String t3 = textBox3.Text; // yıllık satiş
            String t4 = textBox4.Text; // birim fiyat 
            String t5 = textBox5.Text; // min stok 
            String t6 = textBox6.Text; // t süresi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler1 (MalzemeKodu, MalzemeAdi, YıllıkSatis,BirimFiyat,MinStok,TSüresi) VALUES ('" + t1+"','" + t2+"','" + t3+"','" + t4+"','" + t5+"','" + t6+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele() // veritabanındaki gücenllemeler
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Malzemeler1",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {// güncelleme

            String t1 = textBox1.Text; // malzeme kodu 
            String t2 = textBox2.Text; // malzeme adı 
            String t3 = textBox3.Text; // yıllık satiş
            String t4 = textBox4.Text; // birim fiyat 
            String t5 = textBox5.Text; // min stok 
            String t6 = textBox6.Text; // t süresi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler1 SET MalzemeKodu='"+t1+ "',MalzemeAdi='" + t2 + "',YıllıkSatis='" +t3+ "', BirimFiyat='"+t4+ "',MinStok='"+t5+ "',TSüresi='"+t6+ "' WHERE MalzemeKodu='"+ t1 +"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            
        }
    }
}
