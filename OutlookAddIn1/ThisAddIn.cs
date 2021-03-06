﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OutlookAddIn1
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.LastLaunch = System.DateTime.Now;
            Properties.Settings.Default.Save();
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += 
                new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

            int installType = 1;
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\DrewGreen.net.SpiceworksOutlookAddIn");
                if (key != null)
                {
                    object regInstType = key.GetValue("InstallType");
                    if (regInstType != null)
                    {
                        installType = (int)regInstType;
                    }
                    else
                    {
                        key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\DrewGreen.net.SpiceworksOutlookAddIn");
                        if (key != null)
                        {
                            regInstType = key.GetValue("InstallType");
                            if (regInstType != null)
                            {
                                installType = (int)regInstType;
                            }
                        }
                    }
                }
                else
                {
                    key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\DrewGreen.net.SpiceworksOutlookAddIn");
                    if (key != null)
                    {
                        object regInstType = key.GetValue("InstallType");
                        if (regInstType != null)
                        {
                            installType = (int)regInstType;
                        }
                    }
                }
            }
            catch (Exception error)
            {

            }

            Globals.Ribbons.RibbonRead.hideButtons(installType);
            Globals.Ribbons.RibbonMain.hideButtons(installType);

            if (Properties.Settings.Default.HelpdeskEmail == "" || Properties.Settings.Default.HelpdeskEmail == null)
            {
                try
                {
                    string helpdeskEmail = "";
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\DrewGreen.net.SpiceworksOutlookAddIn");
                    if(key != null)
                    {
                        helpdeskEmail = (string)key.GetValue("HelpdeskEmail");
                    }
                    else
                    {
                        key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Office\\Outlook\\Addins\\DrewGreen.net.SpiceworksOutlookAddIn");
                        if (key != null)
                        {
                            helpdeskEmail = (string)key.GetValue("HelpdeskEmail");
                        }
                    }
                    if(helpdeskEmail != null)
                    {
                        Properties.Settings.Default.HelpdeskEmail = helpdeskEmail;
                        Properties.Settings.Default.Save();
                    }
                }
                catch { }
            }
        }

        void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
