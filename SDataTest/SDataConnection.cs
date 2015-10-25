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
        private SDataResourceCollectionRequest request = null;
        private String queryValue1 = "";
        private String queryValue2 = "";
        
        
        public SDataConnection(String url, String user, String password) 
        {
            this.url = url;
            this.user = user;
            this.password = password;

            ISDataService service = new SDataService(url, user, password);
            var request = new SDataResourceCollectionRequest(service);
            this.request = request;
        }

        public void setRessourceKind(String ressourceKind)
        {
            this.ressourceKind = ressourceKind;
            request.ResourceKind = this.ressourceKind;
        }

        public AtomFeed readRequest()
        {
            AtomFeed feed = request.Read();
            return feed;
        }

        public SDataResourceCollectionRequest getRequest()
        {
            return this.request;
        }

        public void setQueryValues(String queryValue1, String queryValue2)
        {
            this.queryValue1 = queryValue1;
            this.queryValue2 = queryValue2;
        }
    }
}
