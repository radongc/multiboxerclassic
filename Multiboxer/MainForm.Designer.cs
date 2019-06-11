namespace Multiboxer
{
    partial class MainForm
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
            this.button_StartMultiboxing = new System.Windows.Forms.Button();
            this.tabControl_MainWindow = new System.Windows.Forms.TabControl();
            this.tabPage_Multiboxing = new System.Windows.Forms.TabPage();
            this.button_ClearConsole = new System.Windows.Forms.Button();
            this.checkBox_LogErrors = new System.Windows.Forms.CheckBox();
            this.checkBox_LogDebugs = new System.Windows.Forms.CheckBox();
            this.checkBox_LogMessages = new System.Windows.Forms.CheckBox();
            this.richTextBox_MainDebugConsole = new System.Windows.Forms.RichTextBox();
            this.button_MasterClientListHelp = new System.Windows.Forms.Button();
            this.label_SelectMasterClient = new System.Windows.Forms.Label();
            this.button_RefreshClients = new System.Windows.Forms.Button();
            this.listBox_SelectMasterClient = new System.Windows.Forms.ListBox();
            this.tabPage_IgnoreList = new System.Windows.Forms.TabPage();
            this.checkBox_Whitelist = new System.Windows.Forms.CheckBox();
            this.checkBox_Blacklist = new System.Windows.Forms.CheckBox();
            this.checkBox_EnableIgnoreList = new System.Windows.Forms.CheckBox();
            this.button_SaveIgnoreList = new System.Windows.Forms.Button();
            this.button_IgnoreListHelp = new System.Windows.Forms.Button();
            this.label_IgnoreList = new System.Windows.Forms.Label();
            this.richTextBox_IgnoreList = new System.Windows.Forms.RichTextBox();
            this.statusStrip_MainStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpProvider_IgnoreList = new System.Windows.Forms.HelpProvider();
            this.tabPage_GameClients = new System.Windows.Forms.TabPage();
            this.panelClientInfo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelGameVersion = new System.Windows.Forms.Label();
            this.labelRealmName = new System.Windows.Forms.Label();
            this.labelCharName = new System.Windows.Forms.Label();
            this.labelCharClassName = new System.Windows.Forms.Label();
            this.labelCharLocation = new System.Windows.Forms.Label();
            this.tabControl_MainWindow.SuspendLayout();
            this.tabPage_Multiboxing.SuspendLayout();
            this.tabPage_IgnoreList.SuspendLayout();
            this.statusStrip_MainStatus.SuspendLayout();
            this.tabPage_GameClients.SuspendLayout();
            this.panelClientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_StartMultiboxing
            // 
            this.button_StartMultiboxing.Location = new System.Drawing.Point(505, 316);
            this.button_StartMultiboxing.Name = "button_StartMultiboxing";
            this.button_StartMultiboxing.Size = new System.Drawing.Size(152, 35);
            this.button_StartMultiboxing.TabIndex = 0;
            this.button_StartMultiboxing.Text = "Start Multiboxing";
            this.button_StartMultiboxing.UseVisualStyleBackColor = true;
            this.button_StartMultiboxing.Click += new System.EventHandler(this.button_StartMultiboxing_Click);
            // 
            // tabControl_MainWindow
            // 
            this.tabControl_MainWindow.Controls.Add(this.tabPage_Multiboxing);
            this.tabControl_MainWindow.Controls.Add(this.tabPage_IgnoreList);
            this.tabControl_MainWindow.Controls.Add(this.tabPage_GameClients);
            this.tabControl_MainWindow.Location = new System.Drawing.Point(-2, 3);
            this.tabControl_MainWindow.Name = "tabControl_MainWindow";
            this.tabControl_MainWindow.SelectedIndex = 0;
            this.tabControl_MainWindow.Size = new System.Drawing.Size(677, 401);
            this.tabControl_MainWindow.TabIndex = 1;
            // 
            // tabPage_Multiboxing
            // 
            this.tabPage_Multiboxing.Controls.Add(this.button_ClearConsole);
            this.tabPage_Multiboxing.Controls.Add(this.checkBox_LogErrors);
            this.tabPage_Multiboxing.Controls.Add(this.checkBox_LogDebugs);
            this.tabPage_Multiboxing.Controls.Add(this.checkBox_LogMessages);
            this.tabPage_Multiboxing.Controls.Add(this.richTextBox_MainDebugConsole);
            this.tabPage_Multiboxing.Controls.Add(this.button_MasterClientListHelp);
            this.tabPage_Multiboxing.Controls.Add(this.label_SelectMasterClient);
            this.tabPage_Multiboxing.Controls.Add(this.button_RefreshClients);
            this.tabPage_Multiboxing.Controls.Add(this.listBox_SelectMasterClient);
            this.tabPage_Multiboxing.Controls.Add(this.button_StartMultiboxing);
            this.tabPage_Multiboxing.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Multiboxing.Name = "tabPage_Multiboxing";
            this.tabPage_Multiboxing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Multiboxing.Size = new System.Drawing.Size(669, 375);
            this.tabPage_Multiboxing.TabIndex = 0;
            this.tabPage_Multiboxing.Text = "Multiboxing";
            this.tabPage_Multiboxing.UseVisualStyleBackColor = true;
            // 
            // button_ClearConsole
            // 
            this.button_ClearConsole.Location = new System.Drawing.Point(183, 316);
            this.button_ClearConsole.Name = "button_ClearConsole";
            this.button_ClearConsole.Size = new System.Drawing.Size(49, 35);
            this.button_ClearConsole.TabIndex = 9;
            this.button_ClearConsole.Text = "Clear";
            this.button_ClearConsole.UseVisualStyleBackColor = true;
            this.button_ClearConsole.Click += new System.EventHandler(this.button_ClearConsole_Click);
            // 
            // checkBox_LogErrors
            // 
            this.checkBox_LogErrors.AutoSize = true;
            this.checkBox_LogErrors.Checked = true;
            this.checkBox_LogErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_LogErrors.Location = new System.Drawing.Point(574, 9);
            this.checkBox_LogErrors.Name = "checkBox_LogErrors";
            this.checkBox_LogErrors.Size = new System.Drawing.Size(83, 19);
            this.checkBox_LogErrors.TabIndex = 8;
            this.checkBox_LogErrors.Text = "Error Logs";
            this.checkBox_LogErrors.UseVisualStyleBackColor = true;
            this.checkBox_LogErrors.CheckedChanged += new System.EventHandler(this.checkBox_LogError_CheckedChanged);
            // 
            // checkBox_LogDebugs
            // 
            this.checkBox_LogDebugs.AutoSize = true;
            this.checkBox_LogDebugs.Checked = true;
            this.checkBox_LogDebugs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_LogDebugs.Location = new System.Drawing.Point(475, 9);
            this.checkBox_LogDebugs.Name = "checkBox_LogDebugs";
            this.checkBox_LogDebugs.Size = new System.Drawing.Size(93, 19);
            this.checkBox_LogDebugs.TabIndex = 7;
            this.checkBox_LogDebugs.Text = "Debug Logs";
            this.checkBox_LogDebugs.UseVisualStyleBackColor = true;
            this.checkBox_LogDebugs.CheckedChanged += new System.EventHandler(this.checkBox_LogDebug_CheckedChanged);
            // 
            // checkBox_LogMessages
            // 
            this.checkBox_LogMessages.AutoSize = true;
            this.checkBox_LogMessages.Checked = true;
            this.checkBox_LogMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_LogMessages.Location = new System.Drawing.Point(362, 9);
            this.checkBox_LogMessages.Name = "checkBox_LogMessages";
            this.checkBox_LogMessages.Size = new System.Drawing.Size(107, 19);
            this.checkBox_LogMessages.TabIndex = 6;
            this.checkBox_LogMessages.Text = "Message Logs";
            this.checkBox_LogMessages.UseVisualStyleBackColor = true;
            this.checkBox_LogMessages.CheckedChanged += new System.EventHandler(this.checkBox_LogMessages_CheckedChanged);
            // 
            // richTextBox_MainDebugConsole
            // 
            this.richTextBox_MainDebugConsole.Location = new System.Drawing.Point(183, 34);
            this.richTextBox_MainDebugConsole.Name = "richTextBox_MainDebugConsole";
            this.richTextBox_MainDebugConsole.ReadOnly = true;
            this.richTextBox_MainDebugConsole.Size = new System.Drawing.Size(474, 276);
            this.richTextBox_MainDebugConsole.TabIndex = 5;
            this.richTextBox_MainDebugConsole.Text = "";
            // 
            // button_MasterClientListHelp
            // 
            this.button_MasterClientListHelp.Location = new System.Drawing.Point(145, 34);
            this.button_MasterClientListHelp.Name = "button_MasterClientListHelp";
            this.button_MasterClientListHelp.Size = new System.Drawing.Size(27, 24);
            this.button_MasterClientListHelp.TabIndex = 4;
            this.button_MasterClientListHelp.Text = "?";
            this.button_MasterClientListHelp.UseVisualStyleBackColor = true;
            this.button_MasterClientListHelp.Click += new System.EventHandler(this.button_MasterClientListHelp_Click);
            // 
            // label_SelectMasterClient
            // 
            this.label_SelectMasterClient.AutoSize = true;
            this.label_SelectMasterClient.Location = new System.Drawing.Point(29, 40);
            this.label_SelectMasterClient.Name = "label_SelectMasterClient";
            this.label_SelectMasterClient.Size = new System.Drawing.Size(119, 15);
            this.label_SelectMasterClient.TabIndex = 3;
            this.label_SelectMasterClient.Text = "Select Master Client:";
            // 
            // button_RefreshClients
            // 
            this.button_RefreshClients.Location = new System.Drawing.Point(57, 216);
            this.button_RefreshClients.Name = "button_RefreshClients";
            this.button_RefreshClients.Size = new System.Drawing.Size(88, 34);
            this.button_RefreshClients.TabIndex = 2;
            this.button_RefreshClients.Text = "Refresh";
            this.button_RefreshClients.UseVisualStyleBackColor = true;
            this.button_RefreshClients.Click += new System.EventHandler(this.button_RefreshClients_Click);
            // 
            // listBox_SelectMasterClient
            // 
            this.listBox_SelectMasterClient.FormattingEnabled = true;
            this.listBox_SelectMasterClient.Location = new System.Drawing.Point(32, 63);
            this.listBox_SelectMasterClient.Name = "listBox_SelectMasterClient";
            this.listBox_SelectMasterClient.Size = new System.Drawing.Size(140, 147);
            this.listBox_SelectMasterClient.TabIndex = 1;
            this.listBox_SelectMasterClient.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectMasterClient_SelectedIndexChanged);
            // 
            // tabPage_IgnoreList
            // 
            this.tabPage_IgnoreList.Controls.Add(this.checkBox_Whitelist);
            this.tabPage_IgnoreList.Controls.Add(this.checkBox_Blacklist);
            this.tabPage_IgnoreList.Controls.Add(this.checkBox_EnableIgnoreList);
            this.tabPage_IgnoreList.Controls.Add(this.button_SaveIgnoreList);
            this.tabPage_IgnoreList.Controls.Add(this.button_IgnoreListHelp);
            this.tabPage_IgnoreList.Controls.Add(this.label_IgnoreList);
            this.tabPage_IgnoreList.Controls.Add(this.richTextBox_IgnoreList);
            this.tabPage_IgnoreList.Location = new System.Drawing.Point(4, 22);
            this.tabPage_IgnoreList.Name = "tabPage_IgnoreList";
            this.tabPage_IgnoreList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_IgnoreList.Size = new System.Drawing.Size(669, 375);
            this.tabPage_IgnoreList.TabIndex = 1;
            this.tabPage_IgnoreList.Text = "Ignore List";
            this.tabPage_IgnoreList.UseVisualStyleBackColor = true;
            // 
            // checkBox_Whitelist
            // 
            this.checkBox_Whitelist.AutoSize = true;
            this.checkBox_Whitelist.Location = new System.Drawing.Point(376, 97);
            this.checkBox_Whitelist.Name = "checkBox_Whitelist";
            this.checkBox_Whitelist.Size = new System.Drawing.Size(132, 19);
            this.checkBox_Whitelist.TabIndex = 6;
            this.checkBox_Whitelist.Text = "Whitelist these keys";
            this.checkBox_Whitelist.UseVisualStyleBackColor = true;
            this.checkBox_Whitelist.CheckedChanged += new System.EventHandler(this.checkBox_Whitelist_CheckedChanged);
            // 
            // checkBox_Blacklist
            // 
            this.checkBox_Blacklist.AutoSize = true;
            this.checkBox_Blacklist.Checked = true;
            this.checkBox_Blacklist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Blacklist.Location = new System.Drawing.Point(376, 72);
            this.checkBox_Blacklist.Name = "checkBox_Blacklist";
            this.checkBox_Blacklist.Size = new System.Drawing.Size(131, 19);
            this.checkBox_Blacklist.TabIndex = 5;
            this.checkBox_Blacklist.Text = "Blacklist these keys";
            this.checkBox_Blacklist.UseVisualStyleBackColor = true;
            this.checkBox_Blacklist.CheckedChanged += new System.EventHandler(this.checkBox_Blacklist_CheckedChanged);
            // 
            // checkBox_EnableIgnoreList
            // 
            this.checkBox_EnableIgnoreList.AutoSize = true;
            this.checkBox_EnableIgnoreList.Checked = true;
            this.checkBox_EnableIgnoreList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_EnableIgnoreList.Location = new System.Drawing.Point(376, 47);
            this.checkBox_EnableIgnoreList.Name = "checkBox_EnableIgnoreList";
            this.checkBox_EnableIgnoreList.Size = new System.Drawing.Size(122, 19);
            this.checkBox_EnableIgnoreList.TabIndex = 4;
            this.checkBox_EnableIgnoreList.Text = "Enable IgnoreList";
            this.checkBox_EnableIgnoreList.UseVisualStyleBackColor = true;
            this.checkBox_EnableIgnoreList.CheckedChanged += new System.EventHandler(this.checkBox_EnableIgnoreList_CheckedChanged);
            // 
            // button_SaveIgnoreList
            // 
            this.button_SaveIgnoreList.Location = new System.Drawing.Point(295, 17);
            this.button_SaveIgnoreList.Name = "button_SaveIgnoreList";
            this.button_SaveIgnoreList.Size = new System.Drawing.Size(75, 24);
            this.button_SaveIgnoreList.TabIndex = 3;
            this.button_SaveIgnoreList.Text = "Save";
            this.button_SaveIgnoreList.UseVisualStyleBackColor = true;
            this.button_SaveIgnoreList.Click += new System.EventHandler(this.button_SaveIgnoreList_Click);
            // 
            // button_IgnoreListHelp
            // 
            this.button_IgnoreListHelp.Location = new System.Drawing.Point(214, 17);
            this.button_IgnoreListHelp.Name = "button_IgnoreListHelp";
            this.button_IgnoreListHelp.Size = new System.Drawing.Size(27, 24);
            this.button_IgnoreListHelp.TabIndex = 2;
            this.button_IgnoreListHelp.Text = "?";
            this.button_IgnoreListHelp.UseVisualStyleBackColor = true;
            this.button_IgnoreListHelp.Click += new System.EventHandler(this.button_IgnoreListHelp_Click);
            // 
            // label_IgnoreList
            // 
            this.label_IgnoreList.AutoSize = true;
            this.label_IgnoreList.Location = new System.Drawing.Point(144, 20);
            this.label_IgnoreList.Name = "label_IgnoreList";
            this.label_IgnoreList.Size = new System.Drawing.Size(64, 15);
            this.label_IgnoreList.TabIndex = 1;
            this.label_IgnoreList.Text = "Ignore List";
            // 
            // richTextBox_IgnoreList
            // 
            this.richTextBox_IgnoreList.Location = new System.Drawing.Point(10, 47);
            this.richTextBox_IgnoreList.Name = "richTextBox_IgnoreList";
            this.richTextBox_IgnoreList.Size = new System.Drawing.Size(360, 263);
            this.richTextBox_IgnoreList.TabIndex = 0;
            this.richTextBox_IgnoreList.Text = "";
            // 
            // statusStrip_MainStatus
            // 
            this.statusStrip_MainStatus.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip_MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Status});
            this.statusStrip_MainStatus.Location = new System.Drawing.Point(0, 401);
            this.statusStrip_MainStatus.Name = "statusStrip_MainStatus";
            this.statusStrip_MainStatus.Size = new System.Drawing.Size(671, 24);
            this.statusStrip_MainStatus.TabIndex = 3;
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(18, 19);
            this.toolStripStatusLabel_Status.Text = "...";
            // 
            // tabPage_GameClients
            // 
            this.tabPage_GameClients.Controls.Add(this.panelClientInfo);
            this.tabPage_GameClients.Location = new System.Drawing.Point(4, 22);
            this.tabPage_GameClients.Name = "tabPage_GameClients";
            this.tabPage_GameClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_GameClients.Size = new System.Drawing.Size(669, 375);
            this.tabPage_GameClients.TabIndex = 2;
            this.tabPage_GameClients.Text = "Game Clients";
            this.tabPage_GameClients.UseVisualStyleBackColor = true;
            // 
            // panelClientInfo
            // 
            this.panelClientInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClientInfo.Controls.Add(this.labelCharLocation);
            this.panelClientInfo.Controls.Add(this.labelCharClassName);
            this.panelClientInfo.Controls.Add(this.labelCharName);
            this.panelClientInfo.Controls.Add(this.labelRealmName);
            this.panelClientInfo.Controls.Add(this.labelGameVersion);
            this.panelClientInfo.Controls.Add(this.label5);
            this.panelClientInfo.Controls.Add(this.label4);
            this.panelClientInfo.Controls.Add(this.label3);
            this.panelClientInfo.Controls.Add(this.label2);
            this.panelClientInfo.Controls.Add(this.label1);
            this.panelClientInfo.Location = new System.Drawing.Point(307, 6);
            this.panelClientInfo.Name = "panelClientInfo";
            this.panelClientInfo.Size = new System.Drawing.Size(350, 363);
            this.panelClientInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Realm Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Character Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Character Class:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Character Location:";
            // 
            // labelGameVersion
            // 
            this.labelGameVersion.AutoSize = true;
            this.labelGameVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameVersion.Location = new System.Drawing.Point(180, 14);
            this.labelGameVersion.Name = "labelGameVersion";
            this.labelGameVersion.Size = new System.Drawing.Size(84, 16);
            this.labelGameVersion.TabIndex = 6;
            this.labelGameVersion.Text = "%gversion%";
            // 
            // labelRealmName
            // 
            this.labelRealmName.AutoSize = true;
            this.labelRealmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRealmName.Location = new System.Drawing.Point(180, 43);
            this.labelRealmName.Name = "labelRealmName";
            this.labelRealmName.Size = new System.Drawing.Size(84, 16);
            this.labelRealmName.TabIndex = 7;
            this.labelRealmName.Text = "%gversion%";
            // 
            // labelCharName
            // 
            this.labelCharName.AutoSize = true;
            this.labelCharName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharName.Location = new System.Drawing.Point(180, 71);
            this.labelCharName.Name = "labelCharName";
            this.labelCharName.Size = new System.Drawing.Size(84, 16);
            this.labelCharName.TabIndex = 8;
            this.labelCharName.Text = "%gversion%";
            // 
            // labelCharClassName
            // 
            this.labelCharClassName.AutoSize = true;
            this.labelCharClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharClassName.Location = new System.Drawing.Point(180, 99);
            this.labelCharClassName.Name = "labelCharClassName";
            this.labelCharClassName.Size = new System.Drawing.Size(84, 16);
            this.labelCharClassName.TabIndex = 9;
            this.labelCharClassName.Text = "%gversion%";
            // 
            // labelCharLocation
            // 
            this.labelCharLocation.AutoSize = true;
            this.labelCharLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharLocation.Location = new System.Drawing.Point(180, 126);
            this.labelCharLocation.Name = "labelCharLocation";
            this.labelCharLocation.Size = new System.Drawing.Size(84, 16);
            this.labelCharLocation.TabIndex = 10;
            this.labelCharLocation.Text = "%gversion%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 425);
            this.Controls.Add(this.statusStrip_MainStatus);
            this.Controls.Add(this.tabControl_MainWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Multiboxer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl_MainWindow.ResumeLayout(false);
            this.tabPage_Multiboxing.ResumeLayout(false);
            this.tabPage_Multiboxing.PerformLayout();
            this.tabPage_IgnoreList.ResumeLayout(false);
            this.tabPage_IgnoreList.PerformLayout();
            this.statusStrip_MainStatus.ResumeLayout(false);
            this.statusStrip_MainStatus.PerformLayout();
            this.tabPage_GameClients.ResumeLayout(false);
            this.panelClientInfo.ResumeLayout(false);
            this.panelClientInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_StartMultiboxing;
        private System.Windows.Forms.TabControl tabControl_MainWindow;
        private System.Windows.Forms.TabPage tabPage_Multiboxing;
        private System.Windows.Forms.TabPage tabPage_IgnoreList;
        private System.Windows.Forms.ListBox listBox_SelectMasterClient;
        private System.Windows.Forms.Button button_RefreshClients;
        private System.Windows.Forms.Label label_IgnoreList;
        private System.Windows.Forms.RichTextBox richTextBox_IgnoreList;
        private System.Windows.Forms.HelpProvider helpProvider_IgnoreList;
        private System.Windows.Forms.Button button_IgnoreListHelp;
        private System.Windows.Forms.Button button_SaveIgnoreList;
        private System.Windows.Forms.StatusStrip statusStrip_MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.Label label_SelectMasterClient;
        private System.Windows.Forms.Button button_MasterClientListHelp;
        private System.Windows.Forms.RichTextBox richTextBox_MainDebugConsole;
        private System.Windows.Forms.CheckBox checkBox_LogErrors;
        private System.Windows.Forms.CheckBox checkBox_LogDebugs;
        private System.Windows.Forms.CheckBox checkBox_LogMessages;
        private System.Windows.Forms.CheckBox checkBox_Blacklist;
        private System.Windows.Forms.CheckBox checkBox_EnableIgnoreList;
        private System.Windows.Forms.CheckBox checkBox_Whitelist;
        private System.Windows.Forms.Button button_ClearConsole;
        private System.Windows.Forms.TabPage tabPage_GameClients;
        private System.Windows.Forms.Panel panelClientInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCharLocation;
        private System.Windows.Forms.Label labelCharClassName;
        private System.Windows.Forms.Label labelCharName;
        private System.Windows.Forms.Label labelRealmName;
        private System.Windows.Forms.Label labelGameVersion;
    }
}

