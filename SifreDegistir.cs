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
    public partial class SifreDegistir : Form
    {
        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                Class.Login login = new Class.Login();
                login.SifreDegistir(Int32.Parse(label1.Text),textBox1.Text);
                MessageBox.Show("Şifre başarıyla değiştirildi.");
                this.Close();

            }
            else
            {
                MessageBox.Show("Girilen şifre çok kısa");
            }
        }

        private void SifreDegistir_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lobi lobi = new Lobi();
            lobi.label1.Text = label1.Text;
            lobi.Show();
        }
    }
}
