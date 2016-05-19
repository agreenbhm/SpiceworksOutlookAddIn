namespace OutlookAddIn1
{
    partial class settingsFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsFrm));
            this.helpdeskEmailText = new System.Windows.Forms.TextBox();
            this.helpdeskEmailLabel = new System.Windows.Forms.Label();
            this.assigneeList = new System.Windows.Forms.ListView();
            this.assigneeListLabel = new System.Windows.Forms.Label();
            this.addAssigneeTextLabel = new System.Windows.Forms.Label();
            this.addAssigneeText = new System.Windows.Forms.TextBox();
            this.addAssigneeButton = new System.Windows.Forms.Button();
            this.removeAssigneeButton = new System.Windows.Forms.Button();
            this.assigneeButtonsLabel = new System.Windows.Forms.Label();
            this.closePromptCheckbox = new System.Windows.Forms.CheckBox();
            this.assignPromptCheckbox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.closeMsgCheckbox = new System.Windows.Forms.CheckBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.createPromptCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // helpdeskEmailText
            // 
            this.helpdeskEmailText.Location = new System.Drawing.Point(12, 12);
            this.helpdeskEmailText.Name = "helpdeskEmailText";
            this.helpdeskEmailText.Size = new System.Drawing.Size(202, 20);
            this.helpdeskEmailText.TabIndex = 0;
            // 
            // helpdeskEmailLabel
            // 
            this.helpdeskEmailLabel.AutoSize = true;
            this.helpdeskEmailLabel.Location = new System.Drawing.Point(220, 15);
            this.helpdeskEmailLabel.Name = "helpdeskEmailLabel";
            this.helpdeskEmailLabel.Size = new System.Drawing.Size(121, 13);
            this.helpdeskEmailLabel.TabIndex = 1;
            this.helpdeskEmailLabel.Text = "Helpdesk Email Address";
            // 
            // assigneeList
            // 
            this.assigneeList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.assigneeList.Location = new System.Drawing.Point(12, 38);
            this.assigneeList.Name = "assigneeList";
            this.assigneeList.Size = new System.Drawing.Size(202, 97);
            this.assigneeList.TabIndex = 4;
            this.assigneeList.UseCompatibleStateImageBehavior = false;
            this.assigneeList.View = System.Windows.Forms.View.List;
            // 
            // assigneeListLabel
            // 
            this.assigneeListLabel.AutoSize = true;
            this.assigneeListLabel.Location = new System.Drawing.Point(220, 75);
            this.assigneeListLabel.Name = "assigneeListLabel";
            this.assigneeListLabel.Size = new System.Drawing.Size(182, 26);
            this.assigneeListLabel.TabIndex = 5;
            this.assigneeListLabel.Text = "Ticket Assignees:\r\nPeople who may be assigned tickets.";
            // 
            // addAssigneeTextLabel
            // 
            this.addAssigneeTextLabel.AutoSize = true;
            this.addAssigneeTextLabel.Location = new System.Drawing.Point(220, 144);
            this.addAssigneeTextLabel.Name = "addAssigneeTextLabel";
            this.addAssigneeTextLabel.Size = new System.Drawing.Size(213, 13);
            this.addAssigneeTextLabel.TabIndex = 6;
            this.addAssigneeTextLabel.Text = "Enter email to add to \"Ticket Assignees\" list";
            // 
            // addAssigneeText
            // 
            this.addAssigneeText.Location = new System.Drawing.Point(12, 141);
            this.addAssigneeText.Name = "addAssigneeText";
            this.addAssigneeText.Size = new System.Drawing.Size(202, 20);
            this.addAssigneeText.TabIndex = 7;
            // 
            // addAssigneeButton
            // 
            this.addAssigneeButton.Location = new System.Drawing.Point(13, 168);
            this.addAssigneeButton.Name = "addAssigneeButton";
            this.addAssigneeButton.Size = new System.Drawing.Size(84, 23);
            this.addAssigneeButton.TabIndex = 8;
            this.addAssigneeButton.Text = "Add Assignee";
            this.addAssigneeButton.UseVisualStyleBackColor = true;
            this.addAssigneeButton.Click += new System.EventHandler(this.addAssigneeButton_Click);
            // 
            // removeAssigneeButton
            // 
            this.removeAssigneeButton.Location = new System.Drawing.Point(109, 168);
            this.removeAssigneeButton.Name = "removeAssigneeButton";
            this.removeAssigneeButton.Size = new System.Drawing.Size(105, 23);
            this.removeAssigneeButton.TabIndex = 9;
            this.removeAssigneeButton.Text = "Remove Assignee";
            this.removeAssigneeButton.UseVisualStyleBackColor = true;
            this.removeAssigneeButton.Click += new System.EventHandler(this.removeAssigneeButton_Click);
            // 
            // assigneeButtonsLabel
            // 
            this.assigneeButtonsLabel.AutoSize = true;
            this.assigneeButtonsLabel.Location = new System.Drawing.Point(220, 173);
            this.assigneeButtonsLabel.Name = "assigneeButtonsLabel";
            this.assigneeButtonsLabel.Size = new System.Drawing.Size(156, 26);
            this.assigneeButtonsLabel.TabIndex = 10;
            this.assigneeButtonsLabel.Text = "Add new assignee to list\r\nor remove highlighted assignee.";
            // 
            // closePromptCheckbox
            // 
            this.closePromptCheckbox.AutoSize = true;
            this.closePromptCheckbox.Location = new System.Drawing.Point(12, 212);
            this.closePromptCheckbox.Name = "closePromptCheckbox";
            this.closePromptCheckbox.Size = new System.Drawing.Size(205, 17);
            this.closePromptCheckbox.TabIndex = 11;
            this.closePromptCheckbox.Text = "Don\'t Prompt For \"Close\" Confirmation";
            this.closePromptCheckbox.UseVisualStyleBackColor = true;
            // 
            // assignPromptCheckbox
            // 
            this.assignPromptCheckbox.AutoSize = true;
            this.assignPromptCheckbox.Location = new System.Drawing.Point(12, 235);
            this.assignPromptCheckbox.Name = "assignPromptCheckbox";
            this.assignPromptCheckbox.Size = new System.Drawing.Size(210, 17);
            this.assignPromptCheckbox.TabIndex = 12;
            this.assignPromptCheckbox.Text = "Don\'t Prompt For \"Assign\" Confirmation";
            this.assignPromptCheckbox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(12, 322);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(345, 322);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // closeMsgCheckbox
            // 
            this.closeMsgCheckbox.AutoSize = true;
            this.closeMsgCheckbox.Location = new System.Drawing.Point(12, 281);
            this.closeMsgCheckbox.Name = "closeMsgCheckbox";
            this.closeMsgCheckbox.Size = new System.Drawing.Size(188, 17);
            this.closeMsgCheckbox.TabIndex = 15;
            this.closeMsgCheckbox.Text = "Close Message After Assign/Close";
            this.closeMsgCheckbox.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(345, 223);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(87, 23);
            this.importButton.TabIndex = 16;
            this.importButton.Text = "Import Settings";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(345, 252);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(87, 23);
            this.exportButton.TabIndex = 17;
            this.exportButton.Text = "Export Settings";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // createPromptCheckbox
            // 
            this.createPromptCheckbox.AutoSize = true;
            this.createPromptCheckbox.Location = new System.Drawing.Point(12, 258);
            this.createPromptCheckbox.Name = "createPromptCheckbox";
            this.createPromptCheckbox.Size = new System.Drawing.Size(243, 17);
            this.createPromptCheckbox.TabIndex = 18;
            this.createPromptCheckbox.Text = "Don\'t Prompt For \"Create Ticket\" Confirmation";
            this.createPromptCheckbox.UseVisualStyleBackColor = true;
            // 
            // settingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 367);
            this.Controls.Add(this.createPromptCheckbox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.closeMsgCheckbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.assignPromptCheckbox);
            this.Controls.Add(this.closePromptCheckbox);
            this.Controls.Add(this.assigneeButtonsLabel);
            this.Controls.Add(this.removeAssigneeButton);
            this.Controls.Add(this.addAssigneeButton);
            this.Controls.Add(this.addAssigneeText);
            this.Controls.Add(this.addAssigneeTextLabel);
            this.Controls.Add(this.assigneeListLabel);
            this.Controls.Add(this.assigneeList);
            this.Controls.Add(this.helpdeskEmailLabel);
            this.Controls.Add(this.helpdeskEmailText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsFrm";
            this.Text = "Spiceworks Outlook AddIn - Settings";
            this.Load += new System.EventHandler(this.settingsFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox helpdeskEmailText;
        private System.Windows.Forms.Label helpdeskEmailLabel;
        private System.Windows.Forms.ListView assigneeList;
        private System.Windows.Forms.Label assigneeListLabel;
        private System.Windows.Forms.Label addAssigneeTextLabel;
        private System.Windows.Forms.TextBox addAssigneeText;
        private System.Windows.Forms.Button addAssigneeButton;
        private System.Windows.Forms.Button removeAssigneeButton;
        private System.Windows.Forms.Label assigneeButtonsLabel;
        private System.Windows.Forms.CheckBox closePromptCheckbox;
        private System.Windows.Forms.CheckBox assignPromptCheckbox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox closeMsgCheckbox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.CheckBox createPromptCheckbox;
    }
}