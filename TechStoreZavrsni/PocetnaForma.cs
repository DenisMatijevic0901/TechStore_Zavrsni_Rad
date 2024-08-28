using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechStoreZavrsni
{
    public partial class PocetnaForma : Form
    {
        public CrmServiceClient _service = ServiceClient.getCRMService();
        public PocetnaForma()
        {
            InitializeComponent();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
        }

        private void btnProizvod_Click(object sender, EventArgs e)
        {
            Form pregled = new PregledProizvoda(_service);
            this.Hide();
            pregled.ShowDialog();
            this.Show();
        }

        private void btnKupnja_Click(object sender, EventArgs e)
        {
            Form kupnja = new KupnjaProizvoda(_service);
            this.Hide();
            kupnja.ShowDialog();
            this.Show();
        }

        private void btnNarudzba_Click(object sender, EventArgs e)
        {
            Form pregled = new PregledNarudzbi(_service);
            this.Hide();
            pregled.ShowDialog();
            this.Show();
        }

        private void PocetnaForma_Load(object sender, EventArgs e)
        {
            if (_service.IsReady)
                MessageBox.Show("Uspješno povezivanje s https://techstore.crm4.dynamics.com/.");
            else
                MessageBox.Show("Neuspješno povezivanje.");
        }

        private void btnGoal_Click(object sender, EventArgs e)
        {
            Form pregled = new PregledCiljeva(_service);
            this.Hide();
            pregled.ShowDialog();
            this.Show();
        }

        private void btnFakture_Click(object sender, EventArgs e)
        {
            Form pregled = new PregledFaktura(_service);
            this.Hide();
            pregled.ShowDialog();
            this.Show();
        }
    }
}
