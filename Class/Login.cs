using MySql.Data.MySqlClient;
using SOS.Datas;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOS.Class
{
    
    class Login

    {

        Paths.Paths paths = new Paths.Paths();
        private readonly MySqlConnection con = new MySqlConnection();
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        public Login()
        {
            con.ConnectionString = paths.dbPath;
        }
        public int LoginID(string username, string password)
        {
            con.Open();

            string sorgu = "SELECT id FROM kullanici WHERE username='" + username + "'AND password='" + password + "'";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();
            int id = -1;
            while (dr.Read())
            {
                id = Int32.Parse(dr[0].ToString());
            }
            con.Close();

            return id;
        }
        public bool LoginControl(string username,string password)
        {
            con.Open();

            string sorgu = "SELECT COUNT(*) FROM kullanici WHERE username='"+username+"'AND password='"+password+"'";
            cmd = new MySqlCommand(sorgu, con);
            int sonuc= Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if (sonuc > 0)
            {
                con.Open();
                sorgu = "UPDATE kullanici SET online="+1+" WHERE username='"+username+"' AND password='"+password+"'";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            return false;
        }
        public bool CreateControl(string username, string password)
        {
            con.Open();
            List<Datas.User> onlineList = new List<Datas.User>();
            string sorgu = "SELECT count(*) FROM kullanici WHERE username='"+username+"'";
            cmd = new MySqlCommand(sorgu, con);
            int sonuc = Int32.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if (sonuc == 0)
            {
                con.Open();
                sorgu = "INSERT INTO kullanici (username,password) VALUES ('"+username+"','"+password+"')";
                cmd = new MySqlCommand(sorgu, con);
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            return false;
          


        }
        public void offline(int id)
        {
            con.Open();
            string sorgu = "UPDATE kullanici SET online=" + 0 + " WHERE id="+id+"";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void online(int id)
        {
            con.Open();
            string sorgu = "UPDATE kullanici SET online=" + 1 + " WHERE id=" + id + "";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SifreDegistir(int id,string password)
        {
            con.Open();
            string sorgu = "UPDATE kullanici SET password='" + password + "' WHERE id=" + id + "";
            cmd = new MySqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
