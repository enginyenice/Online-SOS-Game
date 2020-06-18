using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Datas
{
    class User
    {
        private string username;
        private int userID;
        private int galibiyet;
        private int malubiyet;
        private int avaraj;

        public string Username { get => username; set => username = value; }
        public int UserID { get => userID; set => userID = value; }
        public int Avaraj { get => avaraj; set => avaraj = value; }
        public int Malubiyet { get => malubiyet; set => malubiyet = value; }
        public int Galibiyet { get => galibiyet; set => galibiyet = value; }
    }
}
