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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Class.Login login = new Class.Login();
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool result = login.LoginControl(username.Text, password.Text);
            if (result == true)
            { Lobi lobi = new Lobi();
                int userID = login.LoginID(username.Text, password.Text);
                lobi.label1.Text = userID.ToString();
                lobi.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No Login");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = login.CreateControl(username.Text, password.Text);
            if(result == true)
            {
                MessageBox.Show("Kayıt olundu.");
            } else
            {
                MessageBox.Show("Böyle bir kullanıcı adı sistemde mevcut");
            }
            
    }
    }
}
