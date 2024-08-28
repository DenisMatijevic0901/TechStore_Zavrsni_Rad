using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace TechStoreZavrsni
{
    public partial class KupnjaProizvoda : Form
    {

        public CrmServiceClient _service = null;

        public KupnjaProizvoda(CrmServiceClient s)
        {
            InitializeComponent();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
            _service = s;
        }

        
        public void RetrieveAllProducts()
        {
            dgvProducts.Rows.Clear();
            QueryExpression qe = new QueryExpression("product");
            qe.ColumnSet = new ColumnSet("name", "price", "description", "productid", "defaultuomid", "quantityonhand", "validtodate");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach (Entity e in ec.Entities)
            {
                if (DateTime.Parse(e["validtodate"].ToString()) > DateTime.Now)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProducts.Rows[0].Clone();
                    row.Cells[0].Value = e["name"];
                    row.Cells[1].Value = Math.Round(((Money)e["price"]).Value, 2);
                    row.Cells[2].Value = e["description"];
                    row.Cells[3].Value = e["productid"];
                    row.Cells[4].Value = ((EntityReference)e["defaultuomid"]).Id;
                    row.Cells[5].Value = Math.Round((decimal)e["quantityonhand"], 0);
                    dgvProducts.Rows.Add(row);
                }
            }

            foreach (DataGridViewRow redak in dgvProducts.Rows)
            {
                if (redak != dgvProducts.Rows[dgvProducts.RowCount - 1])
                {
                    if (redak.Cells[5].Value.ToString().Equals("0"))
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
        

        private void Form1_Load(object sender, EventArgs e)
        {
            RetrieveAllProducts();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            tbName.ReadOnly = true;
            tbPrice.ReadOnly = true;
            tbDesc.ReadOnly = true;

            tbName.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            tbPrice.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            tbDesc.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            tbID.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            tbUom.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            tbQuantity.Text = dgvProducts.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnNaruci_Click(object sender, EventArgs e)
        {
            if(numKolicina.Value > decimal.Parse(tbQuantity.Text)) 
                MessageBox.Show("Proizvod nije u zalihi.");
            else {
                Entity order = new Entity("salesorder");
                order["name"] = "Narudžba: " + tbName.Text + ", " + numKolicina.Value.ToString() + " kom.";
                //Guid guid = _service.Create(order);

                Entity details = new Entity("salesorderdetail");
                details["productid"] = new EntityReference("product", Guid.Parse(tbID.Text));
                details["uomid"] = new EntityReference("uom", Guid.Parse(tbUom.Text));
                details["quantity"] = numKolicina.Value;

                Entity product = new Entity("product");
                product.Id = Guid.Parse(tbID.Text);
                product.Attributes["quantityonhand"] = (decimal.Parse(tbQuantity.Text) - numKolicina.Value);

                Form narudzbaForm = new Narudzba(order, details, product, tbName.Text, tbPrice.Text, numKolicina.Value.ToString(), _service);
                narudzbaForm.ShowDialog();
                RetrieveAllProducts();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
