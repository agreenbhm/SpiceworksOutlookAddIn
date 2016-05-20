using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;
using System.Collections;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows.Forms;

namespace OutlookAddIn1
{
    [RunInstaller(true)]
    public class MyInstallerClass : Installer
    {
        public MyInstallerClass() : base()
        {

        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string helpdeskEmail = Context.Parameters["HelpdeskEmail"];
            //Properties.Settings.Default.HelpdeskEmail = Context.Parameters["HelpdeskEmail"];
            //Properties.Settings.Default.Save();
            //MessageBox.Show(Context.Parameters["HelpdeskEmail"], "Custom Action Debug", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RegistryKey key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\DrewGreen.net.SpiceworksOutlookAddIn");
            if (key != null)
            {
                key.SetValue("HelpdeskEmail", helpdeskEmail);
                key.Close();
            }

        }
    }
}

