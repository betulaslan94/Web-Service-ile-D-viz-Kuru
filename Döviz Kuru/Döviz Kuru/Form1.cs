using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Döviz_Kuru
{
    public partial class Form1 : Form
    {
        string today = "http://www.tcmb.gov.tr/kurlar/today.xml";
        public Form1()
        {
            InitializeComponent();
            Goster();
        }
        public void Goster()
        {
            var xml = new XmlDocument();
            xml.Load(today);
            string USD = xml.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string EURO = xml.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;

            label1.Text = (string.Format("USD   : {0} TL", USD));
            label2.Text = (string.Format("EURO  : {0} TL", EURO));
        }
        public double dhesapla(float x)
        {
            var xml = new XmlDocument();
            xml.Load(today);
            string USD = xml.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            float sayi = float.Parse(USD);
            double sonuc = x / sayi * 10000;
            sonuc = Math.Round(sonuc, 2);
            return sonuc;
        }
        public double ehesapla(float x)
        {
            var xml = new XmlDocument();
            xml.Load(today);
            string EURO = xml.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            float sayi = float.Parse(EURO);
            double sonuc = x / sayi * 10000;
            sonuc = Math.Round(sonuc, 2);
            return sonuc;
        }

        private void temizleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = (dhesapla(Convert.ToInt32(textBox1.Text))).ToString();
            textBox3.Text = (ehesapla(Convert.ToInt32(textBox1.Text))).ToString();
        }
    }
}
