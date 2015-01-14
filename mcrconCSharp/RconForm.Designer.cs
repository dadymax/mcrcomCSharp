namespace mcrconCSharp
{
    partial class RconForm
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
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.grpHost = new System.Windows.Forms.GroupBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.grpPass = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.mainSplitPanel = new System.Windows.Forms.SplitContainer();
            this.splitCommands = new System.Windows.Forms.SplitContainer();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.radbtnConnectionState = new System.Windows.Forms.RadioButton();
            this.grpConnection.SuspendLayout();
            this.grpHost.SuspendLayout();
            this.grpPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitPanel)).BeginInit();
            this.mainSplitPanel.Panel1.SuspendLayout();
            this.mainSplitPanel.Panel2.SuspendLayout();
            this.mainSplitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCommands)).BeginInit();
            this.splitCommands.Panel1.SuspendLayout();
            this.splitCommands.Panel2.SuspendLayout();
            this.splitCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.radbtnConnectionState);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.grpPass);
            this.grpConnection.Controls.Add(this.grpHost);
            this.grpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConnection.Location = new System.Drawing.Point(0, 0);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(317, 155);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // grpHost
            // 
            this.grpHost.Controls.Add(this.txtHost);
            this.grpHost.Location = new System.Drawing.Point(6, 19);
            this.grpHost.Name = "grpHost";
            this.grpHost.Size = new System.Drawing.Size(306, 47);
            this.grpHost.TabIndex = 0;
            this.grpHost.TabStop = false;
            this.grpHost.Text = "Hostname or IPv4";
            // 
            // txtHost
            // 
            this.txtHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHost.Location = new System.Drawing.Point(3, 16);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(300, 20);
            this.txtHost.TabIndex = 0;
            // 
            // grpPass
            // 
            this.grpPass.Controls.Add(this.txtPass);
            this.grpPass.Location = new System.Drawing.Point(6, 72);
            this.grpPass.Name = "grpPass";
            this.grpPass.Size = new System.Drawing.Size(306, 47);
            this.grpPass.TabIndex = 1;
            this.grpPass.TabStop = false;
            this.grpPass.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Location = new System.Drawing.Point(3, 16);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(300, 20);
            this.txtPass.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 125);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(153, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(0, 0);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(163, 212);
            this.txtResponse.TabIndex = 1;
            // 
            // mainSplitPanel
            // 
            this.mainSplitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitPanel.IsSplitterFixed = true;
            this.mainSplitPanel.Location = new System.Drawing.Point(0, 0);
            this.mainSplitPanel.Name = "mainSplitPanel";
            // 
            // mainSplitPanel.Panel1
            // 
            this.mainSplitPanel.Panel1.Controls.Add(this.splitCommands);
            this.mainSplitPanel.Panel1MinSize = 317;
            // 
            // mainSplitPanel.Panel2
            // 
            this.mainSplitPanel.Panel2.Controls.Add(this.txtResponse);
            this.mainSplitPanel.Size = new System.Drawing.Size(484, 212);
            this.mainSplitPanel.SplitterDistance = 317;
            this.mainSplitPanel.TabIndex = 2;
            // 
            // splitCommands
            // 
            this.splitCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCommands.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitCommands.IsSplitterFixed = true;
            this.splitCommands.Location = new System.Drawing.Point(0, 0);
            this.splitCommands.Name = "splitCommands";
            this.splitCommands.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCommands.Panel1
            // 
            this.splitCommands.Panel1.Controls.Add(this.grpConnection);
            this.splitCommands.Panel1MinSize = 155;
            // 
            // splitCommands.Panel2
            // 
            this.splitCommands.Panel2.Controls.Add(this.txtCommand);
            this.splitCommands.Panel2.Controls.Add(this.btnSendCommand);
            this.splitCommands.Size = new System.Drawing.Size(317, 212);
            this.splitCommands.SplitterDistance = 155;
            this.splitCommands.TabIndex = 1;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(6, 29);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(75, 23);
            this.btnSendCommand.TabIndex = 0;
            this.btnSendCommand.Text = "Send";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(6, 3);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(306, 20);
            this.txtCommand.TabIndex = 1;
            // 
            // radbtnConnectionState
            // 
            this.radbtnConnectionState.AutoSize = true;
            this.radbtnConnectionState.Location = new System.Drawing.Point(177, 128);
            this.radbtnConnectionState.Name = "radbtnConnectionState";
            this.radbtnConnectionState.Size = new System.Drawing.Size(135, 17);
            this.radbtnConnectionState.TabIndex = 3;
            this.radbtnConnectionState.Text = "Connection established";
            this.radbtnConnectionState.UseVisualStyleBackColor = true;
            // 
            // RconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.mainSplitPanel);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "RconForm";
            this.Text = "Minecraft Rcon by dadymax";
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpHost.ResumeLayout(false);
            this.grpHost.PerformLayout();
            this.grpPass.ResumeLayout(false);
            this.grpPass.PerformLayout();
            this.mainSplitPanel.Panel1.ResumeLayout(false);
            this.mainSplitPanel.Panel2.ResumeLayout(false);
            this.mainSplitPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitPanel)).EndInit();
            this.mainSplitPanel.ResumeLayout(false);
            this.splitCommands.Panel1.ResumeLayout(false);
            this.splitCommands.Panel2.ResumeLayout(false);
            this.splitCommands.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCommands)).EndInit();
            this.splitCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.GroupBox grpHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.SplitContainer mainSplitPanel;
        private System.Windows.Forms.SplitContainer splitCommands;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.RadioButton radbtnConnectionState;
    }
}

