using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Drawing;

namespace OutlookAddIn1
{
    public partial class RibbonMain
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RibbonControlEventArgs e)
        {
            List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
            foreach(Outlook.MailItem mailItem in mailItemList)
            {
                Logic.ForwardMessage(mailItem);
            }
        }

        private void button2_Click_1(object sender, RibbonControlEventArgs e)
        {
            settingsFrm settings = new settingsFrm();
            settings.Show();
    
        }

        private void closeButton_Click(object sender, RibbonControlEventArgs e)
        {
            List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
            foreach(Outlook.MailItem mailItem in mailItemList)
            {
                Logic.CloseTicket(mailItem);
            }
        }

        private void closeTicketResponse_Click(object sender, RibbonControlEventArgs e)
        {
            
            List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
            foreach(Outlook.MailItem mailItem in mailItemList)
            {
                Logic.CloseTicketWithResponse(mailItem);
            }
        }
    }
}
