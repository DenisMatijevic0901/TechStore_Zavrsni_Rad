using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace TechStoreZavrsni
{
    public partial class UnesiCilj : Form
    {
        public CrmServiceClient _service = null;
        public UnesiCilj(CrmServiceClient s)
        {
            InitializeComponent();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
            _service = s;
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNaziv.Text) || string.IsNullOrEmpty(tbCilj.Text) || (cmbVrstaCilja.SelectedIndex != 0 && cmbVrstaCilja.SelectedIndex != 1))
                MessageBox.Show("Popunite sva polja prije dodavanja proizvoda.");
            else
            {
                Entity goal = new Entity("goal");
                goal["title"] = tbNaziv.Text;
                goal["goalstartdate"] = dtpOd.Value;
                goal["goalenddate"] = dtpDo.Value;
                goal["fiscalyear"] = new OptionSetValue(2022);
                goal["fiscalperiod"] = new OptionSetValue(3);
                if (cmbVrstaCilja.SelectedIndex == 1)
                {
                    goal["metricid"] = new EntityReference("metric", ServiceClient.revenue);
                    goal["targetmoney"] = new Money(decimal.Parse(tbCilj.Text));
                    goal["actualmoney"] = new Money(decimal.Parse("0"));
                }
                else if (cmbVrstaCilja.SelectedIndex == 0)
                {
                    goal["metricid"] = new EntityReference("metric", ServiceClient.productUnit);
                    goal["targetdecimal"] = decimal.Parse(tbCilj.Text);
                    goal["actualdecimal"] = decimal.Parse("0");
                }

                goal["percentage"] = decimal.Parse("0");
                goal["isoverride"] = true;
                Guid goalGuid = _service.Create(goal);

                MessageBox.Show("Cilj je uspješno dodan.");
                this.Close();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
