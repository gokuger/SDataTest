using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDataTest
{
    class SDataConnection
    {
        private String connectionPath = "";
        private String user = "";
        private String password = "";
        
        public SDataConnection(String connectionPath, String user, String password)
        {
            this.connectionPath = connectionPath;
            this.user = user;
            this.password = password;
        }

        public void connect()
        {
 
        }
    }
}
