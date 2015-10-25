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
            SDataConnection SDataConnection = new SDataConnection("http://localhost:3333/sdata/slx/dynamic/-/", "admin", "");
            SDataConnection.setRessourceKind("Tickets");
            // SDataConnection.request.QueryValues.Add("where", "LastName like 'Ab%'");
            SDataConnection.setQueryValues("where", "TicketNumber eq '001-00-000004'");
            

            foreach (AtomEntry entry in SDataConnection.readRequest().Entries)
            {
                SDataPayload payload = entry.GetSDataPayload();
                MessageBox.Show(payload.Values["TicketNumber"].ToString());
            }
        }
    }
}