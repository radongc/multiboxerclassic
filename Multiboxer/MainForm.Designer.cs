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
            this.button_RefreshClients = new System.Windows.Forms.Button();
            this.listBox_SelectMasterClient = new System.Windows.Forms.ListBox();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.button_IgnoreListHelp = new System.Windows.Forms.Button();
            this.label_IgnoreList = new System.Windows.Forms.Label();
            this.richTextBox_IgnoreList = new System.Windows.Forms.RichTextBox();
            this.helpProvider_IgnoreList = new System.Windows.Forms.HelpProvider();
            this.tabControl_MainWindow.SuspendLayout();
            this.tabPage_Multiboxing.SuspendLayout();
            this.tabPage_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_StartMultiboxing
            // 
            this.button_StartMultiboxing.Location = new System.Drawing.Point(505, 327);
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
            this.tabControl_MainWindow.Controls.Add(this.tabPage_Settings);
            this.tabControl_MainWindow.Location = new System.Drawing.Point(-2, 3);
            this.tabControl_MainWindow.Name = "tabControl_MainWindow";
            this.tabControl_MainWindow.SelectedIndex = 0;
            this.tabControl_MainWindow.Size = new System.Drawing.Size(677, 401);
            this.tabControl_MainWindow.TabIndex = 1;
            // 
            // tabPage_Multiboxing
            // 
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
            // button_RefreshClients
            // 
            this.button_RefreshClients.Location = new System.Drawing.Point(49, 176);
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
            this.listBox_SelectMasterClient.Location = new System.Drawing.Point(24, 23);
            this.listBox_SelectMasterClient.Name = "listBox_SelectMasterClient";
            this.listBox_SelectMasterClient.Size = new System.Drawing.Size(140, 147);
            this.listBox_SelectMasterClient.TabIndex = 1;
            this.listBox_SelectMasterClient.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectMasterClient_SelectedIndexChanged);
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Controls.Add(this.button_IgnoreListHelp);
            this.tabPage_Settings.Controls.Add(this.label_IgnoreList);
            this.tabPage_Settings.Controls.Add(this.richTextBox_IgnoreList);
            this.tabPage_Settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Settings.Size = new System.Drawing.Size(669, 375);
            this.tabPage_Settings.TabIndex = 1;
            this.tabPage_Settings.Text = "Settings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // button_IgnoreListHelp
            // 
            this.button_IgnoreListHelp.Location = new System.Drawing.Point(214, 17);
            this.button_IgnoreListHelp.Name = "button_IgnoreListHelp";
            this.button_IgnoreListHelp.Size = new System.Drawing.Size(27, 24);
            this.button_IgnoreListHelp.TabIndex = 2;
            this.button_IgnoreListHelp.Text = "?";
            this.button_IgnoreListHelp.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 399);
            this.Controls.Add(this.tabControl_MainWindow);
            this.Name = "MainForm";
            this.Text = "Multiboxer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl_MainWindow.ResumeLayout(false);
            this.tabPage_Multiboxing.ResumeLayout(false);
            this.tabPage_Settings.ResumeLayout(false);
            this.tabPage_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_StartMultiboxing;
        private System.Windows.Forms.TabControl tabControl_MainWindow;
        private System.Windows.Forms.TabPage tabPage_Multiboxing;
        private System.Windows.Forms.TabPage tabPage_Settings;
        private System.Windows.Forms.ListBox listBox_SelectMasterClient;
        private System.Windows.Forms.Button button_RefreshClients;
        private System.Windows.Forms.Label label_IgnoreList;
        private System.Windows.Forms.RichTextBox richTextBox_IgnoreList;
        private System.Windows.Forms.HelpProvider helpProvider_IgnoreList;
        private System.Windows.Forms.Button button_IgnoreListHelp;
    }
}

