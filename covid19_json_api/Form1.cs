using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace covid19_json_api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] CoranaVerileri, CoranaGunlukVeriBilgisi;

            using (WebClient wc = new WebClient())
            {
                var url = wc.DownloadString("https://raw.githubusercontent.com/ozanerturk/covid19-turkey-api/master/dataset/timeline.json");

                CoranaVerileri = url.ToString().Split('{');
            }

            for (int i = 1; i <=10; i++)
            {
                CoranaGunlukVeriBilgisi = CoranaVerileri[CoranaVerileri.Length-i].Split('"');

                if (i==1)
                {
                    label1.Text = CoranaGunlukVeriBilgisi[3] + "COVİD HASTA TABLOSU";
                }

                tarih.ListView.Items.Add(CoranaGunlukVeriBilgisi[3]);
                test.ListView.Items.Add(CoranaGunlukVeriBilgisi[31]);
                vaka.ListView.Items.Add(CoranaGunlukVeriBilgisi[35]);
                iyilesen.ListView.Items.Add(CoranaGunlukVeriBilgisi[51]);
                vefat.ListView.Items.Add(CoranaGunlukVeriBilgisi[47]);
            }

            
        }
    }
}
