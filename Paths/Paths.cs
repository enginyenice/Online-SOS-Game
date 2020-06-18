using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Paths
{
    class Paths
    {
        public static string server = "localhost";
        public static string database = "sosgame";
        public static string uid = "root";
        public static string password = "123456789";
        public string dbPath = "Server=" + server + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + password + ";AllowUserVariables=True;UseCompression=True";
     
    }
}
