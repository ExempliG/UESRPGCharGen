namespace UESRPG_Character_Manager.UI.MainWindow
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spellListView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.SpellListView();
            this.skillListView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.SkillListView();
            this.attributesView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.AttributesView();
            this.charaView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.CharacteristicsView();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.armorView_equipPage = new UESRPG_Character_Manager.UI.CharacterViews.ArmorView();
            this.weaponsView_equipPage = new UESRPG_Character_Manager.UI.CharacterViews.WeaponsView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.receivedDamageView_rollsPage = new UESRPG_Character_Manager.UI.ActionViews.ReceivedDamageView();
            this.spellDamageView_rollsPage = new UESRPG_Character_Manager.UI.ActionViews.SpellDamageView();
            this.weaponDamageView_rollsPage = new UESRPG_Character_Manager.UI.ActionViews.WeaponDamageView();
            this.checkRollView_rollsPage = new UESRPG_Character_Manager.UI.ActionViews.CheckRollView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.characterNotesRtb = new System.Windows.Forms.RichTextBox();
            this.spellsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.characterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.weaponsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMi = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMi = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.characterSelector = new UESRPG_Character_Manager.UI.MainWindow.CharacterSelector();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.spellListView_statsPage);
            this.tabPage1.Controls.Add(this.skillListView_statsPage);
            this.tabPage1.Controls.Add(this.attributesView_statsPage);
            this.tabPage1.Controls.Add(this.charaView_statsPage);
            this.tabPage1.Controls.Add(this.nameTb);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(992, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // spellListView_statsPage
            // 
            this.spellListView_statsPage.Location = new System.Drawing.Point(484, 198);
            this.spellListView_statsPage.Name = "spellListView_statsPage";
            this.spellListView_statsPage.Size = new System.Drawing.Size(504, 170);
            this.spellListView_statsPage.TabIndex = 8;
            // 
            // skillListView_statsPage
            // 
            this.skillListView_statsPage.Location = new System.Drawing.Point(484, 37);
            this.skillListView_statsPage.Name = "skillListView_statsPage";
            this.skillListView_statsPage.Size = new System.Drawing.Size(504, 155);
            this.skillListView_statsPage.TabIndex = 4;
            // 
            // attributesView_statsPage
            // 
            this.attributesView_statsPage.Location = new System.Drawing.Point(134, 37);
            this.attributesView_statsPage.Name = "attributesView_statsPage";
            this.attributesView_statsPage.Size = new System.Drawing.Size(344, 329);
            this.attributesView_statsPage.TabIndex = 3;
            // 
            // charaView_statsPage
            // 
            this.charaView_statsPage.Location = new System.Drawing.Point(3, 37);
            this.charaView_statsPage.Name = "charaView_statsPage";
            this.charaView_statsPage.Size = new System.Drawing.Size(129, 232);
            this.charaView_statsPage.TabIndex = 2;
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(44, 6);
            this.nameTb.Margin = new System.Windows.Forms.Padding(2);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(81, 20);
            this.nameTb.TabIndex = 1;
            this.nameTb.TextChanged += new System.EventHandler(this.nameTb_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(5, 8);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 7;
            this.label31.Text = "Name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.armorView_equipPage);
            this.tabPage3.Controls.Add(this.weaponsView_equipPage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(992, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Equipment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // armorView_equipPage
            // 
            this.armorView_equipPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.armorView_equipPage.Location = new System.Drawing.Point(482, 6);
            this.armorView_equipPage.Name = "armorView_equipPage";
            this.armorView_equipPage.Size = new System.Drawing.Size(504, 376);
            this.armorView_equipPage.TabIndex = 27;
            // 
            // weaponsView_equipPage
            // 
            this.weaponsView_equipPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.weaponsView_equipPage.Location = new System.Drawing.Point(4, 6);
            this.weaponsView_equipPage.Name = "weaponsView_equipPage";
            this.weaponsView_equipPage.Size = new System.Drawing.Size(474, 377);
            this.weaponsView_equipPage.TabIndex = 26;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.receivedDamageView_rollsPage);
            this.tabPage2.Controls.Add(this.spellDamageView_rollsPage);
            this.tabPage2.Controls.Add(this.weaponDamageView_rollsPage);
            this.tabPage2.Controls.Add(this.checkRollView_rollsPage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Combat & Rolls";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // receivedDamageView_rollsPage
            // 
            this.receivedDamageView_rollsPage.Location = new System.Drawing.Point(516, 6);
            this.receivedDamageView_rollsPage.Name = "receivedDamageView_rollsPage";
            this.receivedDamageView_rollsPage.Size = new System.Drawing.Size(175, 185);
            this.receivedDamageView_rollsPage.TabIndex = 32;
            // 
            // spellDamageView_rollsPage
            // 
            this.spellDamageView_rollsPage.Location = new System.Drawing.Point(262, 149);
            this.spellDamageView_rollsPage.Name = "spellDamageView_rollsPage";
            this.spellDamageView_rollsPage.Size = new System.Drawing.Size(249, 156);
            this.spellDamageView_rollsPage.TabIndex = 31;
            // 
            // weaponDamageView_rollsPage
            // 
            this.weaponDamageView_rollsPage.Location = new System.Drawing.Point(6, 149);
            this.weaponDamageView_rollsPage.Name = "weaponDamageView_rollsPage";
            this.weaponDamageView_rollsPage.Size = new System.Drawing.Size(250, 156);
            this.weaponDamageView_rollsPage.TabIndex = 30;
            // 
            // checkRollView_rollsPage
            // 
            this.checkRollView_rollsPage.Location = new System.Drawing.Point(6, 6);
            this.checkRollView_rollsPage.Name = "checkRollView_rollsPage";
            this.checkRollView_rollsPage.Size = new System.Drawing.Size(504, 137);
            this.checkRollView_rollsPage.TabIndex = 29;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.characterNotesRtb);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(992, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Notes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // characterNotesRtb
            // 
            this.characterNotesRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.characterNotesRtb.Location = new System.Drawing.Point(7, 7);
            this.characterNotesRtb.Name = "characterNotesRtb";
            this.characterNotesRtb.Size = new System.Drawing.Size(979, 349);
            this.characterNotesRtb.TabIndex = 0;
            this.characterNotesRtb.Text = "";
            // 
            // spellsBindingSource
            // 
            this.spellsBindingSource.DataMember = "Spells";
            this.spellsBindingSource.DataSource = this.characterBindingSource;
            // 
            // characterBindingSource
            // 
            this.characterBindingSource.DataSource = typeof(UESRPG_Character_Manager.CharacterComponents.Character);
            // 
            // weaponsBindingSource
            // 
            this.weaponsBindingSource.DataMember = "Weapons";
            this.weaponsBindingSource.DataSource = this.characterBindingSource;
            // 
            // skillsBindingSource
            // 
            this.skillsBindingSource.DataMember = "Skills";
            this.skillsBindingSource.DataSource = this.characterBindingSource;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMi,
            this.saveAsMi,
            this.loadMi});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // saveMi
            // 
            this.saveMi.Name = "saveMi";
            this.saveMi.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveMi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMi.Size = new System.Drawing.Size(193, 22);
            this.saveMi.Text = "Save";
            this.saveMi.Click += new System.EventHandler(this.saveMi_Click);
            // 
            // saveAsMi
            // 
            this.saveAsMi.Name = "saveAsMi";
            this.saveAsMi.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMi.Size = new System.Drawing.Size(193, 22);
            this.saveAsMi.Text = "Save as...";
            this.saveAsMi.Click += new System.EventHandler(this.saveAsMi_Click);
            // 
            // loadMi
            // 
            this.loadMi.Name = "loadMi";
            this.loadMi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadMi.Size = new System.Drawing.Size(193, 22);
            this.loadMi.Text = "Load...";
            this.loadMi.Click += new System.EventHandler(this.loadMi_Click);
            // 
            // skillsBindingSource1
            // 
            this.skillsBindingSource1.DataMember = "Skills";
            this.skillsBindingSource1.DataSource = this.characterBindingSource;
            // 
            // characterSelector
            // 
            this.characterSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.characterSelector.Location = new System.Drawing.Point(12, 447);
            this.characterSelector.Name = "characterSelector";
            this.characterSelector.Size = new System.Drawing.Size(322, 23);
            this.characterSelector.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 477);
            this.Controls.Add(this.characterSelector);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1040, 515);
            this.Name = "MainWindow";
            this.Text = "UESRPG Character Generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spellsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label31;
    private System.Windows.Forms.BindingSource characterBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMi;
        private System.Windows.Forms.ToolStripMenuItem saveAsMi;
        private System.Windows.Forms.ToolStripMenuItem loadMi;
        private System.Windows.Forms.BindingSource skillsBindingSource;
        private System.Windows.Forms.BindingSource weaponsBindingSource;
        private System.Windows.Forms.BindingSource spellsBindingSource;
        private System.Windows.Forms.BindingSource skillsBindingSource1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox characterNotesRtb;
        private UI.CharacterViews.CharacteristicsView charaView_statsPage;
        private UI.MainWindow.CharacterSelector characterSelector;
        private UI.CharacterViews.AttributesView attributesView_statsPage;
        private CharacterViews.SkillListView skillListView_statsPage;
        private CharacterViews.SpellListView spellListView_statsPage;
        private CharacterViews.WeaponsView weaponsView_equipPage;
        private CharacterViews.ArmorView armorView_equipPage;
        private ActionViews.CheckRollView checkRollView_rollsPage;
        private ActionViews.WeaponDamageView weaponDamageView_rollsPage;
        private ActionViews.SpellDamageView spellDamageView_rollsPage;
        private ActionViews.ReceivedDamageView receivedDamageView_rollsPage;
    }
}

