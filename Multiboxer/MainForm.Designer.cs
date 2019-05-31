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
            this.components = new System.ComponentModel.Container();
            this.button_StartMultiboxing = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_MainWindow = new System.Windows.Forms.TabControl();
            this.tabPage_Multiboxing = new System.Windows.Forms.TabPage();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl_MainWindow.SuspendLayout();
            this.tabPage_Multiboxing.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
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
            this.tabPage_Multiboxing.Controls.Add(this.button_StartMultiboxing);
            this.tabPage_Multiboxing.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Multiboxing.Name = "tabPage_Multiboxing";
            this.tabPage_Multiboxing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Multiboxing.Size = new System.Drawing.Size(669, 375);
            this.tabPage_Multiboxing.TabIndex = 0;
            this.tabPage_Multiboxing.Text = "Multiboxing";
            this.tabPage_Multiboxing.UseVisualStyleBackColor = true;
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Settings.Size = new System.Drawing.Size(669, 375);
            this.tabPage_Settings.TabIndex = 1;
            this.tabPage_Settings.Text = "Settings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 399);
            this.Controls.Add(this.tabControl_MainWindow);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl_MainWindow.ResumeLayout(false);
            this.tabPage_Multiboxing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_StartMultiboxing;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl_MainWindow;
        private System.Windows.Forms.TabPage tabPage_Multiboxing;
        private System.Windows.Forms.TabPage tabPage_Settings;
    }
}

