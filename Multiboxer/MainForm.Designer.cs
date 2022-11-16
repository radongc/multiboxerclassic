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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStartMultiboxing = new System.Windows.Forms.Button();
            this.tabControlMainWindow = new System.Windows.Forms.TabControl();
            this.tabPageMultiboxing = new System.Windows.Forms.TabPage();
            this.labelMultiboxerVersion = new System.Windows.Forms.Label();
            this.buttonClearConsole = new System.Windows.Forms.Button();
            this.checkBoxLogErrors = new System.Windows.Forms.CheckBox();
            this.checkBoxLogDebugs = new System.Windows.Forms.CheckBox();
            this.checkBoxLogMessages = new System.Windows.Forms.CheckBox();
            this.richTextBoxMainDebugConsole = new System.Windows.Forms.RichTextBox();
            this.buttonMasterClientListHelp = new System.Windows.Forms.Button();
            this.labelSelectMasterClient = new System.Windows.Forms.Label();
            this.buttonRefreshClients = new System.Windows.Forms.Button();
            this.listBoxSelectMasterClient = new System.Windows.Forms.ListBox();
            this.tabPageIgnoreList = new System.Windows.Forms.TabPage();
            this.groupBoxDefaultBindings = new System.Windows.Forms.GroupBox();
            this.buttonDefaultBindingsHelp = new System.Windows.Forms.Button();
            this.checkBoxF8 = new System.Windows.Forms.CheckBox();
            this.checkBoxF12 = new System.Windows.Forms.CheckBox();
            this.checkBoxF9 = new System.Windows.Forms.CheckBox();
            this.checkBoxF12OrAlt = new System.Windows.Forms.CheckBox();
            this.checkBoxSingleClick = new System.Windows.Forms.CheckBox();
            this.checkBoxF11 = new System.Windows.Forms.CheckBox();
            this.checkBoxUP = new System.Windows.Forms.CheckBox();
            this.checkBoxF10 = new System.Windows.Forms.CheckBox();
            this.checkBoxWhitelist = new System.Windows.Forms.CheckBox();
            this.checkBoxBlacklist = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableIgnoreList = new System.Windows.Forms.CheckBox();
            this.buttonSaveIgnoreList = new System.Windows.Forms.Button();
            this.buttonIgnoreListHelp = new System.Windows.Forms.Button();
            this.labelIgnoreList = new System.Windows.Forms.Label();
            this.richTextBoxIgnoreList = new System.Windows.Forms.RichTextBox();
            this.tabPageMacroList = new System.Windows.Forms.TabPage();
            this.labelShouldBeBoundToKey = new System.Windows.Forms.Label();
            this.labelShouldBeBoundToText = new System.Windows.Forms.Label();
            this.buttonMacroGenHelp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCopyMacroContent = new System.Windows.Forms.Button();
            this.buttonCopyMacroName = new System.Windows.Forms.Button();
            this.textBoxMacroName = new System.Windows.Forms.TextBox();
            this.richTextBoxMacroContent = new System.Windows.Forms.RichTextBox();
            this.listBoxDefaultMacros = new System.Windows.Forms.ListBox();
            this.statusStripMainStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.helpProvider_IgnoreList = new System.Windows.Forms.HelpProvider();
            this.tabControlMainWindow.SuspendLayout();
            this.tabPageMultiboxing.SuspendLayout();
            this.tabPageIgnoreList.SuspendLayout();
            this.groupBoxDefaultBindings.SuspendLayout();
            this.tabPageMacroList.SuspendLayout();
            this.statusStripMainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartMultiboxing
            // 
            this.buttonStartMultiboxing.Location = new System.Drawing.Point(721, 473);
            this.buttonStartMultiboxing.Name = "buttonStartMultiboxing";
            this.buttonStartMultiboxing.Size = new System.Drawing.Size(152, 35);
            this.buttonStartMultiboxing.TabIndex = 0;
            this.buttonStartMultiboxing.Text = "Start Multiboxing";
            this.buttonStartMultiboxing.UseVisualStyleBackColor = true;
            this.buttonStartMultiboxing.Click += new System.EventHandler(this.buttonStartMultiboxing_Click);
            // 
            // tabControlMainWindow
            // 
            this.tabControlMainWindow.Controls.Add(this.tabPageMultiboxing);
            this.tabControlMainWindow.Controls.Add(this.tabPageIgnoreList);
            this.tabControlMainWindow.Controls.Add(this.tabPageMacroList);
            this.tabControlMainWindow.Location = new System.Drawing.Point(-2, 3);
            this.tabControlMainWindow.Name = "tabControlMainWindow";
            this.tabControlMainWindow.SelectedIndex = 0;
            this.tabControlMainWindow.Size = new System.Drawing.Size(887, 540);
            this.tabControlMainWindow.TabIndex = 1;
            // 
            // tabPageMultiboxing
            // 
            this.tabPageMultiboxing.Controls.Add(this.labelMultiboxerVersion);
            this.tabPageMultiboxing.Controls.Add(this.buttonClearConsole);
            this.tabPageMultiboxing.Controls.Add(this.checkBoxLogErrors);
            this.tabPageMultiboxing.Controls.Add(this.checkBoxLogDebugs);
            this.tabPageMultiboxing.Controls.Add(this.checkBoxLogMessages);
            this.tabPageMultiboxing.Controls.Add(this.richTextBoxMainDebugConsole);
            this.tabPageMultiboxing.Controls.Add(this.buttonMasterClientListHelp);
            this.tabPageMultiboxing.Controls.Add(this.labelSelectMasterClient);
            this.tabPageMultiboxing.Controls.Add(this.buttonRefreshClients);
            this.tabPageMultiboxing.Controls.Add(this.listBoxSelectMasterClient);
            this.tabPageMultiboxing.Controls.Add(this.buttonStartMultiboxing);
            this.tabPageMultiboxing.Location = new System.Drawing.Point(4, 22);
            this.tabPageMultiboxing.Name = "tabPageMultiboxing";
            this.tabPageMultiboxing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMultiboxing.Size = new System.Drawing.Size(879, 514);
            this.tabPageMultiboxing.TabIndex = 0;
            this.tabPageMultiboxing.Text = "Multiboxing";
            this.tabPageMultiboxing.UseVisualStyleBackColor = true;
            // 
            // labelMultiboxerVersion
            // 
            this.labelMultiboxerVersion.AutoSize = true;
            this.labelMultiboxerVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMultiboxerVersion.Location = new System.Drawing.Point(6, 495);
            this.labelMultiboxerVersion.Name = "labelMultiboxerVersion";
            this.labelMultiboxerVersion.Size = new System.Drawing.Size(124, 13);
            this.labelMultiboxerVersion.TabIndex = 10;
            this.labelMultiboxerVersion.Text = "Multiboxer Classic v0.3.2";
            // 
            // buttonClearConsole
            // 
            this.buttonClearConsole.Location = new System.Drawing.Point(178, 473);
            this.buttonClearConsole.Name = "buttonClearConsole";
            this.buttonClearConsole.Size = new System.Drawing.Size(49, 35);
            this.buttonClearConsole.TabIndex = 9;
            this.buttonClearConsole.Text = "Clear";
            this.buttonClearConsole.UseVisualStyleBackColor = true;
            this.buttonClearConsole.Click += new System.EventHandler(this.buttonClearConsole_Click);
            // 
            // checkBoxLogErrors
            // 
            this.checkBoxLogErrors.AutoSize = true;
            this.checkBoxLogErrors.Checked = true;
            this.checkBoxLogErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLogErrors.Location = new System.Drawing.Point(788, 9);
            this.checkBoxLogErrors.Name = "checkBoxLogErrors";
            this.checkBoxLogErrors.Size = new System.Drawing.Size(74, 17);
            this.checkBoxLogErrors.TabIndex = 8;
            this.checkBoxLogErrors.Text = "Error Logs";
            this.checkBoxLogErrors.UseVisualStyleBackColor = true;
            this.checkBoxLogErrors.CheckedChanged += new System.EventHandler(this.checkBoxLogError_CheckedChanged);
            // 
            // checkBoxLogDebugs
            // 
            this.checkBoxLogDebugs.AutoSize = true;
            this.checkBoxLogDebugs.Location = new System.Drawing.Point(689, 9);
            this.checkBoxLogDebugs.Name = "checkBoxLogDebugs";
            this.checkBoxLogDebugs.Size = new System.Drawing.Size(84, 17);
            this.checkBoxLogDebugs.TabIndex = 7;
            this.checkBoxLogDebugs.Text = "Debug Logs";
            this.checkBoxLogDebugs.UseVisualStyleBackColor = true;
            this.checkBoxLogDebugs.CheckedChanged += new System.EventHandler(this.checkBoxLogDebug_CheckedChanged);
            // 
            // checkBoxLogMessages
            // 
            this.checkBoxLogMessages.AutoSize = true;
            this.checkBoxLogMessages.Checked = true;
            this.checkBoxLogMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLogMessages.Location = new System.Drawing.Point(576, 9);
            this.checkBoxLogMessages.Name = "checkBoxLogMessages";
            this.checkBoxLogMessages.Size = new System.Drawing.Size(95, 17);
            this.checkBoxLogMessages.TabIndex = 6;
            this.checkBoxLogMessages.Text = "Message Logs";
            this.checkBoxLogMessages.UseVisualStyleBackColor = true;
            this.checkBoxLogMessages.CheckedChanged += new System.EventHandler(this.checkBoxLogMessages_CheckedChanged);
            // 
            // richTextBoxMainDebugConsole
            // 
            this.richTextBoxMainDebugConsole.Location = new System.Drawing.Point(178, 34);
            this.richTextBoxMainDebugConsole.Name = "richTextBoxMainDebugConsole";
            this.richTextBoxMainDebugConsole.ReadOnly = true;
            this.richTextBoxMainDebugConsole.Size = new System.Drawing.Size(693, 433);
            this.richTextBoxMainDebugConsole.TabIndex = 5;
            this.richTextBoxMainDebugConsole.Text = "";
            // 
            // buttonMasterClientListHelp
            // 
            this.buttonMasterClientListHelp.Location = new System.Drawing.Point(136, 34);
            this.buttonMasterClientListHelp.Name = "buttonMasterClientListHelp";
            this.buttonMasterClientListHelp.Size = new System.Drawing.Size(27, 24);
            this.buttonMasterClientListHelp.TabIndex = 4;
            this.buttonMasterClientListHelp.Text = "?";
            this.buttonMasterClientListHelp.UseVisualStyleBackColor = true;
            this.buttonMasterClientListHelp.Click += new System.EventHandler(this.buttonMasterClientListHelp_Click);
            // 
            // labelSelectMasterClient
            // 
            this.labelSelectMasterClient.AutoSize = true;
            this.labelSelectMasterClient.Location = new System.Drawing.Point(20, 40);
            this.labelSelectMasterClient.Name = "labelSelectMasterClient";
            this.labelSelectMasterClient.Size = new System.Drawing.Size(104, 13);
            this.labelSelectMasterClient.TabIndex = 3;
            this.labelSelectMasterClient.Text = "Select Master Client:";
            // 
            // buttonRefreshClients
            // 
            this.buttonRefreshClients.Location = new System.Drawing.Point(48, 216);
            this.buttonRefreshClients.Name = "buttonRefreshClients";
            this.buttonRefreshClients.Size = new System.Drawing.Size(88, 34);
            this.buttonRefreshClients.TabIndex = 2;
            this.buttonRefreshClients.Text = "Refresh";
            this.buttonRefreshClients.UseVisualStyleBackColor = true;
            this.buttonRefreshClients.Click += new System.EventHandler(this.buttonRefreshClients_Click);
            // 
            // listBoxSelectMasterClient
            // 
            this.listBoxSelectMasterClient.FormattingEnabled = true;
            this.listBoxSelectMasterClient.Location = new System.Drawing.Point(23, 63);
            this.listBoxSelectMasterClient.Name = "listBoxSelectMasterClient";
            this.listBoxSelectMasterClient.Size = new System.Drawing.Size(140, 147);
            this.listBoxSelectMasterClient.TabIndex = 1;
            this.listBoxSelectMasterClient.SelectedIndexChanged += new System.EventHandler(this.listBoxSelectMasterClient_SelectedIndexChanged);
            // 
            // tabPageIgnoreList
            // 
            this.tabPageIgnoreList.Controls.Add(this.groupBoxDefaultBindings);
            this.tabPageIgnoreList.Controls.Add(this.checkBoxWhitelist);
            this.tabPageIgnoreList.Controls.Add(this.checkBoxBlacklist);
            this.tabPageIgnoreList.Controls.Add(this.checkBoxEnableIgnoreList);
            this.tabPageIgnoreList.Controls.Add(this.buttonSaveIgnoreList);
            this.tabPageIgnoreList.Controls.Add(this.buttonIgnoreListHelp);
            this.tabPageIgnoreList.Controls.Add(this.labelIgnoreList);
            this.tabPageIgnoreList.Controls.Add(this.richTextBoxIgnoreList);
            this.tabPageIgnoreList.Location = new System.Drawing.Point(4, 22);
            this.tabPageIgnoreList.Name = "tabPageIgnoreList";
            this.tabPageIgnoreList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIgnoreList.Size = new System.Drawing.Size(879, 514);
            this.tabPageIgnoreList.TabIndex = 1;
            this.tabPageIgnoreList.Text = "Key Configuration";
            this.tabPageIgnoreList.UseVisualStyleBackColor = true;
            // 
            // groupBoxDefaultBindings
            // 
            this.groupBoxDefaultBindings.Controls.Add(this.buttonDefaultBindingsHelp);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxF8);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxF12);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxF9);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxF12OrAlt);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxSingleClick);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxF11);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxUP);
            this.groupBoxDefaultBindings.Controls.Add(this.checkBoxF10);
            this.groupBoxDefaultBindings.Location = new System.Drawing.Point(531, 39);
            this.groupBoxDefaultBindings.Name = "groupBoxDefaultBindings";
            this.groupBoxDefaultBindings.Size = new System.Drawing.Size(340, 271);
            this.groupBoxDefaultBindings.TabIndex = 10;
            this.groupBoxDefaultBindings.TabStop = false;
            this.groupBoxDefaultBindings.Text = "Default Bindings";
            // 
            // buttonDefaultBindingsHelp
            // 
            this.buttonDefaultBindingsHelp.Location = new System.Drawing.Point(307, 19);
            this.buttonDefaultBindingsHelp.Name = "buttonDefaultBindingsHelp";
            this.buttonDefaultBindingsHelp.Size = new System.Drawing.Size(27, 24);
            this.buttonDefaultBindingsHelp.TabIndex = 9;
            this.buttonDefaultBindingsHelp.Text = "?";
            this.buttonDefaultBindingsHelp.UseVisualStyleBackColor = true;
            this.buttonDefaultBindingsHelp.Click += new System.EventHandler(this.buttonDefaultBindingsHelp_Click);
            // 
            // checkBoxF8
            // 
            this.checkBoxF8.AutoSize = true;
            this.checkBoxF8.Location = new System.Drawing.Point(28, 194);
            this.checkBoxF8.Name = "checkBoxF8";
            this.checkBoxF8.Size = new System.Drawing.Size(159, 17);
            this.checkBoxF8.TabIndex = 7;
            this.checkBoxF8.Text = "W Key => Follow macro (F8)";
            this.checkBoxF8.UseVisualStyleBackColor = true;
            this.checkBoxF8.CheckedChanged += new System.EventHandler(this.checkBoxF8_CheckedChanged);
            // 
            // checkBoxF12
            // 
            this.checkBoxF12.AutoSize = true;
            this.checkBoxF12.Location = new System.Drawing.Point(28, 33);
            this.checkBoxF12.Name = "checkBoxF12";
            this.checkBoxF12.Size = new System.Drawing.Size(173, 17);
            this.checkBoxF12.TabIndex = 0;
            this.checkBoxF12.Text = "Left Click => assist macro (F12)";
            this.checkBoxF12.UseVisualStyleBackColor = true;
            this.checkBoxF12.CheckedChanged += new System.EventHandler(this.checkBoxF12_CheckedChanged);
            // 
            // checkBoxF9
            // 
            this.checkBoxF9.AutoSize = true;
            this.checkBoxF9.Location = new System.Drawing.Point(28, 171);
            this.checkBoxF9.Name = "checkBoxF9";
            this.checkBoxF9.Size = new System.Drawing.Size(193, 17);
            this.checkBoxF9.TabIndex = 6;
            this.checkBoxF9.Text = "Double Click => setview macro (F9)";
            this.checkBoxF9.UseVisualStyleBackColor = true;
            this.checkBoxF9.CheckedChanged += new System.EventHandler(this.checkBoxF9_CheckedChanged);
            // 
            // checkBoxF12OrAlt
            // 
            this.checkBoxF12OrAlt.AutoSize = true;
            this.checkBoxF12OrAlt.Location = new System.Drawing.Point(28, 56);
            this.checkBoxF12OrAlt.Name = "checkBoxF12OrAlt";
            this.checkBoxF12OrAlt.Size = new System.Drawing.Size(180, 17);
            this.checkBoxF12OrAlt.TabIndex = 1;
            this.checkBoxF12OrAlt.Text = "Right Click => assist macro (F12)";
            this.checkBoxF12OrAlt.UseVisualStyleBackColor = true;
            this.checkBoxF12OrAlt.CheckedChanged += new System.EventHandler(this.checkBoxF12OrAlt_CheckedChanged);
            // 
            // checkBoxSingleClick
            // 
            this.checkBoxSingleClick.AutoSize = true;
            this.checkBoxSingleClick.Location = new System.Drawing.Point(28, 148);
            this.checkBoxSingleClick.Name = "checkBoxSingleClick";
            this.checkBoxSingleClick.Size = new System.Drawing.Size(229, 17);
            this.checkBoxSingleClick.TabIndex = 5;
            this.checkBoxSingleClick.Text = "Left Control => Toggle mouse broadcasting";
            this.checkBoxSingleClick.UseVisualStyleBackColor = true;
            this.checkBoxSingleClick.CheckedChanged += new System.EventHandler(this.checkBoxSingleClick_CheckedChanged);
            // 
            // checkBoxF11
            // 
            this.checkBoxF11.AutoSize = true;
            this.checkBoxF11.Location = new System.Drawing.Point(28, 79);
            this.checkBoxF11.Name = "checkBoxF11";
            this.checkBoxF11.Size = new System.Drawing.Size(214, 17);
            this.checkBoxF11.TabIndex = 2;
            this.checkBoxF11.Text = "Right Click => Interact with Target (F11)";
            this.checkBoxF11.UseVisualStyleBackColor = true;
            this.checkBoxF11.CheckedChanged += new System.EventHandler(this.checkBoxF11_CheckedChanged);
            // 
            // checkBoxUP
            // 
            this.checkBoxUP.AutoSize = true;
            this.checkBoxUP.Location = new System.Drawing.Point(28, 125);
            this.checkBoxUP.Name = "checkBoxUP";
            this.checkBoxUP.Size = new System.Drawing.Size(154, 17);
            this.checkBoxUP.TabIndex = 4;
            this.checkBoxUP.Text = "Mouse Button 4 => UP key";
            this.checkBoxUP.UseVisualStyleBackColor = true;
            this.checkBoxUP.CheckedChanged += new System.EventHandler(this.checkBoxUP_CheckedChanged);
            // 
            // checkBoxF10
            // 
            this.checkBoxF10.AutoSize = true;
            this.checkBoxF10.Location = new System.Drawing.Point(28, 102);
            this.checkBoxF10.Name = "checkBoxF10";
            this.checkBoxF10.Size = new System.Drawing.Size(188, 17);
            this.checkBoxF10.TabIndex = 3;
            this.checkBoxF10.Text = "Right Click => confirm macro (F10)";
            this.checkBoxF10.UseVisualStyleBackColor = true;
            this.checkBoxF10.CheckedChanged += new System.EventHandler(this.checkBoxF10_CheckedChanged);
            // 
            // checkBoxWhitelist
            // 
            this.checkBoxWhitelist.AutoSize = true;
            this.checkBoxWhitelist.Location = new System.Drawing.Point(376, 97);
            this.checkBoxWhitelist.Name = "checkBoxWhitelist";
            this.checkBoxWhitelist.Size = new System.Drawing.Size(120, 17);
            this.checkBoxWhitelist.TabIndex = 6;
            this.checkBoxWhitelist.Text = "Whitelist these keys";
            this.checkBoxWhitelist.UseVisualStyleBackColor = true;
            this.checkBoxWhitelist.CheckedChanged += new System.EventHandler(this.checkBoxWhitelist_CheckedChanged);
            // 
            // checkBoxBlacklist
            // 
            this.checkBoxBlacklist.AutoSize = true;
            this.checkBoxBlacklist.Checked = true;
            this.checkBoxBlacklist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBlacklist.Location = new System.Drawing.Point(376, 72);
            this.checkBoxBlacklist.Name = "checkBoxBlacklist";
            this.checkBoxBlacklist.Size = new System.Drawing.Size(119, 17);
            this.checkBoxBlacklist.TabIndex = 5;
            this.checkBoxBlacklist.Text = "Blacklist these keys";
            this.checkBoxBlacklist.UseVisualStyleBackColor = true;
            this.checkBoxBlacklist.CheckedChanged += new System.EventHandler(this.checkBoxBlacklist_CheckedChanged);
            // 
            // checkBoxEnableIgnoreList
            // 
            this.checkBoxEnableIgnoreList.AutoSize = true;
            this.checkBoxEnableIgnoreList.Checked = true;
            this.checkBoxEnableIgnoreList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableIgnoreList.Location = new System.Drawing.Point(376, 47);
            this.checkBoxEnableIgnoreList.Name = "checkBoxEnableIgnoreList";
            this.checkBoxEnableIgnoreList.Size = new System.Drawing.Size(108, 17);
            this.checkBoxEnableIgnoreList.TabIndex = 4;
            this.checkBoxEnableIgnoreList.Text = "Enable IgnoreList";
            this.checkBoxEnableIgnoreList.UseVisualStyleBackColor = true;
            this.checkBoxEnableIgnoreList.CheckedChanged += new System.EventHandler(this.checkBoxEnableIgnoreList_CheckedChanged);
            // 
            // buttonSaveIgnoreList
            // 
            this.buttonSaveIgnoreList.Location = new System.Drawing.Point(295, 17);
            this.buttonSaveIgnoreList.Name = "buttonSaveIgnoreList";
            this.buttonSaveIgnoreList.Size = new System.Drawing.Size(75, 24);
            this.buttonSaveIgnoreList.TabIndex = 3;
            this.buttonSaveIgnoreList.Text = "Save";
            this.buttonSaveIgnoreList.UseVisualStyleBackColor = true;
            this.buttonSaveIgnoreList.Click += new System.EventHandler(this.buttonSaveIgnoreList_Click);
            // 
            // buttonIgnoreListHelp
            // 
            this.buttonIgnoreListHelp.Location = new System.Drawing.Point(206, 17);
            this.buttonIgnoreListHelp.Name = "buttonIgnoreListHelp";
            this.buttonIgnoreListHelp.Size = new System.Drawing.Size(27, 24);
            this.buttonIgnoreListHelp.TabIndex = 2;
            this.buttonIgnoreListHelp.Text = "?";
            this.buttonIgnoreListHelp.UseVisualStyleBackColor = true;
            this.buttonIgnoreListHelp.Click += new System.EventHandler(this.buttonIgnoreListHelp_Click);
            // 
            // labelIgnoreList
            // 
            this.labelIgnoreList.AutoSize = true;
            this.labelIgnoreList.Location = new System.Drawing.Point(144, 20);
            this.labelIgnoreList.Name = "labelIgnoreList";
            this.labelIgnoreList.Size = new System.Drawing.Size(56, 13);
            this.labelIgnoreList.TabIndex = 1;
            this.labelIgnoreList.Text = "Ignore List";
            // 
            // richTextBoxIgnoreList
            // 
            this.richTextBoxIgnoreList.Location = new System.Drawing.Point(10, 47);
            this.richTextBoxIgnoreList.Name = "richTextBoxIgnoreList";
            this.richTextBoxIgnoreList.Size = new System.Drawing.Size(360, 263);
            this.richTextBoxIgnoreList.TabIndex = 0;
            this.richTextBoxIgnoreList.Text = "";
            // 
            // tabPageMacroList
            // 
            this.tabPageMacroList.Controls.Add(this.labelShouldBeBoundToKey);
            this.tabPageMacroList.Controls.Add(this.labelShouldBeBoundToText);
            this.tabPageMacroList.Controls.Add(this.buttonMacroGenHelp);
            this.tabPageMacroList.Controls.Add(this.label3);
            this.tabPageMacroList.Controls.Add(this.label2);
            this.tabPageMacroList.Controls.Add(this.buttonCopyMacroContent);
            this.tabPageMacroList.Controls.Add(this.buttonCopyMacroName);
            this.tabPageMacroList.Controls.Add(this.textBoxMacroName);
            this.tabPageMacroList.Controls.Add(this.richTextBoxMacroContent);
            this.tabPageMacroList.Controls.Add(this.listBoxDefaultMacros);
            this.tabPageMacroList.Location = new System.Drawing.Point(4, 22);
            this.tabPageMacroList.Name = "tabPageMacroList";
            this.tabPageMacroList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMacroList.Size = new System.Drawing.Size(879, 514);
            this.tabPageMacroList.TabIndex = 2;
            this.tabPageMacroList.Text = "Binding Macros";
            this.tabPageMacroList.UseVisualStyleBackColor = true;
            // 
            // labelShouldBeBoundToKey
            // 
            this.labelShouldBeBoundToKey.AutoSize = true;
            this.labelShouldBeBoundToKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShouldBeBoundToKey.Location = new System.Drawing.Point(743, 56);
            this.labelShouldBeBoundToKey.Name = "labelShouldBeBoundToKey";
            this.labelShouldBeBoundToKey.Size = new System.Drawing.Size(0, 20);
            this.labelShouldBeBoundToKey.TabIndex = 12;
            // 
            // labelShouldBeBoundToText
            // 
            this.labelShouldBeBoundToText.AutoSize = true;
            this.labelShouldBeBoundToText.Location = new System.Drawing.Point(712, 33);
            this.labelShouldBeBoundToText.Name = "labelShouldBeBoundToText";
            this.labelShouldBeBoundToText.Size = new System.Drawing.Size(0, 13);
            this.labelShouldBeBoundToText.TabIndex = 11;
            // 
            // buttonMacroGenHelp
            // 
            this.buttonMacroGenHelp.Location = new System.Drawing.Point(519, 323);
            this.buttonMacroGenHelp.Name = "buttonMacroGenHelp";
            this.buttonMacroGenHelp.Size = new System.Drawing.Size(27, 24);
            this.buttonMacroGenHelp.TabIndex = 10;
            this.buttonMacroGenHelp.Text = "?";
            this.buttonMacroGenHelp.UseVisualStyleBackColor = true;
            this.buttonMacroGenHelp.Click += new System.EventHandler(this.buttonMacroGenHelp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selected Macro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Macros";
            // 
            // buttonCopyMacroContent
            // 
            this.buttonCopyMacroContent.Location = new System.Drawing.Point(552, 313);
            this.buttonCopyMacroContent.Name = "buttonCopyMacroContent";
            this.buttonCopyMacroContent.Size = new System.Drawing.Size(105, 45);
            this.buttonCopyMacroContent.TabIndex = 6;
            this.buttonCopyMacroContent.Text = "Copy Macro";
            this.buttonCopyMacroContent.UseVisualStyleBackColor = true;
            this.buttonCopyMacroContent.Click += new System.EventHandler(this.buttonCopyMacroContent_Click);
            // 
            // buttonCopyMacroName
            // 
            this.buttonCopyMacroName.Location = new System.Drawing.Point(407, 312);
            this.buttonCopyMacroName.Name = "buttonCopyMacroName";
            this.buttonCopyMacroName.Size = new System.Drawing.Size(105, 45);
            this.buttonCopyMacroName.TabIndex = 5;
            this.buttonCopyMacroName.Text = "Copy Name";
            this.buttonCopyMacroName.UseVisualStyleBackColor = true;
            this.buttonCopyMacroName.Click += new System.EventHandler(this.buttonCopyMacroName_Click);
            // 
            // textBoxMacroName
            // 
            this.textBoxMacroName.Location = new System.Drawing.Point(407, 30);
            this.textBoxMacroName.Name = "textBoxMacroName";
            this.textBoxMacroName.Size = new System.Drawing.Size(250, 20);
            this.textBoxMacroName.TabIndex = 4;
            // 
            // richTextBoxMacroContent
            // 
            this.richTextBoxMacroContent.Location = new System.Drawing.Point(407, 56);
            this.richTextBoxMacroContent.Name = "richTextBoxMacroContent";
            this.richTextBoxMacroContent.Size = new System.Drawing.Size(250, 250);
            this.richTextBoxMacroContent.TabIndex = 3;
            this.richTextBoxMacroContent.Text = "";
            // 
            // listBoxDefaultMacros
            // 
            this.listBoxDefaultMacros.FormattingEnabled = true;
            this.listBoxDefaultMacros.Location = new System.Drawing.Point(10, 30);
            this.listBoxDefaultMacros.Name = "listBoxDefaultMacros";
            this.listBoxDefaultMacros.Size = new System.Drawing.Size(391, 329);
            this.listBoxDefaultMacros.TabIndex = 2;
            this.listBoxDefaultMacros.SelectedIndexChanged += new System.EventHandler(this.listBoxDefaultMacros_SelectedIndexChanged);
            // 
            // statusStripMainStatus
            // 
            this.statusStripMainStatus.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStripMainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStripMainStatus.Location = new System.Drawing.Point(0, 546);
            this.statusStripMainStatus.Name = "statusStripMainStatus";
            this.statusStripMainStatus.Size = new System.Drawing.Size(885, 22);
            this.statusStripMainStatus.TabIndex = 3;
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelStatus.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 568);
            this.Controls.Add(this.statusStripMainStatus);
            this.Controls.Add(this.tabControlMainWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Game Manager 2021";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMainWindow.ResumeLayout(false);
            this.tabPageMultiboxing.ResumeLayout(false);
            this.tabPageMultiboxing.PerformLayout();
            this.tabPageIgnoreList.ResumeLayout(false);
            this.tabPageIgnoreList.PerformLayout();
            this.groupBoxDefaultBindings.ResumeLayout(false);
            this.groupBoxDefaultBindings.PerformLayout();
            this.tabPageMacroList.ResumeLayout(false);
            this.tabPageMacroList.PerformLayout();
            this.statusStripMainStatus.ResumeLayout(false);
            this.statusStripMainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartMultiboxing;
        private System.Windows.Forms.TabControl tabControlMainWindow;
        private System.Windows.Forms.TabPage tabPageMultiboxing;
        private System.Windows.Forms.TabPage tabPageIgnoreList;
        private System.Windows.Forms.ListBox listBoxSelectMasterClient;
        private System.Windows.Forms.Button buttonRefreshClients;
        private System.Windows.Forms.Label labelIgnoreList;
        private System.Windows.Forms.RichTextBox richTextBoxIgnoreList;
        private System.Windows.Forms.HelpProvider helpProvider_IgnoreList;
        private System.Windows.Forms.Button buttonIgnoreListHelp;
        private System.Windows.Forms.Button buttonSaveIgnoreList;
        private System.Windows.Forms.StatusStrip statusStripMainStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Label labelSelectMasterClient;
        private System.Windows.Forms.Button buttonMasterClientListHelp;
        private System.Windows.Forms.RichTextBox richTextBoxMainDebugConsole;
        private System.Windows.Forms.CheckBox checkBoxLogErrors;
        private System.Windows.Forms.CheckBox checkBoxLogDebugs;
        private System.Windows.Forms.CheckBox checkBoxLogMessages;
        private System.Windows.Forms.CheckBox checkBoxBlacklist;
        private System.Windows.Forms.CheckBox checkBoxEnableIgnoreList;
        private System.Windows.Forms.CheckBox checkBoxWhitelist;
        private System.Windows.Forms.Button buttonClearConsole;
        private System.Windows.Forms.TabPage tabPageMacroList;
        private System.Windows.Forms.TextBox textBoxMacroName;
        private System.Windows.Forms.RichTextBox richTextBoxMacroContent;
        private System.Windows.Forms.ListBox listBoxDefaultMacros;
        private System.Windows.Forms.Button buttonCopyMacroContent;
        private System.Windows.Forms.Button buttonCopyMacroName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMacroGenHelp;
        private System.Windows.Forms.CheckBox checkBoxF12;
        private System.Windows.Forms.CheckBox checkBoxF8;
        private System.Windows.Forms.CheckBox checkBoxF9;
        private System.Windows.Forms.CheckBox checkBoxSingleClick;
        private System.Windows.Forms.CheckBox checkBoxUP;
        private System.Windows.Forms.CheckBox checkBoxF10;
        private System.Windows.Forms.CheckBox checkBoxF11;
        private System.Windows.Forms.CheckBox checkBoxF12OrAlt;
        private System.Windows.Forms.Label labelMultiboxerVersion;
        private System.Windows.Forms.Button buttonDefaultBindingsHelp;
        private System.Windows.Forms.Label labelShouldBeBoundToText;
        private System.Windows.Forms.Label labelShouldBeBoundToKey;
        private System.Windows.Forms.GroupBox groupBoxDefaultBindings;
    }
}

