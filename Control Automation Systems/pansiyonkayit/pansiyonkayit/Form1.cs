using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cartcurtkayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-DC520F6\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True");
        
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            

        }

        private void verilerigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from pansiyontakip", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["odano"].ToString());
                ekle.SubItems.Add(oku["gtarih"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["hesap"].ToString());
                ekle.SubItems.Add(oku["ctarih"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }
        private void kaydet()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into pansiyontakip(id, ad, soyad, odano, gtarih, telefon, hesap, ctarih) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text.ToString()+"','"+ textBox6.Text.ToString()+"','" +  dateTimePicker2.Text.ToString()+"')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            temizle();
            listView1.Items.Clear();
            verilerigoster();
            
        }
        private void güncelle()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update pansiyontakip set id='"+ textBox1.Text.ToString()+"', ad='"+ textBox2.Text.ToString()+"', soyad='"+ textBox3.Text.ToString()+"', odano='"+ textBox4.Text.ToString()+"', gtarih='"+ dateTimePicker1.Text.ToString()+"', telefon='"+ textBox5.Text.ToString()+"', hesap='"+ textBox6.Text.ToString()+"', ctarih='"+ dateTimePicker2.Text.ToString()+"'where id="+textBox1.Text.ToString()+"",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            temizle();
            listView1.Items.Clear();
            verilerigoster();
        }
        private void sil()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from pansiyontakip where id=("+ textBox1.Text.ToString()+")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            temizle();
            listView1.Items.Clear();
            verilerigoster();
        }
        private void ara()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from pansiyontakip where ad like '%"+textBox7.Text.ToString()+"%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["odano"].ToString());
                ekle.SubItems.Add(oku["gtarih"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["hesap"].ToString());
                ekle.SubItems.Add(oku["ctarih"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
            listView1.Items.Clear();
            verilerigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            kaydet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DialogResult result1 = MessageBox.Show("Bu Kayıdı Güncellemek İstediğinize eminmisiniz", "Kullancı Verileri Güncellenecek!", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                güncelle();
            }
            else
            {

            }
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
           DialogResult result1 = MessageBox.Show("Bu Kayıdı Silmek İstediğinize eminmisiniz", "Kullancı Silinecek!", MessageBoxButtons.YesNo);
            if (result1== DialogResult.Yes)
            {
                sil();
            }
            else
            {
                
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ara();
        }
    }
}
