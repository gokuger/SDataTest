using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sage.SData.Client.Core;
using Sage.SData.Client.Atom;
using Sage.SData.Client.Extensions;

namespace SDataTest
{
    class SDataConnection
    {
        private String url = "";
        private String user = "";
        private String password = "";
        private String ressourceKind;
        var request = null;
        
        public SDataConnection(String url, String user, String password, String ressourceKind)
        {
            this.url = url;
            this.user = user;
            this.password = password;
            this.ressourceKind = ressourceKind;
        }

        public void setConnection()
        {
            ISDataService service = new SDataService(url, user, password);
            var request = new SDataResourceCollectionRequest(service);    
        }

        public void setRessourceKind(String ressourceKind)
        {
                 
        }
    }
}
