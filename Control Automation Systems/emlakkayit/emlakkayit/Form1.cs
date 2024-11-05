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

namespace emlakkayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ATILLAHP\\SQLEXPRESS;Initial Catalog=emlakkayit;Integrated Security=True");
 
        private void verilerigoruntule()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from siteuzem", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["asite"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["noo"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void veritemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();

        }
        private void kaydet()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into siteuzem(id, asite, oda, metre, fiyat, blok, noo, adsoyad, telefon, notlar, satkira) values('"+textBox1.Text.ToString() +"', '"+comboBox1.Text.ToString()+ "', '" +comboBox3.Text.ToString()+ "', '" +textBox2.Text.ToString() +"', '" +textBox3.Text.ToString() +"', '" +comboBox4.Text.ToString()+ "', '" +textBox4.Text.ToString()+ "', '" +textBox5.Text.ToString()+ "', '" +textBox6.Text.ToString()+ "', '"+ textBox6.Text.ToString() +"', '" +comboBox2.Text.ToString()+"')" , baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            listView1.Items.Clear();
            verilerigoruntule();
            veritemizle();
            
        }
        private void güncelle()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update siteuzem set id='" + textBox1.Text.ToString() + "', asite='" + comboBox1.Text.ToString() + "', oda='" + comboBox3.Text.ToString() + "', metre='" + textBox2.Text.ToString() + "', fiyat='" + textBox3.Text.ToString() + "', blok='" + comboBox4.Text.ToString() + "', noo='" + textBox4.Text.ToString()+"', adsoyad='"+textBox5.Text.ToString()+"', telefon='"+textBox6.Text.ToString()+"', notlar='" + textBox7.Text.ToString()+"', satkira='"+ comboBox2.Text.ToString()+ "'where id="+ textBox1.Text.ToString()+"", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            listView1.Items.Clear();
            verilerigoruntule();
            veritemizle();
        }
        private void sil()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from siteuzem where id=(" + textBox1.Text.ToString() + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            listView1.Items.Clear();
            verilerigoruntule();
            veritemizle();
        }

        private void arama()
        {
            baglan.Open(); 
            SqlCommand komut = new SqlCommand("select * from siteuzem where adsoyad like'%"+ textBox8.Text.ToString()+"%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["asite"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["noo"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString()); 

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoruntule();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="ZAMBAK") 
            {
                button7.BackColor = Color.YellowGreen;
                button8.BackColor = Color.DarkGray;
                button9.BackColor = Color.DarkGray;
                button10.BackColor = Color.DarkGray;

            }
            if (comboBox1.Text == "MENEKŞE")
            {
                button7.BackColor = Color.DarkGray;
                button8.BackColor = Color.DarkGray;
                button9.BackColor = Color.DarkGray;
                button10.BackColor = Color.YellowGreen;

            }
            if (comboBox1.Text == "GÜL")
            {
                button7.BackColor = Color.DarkGray;
                button8.BackColor = Color.DarkGray;
                button9.BackColor = Color.YellowGreen;
                button10.BackColor = Color.DarkGray;

            }
            if (comboBox1.Text == "PAPATYA")
            {
                button7.BackColor = Color.DarkGray;
                button8.BackColor = Color.YellowGreen;
                button9.BackColor = Color.DarkGray;
                button10.BackColor = Color.DarkGray;

            }
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            kaydet();
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;    
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sil();
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            güncelle();
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            arama();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "ZAMBAK";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "PAPATYA";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "GÜL";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "MENEKŞE";
        }
    }
}
