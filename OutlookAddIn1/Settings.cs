using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace OutlookAddIn1
{
    public partial class settingsFrm : Form
    {

        public settingsFrm()
        {
            InitializeComponent();
        }

        private void settingsFrm_Load(object sender, System.EventArgs e)
        {
            this.helpdeskEmailText.Text = Properties.Settings.Default.HelpdeskEmail;
            this.closePromptCheckbox.Checked = Properties.Settings.Default.NoCloseConf;
            this.assignPromptCheckbox.Checked = Properties.Settings.Default.NoAssignConf;
            this.closeMsgCheckbox.Checked = Properties.Settings.Default.CloseMsg;
            ColumnHeader header = new ColumnHeader();
            header.Text = "Ticket Assignees";
            header.Name = "ticketAssignees";
            header.Width = assigneeList.Width;
            assigneeList.Columns.Add(header);
            if(Properties.Settings.Default.TicketAssignees != null && Properties.Settings.Default.TicketAssignees.Count > 0)
            {
                foreach (string email in Properties.Settings.Default.TicketAssignees)
                {
                    this.assigneeList.Items.Add(email);
                }
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HelpdeskEmail = this.helpdeskEmailText.Text;
            Properties.Settings.Default.NoCloseConf = this.closePromptCheckbox.Checked;
            Properties.Settings.Default.NoAssignConf = this.assignPromptCheckbox.Checked;
            Properties.Settings.Default.CloseMsg = this.closeMsgCheckbox.Checked;
            System.Collections.Specialized.StringCollection assigneeStrCollection = 
                new System.Collections.Specialized.StringCollection();
            foreach(ListViewItem email in this.assigneeList.Items)
            {
                assigneeStrCollection.Add(email.Text);
            }
            Properties.Settings.Default.TicketAssignees = assigneeStrCollection;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addAssigneeButton_Click(object sender, EventArgs e)
        {
            ListViewItem newEmail = assigneeList.FindItemWithText(this.addAssigneeText.Text);
            if (newEmail == null)
            {
                if (!this.addAssigneeText.Text.Contains("@"))
                {
                    MessageBox.Show("Unable to add assignee. Please verify you have entered a valid email address."
                            , "Spiceworks Outlook AddIn: Error Adding Assignee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.assigneeList.Items.Add(this.addAssigneeText.Text);
                    this.addAssigneeText.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Unable to add assignee. Email already in list."
                        , "Spiceworks Outlook AddIn: Error Adding Assignee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void removeAssigneeButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in this.assigneeList.SelectedItems)
            {
                this.assigneeList.Items.Remove(item);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, dynamic> settingsDict = new Dictionary<string, dynamic>();

                settingsDict.Add("HelpdeskEmail", Properties.Settings.Default.HelpdeskEmail);
                settingsDict.Add("CloseMsg", Properties.Settings.Default.CloseMsg.ToString());
                settingsDict.Add("NoAssignConf", Properties.Settings.Default.NoAssignConf.ToString());
                settingsDict.Add("NoCloseConf", Properties.Settings.Default.NoCloseConf.ToString());
                settingsDict.Add("TicketAssignees", Properties.Settings.Default.TicketAssignees);

                string settings = JsonConvert.SerializeObject(settingsDict);

                System.Windows.Forms.SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Configuration Files | *.conf";
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    System.IO.Stream fileStream = saveDialog.OpenFile();
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                    sw.Write(settings);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("Unable to export settings."
                        , "Spiceworks Outlook AddIn: Error Exporting Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }
    }
}
