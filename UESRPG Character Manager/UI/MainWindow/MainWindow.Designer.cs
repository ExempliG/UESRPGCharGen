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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.charaView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.CharacteristicsView();
            this.attributesView_statsPage = new UESRPG_Character_Manager.UI.AttributesView();
            this.label31 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.checkRollView_statsPage = new UESRPG_Character_Manager.UI.ActionViews.CheckRollView();
            this.skillSpellTc = new System.Windows.Forms.TabControl();
            this.skillsTp = new System.Windows.Forms.TabPage();
            this.skillListView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.SkillListView();
            this.spellsTp = new System.Windows.Forms.TabPage();
            this.spellListView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.SpellListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.armorView_equipPage = new UESRPG_Character_Manager.UI.CharacterViews.ArmorView();
            this.weaponsView_equipPage = new UESRPG_Character_Manager.UI.CharacterViews.WeaponsView();
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
            this.manageCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCombatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.characterSelector = new UESRPG_Character_Manager.UI.Selectors.CharacterSelector();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.skillSpellTc.SuspendLayout();
            this.skillsTp.SuspendLayout();
            this.spellsTp.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.MinimumSize = new System.Drawing.Size(935, 414);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1005, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(997, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.Controls.Add(this.label31);
            this.splitContainer2.Panel1.Controls.Add(this.nameTb);
            this.splitContainer2.Panel1MinSize = 413;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2MinSize = 505;
            this.splitContainer2.Size = new System.Drawing.Size(951, 388);
            this.splitContainer2.SplitterDistance = 413;
            this.splitContainer2.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.charaView_statsPage);
            this.splitContainer1.Panel1MinSize = 127;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.attributesView_statsPage);
            this.splitContainer1.Panel2MinSize = 282;
            this.splitContainer1.Size = new System.Drawing.Size(413, 357);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 12;
            // 
            // charaView_statsPage
            // 
            this.charaView_statsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charaView_statsPage.Location = new System.Drawing.Point(2, 2);
            this.charaView_statsPage.Name = "charaView_statsPage";
            this.charaView_statsPage.Size = new System.Drawing.Size(118, 351);
            this.charaView_statsPage.TabIndex = 2;
            // 
            // attributesView_statsPage
            // 
            this.attributesView_statsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attributesView_statsPage.Location = new System.Drawing.Point(3, 0);
            this.attributesView_statsPage.MinimumSize = new System.Drawing.Size(275, 329);
            this.attributesView_statsPage.Name = "attributesView_statsPage";
            this.attributesView_statsPage.Size = new System.Drawing.Size(275, 353);
            this.attributesView_statsPage.TabIndex = 3;
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
            // nameTb
            // 
            this.nameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTb.Location = new System.Drawing.Point(44, 6);
            this.nameTb.Margin = new System.Windows.Forms.Padding(2);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(188, 20);
            this.nameTb.TabIndex = 1;
            this.nameTb.TextChanged += new System.EventHandler(this.nameTb_TextChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(2, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.checkRollView_statsPage);
            this.splitContainer3.Panel1MinSize = 137;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.skillSpellTc);
            this.splitContainer3.Panel2MinSize = 214;
            this.splitContainer3.Size = new System.Drawing.Size(532, 392);
            this.splitContainer3.SplitterDistance = 142;
            this.splitContainer3.TabIndex = 5;
            // 
            // checkRollView_statsPage
            // 
            this.checkRollView_statsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRollView_statsPage.Location = new System.Drawing.Point(2, 2);
            this.checkRollView_statsPage.MinimumSize = new System.Drawing.Size(502, 137);
            this.checkRollView_statsPage.Name = "checkRollView_statsPage";
            this.checkRollView_statsPage.Size = new System.Drawing.Size(570, 137);
            this.checkRollView_statsPage.TabIndex = 9;
            // 
            // skillSpellTc
            // 
            this.skillSpellTc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skillSpellTc.Controls.Add(this.skillsTp);
            this.skillSpellTc.Controls.Add(this.spellsTp);
            this.skillSpellTc.Location = new System.Drawing.Point(2, 2);
            this.skillSpellTc.MinimumSize = new System.Drawing.Size(505, 214);
            this.skillSpellTc.Name = "skillSpellTc";
            this.skillSpellTc.SelectedIndex = 0;
            this.skillSpellTc.Size = new System.Drawing.Size(570, 243);
            this.skillSpellTc.TabIndex = 10;
            // 
            // skillsTp
            // 
            this.skillsTp.Controls.Add(this.skillListView_statsPage);
            this.skillsTp.Location = new System.Drawing.Point(4, 22);
            this.skillsTp.Name = "skillsTp";
            this.skillsTp.Padding = new System.Windows.Forms.Padding(3);
            this.skillsTp.Size = new System.Drawing.Size(562, 217);
            this.skillsTp.TabIndex = 0;
            this.skillsTp.Text = "Skill List";
            this.skillsTp.UseVisualStyleBackColor = true;
            // 
            // skillListView_statsPage
            // 
            this.skillListView_statsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skillListView_statsPage.Location = new System.Drawing.Point(6, 6);
            this.skillListView_statsPage.Name = "skillListView_statsPage";
            this.skillListView_statsPage.Size = new System.Drawing.Size(550, 208);
            this.skillListView_statsPage.TabIndex = 4;
            // 
            // spellsTp
            // 
            this.spellsTp.Controls.Add(this.spellListView_statsPage);
            this.spellsTp.Location = new System.Drawing.Point(4, 22);
            this.spellsTp.Name = "spellsTp";
            this.spellsTp.Padding = new System.Windows.Forms.Padding(3);
            this.spellsTp.Size = new System.Drawing.Size(522, 217);
            this.spellsTp.TabIndex = 1;
            this.spellsTp.Text = "Spell List";
            this.spellsTp.UseVisualStyleBackColor = true;
            // 
            // spellListView_statsPage
            // 
            this.spellListView_statsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spellListView_statsPage.Location = new System.Drawing.Point(6, 6);
            this.spellListView_statsPage.Name = "spellListView_statsPage";
            this.spellListView_statsPage.Size = new System.Drawing.Size(510, 208);
            this.spellListView_statsPage.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.armorView_equipPage);
            this.tabPage3.Controls.Add(this.weaponsView_equipPage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(997, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Equipment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // armorView_equipPage
            // 
            this.armorView_equipPage.Location = new System.Drawing.Point(482, 6);
            this.armorView_equipPage.MinimumSize = new System.Drawing.Size(509, 376);
            this.armorView_equipPage.Name = "armorView_equipPage";
            this.armorView_equipPage.Size = new System.Drawing.Size(509, 376);
            this.armorView_equipPage.TabIndex = 27;
            // 
            // weaponsView_equipPage
            // 
            this.weaponsView_equipPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.weaponsView_equipPage.Location = new System.Drawing.Point(4, 6);
            this.weaponsView_equipPage.Name = "weaponsView_equipPage";
            this.weaponsView_equipPage.Size = new System.Drawing.Size(472, 377);
            this.weaponsView_equipPage.TabIndex = 26;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.characterNotesRtb);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(997, 388);
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
            this.characterNotesRtb.Size = new System.Drawing.Size(1003, 349);
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
            this.characterBindingSource.DataSource = typeof(UESRPG_Character_Manager.CharacterComponents.Character.Character);
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
            this.fIleToolStripMenuItem,
            this.specialFunctionsToolStripMenuItem});
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
            this.loadMi,
            this.manageCharactersToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "&File";
            // 
            // saveMi
            // 
            this.saveMi.Name = "saveMi";
            this.saveMi.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveMi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMi.Size = new System.Drawing.Size(193, 22);
            this.saveMi.Text = "&Save";
            this.saveMi.Click += new System.EventHandler(this.saveMi_Click);
            // 
            // saveAsMi
            // 
            this.saveAsMi.Name = "saveAsMi";
            this.saveAsMi.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMi.Size = new System.Drawing.Size(193, 22);
            this.saveAsMi.Text = "Save &as...";
            this.saveAsMi.Click += new System.EventHandler(this.saveAsMi_Click);
            // 
            // loadMi
            // 
            this.loadMi.Name = "loadMi";
            this.loadMi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadMi.Size = new System.Drawing.Size(193, 22);
            this.loadMi.Text = "&Load...";
            this.loadMi.Click += new System.EventHandler(this.loadMi_Click);
            // 
            // manageCharactersToolStripMenuItem
            // 
            this.manageCharactersToolStripMenuItem.Enabled = false;
            this.manageCharactersToolStripMenuItem.Name = "manageCharactersToolStripMenuItem";
            this.manageCharactersToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.manageCharactersToolStripMenuItem.Text = "Manage Characters";
            this.manageCharactersToolStripMenuItem.Click += new System.EventHandler(this.manageCharactersToolStripMenuItem_Click);
            // 
            // specialFunctionsToolStripMenuItem
            // 
            this.specialFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCombatMenuItem,
            this.showConsoleToolStripMenuItem});
            this.specialFunctionsToolStripMenuItem.Name = "specialFunctionsToolStripMenuItem";
            this.specialFunctionsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.specialFunctionsToolStripMenuItem.Text = "Special &Functions";
            // 
            // newCombatMenuItem
            // 
            this.newCombatMenuItem.Enabled = false;
            this.newCombatMenuItem.Name = "newCombatMenuItem";
            this.newCombatMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newCombatMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newCombatMenuItem.Text = "New &Combat";
            this.newCombatMenuItem.Click += new System.EventHandler(this.newCombatMenuItem_Click);
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.showConsoleToolStripMenuItem.Text = "Show Console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.showConsoleToolStripMenuItem_Click);
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
            this.MinimumSize = new System.Drawing.Size(970, 516);
            this.Name = "MainWindow";
            this.Text = "UESRPG Character Generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.skillSpellTc.ResumeLayout(false);
            this.skillsTp.ResumeLayout(false);
            this.spellsTp.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
        private UI.Selectors.CharacterSelector characterSelector;
        private AttributesView attributesView_statsPage;
        private CharacterViews.SkillListView skillListView_statsPage;
        private CharacterViews.SpellListView spellListView_statsPage;
        private CharacterViews.WeaponsView weaponsView_equipPage;
        private CharacterViews.ArmorView armorView_equipPage;
        private System.Windows.Forms.ToolStripMenuItem manageCharactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCombatMenuItem;
        private System.Windows.Forms.TabControl skillSpellTc;
        private System.Windows.Forms.TabPage skillsTp;
        private System.Windows.Forms.TabPage spellsTp;
        private ActionViews.CheckRollView checkRollView_statsPage;
        private System.Windows.Forms.ToolStripMenuItem showConsoleToolStripMenuItem;
        private CharacterViews.CharacteristicsView charaView_statsPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}

