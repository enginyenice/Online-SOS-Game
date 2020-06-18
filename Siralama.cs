using SOS.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOS
{
    public partial class Siralama : Form
    {
        public Siralama()
        {
            InitializeComponent();
        }

        Class.Siralama siralama = new Class.Siralama();
        private void Siralama_Load(object sender, EventArgs e)
        {
            SiralamaList.Columns.Add("Kullanıcı Adı", 100);
            SiralamaList.Columns.Add("Galibiyet", 100);
            SiralamaList.Columns.Add("Malubiyet", 100);
            SiralamaList.Columns.Add("Avaraj", 100);
            List<Datas.User> siralamaListesi = new List<Datas.User>();
            siralamaListesi =  siralama.SiramalaGetir();
            foreach (var item in siralamaListesi)
            {
                string[] siralamaData = { item.Username.ToString(), item.Galibiyet.ToString(), item.Malubiyet.ToString(), item.Avaraj.ToString() };
                ListViewItem SiralamaItem = new ListViewItem(siralamaData);
                SiralamaList.Items.Add(SiralamaItem);
            }

        }

        private void Siralama_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lobi lobi = new Lobi();
            lobi.label1.Text = label1.Text;
            lobi.Show();
        }
    }
}
