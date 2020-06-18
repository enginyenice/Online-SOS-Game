using MySql.Data.MySqlClient;
using SOS.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Class
{
    class Siralama
    {
        Paths.Paths paths = new Paths.Paths();
        private readonly MySqlConnection con = new MySqlConnection();
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        
        public Siralama()
        {
            con.ConnectionString = paths.dbPath;
        }
        public List<Datas.User> SiramalaGetir()
        {
            List<Datas.User> liste = new List<User>();
            con.Open();
            string sorgu = "SELECT username,galibiyet,malubiyet,avaraj FROM kullanici ORDER BY avaraj DESC";
            cmd = new MySqlCommand(sorgu, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Datas.User User = new Datas.User();
                User.Username = dr[0].ToString();
                User.Galibiyet = Int32.Parse(dr[1].ToString());
                User.Malubiyet = Int32.Parse(dr[2].ToString());
                User.Avaraj= Int32.Parse(dr[3].ToString());
                liste.Add(User);
            }
            con.Close();


            return liste;
        }
    }
}
