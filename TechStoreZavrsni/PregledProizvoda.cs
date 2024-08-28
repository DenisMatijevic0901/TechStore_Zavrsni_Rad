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

namespace TechStoreZavrsni
{
    public partial class PregledProizvoda : Form
    {
        public CrmServiceClient _service = null;

        public PregledProizvoda(CrmServiceClient s)
        {
            InitializeComponent();
            _service = s;
        }

        private void PregledProizvoda_Load(object sender, EventArgs e)
        {
            RetrieveAllProducts();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
        }

        public void RetrieveAllProducts()
        {
            dgvProducts.Rows.Clear();
            QueryExpression qe = new QueryExpression("product");
            qe.ColumnSet = new ColumnSet("name", "price", "description", "productid", "defaultuomid", "quantityonhand", "validfromdate", "validtodate");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach (Entity e in ec.Entities)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProducts.Rows[0].Clone();
                row.Cells[0].Value = e["name"];
                row.Cells[1].Value = Math.Round(((Money)e["price"]).Value, 2);
                row.Cells[2].Value = e["description"];
                row.Cells[3].Value = e["productid"];
                row.Cells[4].Value = ((EntityReference)e["defaultuomid"]).Id;
                try { 
                    row.Cells[5].Value = Math.Round((decimal)e["quantityonhand"], 0); 
                }catch(KeyNotFoundException ex)
                {
                    Entity product = new Entity("product");
                    product.Id = e.Id;
                    product.Attributes["quantityonhand"] = (decimal)0;
                    _service.Update(product);
                    row.Cells[5].Value = Math.Round((decimal)0, 0);
                }

                row.Cells[6].Value = e["validfromdate"];
                row.Cells[7].Value = e["validtodate"];
                dgvProducts.Rows.Add(row);
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

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            tbName.ReadOnly = true;

            tbName.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            tbPrice.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            tbDesc.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            tbID.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            tbUom.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            numNovaKolicina.Value = (decimal)dgvProducts.CurrentRow.Cells[5].Value;
            dtpOd.Value = DateTime.Parse(dgvProducts.CurrentRow.Cells[6].Value.ToString());
            dtpDo.Value = DateTime.Parse(dgvProducts.CurrentRow.Cells[7].Value.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Entity product = new Entity("product");
            product.Id = Guid.Parse(tbID.Text);
            product.Attributes["quantityonhand"] = numNovaKolicina.Value;
            product.Attributes["price"] = new Money(decimal.Parse(tbPrice.Text));
            product.Attributes["description"] = tbDesc.Text;
            product.Attributes["validfromdate"] = dtpOd.Value;
            product.Attributes["validtodate"] = dtpDo.Value;
            _service.Update(product);
            RetrieveAllProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form unesiForma = new UnesiProizvod(_service);
            unesiForma.ShowDialog();
            RetrieveAllProducts();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _service.Delete("product", new Guid(tbID.Text));
            RetrieveAllProducts();
            MessageBox.Show("Proizvod obrisan.");
        }
    }
}
