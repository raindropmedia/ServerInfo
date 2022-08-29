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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.saveButton = new System.Windows.Forms.Button();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.showMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectApplication = new System.Windows.Forms.OpenFileDialog();
            this.selectapplicationButton = new System.Windows.Forms.Button();
            this.listipButton = new System.Windows.Forms.Button();
            this.startAppButton = new System.Windows.Forms.Button();
            this.getDiskInfoButton = new System.Windows.Forms.Button();
            this.getCpuInfoButton = new System.Windows.Forms.Button();
            this.getDisplayInfoButton = new System.Windows.Forms.Button();
            this.readComPortsButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comPortSelect = new System.Windows.Forms.ComboBox();
            this.connectComButton = new System.Windows.Forms.Button();
            this.sendHelloButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(152, 297);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 57);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.Location = new System.Drawing.Point(148, 25);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(51, 20);
            this.lblHelloWorld.TabIndex = 1;
            this.lblHelloWorld.Text = "label1";
            // 
            // showMessageCheckBox
            // 
            this.showMessageCheckBox.AutoSize = true;
            this.showMessageCheckBox.Checked = true;
            this.showMessageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMessageCheckBox.Location = new System.Drawing.Point(152, 244);
            this.showMessageCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showMessageCheckBox.Name = "showMessageCheckBox";
            this.showMessageCheckBox.Size = new System.Drawing.Size(144, 24);
            this.showMessageCheckBox.TabIndex = 2;
            this.showMessageCheckBox.Text = "Show Message";
            this.showMessageCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(328, 297);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(123, 57);
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
            this.selectapplicationButton.Location = new System.Drawing.Point(152, 57);
            this.selectapplicationButton.Name = "selectapplicationButton";
            this.selectapplicationButton.Size = new System.Drawing.Size(123, 57);
            this.selectapplicationButton.TabIndex = 4;
            this.selectapplicationButton.Text = "Anwendung auswählen";
            this.selectapplicationButton.UseVisualStyleBackColor = true;
            this.selectapplicationButton.Click += new System.EventHandler(this.selectapplicationButton_Click);
            // 
            // listipButton
            // 
            this.listipButton.Location = new System.Drawing.Point(328, 57);
            this.listipButton.Name = "listipButton";
            this.listipButton.Size = new System.Drawing.Size(123, 57);
            this.listipButton.TabIndex = 5;
            this.listipButton.Text = "List IP";
            this.listipButton.UseVisualStyleBackColor = true;
            this.listipButton.Click += new System.EventHandler(this.listipButton_Click);
            // 
            // startAppButton
            // 
            this.startAppButton.Location = new System.Drawing.Point(152, 120);
            this.startAppButton.Name = "startAppButton";
            this.startAppButton.Size = new System.Drawing.Size(123, 57);
            this.startAppButton.TabIndex = 6;
            this.startAppButton.Text = "Anwendung starten";
            this.startAppButton.UseVisualStyleBackColor = true;
            this.startAppButton.Click += new System.EventHandler(this.startAppButton_Click);
            // 
            // getDiskInfoButton
            // 
            this.getDiskInfoButton.Location = new System.Drawing.Point(586, 57);
            this.getDiskInfoButton.Name = "getDiskInfoButton";
            this.getDiskInfoButton.Size = new System.Drawing.Size(123, 57);
            this.getDiskInfoButton.TabIndex = 7;
            this.getDiskInfoButton.Text = "Disk Info";
            this.getDiskInfoButton.UseVisualStyleBackColor = true;
            this.getDiskInfoButton.Click += new System.EventHandler(this.getDiskInfoButton_Click);
            // 
            // getCpuInfoButton
            // 
            this.getCpuInfoButton.Location = new System.Drawing.Point(457, 57);
            this.getCpuInfoButton.Name = "getCpuInfoButton";
            this.getCpuInfoButton.Size = new System.Drawing.Size(123, 57);
            this.getCpuInfoButton.TabIndex = 8;
            this.getCpuInfoButton.Text = "CPU Info";
            this.getCpuInfoButton.UseVisualStyleBackColor = true;
            this.getCpuInfoButton.Click += new System.EventHandler(this.getCpuInfoButton_Click);
            // 
            // getDisplayInfoButton
            // 
            this.getDisplayInfoButton.Location = new System.Drawing.Point(586, 120);
            this.getDisplayInfoButton.Name = "getDisplayInfoButton";
            this.getDisplayInfoButton.Size = new System.Drawing.Size(123, 57);
            this.getDisplayInfoButton.TabIndex = 9;
            this.getDisplayInfoButton.TabStop = false;
            this.getDisplayInfoButton.Text = "Display Info";
            this.getDisplayInfoButton.UseVisualStyleBackColor = true;
            this.getDisplayInfoButton.Click += new System.EventHandler(this.getDisplayInfoButton_Click);
            // 
            // readComPortsButton
            // 
            this.readComPortsButton.Location = new System.Drawing.Point(457, 183);
            this.readComPortsButton.Name = "readComPortsButton";
            this.readComPortsButton.Size = new System.Drawing.Size(123, 57);
            this.readComPortsButton.TabIndex = 10;
            this.readComPortsButton.TabStop = false;
            this.readComPortsButton.Text = "Read ComPorts";
            this.readComPortsButton.UseVisualStyleBackColor = true;
            this.readComPortsButton.Click += new System.EventHandler(this.readComPortsButton_Click);
            // 
            // comPortSelect
            // 
            this.comPortSelect.FormattingEnabled = true;
            this.comPortSelect.Location = new System.Drawing.Point(457, 245);
            this.comPortSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comPortSelect.Name = "comPortSelect";
            this.comPortSelect.Size = new System.Drawing.Size(254, 28);
            this.comPortSelect.TabIndex = 11;
            this.comPortSelect.SelectedIndexChanged += new System.EventHandler(this.ChangedComIndex);
            // 
            // connectComButton
            // 
            this.connectComButton.Location = new System.Drawing.Point(586, 183);
            this.connectComButton.Name = "connectComButton";
            this.connectComButton.Size = new System.Drawing.Size(123, 57);
            this.connectComButton.TabIndex = 12;
            this.connectComButton.TabStop = false;
            this.connectComButton.Text = "Connect";
            this.connectComButton.UseVisualStyleBackColor = true;
            this.connectComButton.Click += new System.EventHandler(this.connectComButton_Click);
            // 
            // sendHelloButton
            // 
            this.sendHelloButton.Location = new System.Drawing.Point(586, 297);
            this.sendHelloButton.Name = "sendHelloButton";
            this.sendHelloButton.Size = new System.Drawing.Size(123, 57);
            this.sendHelloButton.TabIndex = 13;
            this.sendHelloButton.TabStop = false;
            this.sendHelloButton.Text = "Send Hello World";
            this.sendHelloButton.UseVisualStyleBackColor = true;
            this.sendHelloButton.Click += new System.EventHandler(this.sendHelloButton_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendHelloButton);
            this.Controls.Add(this.connectComButton);
            this.Controls.Add(this.comPortSelect);
            this.Controls.Add(this.readComPortsButton);
            this.Controls.Add(this.getDisplayInfoButton);
            this.Controls.Add(this.getCpuInfoButton);
            this.Controls.Add(this.getDiskInfoButton);
            this.Controls.Add(this.startAppButton);
            this.Controls.Add(this.listipButton);
            this.Controls.Add(this.selectapplicationButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.showMessageCheckBox);
            this.Controls.Add(this.lblHelloWorld);
            this.Controls.Add(this.saveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button startAppButton;
        private System.Windows.Forms.Button getDiskInfoButton;
        private System.Windows.Forms.Button getCpuInfoButton;
        private System.Windows.Forms.Button getDisplayInfoButton;
        private System.Windows.Forms.Button readComPortsButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comPortSelect;
        private System.Windows.Forms.Button connectComButton;
        private System.Windows.Forms.Button sendHelloButton;
    }
}

