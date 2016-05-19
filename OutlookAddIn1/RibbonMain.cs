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
            Outlook.MailItem mailItem = Logic.GetMailItem(e);
            Logic.ForwardMessage(mailItem);
        }

        private void button2_Click_1(object sender, RibbonControlEventArgs e)
        {
            //string helpdeskEmail = Properties.Settings.Default.HelpdeskEmail;
            settingsFrm settings = new settingsFrm();
            settings.Show();
            /*
            if (Logic.InputBox("Spiceworks Email Forwarder", "Helpdesk Email Address:", ref helpdeskEmail) == DialogResult.OK)
            {
                Properties.Settings.Default.HelpdeskEmail = helpdeskEmail;
                Properties.Settings.Default.Save();
            }
            */
        }
    }
}
