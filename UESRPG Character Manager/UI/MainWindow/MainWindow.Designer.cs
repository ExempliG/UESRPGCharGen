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
            this.attributesView_statsPage = new UESRPG_Character_Manager.UI.AttributesView();
            this.charaView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.CharacteristicsView();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.armorView_equipPage = new UESRPG_Character_Manager.UI.CharacterViews.ArmorView();
            this.weaponsView_equipPage = new UESRPG_Character_Manager.UI.CharacterViews.WeaponsView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.healthLb = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.spellRollBt = new System.Windows.Forms.Button();
            this.spellResultBreakdownTb = new System.Windows.Forms.TextBox();
            this.spellResultTb = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.spellsCb = new System.Windows.Forms.ComboBox();
            this.spellsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.characterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.weaponResultBreakdownTb = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.weaponResultTb = new System.Windows.Forms.TextBox();
            this.weaponRollBt = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.weaponCb = new System.Windows.Forms.ComboBox();
            this.weaponsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.applyDamageBt = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.finalDamageReceivedTb = new System.Windows.Forms.TextBox();
            this.hitLocationCb = new System.Windows.Forms.ComboBox();
            this.receivedPenTb = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.receivedDamageTb = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.notesCommitChangesBt = new System.Windows.Forms.Button();
            this.characterNotesRtb = new System.Windows.Forms.RichTextBox();
            this.skillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMi = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMi = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.characterSelector = new UESRPG_Character_Manager.UI.MainWindow.CharacterSelector();
            this.checkRollView_rollsPage = new UESRPG_Character_Manager.UI.ActionViews.CheckRollView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsBindingSource)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.armorView_equipPage.Location = new System.Drawing.Point(482, 6);
            this.armorView_equipPage.Name = "armorView_equipPage";
            this.armorView_equipPage.Size = new System.Drawing.Size(504, 370);
            this.armorView_equipPage.TabIndex = 27;
            // 
            // weaponsView_equipPage
            // 
            this.weaponsView_equipPage.Location = new System.Drawing.Point(4, 6);
            this.weaponsView_equipPage.Name = "weaponsView_equipPage";
            this.weaponsView_equipPage.Size = new System.Drawing.Size(474, 377);
            this.weaponsView_equipPage.TabIndex = 26;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.checkRollView_rollsPage);
            this.tabPage2.Controls.Add(this.healthLb);
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Combat & Rolls";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // healthLb
            // 
            this.healthLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.healthLb.AutoSize = true;
            this.healthLb.Location = new System.Drawing.Point(813, 171);
            this.healthLb.Name = "healthLb";
            this.healthLb.Size = new System.Drawing.Size(41, 13);
            this.healthLb.TabIndex = 28;
            this.healthLb.Text = "Health:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.spellRollBt);
            this.groupBox10.Controls.Add(this.spellResultBreakdownTb);
            this.groupBox10.Controls.Add(this.spellResultTb);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.spellsCb);
            this.groupBox10.Location = new System.Drawing.Point(260, 149);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(248, 155);
            this.groupBox10.TabIndex = 27;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Spell Damage";
            // 
            // spellRollBt
            // 
            this.spellRollBt.Enabled = false;
            this.spellRollBt.Location = new System.Drawing.Point(167, 98);
            this.spellRollBt.Name = "spellRollBt";
            this.spellRollBt.Size = new System.Drawing.Size(75, 23);
            this.spellRollBt.TabIndex = 6;
            this.spellRollBt.Text = "Roll";
            this.spellRollBt.UseVisualStyleBackColor = true;
            this.spellRollBt.Click += new System.EventHandler(this.spellRollBt_Click);
            // 
            // spellResultBreakdownTb
            // 
            this.spellResultBreakdownTb.Location = new System.Drawing.Point(76, 72);
            this.spellResultBreakdownTb.Name = "spellResultBreakdownTb";
            this.spellResultBreakdownTb.Size = new System.Drawing.Size(166, 20);
            this.spellResultBreakdownTb.TabIndex = 5;
            // 
            // spellResultTb
            // 
            this.spellResultTb.Location = new System.Drawing.Point(76, 46);
            this.spellResultTb.Name = "spellResultTb";
            this.spellResultTb.Size = new System.Drawing.Size(166, 20);
            this.spellResultTb.TabIndex = 4;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 75);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(64, 13);
            this.label43.TabIndex = 3;
            this.label43.Text = "Breakdown:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 49);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 13);
            this.label41.TabIndex = 2;
            this.label41.Text = "Result:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 22);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(33, 13);
            this.label40.TabIndex = 1;
            this.label40.Text = "Spell:";
            // 
            // spellsCb
            // 
            this.spellsCb.DataSource = this.spellsBindingSource;
            this.spellsCb.FormattingEnabled = true;
            this.spellsCb.Location = new System.Drawing.Point(76, 19);
            this.spellsCb.Name = "spellsCb";
            this.spellsCb.Size = new System.Drawing.Size(166, 21);
            this.spellsCb.TabIndex = 0;
            this.spellsCb.SelectedIndexChanged += new System.EventHandler(this.spellsCb_SelectedIndexChanged);
            // 
            // spellsBindingSource
            // 
            this.spellsBindingSource.DataMember = "Spells";
            this.spellsBindingSource.DataSource = this.characterBindingSource;
            // 
            // characterBindingSource
            // 
            this.characterBindingSource.DataSource = typeof(UESRPG_Character_Manager.Character);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label39);
            this.groupBox8.Controls.Add(this.weaponResultBreakdownTb);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Controls.Add(this.weaponResultTb);
            this.groupBox8.Controls.Add(this.weaponRollBt);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.weaponCb);
            this.groupBox8.Location = new System.Drawing.Point(6, 149);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(248, 155);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Weapon Damage";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 75);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 13);
            this.label39.TabIndex = 6;
            this.label39.Text = "Breakdown:";
            // 
            // weaponResultBreakdownTb
            // 
            this.weaponResultBreakdownTb.Location = new System.Drawing.Point(76, 72);
            this.weaponResultBreakdownTb.Name = "weaponResultBreakdownTb";
            this.weaponResultBreakdownTb.Size = new System.Drawing.Size(166, 20);
            this.weaponResultBreakdownTb.TabIndex = 5;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 49);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(40, 13);
            this.label38.TabIndex = 4;
            this.label38.Text = "Result:";
            // 
            // weaponResultTb
            // 
            this.weaponResultTb.Location = new System.Drawing.Point(76, 46);
            this.weaponResultTb.Name = "weaponResultTb";
            this.weaponResultTb.Size = new System.Drawing.Size(166, 20);
            this.weaponResultTb.TabIndex = 3;
            // 
            // weaponRollBt
            // 
            this.weaponRollBt.Enabled = false;
            this.weaponRollBt.Location = new System.Drawing.Point(167, 98);
            this.weaponRollBt.Name = "weaponRollBt";
            this.weaponRollBt.Size = new System.Drawing.Size(75, 23);
            this.weaponRollBt.TabIndex = 2;
            this.weaponRollBt.Text = "Roll";
            this.weaponRollBt.UseVisualStyleBackColor = true;
            this.weaponRollBt.Click += new System.EventHandler(this.weaponRollBt_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "Weapon:";
            // 
            // weaponCb
            // 
            this.weaponCb.DataSource = this.weaponsBindingSource;
            this.weaponCb.DisplayMember = "Name";
            this.weaponCb.FormattingEnabled = true;
            this.weaponCb.Location = new System.Drawing.Point(76, 19);
            this.weaponCb.Name = "weaponCb";
            this.weaponCb.Size = new System.Drawing.Size(166, 21);
            this.weaponCb.TabIndex = 0;
            this.weaponCb.SelectedIndexChanged += new System.EventHandler(this.weaponCb_SelectedIndexChanged);
            // 
            // weaponsBindingSource
            // 
            this.weaponsBindingSource.DataMember = "Weapons";
            this.weaponsBindingSource.DataSource = this.characterBindingSource;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.applyDamageBt);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.finalDamageReceivedTb);
            this.groupBox5.Controls.Add(this.hitLocationCb);
            this.groupBox5.Controls.Add(this.receivedPenTb);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.receivedDamageTb);
            this.groupBox5.Location = new System.Drawing.Point(813, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 155);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Received Damage";
            // 
            // applyDamageBt
            // 
            this.applyDamageBt.Location = new System.Drawing.Point(61, 125);
            this.applyDamageBt.Name = "applyDamageBt";
            this.applyDamageBt.Size = new System.Drawing.Size(102, 23);
            this.applyDamageBt.TabIndex = 8;
            this.applyDamageBt.Text = "Apply Damage";
            this.applyDamageBt.UseVisualStyleBackColor = true;
            this.applyDamageBt.Click += new System.EventHandler(this.applyDamageBt_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 102);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 13);
            this.label36.TabIndex = 7;
            this.label36.Text = "Result:";
            // 
            // finalDamageReceivedTb
            // 
            this.finalDamageReceivedTb.Location = new System.Drawing.Point(63, 99);
            this.finalDamageReceivedTb.Name = "finalDamageReceivedTb";
            this.finalDamageReceivedTb.Size = new System.Drawing.Size(100, 20);
            this.finalDamageReceivedTb.TabIndex = 6;
            // 
            // hitLocationCb
            // 
            this.hitLocationCb.FormattingEnabled = true;
            this.hitLocationCb.Location = new System.Drawing.Point(63, 72);
            this.hitLocationCb.Name = "hitLocationCb";
            this.hitLocationCb.Size = new System.Drawing.Size(100, 21);
            this.hitLocationCb.TabIndex = 5;
            this.hitLocationCb.SelectedIndexChanged += new System.EventHandler(this.receivedDamage_ParameterChange);
            // 
            // receivedPenTb
            // 
            this.receivedPenTb.Location = new System.Drawing.Point(63, 46);
            this.receivedPenTb.Name = "receivedPenTb";
            this.receivedPenTb.Size = new System.Drawing.Size(100, 20);
            this.receivedPenTb.TabIndex = 4;
            this.receivedPenTb.Text = "0";
            this.receivedPenTb.TextChanged += new System.EventHandler(this.receivedDamage_ParameterChange);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 75);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(51, 13);
            this.label35.TabIndex = 3;
            this.label35.Text = "Location:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 49);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Pen:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 13);
            this.label32.TabIndex = 1;
            this.label32.Text = "Damage:";
            // 
            // receivedDamageTb
            // 
            this.receivedDamageTb.Location = new System.Drawing.Point(63, 20);
            this.receivedDamageTb.Name = "receivedDamageTb";
            this.receivedDamageTb.Size = new System.Drawing.Size(100, 20);
            this.receivedDamageTb.TabIndex = 0;
            this.receivedDamageTb.Text = "0";
            this.receivedDamageTb.TextChanged += new System.EventHandler(this.receivedDamage_ParameterChange);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.notesCommitChangesBt);
            this.tabPage4.Controls.Add(this.characterNotesRtb);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(992, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Notes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // notesCommitChangesBt
            // 
            this.notesCommitChangesBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.notesCommitChangesBt.Location = new System.Drawing.Point(895, 362);
            this.notesCommitChangesBt.Name = "notesCommitChangesBt";
            this.notesCommitChangesBt.Size = new System.Drawing.Size(91, 23);
            this.notesCommitChangesBt.TabIndex = 1;
            this.notesCommitChangesBt.Text = "Update Notes";
            this.notesCommitChangesBt.UseVisualStyleBackColor = true;
            this.notesCommitChangesBt.Click += new System.EventHandler(this.notesCommitChangesBt_Click);
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
            this.characterSelector.Location = new System.Drawing.Point(12, 447);
            this.characterSelector.Name = "characterSelector";
            this.characterSelector.Size = new System.Drawing.Size(322, 23);
            this.characterSelector.TabIndex = 5;
            // 
            // checkRollView_rollsPage
            // 
            this.checkRollView_rollsPage.Location = new System.Drawing.Point(6, 6);
            this.checkRollView_rollsPage.Name = "checkRollView_rollsPage";
            this.checkRollView_rollsPage.Size = new System.Drawing.Size(504, 137);
            this.checkRollView_rollsPage.TabIndex = 29;
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
            this.tabPage2.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsBindingSource)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox hitLocationCb;
        private System.Windows.Forms.TextBox receivedPenTb;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox receivedDamageTb;
        private System.Windows.Forms.Button applyDamageBt;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox finalDamageReceivedTb;
        private System.Windows.Forms.BindingSource skillsBindingSource;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox weaponCb;
        private System.Windows.Forms.BindingSource weaponsBindingSource;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox weaponResultTb;
        private System.Windows.Forms.Button weaponRollBt;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox weaponResultBreakdownTb;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button spellRollBt;
        private System.Windows.Forms.TextBox spellResultBreakdownTb;
        private System.Windows.Forms.TextBox spellResultTb;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox spellsCb;
        private System.Windows.Forms.BindingSource spellsBindingSource;
        private System.Windows.Forms.BindingSource skillsBindingSource1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox characterNotesRtb;
        private System.Windows.Forms.Button notesCommitChangesBt;
        private System.Windows.Forms.Label healthLb;
        private UI.CharacterViews.CharacteristicsView charaView_statsPage;
        private UI.MainWindow.CharacterSelector characterSelector;
        private AttributesView attributesView_statsPage;
        private CharacterViews.SkillListView skillListView_statsPage;
        private CharacterViews.SpellListView spellListView_statsPage;
        private CharacterViews.WeaponsView weaponsView_equipPage;
        private CharacterViews.ArmorView armorView_equipPage;
        private ActionViews.CheckRollView checkRollView_rollsPage;
    }
}

