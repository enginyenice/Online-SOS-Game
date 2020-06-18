using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Class
{
    class Lobi
    {
        Paths.Paths paths = new Paths.Paths();
        private readonly MySqlConnection con = new MySqlConnection();
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        public Lobi()
        {
            con.ConnectionString = paths.dbPath;
        }
        public List<Datas.User> onlineList()
        {
            con.Open();
            List<Datas.User> onlineList = new List<Datas.User>();
            string sorgu = "SELECT * FROM kullanici WHERE online = "+1+"";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                Datas.User User = new Datas.User();
                User.UserID =Int32.Parse(dr[0].ToString());
                User.Username = dr[1].ToString();
                onlineList.Add(User);
            }
            con.Close();
            return onlineList;
        } 
        public int DavetVarMi(int id)
        {
            int sahipID = 0;
            con.Open();
            string sorgu = "SELECT count(*) FROM davet WHERE misafirID= " + id + " AND result= 0";
            cmd = new MySqlCommand(sorgu, con);
            int sonuc = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if(sonuc > 0)
            {
                con.Open();
                sorgu = "SELECT sahipID FROM davet WHERE misafirID= " + id + " AND result= 0";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sahipID = Int32.Parse(dr[0].ToString());
                }
                con.Close();
            }
            
            return sahipID;
        }
        public void DavetGonder(string username,int id)
        {


            con.Open();
            string sorgu = "SELECT id FROM kullanici WHERE username= '" + username + "'";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int misafirID = 0;
            while (dr.Read())
            {
                misafirID = Int32.Parse(dr[0].ToString());
            }
            con.Close();

            con.Open();
            sorgu = "INSERT INTO davet (sahipID,misafirID) VALUES (" + id + "," + misafirID + ")";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public string GetUserName(int id)
        {

            con.Open();
            string sorgu = "SELECT username FROM kullanici WHERE id= " + id + "";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            string userName = "";
            while (dr.Read())
            {
                userName = dr[0].ToString();
            }
            con.Close();
            return userName;
        }
        public int DavetDurum(int id)
        {           
                con.Open();
                string sorgu = "SELECT result FROM davet WHERE sahipID= " + id + "";
                cmd = new MySqlCommand(sorgu, con);
                dr = cmd.ExecuteReader();
                int result = 0;
                while (dr.Read())
                {
                    result = Int32.Parse(dr[0].ToString());
                }
                con.Close();
            return result;


        }
        public void DavetReddet(int misafir,int sahip)
        {
            con.Open();
            string sorgu = "UPDATE davet SET result = 2 WHERE sahipID=" + sahip + " AND misafirID=" + misafir + "";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DavetSil(int id)
        {
            con.Open();
            string sorgu = "DELETE FROM davet WHERE sahipID=" + id + ";";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int DavetKabul(int misafir, int sahip)
        {
                con.Open();
                string sorgu = "UPDATE davet SET result = 1 WHERE sahipID=" + sahip + " AND misafirID=" + misafir + "";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();

            con.Open();
            sorgu = "INSERT oyun SET SahipID="+sahip+" , MisafirID="+misafir+"";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            sorgu = "SELECT id FROM oyun WHERE MisafirID=" + misafir + " ORDER BY id DESC LIMIT 1";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int gameID = 0;
            while (dr.Read())
            {
                gameID = Int32.Parse(dr[0].ToString());
            }
            con.Close();
            return gameID;
        }
        public int GetGameID(int id)
        {
            int gameID = 0;
            con.Open();
            string sorgu = "SELECT id FROM oyun WHERE SahipID=" + id + " ORDER BY id DESC LIMIT 1";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                gameID = Int32.Parse(dr[0].ToString());
            }
            con.Close();
            return gameID;
        }


    }
}
