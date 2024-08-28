using Microsoft.Xrm.Sdk.Query;
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
using Microsoft.Crm.Sdk.Messages;

namespace TechStoreZavrsni
{
    public partial class PregledNarudzbi : Form
    {

        public CrmServiceClient _service = null;

        public PregledNarudzbi(CrmServiceClient s)
        {
            InitializeComponent();
            _service = s;
        }

        private void PregledNarudzbi_Load(object sender, EventArgs e)
        {
            OsvjeziDgv();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FulfillSalesOrderRequest req = new FulfillSalesOrderRequest();
            req.OrderClose = new Entity("orderclose");
            req.OrderClose["salesorderid"] = new EntityReference("salesorder", new Guid(tbID.Text));
            req.Status = new OptionSetValue(100001); //Fulfill = 100001
            _service.ExecuteCrmOrganizationRequest(req);

            Entity order = _service.Retrieve("salesorder", Guid.Parse(tbID.Text), new ColumnSet("customerid", "name", "salesorderid"));
            Entity orderDetail = null;

            QueryExpression qe = new QueryExpression("salesorderdetail");
            qe.ColumnSet = new ColumnSet("salesorderid", "salesorderdetailid", "productid", "quantity");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach(Entity entity in ec.Entities)
            {
                EntityReference salesOrder = (EntityReference)entity["salesorderid"];
                if (salesOrder.Id.ToString().Equals(tbID.Text))
                {
                    orderDetail = entity;
                    break;
                }
            }
            
            Entity invoice = new Entity("invoice");
            invoice["name"] = "Faktura: " + order["name"].ToString().Substring(10);
            invoice["statuscode"] = new OptionSetValue(1);
            invoice["salesorderid"] = new EntityReference("salesorder", new Guid(tbID.Text));
            EntityReference customer = (EntityReference)order["customerid"];
            invoice["customerid"] = new EntityReference("account", customer.Id);
            Guid invoiceGuid = _service.Create(invoice);

            Entity invoiceDetail = new Entity("invoicedetail");
            invoiceDetail["invoiceid"] = new EntityReference("invoice", invoiceGuid);
            EntityReference product = (EntityReference)orderDetail["productid"];
            invoiceDetail["productid"] = new EntityReference("product", product.Id);
            invoiceDetail["uomid"] = new EntityReference("uom", ServiceClient.uom);
            invoiceDetail["salesorderdetailid"] = new EntityReference("salesorderdetail", orderDetail.Id);
            invoiceDetail["quantity"] = orderDetail.Attributes["quantity"];
            _service.Create(invoiceDetail);
            OsvjeziDgv();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _service.Delete("salesorder", new Guid(tbID.Text));
            OsvjeziDgv();
            MessageBox.Show("Narudžba obrisana");

        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            tbID.Text = dgvOrders.CurrentRow.Cells[4].Value.ToString();
            tbNaziv.Text = dgvOrders.CurrentRow.Cells[0].Value.ToString();
            if (dgvOrders.CurrentRow.Cells[2].Value.ToString() == "Complete") { 
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
            dgvOrders.Rows.Clear();

            QueryExpression qe = new QueryExpression("salesorder");
            qe.ColumnSet = new ColumnSet("name", "totalamount", "statuscode", "customerid", "salesorderid");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach (Entity e2 in ec.Entities)
            {
                DataGridViewRow row = (DataGridViewRow)dgvOrders.Rows[0].Clone();
                row.Cells[0].Value = e2["name"];
                row.Cells[1].Value = Math.Round(((Money)e2["totalamount"]).Value, 2);
                var status = ((OptionSetValue)e2["statuscode"]).Value;
                if (status == 1)
                    row.Cells[2].Value = "New";
                else if (status == 100001)
                    row.Cells[2].Value = "Complete";

                EntityReference test = (EntityReference)e2["customerid"];
                row.Cells[3].Value = test.Name;
                row.Cells[4].Value = e2["salesorderid"];

                dgvOrders.Rows.Add(row);
            }

            foreach (DataGridViewRow redak in dgvOrders.Rows)
            {
                if(redak != dgvOrders.Rows[dgvOrders.RowCount-1]) { 
                    if (redak.Cells[2].Value.ToString() == "Complete")
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
    }
}
