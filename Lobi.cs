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
    public partial class Lobi : Form
    {
        Class.Lobi lobi = new Class.Lobi();
        int userID;

        public Lobi()
        {
            InitializeComponent();
        }

        private void ListeDoldur()
        {
            List<Datas.User> users = LobiClass.onlineList();
            listBox1.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                if (userID != users[i].UserID)
                    listBox1.Items.Add(users[i].Username);
            }
        }
        
        private void DavetVarMi()
        {
            int SahipID = lobi.DavetVarMi(userID);
            if(SahipID > 0)
            {
                timer2.Stop();
                
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show($"{lobi.GetUserName(SahipID)} sizi oyuna davet ediyor", "Oyun Daveti", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    //Davet Kabul
                    int gameID = lobi.DavetKabul(userID, SahipID);
                    Oyun oyun = new Oyun();
                    oyun.label1.Text = gameID.ToString();
                    oyun.label2.Text = userID.ToString();
                    
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    Class.Login login = new Class.Login();
                    login.online(userID);
                    oyun.Show();
                    this.Hide();
                    
                }
                else
                {
                    lobi.DavetReddet(userID, SahipID);
                }
            }
        
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ListeDoldur();
            
        }
        Class.Lobi LobiClass = new Class.Lobi();
        private void Lobi_Load(object sender, EventArgs e)
        {
            userID = Int32.Parse(label1.Text);
            timer1.Start();
            timer2.Start();

            


        }

        private void DavetBtn_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count > 0)
            { 
            lobi.DavetGonder(listBox1.SelectedItem.ToString(), userID);
            DavetBtn.Enabled = false;
            timer3.Start();
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DavetVarMi();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int durum = lobi.DavetDurum(userID);
            if(durum == 0)
            {
                label2.Text = "Bekleniyor...";
            } else if(durum == 2)
            {
                label2.Text = "Davet Reddedildi.";
                lobi.DavetSil(userID);
                timer3.Stop();
                DavetBtn.Enabled = true;
            } else
            {
                label2.Text = "Davet Kabul Edildi.";
                int gameID = lobi.GetGameID(userID);
                Oyun oyun = new Oyun();
                oyun.label1.Text = gameID.ToString();
                oyun.label2.Text = userID.ToString();
                Class.Login login = new Class.Login();
                login.offline(userID);
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                oyun.Show();
                this.Hide();

            }
        }

        private void Lobi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class.Login login = new Class.Login();
            login.offline(userID);
            Application.Exit();
        }
    }
}
