using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Class
{
    class Oyun
    {
        public string Oyuncu1Adi, Oyuncu2Adi;
        public int Oyuncu1Puan, Oyuncu2Puan;
        public int Oyuncu1ID, Oyuncu2ID;
        Paths.Paths paths = new Paths.Paths();
        private readonly MySqlConnection con = new MySqlConnection();
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        public int[,] board = new int[8, 8];
        public Oyun()
        {
            con.ConnectionString = paths.dbPath;
        }

        public int SiraGetir(int OyunID)
        {
            con.Open();
            string sorgu = "SELECT sira,sahipID FROM oyun WHERE id= " + OyunID + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int Sira = 0;
            int SahipID = 0;
            while (dr.Read())
            {
                Sira = Int32.Parse(dr[0].ToString());
                SahipID = Int32.Parse(dr[1].ToString());
            }
            con.Close();
            if (Sira == 0)
                Sira = SahipID;
            return Sira;
        }

        public int Puan(int OyunID)
        {
            con.Open();
            string sorgu = "SELECT SahipPuan,MisafirPuan FROM oyun WHERE id= " + OyunID + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int Sahip = 0;
            int Misafir = 0;
            while (dr.Read())
            {
                Sahip = Int32.Parse(dr[0].ToString());
                Misafir = Int32.Parse(dr[1].ToString());
            }
            con.Close();

            return Sahip + Misafir;
        }
        public void PuanGuncelle(int Oyun,int Oyuncu,int KazanilanPuan)
        {

            con.Open();
            string sorgu = "SELECT SahipID,MisafirID FROM oyun WHERE id= " + Oyun + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int Sahip = 0;
            int Misafir = 0;
            while (dr.Read())
            {
                Sahip = Int32.Parse(dr[0].ToString());
                Misafir = Int32.Parse(dr[1].ToString());
            }
            con.Close();


            if(Sahip == Oyuncu)
            {


                con.Open();
                sorgu = "UPDATE oyun SET SahipPuan=SahipPuan+"+KazanilanPuan+" WHERE id="+Oyun+"";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                con.Open();
                sorgu = "UPDATE oyun SET MisafirPuan=MisafirPuan+" + KazanilanPuan + " WHERE id=" + Oyun + "";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }







        }
        public void HaritaGonder(int Oyun)
        {
            string mapJSON = JsonConvert.SerializeObject(board);
            con.Open();
            string sorgu = "UPDATE oyun SET OyunHaritasi='" + mapJSON + "' WHERE id=" + Oyun + "";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SiraDegistir(int Oyun, int Oyuncu)
        {
            con.Open();
            string sorgu = "SELECT SahipID,MisafirID FROM oyun WHERE id= " + Oyun + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int Sahip = 0;
            int Misafir = 0;
            while (dr.Read())
            {
                Sahip = Int32.Parse(dr[0].ToString());
                Misafir = Int32.Parse(dr[1].ToString());
            }
            con.Close();


            if (Sahip == Oyuncu)
            {


                con.Open();
                sorgu = "UPDATE oyun SET sira=" + Misafir + " WHERE id=" + Oyun + "";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                con.Open();
                sorgu = "UPDATE oyun SET sira=" + Sahip + " WHERE id=" + Oyun + "";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void HaritaGuncelle(int OyunID)
        {
            con.Open();
            string sorgu = "SELECT OyunHaritasi FROM oyun WHERE id= " + OyunID + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            string map = "";
            while (dr.Read())
            {
                map = dr[0].ToString();
            }
            con.Close();

            if(map.Length > 0)
            {
                map = map.Replace("[", "");
                map = map.Replace("]", "");
                map = map.Replace(",", "");
                int[,] newMap = new int[8, 8];
                int y = 0;
                for(int x = 0; x<map.Length;x++)
                {
                    if (y == 8)
                        break;
                    switch (x % 8)
                    {

                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            newMap[y, (x % 8)] = Int32.Parse(map[x].ToString());
                            break;

                        case 7:
                            newMap[y, (x % 8)] = Int32.Parse(map[x].ToString());
                            y++;
                            break;
                    }
                }
                board = newMap;

            } else
            {
                for(int y = 0; y<8;y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        board[y, x] = 0;
                    }
                }
            }

        }
        public void oyuncuBilgileriCek(int OyunID)
        {
            con.Open();
            string sorgu = "SELECT SahipID,MisafirID,SahipPuan,MisafirPuan FROM oyun WHERE id= " + OyunID + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int sahip = 0, misafir = 0, sahipP = 0, misafirP = 0;
            while (dr.Read())
            {
                sahip = Int32.Parse(dr[0].ToString());
                misafir = Int32.Parse(dr[1].ToString());
                sahipP = Int32.Parse(dr[2].ToString());
                misafirP = Int32.Parse(dr[3].ToString());
            }
            con.Close();
            Oyuncu1Puan = sahipP;
            Oyuncu2Puan = misafirP;
            Oyuncu1ID = sahip;
            Oyuncu2ID = misafir;


            con.Open();
            sorgu = "SELECT username FROM kullanici WHERE id= " + sahip + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            string SahipAdi = "";
            while (dr.Read())
            {
                SahipAdi = dr[0].ToString();
            }
            con.Close();

            con.Open();
            sorgu = "SELECT username FROM kullanici WHERE id= " + misafir + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            string MisafirAdi = "";
            while (dr.Read())
            {
                MisafirAdi = dr[0].ToString();
            }
            con.Close();

            Oyuncu1Adi = SahipAdi;
            Oyuncu2Adi = MisafirAdi;

        }
        public void SohbetGonder(int OyunID,int OyuncuID,string mesaj)
        {
            con.Open();
            string sorgu = "SELECT mesaj FROM sohbet WHERE oyunID= " + OyunID + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            string m = "";
            while (dr.Read())
            {
                m = dr[0].ToString();
            }
            con.Close();



            con.Open();
            
            if (OyuncuID == Oyuncu1ID)
            {
                string text = Oyuncu1Adi + " :" + mesaj +"\n"+ m;
                //UPDATE oyun SET SahipPuan=SahipPuan+"+KazanilanPuan+" WHERE id="+Oyun+"

                sorgu = "UPDATE sohbet SET sahipID="+Oyuncu1ID+",mesaj='"+text+"' WHERE oyunID="+OyunID+" ";

            } else
            {
                string text = Oyuncu1Adi + " :" + mesaj + "\n" + m;
                sorgu = "UPDATE sohbet SET misafirID=" + Oyuncu2ID + ",mesaj='" + text + "' WHERE oyunID=" + OyunID + " ";
            }
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string SohbetGetir(int OyunID)
        {
            con.Open();
            string sorgu = "SELECT mesaj FROM sohbet WHERE oyunID= " + OyunID + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            string m = "";
            while (dr.Read())
            {
                m = dr[0].ToString();
            }
            con.Close();
            return m;
        }

    }
    }

