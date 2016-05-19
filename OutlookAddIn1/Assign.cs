using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAddIn1
{
    public partial class assignFrm : Form
    {
        public string returnEmail { get; set; }

        public assignFrm()
        {
            InitializeComponent();
        }

        private void assignFrm_Load(object sender, EventArgs e)
        {
            this.returnEmail = "";
            if (Properties.Settings.Default.TicketAssignees.Count > 0)
            {
                foreach (string email in Properties.Settings.Default.TicketAssignees)
                {
                    this.assignCombo.Items.Add(email);
                }
            }
        }

        private void assignOK_Click(object sender, EventArgs e)
        {
            if(assignCombo.Text != null && assignCombo.Text != "")
            {
                this.returnEmail = assignCombo.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void assignCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
