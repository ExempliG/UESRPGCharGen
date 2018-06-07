namespace UESRPG_Character_Manager.UI.CombatViews
{
    partial class NewCombatantWindow
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
            this.npcRb = new System.Windows.Forms.RadioButton();
            this.characterRb = new System.Windows.Forms.RadioButton();
            this.characterCb = new System.Windows.Forms.ComboBox();
            this.okBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // npcRb
            // 
            this.npcRb.AutoSize = true;
            this.npcRb.Location = new System.Drawing.Point(13, 13);
            this.npcRb.Name = "npcRb";
            this.npcRb.Size = new System.Drawing.Size(69, 17);
            this.npcRb.TabIndex = 0;
            this.npcRb.TabStop = true;
            this.npcRb.Text = "Add NPC";
            this.npcRb.UseVisualStyleBackColor = true;
            this.npcRb.CheckedChanged += new System.EventHandler(this.npcRb_CheckedChanged);
            // 
            // characterRb
            // 
            this.characterRb.AutoSize = true;
            this.characterRb.Location = new System.Drawing.Point(13, 37);
            this.characterRb.Name = "characterRb";
            this.characterRb.Size = new System.Drawing.Size(93, 17);
            this.characterRb.TabIndex = 1;
            this.characterRb.TabStop = true;
            this.characterRb.Text = "Add Character";
            this.characterRb.UseVisualStyleBackColor = true;
            this.characterRb.CheckedChanged += new System.EventHandler(this.characterRb_CheckedChanged);
            // 
            // characterCb
            // 
            this.characterCb.FormattingEnabled = true;
            this.characterCb.Location = new System.Drawing.Point(12, 60);
            this.characterCb.Name = "characterCb";
            this.characterCb.Size = new System.Drawing.Size(167, 21);
            this.characterCb.TabIndex = 2;
            // 
            // okBt
            // 
            this.okBt.Location = new System.Drawing.Point(23, 87);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(75, 23);
            this.okBt.TabIndex = 3;
            this.okBt.Text = "OK";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(104, 87);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 4;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // NewCombatantWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 120);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.okBt);
            this.Controls.Add(this.characterCb);
            this.Controls.Add(this.characterRb);
            this.Controls.Add(this.npcRb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCombatantWindow";
            this.Text = "New Combatant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton npcRb;
        private System.Windows.Forms.RadioButton characterRb;
        private System.Windows.Forms.ComboBox characterCb;
        private System.Windows.Forms.Button okBt;
        private System.Windows.Forms.Button cancelBt;
    }
}