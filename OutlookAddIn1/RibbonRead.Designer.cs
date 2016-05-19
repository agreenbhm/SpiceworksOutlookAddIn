namespace OutlookAddIn1
{
    partial class RibbonRead : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonRead()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonRead));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.Spiceworks = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.Spiceworks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReadMessage";
            this.tab1.Groups.Add(this.Spiceworks);
            this.tab1.Label = "TabReadMessage";
            this.tab1.Name = "tab1";
            // 
            // Spiceworks
            // 
            this.Spiceworks.Items.Add(this.button1);
            this.Spiceworks.Label = "Spiceworks";
            this.Spiceworks.Name = "Spiceworks";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Forward to Spiceworks";
            this.button1.Name = "button1";
            this.button1.ScreenTip = "Forward message to Spiceworks using \"created by\" ticket command.";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // RibbonRead
            // 
            this.Name = "RibbonRead";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonRead_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.Spiceworks.ResumeLayout(false);
            this.Spiceworks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Spiceworks;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonRead RibbonRead
        {
            get { return this.GetRibbon<RibbonRead>(); }
        }
    }
}
