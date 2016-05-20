using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace OutlookAddIn1
{
    public partial class RibbonMain
    {
        public void hideButtons(int installType)
        {
            if(installType == 1)
            {
                try
                {
                    this.newTicketButton.Visible = false;
                }
                catch { }
            }
            else if(installType == 2)
            {
                try
                {
                    this.button2.Visible = false;
                    this.assignButton.Visible = false;
                    this.closeButton.Visible = false;
                    this.closeTicketResponse.Visible = false;
                    this.button1.Visible = false;
                }
                catch { }
            }
        }

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, RibbonControlEventArgs e)
        {
            try
            {
                List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
                foreach (Outlook.MailItem mailItem in mailItemList)
                {
                    Logic.ForwardMessage(mailItem);
                }
            }
            catch
            {
                MessageBox.Show("Unable to create ticket. Make sure the helpdesk email address is set in Settings."
                        , "Spiceworks Outlook AddIn: Error Creating Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click_1(object sender, RibbonControlEventArgs e)
        {
            try
            {
                settingsFrm settings = new settingsFrm();
                settings.Show();
            }
            catch
            {
                MessageBox.Show("Unable to open settings."
                       , "Spiceworks Outlook AddIn: Error Opening Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void closeButton_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
                foreach (Outlook.MailItem mailItem in mailItemList)
                {
                    Logic.CloseTicket(mailItem);
                }
            }
            catch
            {
                MessageBox.Show("Unable to close ticket. Make sure helpdesk email address is set in Settings."
                      , "Spiceworks Outlook AddIn: Error Closing Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closeTicketResponse_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
                foreach (Outlook.MailItem mailItem in mailItemList)
                {
                    Logic.CloseTicketWithResponse(mailItem);
                }
            }
            catch
            {
                MessageBox.Show("Unable to close ticket. Make sure helpdesk email address is set in Settings."
                      , "Spiceworks Outlook AddIn: Error Closing Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void assignButton_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                assignFrm assign = new assignFrm();
                List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
                var result = assign.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (Outlook.MailItem mailItem in mailItemList)
                    {
                        Logic.AssignTicket(mailItem, assign.returnEmail);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to assign ticket. Make sure assignees are added in Settings."
                        , "Spiceworks Outlook AddIn: Error Assigning Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void newTicketButton_Click(object sender, RibbonControlEventArgs e)
        {
            try {
                Outlook.MailItem mailItem = (Outlook.MailItem)
                    Globals.ThisAddIn.Application.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.To = Properties.Settings.Default.HelpdeskEmail;
                mailItem.Display();
            }
            catch
            {

            }
        }
    }
}
