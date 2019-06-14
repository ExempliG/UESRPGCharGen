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
            this.weaponDamageView_action = new UESRPG_Character_Manager.UI.ActionViews.WeaponDamageView();
            this.spellDamageView_action = new UESRPG_Character_Manager.UI.ActionViews.SpellDamageView();
            this.checkRollView_action = new UESRPG_Character_Manager.UI.ActionViews.CheckRollView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.weaponDamageView_reaction = new UESRPG_Character_Manager.UI.ActionViews.WeaponDamageView();
            this.checkRollView_reaction = new UESRPG_Character_Manager.UI.ActionViews.CheckRollView();
            this.receivedDamageView_reaction = new UESRPG_Character_Manager.UI.ActionViews.ReceivedDamageView();
            this.actBt = new System.Windows.Forms.Button();
            this.passBt = new System.Windows.Forms.Button();
            this.newRoundBt = new System.Windows.Forms.Button();
            this.characterHealthView = new UESRPG_Character_Manager.UI.CharacterViews.CharacterHealthView();
            this.combatantsListView = new UESRPG_Character_Manager.UI.Selectors.CombatantsListView();
            this.label1 = new System.Windows.Forms.Label();
            this.initiativeNud = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initiativeNud)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(268, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 332);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.weaponDamageView_action);
            this.tabPage1.Controls.Add(this.spellDamageView_action);
            this.tabPage1.Controls.Add(this.checkRollView_action);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Action";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // weaponDamageView_action
            // 
            this.weaponDamageView_action.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weaponDamageView_action.Location = new System.Drawing.Point(244, 145);
            this.weaponDamageView_action.MinimumSize = new System.Drawing.Size(0, 127);
            this.weaponDamageView_action.Name = "weaponDamageView_action";
            this.weaponDamageView_action.Size = new System.Drawing.Size(236, 157);
            this.weaponDamageView_action.TabIndex = 2;
            // 
            // spellDamageView_action
            // 
            this.spellDamageView_action.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spellDamageView_action.Location = new System.Drawing.Point(6, 145);
            this.spellDamageView_action.MinimumSize = new System.Drawing.Size(0, 127);
            this.spellDamageView_action.Name = "spellDamageView_action";
            this.spellDamageView_action.Size = new System.Drawing.Size(232, 157);
            this.spellDamageView_action.TabIndex = 1;
            // 
            // checkRollView_action
            // 
            this.checkRollView_action.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRollView_action.Location = new System.Drawing.Point(2, 2);
            this.checkRollView_action.Name = "checkRollView_action";
            this.checkRollView_action.Size = new System.Drawing.Size(478, 137);
            this.checkRollView_action.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.weaponDamageView_reaction);
            this.tabPage2.Controls.Add(this.checkRollView_reaction);
            this.tabPage2.Controls.Add(this.receivedDamageView_reaction);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(486, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reaction";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // weaponDamageView_reaction
            // 
            this.weaponDamageView_reaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weaponDamageView_reaction.Location = new System.Drawing.Point(244, 145);
            this.weaponDamageView_reaction.MinimumSize = new System.Drawing.Size(0, 127);
            this.weaponDamageView_reaction.Name = "weaponDamageView_reaction";
            this.weaponDamageView_reaction.Size = new System.Drawing.Size(236, 158);
            this.weaponDamageView_reaction.TabIndex = 3;
            // 
            // checkRollView_reaction
            // 
            this.checkRollView_reaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRollView_reaction.Location = new System.Drawing.Point(2, 2);
            this.checkRollView_reaction.Name = "checkRollView_reaction";
            this.checkRollView_reaction.Size = new System.Drawing.Size(478, 137);
            this.checkRollView_reaction.TabIndex = 1;
            // 
            // receivedDamageView_reaction
            // 
            this.receivedDamageView_reaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.receivedDamageView_reaction.Location = new System.Drawing.Point(6, 145);
            this.receivedDamageView_reaction.Name = "receivedDamageView_reaction";
            this.receivedDamageView_reaction.Size = new System.Drawing.Size(232, 161);
            this.receivedDamageView_reaction.TabIndex = 0;
            // 
            // actBt
            // 
            this.actBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.actBt.Enabled = false;
            this.actBt.Location = new System.Drawing.Point(524, 430);
            this.actBt.Name = "actBt";
            this.actBt.Size = new System.Drawing.Size(75, 23);
            this.actBt.TabIndex = 3;
            this.actBt.Text = "Act";
            this.actBt.UseVisualStyleBackColor = true;
            this.actBt.Click += new System.EventHandler(this.actBt_Click);
            // 
            // passBt
            // 
            this.passBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.passBt.Enabled = false;
            this.passBt.Location = new System.Drawing.Point(605, 430);
            this.passBt.Name = "passBt";
            this.passBt.Size = new System.Drawing.Size(75, 23);
            this.passBt.TabIndex = 4;
            this.passBt.Text = "Pass";
            this.passBt.UseVisualStyleBackColor = true;
            this.passBt.Click += new System.EventHandler(this.passBt_Click);
            // 
            // newRoundBt
            // 
            this.newRoundBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newRoundBt.Enabled = false;
            this.newRoundBt.Location = new System.Drawing.Point(686, 430);
            this.newRoundBt.Name = "newRoundBt";
            this.newRoundBt.Size = new System.Drawing.Size(75, 23);
            this.newRoundBt.TabIndex = 5;
            this.newRoundBt.Text = "New Round";
            this.newRoundBt.UseVisualStyleBackColor = true;
            this.newRoundBt.Click += new System.EventHandler(this.newRoundBt_Click);
            // 
            // characterHealthView
            // 
            this.characterHealthView.Enabled = false;
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
            this.combatantsListView.Size = new System.Drawing.Size(250, 441);
            this.combatantsListView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Initiative";
            // 
            // initiativeNud
            // 
            this.initiativeNud.Location = new System.Drawing.Point(657, 39);
            this.initiativeNud.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.initiativeNud.Name = "initiativeNud";
            this.initiativeNud.Size = new System.Drawing.Size(95, 20);
            this.initiativeNud.TabIndex = 7;
            // 
            // CombatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 461);
            this.Controls.Add(this.initiativeNud);
            this.Controls.Add(this.label1);
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
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.initiativeNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Selectors.CombatantsListView combatantsListView;
        private CharacterViews.CharacterHealthView characterHealthView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ActionViews.CheckRollView checkRollView_action;
        private ActionViews.SpellDamageView spellDamageView_action;
        private ActionViews.WeaponDamageView weaponDamageView_action;
        private System.Windows.Forms.Button actBt;
        private System.Windows.Forms.Button passBt;
        private System.Windows.Forms.Button newRoundBt;
        private ActionViews.ReceivedDamageView receivedDamageView_reaction;
        private ActionViews.CheckRollView checkRollView_reaction;
        private ActionViews.WeaponDamageView weaponDamageView_reaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown initiativeNud;
    }
}