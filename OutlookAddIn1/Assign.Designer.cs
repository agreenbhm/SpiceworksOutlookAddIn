namespace OutlookAddIn1
{
    partial class assignFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(assignFrm));
            this.assignCombo = new System.Windows.Forms.ComboBox();
            this.assignLabel = new System.Windows.Forms.Label();
            this.assignOK = new System.Windows.Forms.Button();
            this.assignCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // assignCombo
            // 
            this.assignCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.assignCombo.FormattingEnabled = true;
            this.assignCombo.Location = new System.Drawing.Point(12, 37);
            this.assignCombo.Name = "assignCombo";
            this.assignCombo.Size = new System.Drawing.Size(259, 21);
            this.assignCombo.TabIndex = 0;
            // 
            // assignLabel
            // 
            this.assignLabel.AutoSize = true;
            this.assignLabel.Location = new System.Drawing.Point(9, 9);
            this.assignLabel.Name = "assignLabel";
            this.assignLabel.Size = new System.Drawing.Size(83, 13);
            this.assignLabel.TabIndex = 1;
            this.assignLabel.Text = "Select Assignee";
            // 
            // assignOK
            // 
            this.assignOK.Location = new System.Drawing.Point(12, 75);
            this.assignOK.Name = "assignOK";
            this.assignOK.Size = new System.Drawing.Size(75, 23);
            this.assignOK.TabIndex = 2;
            this.assignOK.Text = "Assign";
            this.assignOK.UseVisualStyleBackColor = true;
            this.assignOK.Click += new System.EventHandler(this.assignOK_Click);
            // 
            // assignCancel
            // 
            this.assignCancel.Location = new System.Drawing.Point(196, 75);
            this.assignCancel.Name = "assignCancel";
            this.assignCancel.Size = new System.Drawing.Size(75, 23);
            this.assignCancel.TabIndex = 3;
            this.assignCancel.Text = "Cancel";
            this.assignCancel.UseVisualStyleBackColor = true;
            this.assignCancel.Click += new System.EventHandler(this.assignCancel_Click);
            // 
            // assignFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.Controls.Add(this.assignCancel);
            this.Controls.Add(this.assignOK);
            this.Controls.Add(this.assignLabel);
            this.Controls.Add(this.assignCombo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "assignFrm";
            this.Text = "Assign to Ticket";
            this.Load += new System.EventHandler(this.assignFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox assignCombo;
        private System.Windows.Forms.Label assignLabel;
        private System.Windows.Forms.Button assignOK;
        private System.Windows.Forms.Button assignCancel;
    }
}