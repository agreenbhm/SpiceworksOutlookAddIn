namespace OutlookAddIn1
{
    partial class RibbonMain : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonMain()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonMain));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.Spiceworks = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.assignButton = this.Factory.CreateRibbonButton();
            this.closeTicketResponse = this.Factory.CreateRibbonButton();
            this.closeButton = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.newTicketButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.Spiceworks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabMail";
            this.tab1.Groups.Add(this.Spiceworks);
            this.tab1.Label = "TabMail";
            this.tab1.Name = "tab1";
            // 
            // Spiceworks
            // 
            this.Spiceworks.Items.Add(this.button1);
            this.Spiceworks.Items.Add(this.assignButton);
            this.Spiceworks.Items.Add(this.closeTicketResponse);
            this.Spiceworks.Items.Add(this.closeButton);
            this.Spiceworks.Items.Add(this.button2);
            this.Spiceworks.Items.Add(this.newTicketButton);
            this.Spiceworks.Label = "Spiceworks";
            this.Spiceworks.Name = "Spiceworks";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Create Ticket";
            this.button1.Name = "button1";
            this.button1.ScreenTip = "Forward message to Spiceworks using \"created by\" ticket command.";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click_1);
            // 
            // assignButton
            // 
            this.assignButton.Image = ((System.Drawing.Image)(resources.GetObject("assignButton.Image")));
            this.assignButton.Label = "Assign";
            this.assignButton.Name = "assignButton";
            this.assignButton.ShowImage = true;
            this.assignButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.assignButton_Click);
            // 
            // closeTicketResponse
            // 
            this.closeTicketResponse.Image = ((System.Drawing.Image)(resources.GetObject("closeTicketResponse.Image")));
            this.closeTicketResponse.Label = "Close (with reply)";
            this.closeTicketResponse.Name = "closeTicketResponse";
            this.closeTicketResponse.ShowImage = true;
            this.closeTicketResponse.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.closeTicketResponse_Click);
            // 
            // closeButton
            // 
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Label = "Close Ticket";
            this.closeButton.Name = "closeButton";
            this.closeButton.ShowImage = true;
            this.closeButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.closeButton_Click);
            // 
            // button2
            // 
            this.button2.Image = global::OutlookAddIn1.Properties.Resources.spiceworks_app_icon;
            this.button2.Label = "Settings";
            this.button2.Name = "button2";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click_1);
            // 
            // newTicketButton
            // 
            this.newTicketButton.Image = ((System.Drawing.Image)(resources.GetObject("newTicketButton.Image")));
            this.newTicketButton.Label = "New Ticket";
            this.newTicketButton.Name = "newTicketButton";
            this.newTicketButton.ScreenTip = "Forward message to Spiceworks using \"created by\" ticket command.";
            this.newTicketButton.ShowImage = true;
            this.newTicketButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.newTicketButton_Click);
            // 
            // RibbonMain
            // 
            this.Name = "RibbonMain";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton settingsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton closeButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton closeTicketResponse;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton assignButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton newTicketButton;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMain RibbonMain
        {
            get { return this.GetRibbon<RibbonMain>(); }
        }
    }
}
