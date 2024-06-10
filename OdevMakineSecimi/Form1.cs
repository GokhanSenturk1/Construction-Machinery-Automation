using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OdevMakineSecimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        class makineBilgileri
        {
            public string MakineAdi { get; set; }
            public DateTime Tarih { get; set; }
            public string HedefMiktar { get; set; }
            public string ÜretilenMiktar { get; set; }
            public makineBilgileri(string MakineAdi, DateTime Tarih, string HedefMiktar, string ÜretilenMiktar)
            {
                this.MakineAdi = MakineAdi;
                this.Tarih = Tarih;
                this.MakineAdi = MakineAdi;
                this.HedefMiktar = HedefMiktar;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string dosyayolu = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\1ÖdevMakineSeçimi\Makineler.txt";
            try
            {
                StreamReader okuyucu = new StreamReader(dosyayolu);
                string satir;

                while ((satir = okuyucu.ReadLine()) != null)
                {
                    string[] veriDizisi = satir.Split(',');

                    dataGridView1.Rows.Add(veriDizisi);
                }

                okuyucu.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yüklenemedi: " + ex.Message);
            }

        }

        private void btnciz_Click(object sender, EventArgs e)
        {
            string dosyayolu = @"D:\1Fırat Üni Ders Notlarım\2.Sınıf Bahar Dönemi\NTP\1ÖdevMakineSeçimi\Makineler.txt";

            string btarih = dateTimePickerBaslangicTarihi.Text;
            string bbitis = dateTimePickerBitisTarihi.Text;

            try
            {
                StreamReader okuyucu = new StreamReader(dosyayolu);
                string satir;
                


                while ((satir = okuyucu.ReadLine()) != null)
                {
                    string[] veriDizisi = satir.Split(',');

                    for (int i = btarih[0]; i <= bbitis[0]; i++)
                    {
                        string dizi = veriDizisi[1];

                        if (i == dizi[0] && comboBox1.Text == veriDizisi[0])
                        {
                         chart1.Series["Hedef Miktar"].Points.AddXY(veriDizisi[1], veriDizisi[2]);
                         chart1.Series["Üretilen Miktar"].Points.AddXY(bbitis, veriDizisi[3]);
                        }
                    }
                }

                okuyucu.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yüklenemedi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            foreach (var seri in chart1.Series)
            {
                seri.Points.Clear();
            }
        }
    }
}
