namespace Multiboxer
{
    partial class CharacterConfigForm
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
            this.listBoxConfigGameWindows = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxConfigCharacterName = new System.Windows.Forms.TextBox();
            this.comboBoxConfigCharacterClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConfigSaveCharacters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxConfigGameWindows
            // 
            this.listBoxConfigGameWindows.FormattingEnabled = true;
            this.listBoxConfigGameWindows.Location = new System.Drawing.Point(12, 38);
            this.listBoxConfigGameWindows.Name = "listBoxConfigGameWindows";
            this.listBoxConfigGameWindows.Size = new System.Drawing.Size(185, 433);
            this.listBoxConfigGameWindows.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game Windows";
            // 
            // textBoxConfigCharacterName
            // 
            this.textBoxConfigCharacterName.Location = new System.Drawing.Point(323, 38);
            this.textBoxConfigCharacterName.Name = "textBoxConfigCharacterName";
            this.textBoxConfigCharacterName.Size = new System.Drawing.Size(142, 20);
            this.textBoxConfigCharacterName.TabIndex = 2;
            // 
            // comboBoxConfigCharacterClass
            // 
            this.comboBoxConfigCharacterClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfigCharacterClass.FormattingEnabled = true;
            this.comboBoxConfigCharacterClass.Items.AddRange(new object[] {
            "Warrior",
            "Paladin",
            "Hunter",
            "Rogue",
            "Priest",
            "Shaman",
            "Mage",
            "Warlock",
            "Druid"});
            this.comboBoxConfigCharacterClass.Location = new System.Drawing.Point(323, 81);
            this.comboBoxConfigCharacterClass.Name = "comboBoxConfigCharacterClass";
            this.comboBoxConfigCharacterClass.Size = new System.Drawing.Size(142, 21);
            this.comboBoxConfigCharacterClass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Class:";
            // 
            // buttonConfigSaveCharacters
            // 
            this.buttonConfigSaveCharacters.Location = new System.Drawing.Point(354, 436);
            this.buttonConfigSaveCharacters.Name = "buttonConfigSaveCharacters";
            this.buttonConfigSaveCharacters.Size = new System.Drawing.Size(111, 35);
            this.buttonConfigSaveCharacters.TabIndex = 6;
            this.buttonConfigSaveCharacters.Text = "Save Configuration";
            this.buttonConfigSaveCharacters.UseVisualStyleBackColor = true;
            // 
            // CharacterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 482);
            this.Controls.Add(this.buttonConfigSaveCharacters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxConfigCharacterClass);
            this.Controls.Add(this.textBoxConfigCharacterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxConfigGameWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CharacterConfigForm";
            this.Text = "CharacterConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConfigGameWindows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxConfigCharacterName;
        private System.Windows.Forms.ComboBox comboBoxConfigCharacterClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConfigSaveCharacters;
    }
}