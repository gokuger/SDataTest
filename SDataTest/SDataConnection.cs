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
        private String ressourceKind = "";
        
        public SDataConnection(String url, String user, String password) 
        {
            this.url = url;
            this.user = user;
            this.password = password;
        }

        public void setConnection(String ressourceKind)
        {
            ISDataService service = new SDataService(url, user, password);
            var request = new SDataResourceCollectionRequest(service);
            request.ResourceKind = ressourceKind;
        }
    }
}
