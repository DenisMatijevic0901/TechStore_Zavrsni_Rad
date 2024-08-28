using Microsoft.Crm.Sdk.Messages;
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
using System.Windows.Forms;

namespace TechStoreZavrsni
{
    public partial class PregledCiljeva : Form
    {
        public CrmServiceClient _service = null;

        public PregledCiljeva(CrmServiceClient s)
        {
            InitializeComponent();
            _service = s;
        }

        private void PregledCiljeva_Load(object sender, EventArgs e)
        {
            OsvjeziDgv();
            panel.BackColor = ColorTranslator.FromHtml("#011234");
        }

        private void OsvjeziDgv()
        {
            dgvGoals.Rows.Clear();

            QueryExpression qe = new QueryExpression("goal");
            qe.ColumnSet = new ColumnSet("title", "targetdecimal", "targetmoney", "actualmoney", "actualdecimal", "percentage", "statuscode", "goalid", "metricid");
            EntityCollection ec = _service.RetrieveMultiple(qe);

            foreach (Entity e2 in ec.Entities)
            {
                DataGridViewRow row = (DataGridViewRow)dgvGoals.Rows[0].Clone();
                EntityReference test = e2.GetAttributeValue<EntityReference>("metricid");
                row.Cells[0].Value = e2["title"];

                if (test.Id  == ServiceClient.revenue)
                    row.Cells[1].Value = Math.Round(e2.GetAttributeValue<Money>("targetmoney").Value, 2);
                else
                    row.Cells[1].Value = Math.Round(decimal.Parse(e2["targetdecimal"].ToString()), 0);

                try
                {
                    if (test.Id == ServiceClient.revenue) { 
                        row.Cells[2].Value = Math.Round(e2.GetAttributeValue<Money>("actualmoney").Value, 2);
                    }
                    else { 
                        row.Cells[2].Value = Math.Round(decimal.Parse(e2["actualdecimal"].ToString()), 0);
                    }
                }
                catch (Exception ex)
                {
                    Entity goal = new Entity("goal");
                    goal.Id = e2.Id;
                    goal.Attributes["isoverride"] = true;
                    if (test.Id == ServiceClient.revenue)
                        goal.Attributes["actualmoney"] = new Money(decimal.Parse("0"));
                    else
                        goal.Attributes["actualdecimal"] = decimal.Parse("0");

                    _service.Update(goal);
                    row.Cells[2].Value = 0;
                }

                try
                {
                    row.Cells[3].Value = Math.Round(decimal.Parse(e2["percentage"].ToString()), 2);
                }
                catch (KeyNotFoundException ex)
                {
                    Entity goal = new Entity("goal");
                    goal.Id = e2.Id;
                    goal.Attributes["isoverride"] = true;
                    goal.Attributes["percentage"] = decimal.Parse("0");
                    _service.Update(goal);
                    row.Cells[3].Value = 0;
                }

                var status = ((OptionSetValue)e2["statuscode"]).Value;
                if (status == 0)
                    row.Cells[4].Value = "Aktivan";
                else if (status == 1)
                    row.Cells[4].Value = "Zatvoren";

                if (decimal.Parse(row.Cells[3].Value.ToString()) > 100)
                    row.Cells[3].Value = decimal.Parse("100.00");
                row.Cells[3].Value += "%";
                row.Cells[5].Value = e2["goalid"];

                dgvGoals.Rows.Add(row);
            }

            foreach (DataGridViewRow redak in dgvGoals.Rows)
            {
                if (redak != dgvGoals.Rows[dgvGoals.RowCount - 1])
                {
                    if (redak.Cells[4].Value.ToString() == "Zatvoren")
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



        private void dgvGoals_SelectionChanged(object sender, EventArgs e)
        {
            tbID.Text = dgvGoals.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addGoal = new UnesiCilj(_service);
            addGoal.ShowDialog();
            OsvjeziDgv();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            _service.Delete("goal", new Guid(tbID.Text));
            OsvjeziDgv();
            MessageBox.Show("Cilj obrisan");
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
