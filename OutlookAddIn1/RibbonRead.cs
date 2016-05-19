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
            List<Outlook.MailItem> mailItemList = Logic.GetMailItem(e);
            foreach(Outlook.MailItem mailItem in mailItemList)
            {
                Logic.ForwardMessage(mailItem);
            }
        }

        
    }
}
