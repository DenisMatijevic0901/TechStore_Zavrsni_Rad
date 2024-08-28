using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TechStoreZavrsni
{
    public partial class Narudzba : Form
    {
        public CrmServiceClient _service = null;
        Entity order = null;
        Entity details = null;
        Entity product = null;
        string naziv = null;
        string cijena = null;
        string kolicina = null;

        public Narudzba(Entity o, Entity d, Entity p, string n, string c, string k, CrmServiceClient s)
        {
            InitializeComponent();
            order = o;
            details = d;
            product = p;
            naziv = n;
            cijena = c;
            kolicina = k;
            _service = s;
        }

        private void Narudzba_Load(object sender, EventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml("#011234");
            lblNaziv.Text = naziv;
            lblCijena.Text = cijena;
            lblKolicina.Text = kolicina;
            lblUkupno.Text = Math.Round( decimal.Parse(kolicina) * decimal.Parse(cijena), 2 ).ToString() + "kn";
        }

        private void btnNaruci_Click(object sender, EventArgs e)
        {
            QueryExpression qe = new QueryExpression("goal");
            qe.ColumnSet = new ColumnSet("goalid", "metricid", "actualmoney", "actualdecimal");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach(Entity entity in ec.Entities)
            {
                if (entity.GetAttributeValue<EntityReference>("metricid").Id == ServiceClient.revenue)
                {
                    Entity e1 = new Entity("goal");
                    e1.Id = Guid.Parse(entity["goalid"].ToString());
                    e1.Attributes["actualmoney"] = new Money(entity.GetAttributeValue<Money>("actualmoney").Value + decimal.Parse(cijena) * decimal.Parse(kolicina));
                    e1.Attributes["isoverride"] = true;
                    _service.Update(e1);
                }
                else if(entity.GetAttributeValue<EntityReference>("metricid").Id == ServiceClient.productUnit)
                {
                    Entity e1 = new Entity("goal");
                    e1.Id = Guid.Parse(entity["goalid"].ToString());
                    e1.Attributes["actualdecimal"] = decimal.Parse(entity["actualdecimal"].ToString()) + decimal.Parse(kolicina);
                    e1.Attributes["isoverride"] = true;
                    _service.Update(e1);
                }
            }

            var Text = cmbDostava.SelectedItem;
            order["shippingmethodcode"] = new OptionSetValue(cmbDostava.SelectedIndex + 1);

            Entity contact = new Entity("contact");
            contact["firstname"] = tbIme.Text;
            contact["lastname"] = tbPrezime.Text;
            contact["emailaddress1"] = tbEmail.Text;
            contact["telephone1"] = tbPhone.Text;
            contact["address1_line1"] = tbAdresa.Text;
            contact["address1_city"] = tbGrad.Text;
            contact["address1_stateorprovince"] = tbZupanija.Text;
            contact["address1_postalcode"] = tbPostanskiBroj.Text;
            contact["address1_country"] = tbDrzava.Text;
            Guid contactGuid = _service.Create(contact);

            Entity account = new Entity("account");
            account["name"] = tbIme.Text + " " + tbPrezime.Text;
            account["telephone1"] = tbPhone.Text;
            account["emailaddress1"] = tbEmail.Text;
            account["primarycontactid"] = new EntityReference("contact", contactGuid);
            account["address1_line1"] = tbAdresa.Text;
            account["address1_city"] = tbGrad.Text;
            account["address1_stateorprovince"] = tbZupanija.Text;
            account["address1_postalcode"] = tbPostanskiBroj.Text;
            account["address1_country"] = tbDrzava.Text;
            Guid accGuid = _service.Create(account);

            Entity contact2 = new Entity("contact");
            contact2["contactid"] = contactGuid;
            contact2["parentcustomerid"] = new EntityReference("account", accGuid);
            _service.Update(contact2);

            order["customerid"] = new EntityReference("account", accGuid);
            order["emailaddress"] = tbEmail.Text;
            order["shipto_line1"] = tbAdresa.Text;
            order["shipto_city"] = tbGrad.Text;
            order["shipto_stateorprovince"] = tbZupanija.Text;
            order["shipto_postalcode"] = tbPostanskiBroj.Text;
            order["shipto_country"] = tbDrzava.Text;
            order["billto_line1"] = tbAdresa.Text;
            order["billto_city"] = tbGrad.Text;
            order["billto_stateorprovince"] = tbZupanija.Text;
            order["billto_postalcode"] = tbPostanskiBroj.Text;
            order["billto_country"] = tbDrzava.Text;
            Guid guid = _service.Create(order);

            details["salesorderid"] = new EntityReference("salesorder", guid);

            _service.Update(product);
            _service.Create(details);
            MessageBox.Show("Narudžba dovršena.");
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
