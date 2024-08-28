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
using System.Windows.Forms;

namespace TechStoreZavrsni
{
    public partial class UnesiProizvod : Form
    {
        public CrmServiceClient _service = null;
        public UnesiProizvod(CrmServiceClient s)
        {
            InitializeComponent();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
            _service = s;
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNaziv.Text) || string.IsNullOrEmpty(tbCijena.Text) || string.IsNullOrEmpty(tbOpis.Text))
                MessageBox.Show("Popunite sva polja prije dodavanja proizvoda.");
            else
            {
                Entity product = new Entity("product");
                product["name"] = tbNaziv.Text;
                product["description"] = tbOpis.Text;
                product["price"] = new Money(decimal.Parse(tbCijena.Text));
                product["quantityonhand"] = numKolicina.Value;
                product["validfromdate"] = dtpOd.Value;
                product["validtodate"] = dtpDo.Value;
                product["defaultuomid"] = new EntityReference("uom", ServiceClient.uom);
                product["defaultuomscheduleid"] = new EntityReference("uomschedule", ServiceClient.uomSchedule);
                Guid productGuid = _service.Create(product);

                Entity price = new Entity("productpricelevel");
                price["pricelevelid"] = new EntityReference("pricelevel", ServiceClient.priceList);
                price["productid"] = new EntityReference("product", productGuid);
                price["amount"] = new Money(decimal.Parse(tbCijena.Text));
                price["uomid"] = new EntityReference("uom", ServiceClient.uom);
                _service.Create(price);
                MessageBox.Show("Proizvod je uspješno dodan.");
                this.Close();
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
