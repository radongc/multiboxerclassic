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
            this.SuspendLayout();
            // 
            // button_StartMultiboxing
            // 
            this.button_StartMultiboxing.Location = new System.Drawing.Point(507, 352);
            this.button_StartMultiboxing.Name = "button_StartMultiboxing";
            this.button_StartMultiboxing.Size = new System.Drawing.Size(152, 35);
            this.button_StartMultiboxing.TabIndex = 0;
            this.button_StartMultiboxing.Text = "Start Multiboxing";
            this.button_StartMultiboxing.UseVisualStyleBackColor = true;
            this.button_StartMultiboxing.Click += new System.EventHandler(this.button_StartMultiboxing_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 399);
            this.Controls.Add(this.button_StartMultiboxing);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_StartMultiboxing;
    }
}

