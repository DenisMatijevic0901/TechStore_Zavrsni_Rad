using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
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
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Crm.Sdk.Messages;

namespace TechStoreZavrsni
{
    public partial class PregledFaktura : Form
    {
        public CrmServiceClient _service = null;

        public PregledFaktura(CrmServiceClient s)
        {
            InitializeComponent();
            _service = s;
            OsvjeziDgv();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
        }

        private void dgvGoals_SelectionChanged(object sender, EventArgs e)
        {
            tbID.Text = dgvInvoice.CurrentRow.Cells[4].Value.ToString();

            if (dgvInvoice.CurrentRow.Cells[1].Value.ToString() == "Billed")
            {
                cbStatus.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                cbStatus.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }

        private void OsvjeziDgv()
        {
            dgvInvoice.Rows.Clear();

            QueryExpression qe = new QueryExpression("invoice");
            qe.ColumnSet = new ColumnSet("invoiceid", "customerid", "totalamount", "statuscode", "name");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach (Entity e2 in ec.Entities)
            {
                DataGridViewRow row = (DataGridViewRow)dgvInvoice.Rows[0].Clone();
                row.Cells[0].Value = e2["name"];
                var status = ((OptionSetValue)e2["statuscode"]).Value;
                if (status == 1)
                    row.Cells[1].Value = "New";
                else if (status == 4)
                    row.Cells[1].Value = "Billed";

                row.Cells[2].Value = Math.Round(((Money)e2["totalamount"]).Value, 2);
                EntityReference customer = (EntityReference)e2["customerid"];
                row.Cells[3].Value = customer.Name;
                row.Cells[4].Value = e2["invoiceid"];

                dgvInvoice.Rows.Add(row);
            }

            foreach (DataGridViewRow redak in dgvInvoice.Rows)
            {
                if (redak != dgvInvoice.Rows[dgvInvoice.RowCount - 1])
                {
                    if (redak.Cells[1].Value.ToString().Equals("Billed"))
                    {
                        redak.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        redak.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _service.Delete("invoice", Guid.Parse(tbID.Text));
            MessageBox.Show("Faktura obrisana.");
            OsvjeziDgv();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Entity invoice = new Entity("invoice");
            invoice.Id = Guid.Parse(tbID.Text);
            invoice.Attributes["statuscode"] = new OptionSetValue(4);
            _service.Update(invoice);
            MessageBox.Show("Faktura ažurirana.");
            OsvjeziDgv();
        }
    }
}
