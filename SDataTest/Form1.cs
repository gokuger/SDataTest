using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sage.SData.Client.Core;
using Sage.SData.Client.Atom;
using Sage.SData.Client.Extensions;

namespace SDataTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // All requests require an ISDataService which provides
            // the service location and user authentication values
            ISDataService svc = new SDataService("http://localhost:3333/sdata/slx/dynamic/-/", "admin", "");

            // Now create the request, passing in the ISDataService we created
            // above
            var req = new SDataResourceCollectionRequest(svc);

            // Tell it which kind of resource we want to access, in this case
            // Contacts. Note, this needs to match the values on the SData tab
            // of the entity in Application Architect
            req.ResourceKind = "Tickets";

            // This part is optional (without it we'd be getting ALL contacts).
            // This is our where clause, or condition of which contacts we want.
            // In this example we want all contacts whose last name starts with
            // the value 'Ab'. We need to use the exact property name as defined
            // in the entity (case-sensitive).
            // req.QueryValues.Add("where", "LastName eq 'Ab%'");

            // Now read the data (or run the query)
            AtomFeed feed = req.Read();

            // We now have the results in our AtomFeed variable, which is
            // basically a list of AtomEntry objects. To get to our data,
            // we need to read the payload from each AtomEntry and then we
            // can access the values for each field from it's Values
            // dictionary. In this example, we'll just write a few fields
            // from each contact to the console.
            foreach (AtomEntry entry in feed.Entries)
            {
                // Get the payload for this entity
                SDataPayload payload = entry.GetSDataPayload();

                // Now read some values from the payload. Note, the
                // property names you use here need to match the property
                // names defined for the entity (these are case-sensitive).
                //string account = payload.Values["AccountName"].ToString();
                //string contactName = payload.Values["NameLF"].ToString();
                //string title = payload.Values["Title"].ToString();
                
                MessageBox.Show(payload.Values["TicketNumber"].ToString());
                
                //Console.WriteLine("{0}, {1} from {2}", contactName, account, title);
            }
        }
    }
}
