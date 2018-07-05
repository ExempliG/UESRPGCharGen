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
            this.npcNameTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // npcRb
            // 
            this.npcRb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.npcRb.AutoSize = true;
            this.npcRb.Location = new System.Drawing.Point(13, 16);
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
            this.characterRb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.characterRb.AutoSize = true;
            this.characterRb.Location = new System.Drawing.Point(13, 40);
            this.characterRb.Name = "characterRb";
            this.characterRb.Size = new System.Drawing.Size(93, 17);
            this.characterRb.TabIndex = 2;
            this.characterRb.TabStop = true;
            this.characterRb.Text = "Add Character";
            this.characterRb.UseVisualStyleBackColor = true;
            this.characterRb.CheckedChanged += new System.EventHandler(this.characterRb_CheckedChanged);
            // 
            // characterCb
            // 
            this.characterCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.characterCb.FormattingEnabled = true;
            this.characterCb.Location = new System.Drawing.Point(112, 39);
            this.characterCb.Name = "characterCb";
            this.characterCb.Size = new System.Drawing.Size(188, 21);
            this.characterCb.TabIndex = 3;
            this.characterCb.SelectedIndexChanged += new System.EventHandler(this.characterCb_SelectedIndexChanged);
            // 
            // okBt
            // 
            this.okBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBt.Location = new System.Drawing.Point(146, 69);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(75, 23);
            this.okBt.TabIndex = 4;
            this.okBt.Text = "OK";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBt.Location = new System.Drawing.Point(227, 69);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 5;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // npcNameTb
            // 
            this.npcNameTb.Location = new System.Drawing.Point(112, 15);
            this.npcNameTb.Name = "npcNameTb";
            this.npcNameTb.Size = new System.Drawing.Size(188, 20);
            this.npcNameTb.TabIndex = 1;
            this.npcNameTb.Text = "Other Combatant(s)";
            // 
            // NewCombatantWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 102);
            this.Controls.Add(this.npcNameTb);
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
        private System.Windows.Forms.TextBox npcNameTb;
    }
}