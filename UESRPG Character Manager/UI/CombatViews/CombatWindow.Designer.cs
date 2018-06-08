namespace UESRPG_Character_Manager.UI.CombatViews
{
    partial class CombatWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.weaponDamageView = new UESRPG_Character_Manager.UI.ActionViews.WeaponDamageView();
            this.spellDamageView = new UESRPG_Character_Manager.UI.ActionViews.SpellDamageView();
            this.checkRollView = new UESRPG_Character_Manager.UI.ActionViews.CheckRollView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.characterHealthView = new UESRPG_Character_Manager.UI.CharacterViews.CharacterHealthView();
            this.combatantsListView = new UESRPG_Character_Manager.UI.CombatViews.CombatantsListView();
            this.actBt = new System.Windows.Forms.Button();
            this.passBt = new System.Windows.Forms.Button();
            this.newRoundBt = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(268, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 302);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.weaponDamageView);
            this.tabPage1.Controls.Add(this.spellDamageView);
            this.tabPage1.Controls.Add(this.checkRollView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Action";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // weaponDamageView
            // 
            this.weaponDamageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weaponDamageView.Location = new System.Drawing.Point(244, 145);
            this.weaponDamageView.MinimumSize = new System.Drawing.Size(0, 127);
            this.weaponDamageView.Name = "weaponDamageView";
            this.weaponDamageView.Size = new System.Drawing.Size(236, 127);
            this.weaponDamageView.TabIndex = 2;
            // 
            // spellDamageView
            // 
            this.spellDamageView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spellDamageView.Location = new System.Drawing.Point(6, 145);
            this.spellDamageView.MinimumSize = new System.Drawing.Size(0, 127);
            this.spellDamageView.Name = "spellDamageView";
            this.spellDamageView.Size = new System.Drawing.Size(232, 127);
            this.spellDamageView.TabIndex = 1;
            // 
            // checkRollView
            // 
            this.checkRollView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRollView.Location = new System.Drawing.Point(2, 2);
            this.checkRollView.Name = "checkRollView";
            this.checkRollView.Size = new System.Drawing.Size(478, 137);
            this.checkRollView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(486, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reaction";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // characterHealthView
            // 
            this.characterHealthView.CharacterId = ((uint)(0u));
            this.characterHealthView.Location = new System.Drawing.Point(268, 12);
            this.characterHealthView.Name = "characterHealthView";
            this.characterHealthView.Size = new System.Drawing.Size(324, 77);
            this.characterHealthView.TabIndex = 1;
            // 
            // combatantsListView
            // 
            this.combatantsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.combatantsListView.Location = new System.Drawing.Point(12, 12);
            this.combatantsListView.Name = "combatantsListView";
            this.combatantsListView.Size = new System.Drawing.Size(250, 414);
            this.combatantsListView.TabIndex = 0;
            // 
            // actBt
            // 
            this.actBt.Location = new System.Drawing.Point(524, 400);
            this.actBt.Name = "actBt";
            this.actBt.Size = new System.Drawing.Size(75, 23);
            this.actBt.TabIndex = 3;
            this.actBt.Text = "Act";
            this.actBt.UseVisualStyleBackColor = true;
            this.actBt.Click += new System.EventHandler(this.actBt_Click);
            // 
            // passBt
            // 
            this.passBt.Location = new System.Drawing.Point(605, 400);
            this.passBt.Name = "passBt";
            this.passBt.Size = new System.Drawing.Size(75, 23);
            this.passBt.TabIndex = 4;
            this.passBt.Text = "Pass";
            this.passBt.UseVisualStyleBackColor = true;
            this.passBt.Click += new System.EventHandler(this.passBt_Click);
            // 
            // newRoundBt
            // 
            this.newRoundBt.Location = new System.Drawing.Point(686, 400);
            this.newRoundBt.Name = "newRoundBt";
            this.newRoundBt.Size = new System.Drawing.Size(75, 23);
            this.newRoundBt.TabIndex = 5;
            this.newRoundBt.Text = "New Round";
            this.newRoundBt.UseVisualStyleBackColor = true;
            this.newRoundBt.Click += new System.EventHandler(this.newRoundBt_Click);
            // 
            // CombatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 431);
            this.Controls.Add(this.newRoundBt);
            this.Controls.Add(this.passBt);
            this.Controls.Add(this.actBt);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.characterHealthView);
            this.Controls.Add(this.combatantsListView);
            this.Name = "CombatWindow";
            this.Text = "Combat";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CombatantsListView combatantsListView;
        private CharacterViews.CharacterHealthView characterHealthView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ActionViews.CheckRollView checkRollView;
        private ActionViews.SpellDamageView spellDamageView;
        private ActionViews.WeaponDamageView weaponDamageView;
        private System.Windows.Forms.Button actBt;
        private System.Windows.Forms.Button passBt;
        private System.Windows.Forms.Button newRoundBt;
    }
}