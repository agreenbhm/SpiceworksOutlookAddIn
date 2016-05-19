using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace OutlookAddIn1
{
    public partial class RibbonRead
    {
        private void RibbonRead_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
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

        private void button2_Click(object sender, RibbonControlEventArgs e)
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
    }
}
