/*
 TODO: Seçim yapmadan tamam basılıyor...
 */

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
    public partial class Oyun : Form
    {
        Class.Oyun oyunData= new Class.Oyun();
        private int OyunID, OyuncuID,SuandaSira;
        private string OyunCuAdi1, OyuncuAdi2;
        private int OyuncuPuan1, OyuncuPuan2;
        public Oyun()
        {
            InitializeComponent();
        }

        private void Oyun_Load(object sender, EventArgs e)
        {
            board();
            SiraTimer.Start();
            OyunID = Int32.Parse(label1.Text);
            OyuncuID = Int32.Parse(label2.Text);

            oyunData.oyuncuBilgileriCek(OyunID);
            OyunCuAdi1 = oyunData.Oyuncu1Adi;
            OyuncuAdi2 = oyunData.Oyuncu2Adi;
            OyuncuPuan1 = oyunData.Oyuncu1Puan;
            OyuncuPuan2 = oyunData.Oyuncu2Puan;
            Oyuncu1.Text = OyunCuAdi1;
            Oyuncu2.Text = OyuncuAdi2;
            Oyuncu1Skor.Text = OyuncuPuan1.ToString();
            Oyuncu2Skor.Text = OyuncuPuan2.ToString();

        }
        bool gameOver = false;
        private void GameOver()
        {
            int status = 0;
            for(int y = 0; y<8;y++)
            {
                for(int x = 0; x<8;x++)
                {
                    if (oyunData.board[y, x] == 0)
                    { gameOver = false;
                        status = 1;
                    }
                }
            }
            if(status == 0)
                gameOver = true;
        }

        int iterDurum = 0, kesinY, kesinX,value;
        Label[,] labels = new Label[8, 8];

        private void Oyun_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            if(gameOver == true)
            {
                Siralama siralama = new Siralama();
                siralama.Show();
            } else
            {
                Lobi lobi = new Lobi();
                lobi.label1.Text = OyuncuID.ToString();
                lobi.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MesajTxt.Text.Length > 0)
            {
                oyunData.SohbetGonder(OyunID, OyuncuID, MesajTxt.Text);
                MesajTxt.Text = "";
            } else
            {
                MessageBox.Show("Mesaj Yok");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(kesinX != -1 && kesinY != -1)
            {
                iterDurum = 0;
                oyunData.board[kesinY, kesinX] = value;
                oyunKontrol();
                kesinX = -1;
                kesinY = -1;
            } else
            {
                MessageBox.Show("Seçim yapmadınız...");
            }

        }

        int siraBende = 0;
        private string SosHarfDondur(int value)
        {
            if (value == 0)
                return " ";
            else if (value == 1)
                return "S";
            else
                return "O";

        }

        string sonSohbet = "";
        private void SiraTimer_Tick(object sender, EventArgs e)
        {
            string sohbet = oyunData.SohbetGetir(OyunID);
            if(sohbet != sonSohbet)
            {
                sonSohbet = sohbet;
                sohbetPenceresi.Clear();
                sohbetPenceresi.Text = sonSohbet;
            }


            SuandaSira = oyunData.SiraGetir(OyunID);
            if (SuandaSira == OyuncuID)
            {

                button1.Visible = true;
                if (siraBende == 0)
                {
                    oyunData.oyuncuBilgileriCek(OyunID);
                    OyunCuAdi1 = oyunData.Oyuncu1Adi;
                    OyuncuAdi2 = oyunData.Oyuncu2Adi;
                    OyuncuPuan1 = oyunData.Oyuncu1Puan;
                    OyuncuPuan2 = oyunData.Oyuncu2Puan;
                    Oyuncu1.Text = OyunCuAdi1;
                    Oyuncu2.Text = OyuncuAdi2;
                    Oyuncu1Skor.Text = OyuncuPuan1.ToString();
                    Oyuncu2Skor.Text = OyuncuPuan2.ToString();
                    oyunData.HaritaGuncelle(OyunID);
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            labels[y, x].Text = SosHarfDondur(oyunData.board[y, x]);
                        }
                    }
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            //Yatay
                            if (x <= 5)
                            {
                                if (oyunData.board[y, x] == 1 && oyunData.board[y, x + 1] == 2 && oyunData.board[y, (x + 2)] == 1)
                                {
                                    labels[y, x].BackColor = Color.Red;
                                    labels[y, x + 1].BackColor = Color.Red;
                                    labels[y, x + 2].BackColor = Color.Red;

                                }
                            }

                            if (y <= 5)
                            {
                                if (oyunData.board[y, x] == 1 && oyunData.board[y + 1, x] == 2 && oyunData.board[y + 2, x] == 1)
                                {
                                    labels[y, x].BackColor = Color.Red;
                                    labels[y + 1, x].BackColor = Color.Red;
                                    labels[y + 2, x].BackColor = Color.Red;
                                }
                            }
                            // Sağ Çapraz
                            if (y <= 5 && x <= 5)
                            {
                                if (oyunData.board[y, x] == 1 && oyunData.board[y + 1, x + 1] == 2 && oyunData.board[y + 2, x + 2] == 1)
                                {
                                    labels[y, x].BackColor = Color.Red;
                                    labels[y + 1, x + 1].BackColor = Color.Red;
                                    labels[y + 2, x + 2].BackColor = Color.Red;
                                }
                            }
                            // Sol Çapraz
                            if (y <= 5 && x >= 2)
                            {
                                if (oyunData.board[y, x] == 1 && oyunData.board[y + 1, x - 1] == 2 && oyunData.board[y + 2, x - 2] == 1)
                                {
                                    labels[y, x].BackColor = Color.Red;
                                    labels[y + 1, x - 1].BackColor = Color.Red;
                                    labels[y + 2, x - 2].BackColor = Color.Red;
                                }
                            }
                        }
                    }
                    siraBende = 1;
                }

            }
            else
            { button1.Visible = false;
                siraBende = 0;
            }
            GameOver();
            if (gameOver == true)
            {
                Class.Login login = new Class.Login();
                login.online(OyuncuID);
                this.Close();
            }

        }
        private void oyunKontrol()
        {
            int dataPuan = oyunData.Puan(OyunID);
            int puan = 0;
            for (int y = 0; y<8;y++)
            {
                for(int x = 0; x< 8;x++)
                {
                    //Yatay
                    if(x<=5)
                    {
                        if(oyunData.board[y,x] == 1 && oyunData.board[y, x+1] == 2 && oyunData.board[y, (x+2)] == 1)
                        {
                           labels[y, x].BackColor = Color.Red;
                           labels[y, x+1].BackColor = Color.Red;
                           labels[y, x+2].BackColor = Color.Red;
                            puan++;
                        }
                    }
                    //Dikey
                    if (y <= 5)
                    {
                        if (oyunData.board[y, x] == 1 && oyunData.board[y+1, x] == 2 && oyunData.board[y+2, x] == 1)
                        {
                            labels[y, x].BackColor = Color.Red;
                            labels[y+1, x].BackColor = Color.Red;
                            labels[y+2, x].BackColor = Color.Red;
                            puan++;
                        }
                    }
                    // Sağ Çapraz
                    if (y <= 5 && x <= 5)
                    {
                        if (oyunData.board[y, x] == 1 && oyunData.board[y + 1, x + 1] == 2 && oyunData.board[y + 2, x + 2] == 1)
                        {
                            labels[y, x].BackColor = Color.Red;
                            labels[y + 1, x + 1].BackColor = Color.Red;
                            labels[y + 2, x + 2].BackColor = Color.Red;
                            puan++;
                        }
                    }
                    // Sol Çapraz
                    if (y <=5 && x >= 2)
                    {
                        if (oyunData.board[y, x] == 1 && oyunData.board[y + 1, x - 1] == 2 && oyunData.board[y + 2, x - 2] == 1)
                        {
                            labels[y, x].BackColor = Color.Red;
                            labels[y + 1, x - 1].BackColor = Color.Red;
                            labels[y + 2, x - 2].BackColor = Color.Red;
                            puan++;
                        }
                    }
                }
            }
            GameOver();
            if (puan == dataPuan) //Puan Alamadı.
            {
                //Harita Gonder
                oyunData.HaritaGonder(OyunID);
                //Sira Degistir
                oyunData.SiraDegistir(OyunID, OyuncuID);         
            }
            else //Puan Aldı
            {
                oyunData.HaritaGonder(OyunID);
                oyunData.PuanGuncelle(OyunID, OyuncuID, (puan - dataPuan));
                //oyunData.PuanGuncelle(OyunID, OyuncuID, (puan - dataPuan));
                //Puan Guncelle
                if(gameOver == true)
                    oyunData.SiraDegistir(OyunID, OyuncuID);

            }
            oyunData.oyuncuBilgileriCek(OyunID);
            OyunCuAdi1 = oyunData.Oyuncu1Adi;
            OyuncuAdi2 = oyunData.Oyuncu2Adi;
            OyuncuPuan1 = oyunData.Oyuncu1Puan;
            OyuncuPuan2 = oyunData.Oyuncu2Puan;
            Oyuncu1.Text = OyunCuAdi1;
            Oyuncu2.Text = OyuncuAdi2;
            Oyuncu1Skor.Text = OyuncuPuan1.ToString();
            Oyuncu2Skor.Text = OyuncuPuan2.ToString();


        }
        private void board()
        {
            int horizotal = 30;
            int vertical = 100;
            

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {

                    labels[y,x] = new Label();
                    labels[y, x].Name = y.ToString()+x.ToString();
                    labels[y, x].Size = new Size(38, 38);
                    labels[y, x].BorderStyle = BorderStyle.FixedSingle;
                    labels[y, x].Text = " ";
                    labels[y, x].Location = new Point(horizotal, vertical);
                    labels[y, x].Click += new EventHandler(this.SOS_Click);   // click event yükle
                    labels[y, x].Font = new Font("Microsoft Sans Serif", 20);

                    this.Controls.Add(labels[y,x]);
                    horizotal += 40;
                }
                horizotal = 30;
                vertical += 40;
            }
        }
        void SOS_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            int clickY, clickX;
            clickY = Int32.Parse(lbl.Name[0].ToString());
            clickX = Int32.Parse(lbl.Name[1].ToString());
            if(oyunData.board[clickY,clickX] == 0)
            {
                if(iterDurum == 0) {
                if(SuandaSira == OyuncuID)
                {
                if(lbl.Text == " ")
                {
                    iterDurum = 1;
                    lbl.Text = "S";
                        value = 1;
                    lbl.BackColor = Color.Green;
                    kesinY = clickY;
                    kesinX = clickX;
                }
                else if(lbl.Text == "S")
                {
                    iterDurum = 1;
                    lbl.Text = "O";
                        value = 2;
                        lbl.BackColor = Color.Green;
                    kesinY = clickY;
                    kesinX = clickX;
                } else
                {
                    iterDurum = 0;
                    lbl.Text = " ";
                    lbl.BackColor = Color.WhiteSmoke;
                    kesinY = -1;
                    kesinX = -1;
                }
                    }
                } else
                {
                    if(SuandaSira == OyuncuID)
                    { 
                    if(clickX == kesinX && clickY == kesinY)
                    {
                        if (lbl.Text == " ")
                        {
                            iterDurum = 1;
                            lbl.Text = "S";
                            value = 1;
                            lbl.BackColor = Color.Green;
                            kesinY = clickY;
                            kesinX = clickX;
                        }
                        else if (lbl.Text == "S")
                        {
                            iterDurum = 1;
                            lbl.Text = "O";
                            value = 2;
                            lbl.BackColor = Color.Green;
                            kesinY = clickY;
                            kesinX = clickX;
                        }
                        else
                        {
                            iterDurum = 0;
                            lbl.Text = " ";
                            lbl.BackColor = Color.WhiteSmoke;
                            kesinY = -1;
                            kesinX = -1;
                        }
                    }
                }
                }

            } else
            {
                MessageBox.Show("Bu Alan Dolu");
            }
        }
    }
}
