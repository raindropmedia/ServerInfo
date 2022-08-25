namespace ServerInfo
{
    partial class Configuration
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.saveButton = new System.Windows.Forms.Button();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.showMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectApplication = new System.Windows.Forms.OpenFileDialog();
            this.selectapplicationButton = new System.Windows.Forms.Button();
            this.listipButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(270, 460);
            this.saveButton.Margin = new System.Windows.Forms.Padding(5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(219, 88);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.Location = new System.Drawing.Point(264, 39);
            this.lblHelloWorld.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(86, 31);
            this.lblHelloWorld.TabIndex = 1;
            this.lblHelloWorld.Text = "label1";
            // 
            // showMessageCheckBox
            // 
            this.showMessageCheckBox.AutoSize = true;
            this.showMessageCheckBox.Checked = true;
            this.showMessageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMessageCheckBox.Location = new System.Drawing.Point(270, 378);
            this.showMessageCheckBox.Name = "showMessageCheckBox";
            this.showMessageCheckBox.Size = new System.Drawing.Size(225, 35);
            this.showMessageCheckBox.TabIndex = 2;
            this.showMessageCheckBox.Text = "Show Message";
            this.showMessageCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(583, 460);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(219, 88);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectApplication
            // 
            this.selectApplication.FileName = "Anwendung auswählen";
            this.selectApplication.Filter = "Anwendungen (*.exe)|*.exe";
            // 
            // selectapplicationButton
            // 
            this.selectapplicationButton.Location = new System.Drawing.Point(270, 88);
            this.selectapplicationButton.Margin = new System.Windows.Forms.Padding(5);
            this.selectapplicationButton.Name = "selectapplicationButton";
            this.selectapplicationButton.Size = new System.Drawing.Size(219, 88);
            this.selectapplicationButton.TabIndex = 4;
            this.selectapplicationButton.Text = "Anwendung auswählen";
            this.selectapplicationButton.UseVisualStyleBackColor = true;
            this.selectapplicationButton.Click += new System.EventHandler(this.selectapplicationButton_Click);
            // 
            // listipButton
            // 
            this.listipButton.Location = new System.Drawing.Point(583, 88);
            this.listipButton.Margin = new System.Windows.Forms.Padding(5);
            this.listipButton.Name = "listipButton";
            this.listipButton.Size = new System.Drawing.Size(219, 88);
            this.listipButton.TabIndex = 5;
            this.listipButton.Text = "List IP";
            this.listipButton.UseVisualStyleBackColor = true;
            this.listipButton.Click += new System.EventHandler(this.listipButton_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 698);
            this.Controls.Add(this.listipButton);
            this.Controls.Add(this.selectapplicationButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.showMessageCheckBox);
            this.Controls.Add(this.lblHelloWorld);
            this.Controls.Add(this.saveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.Text = "RDM ServerInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveSettings);
            this.Load += new System.EventHandler(this.LoadSettings);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label lblHelloWorld;
        private System.Windows.Forms.CheckBox showMessageCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.OpenFileDialog selectApplication;
        private System.Windows.Forms.Button selectapplicationButton;
        private System.Windows.Forms.Button listipButton;
    }
}

