using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

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
