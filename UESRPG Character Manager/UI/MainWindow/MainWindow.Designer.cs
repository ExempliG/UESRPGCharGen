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
            this.attributesView_statsPage = new UESRPG_Character_Manager.UI.AttributesView();
            this.charaView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.CharacteristicsView();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.addSpellBt = new System.Windows.Forms.Button();
            this.spellsDgv = new System.Windows.Forms.DataGridView();
            this.skillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.characterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.armorNameTb = new System.Windows.Forms.TextBox();
            this.armorQualityCb = new System.Windows.Forms.ComboBox();
            this.armorMaterialCb = new System.Windows.Forms.ComboBox();
            this.armorTypeCb = new System.Windows.Forms.ComboBox();
            this.armorLocationCb = new System.Windows.Forms.ComboBox();
            this.addNewArmorBt = new System.Windows.Forms.Button();
            this.armorDgv = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.addNewWeaponBt = new System.Windows.Forms.Button();
            this.weaponMaterialCb = new System.Windows.Forms.ComboBox();
            this.weaponTypeCb = new System.Windows.Forms.ComboBox();
            this.weaponNameTb = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.weaponsDgv = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfDiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diceSidesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.penetrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encumbranceValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enchantmentLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reachDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handednessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDireDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.weaponsBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hitLocationLb = new System.Windows.Forms.Label();
            this.extraDifficultyNud = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.successOrFailLb = new System.Windows.Forms.Label();
            this.skillsCb = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.rollSuccessesTb = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.rollBreakdownTb = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.rollResultTb = new System.Windows.Forms.TextBox();
            this.rollBt = new System.Windows.Forms.Button();
            this.characteristicCb = new System.Windows.Forms.ComboBox();
            this.skillRb = new System.Windows.Forms.RadioButton();
            this.characteristicRb = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.weaponResultBreakdownTb = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.weaponResultTb = new System.Windows.Forms.TextBox();
            this.weaponRollBt = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.weaponCb = new System.Windows.Forms.ComboBox();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMi = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMi = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.characterSelector = new UESRPG_Character_Manager.UI.MainWindow.CharacterSelector();
            this.skillListView_statsPage = new UESRPG_Character_Manager.UI.CharacterViews.SkillListView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.armorDgv)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extraDifficultyNud)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.skillListView_statsPage);
            this.tabPage1.Controls.Add(this.attributesView_statsPage);
            this.tabPage1.Controls.Add(this.charaView_statsPage);
            this.tabPage1.Controls.Add(this.groupBox9);
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
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.addSpellBt);
            this.groupBox9.Controls.Add(this.spellsDgv);
            this.groupBox9.Location = new System.Drawing.Point(484, 197);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(502, 169);
            this.groupBox9.TabIndex = 26;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Spells";
            // 
            // addSpellBt
            // 
            this.addSpellBt.Location = new System.Drawing.Point(7, 19);
            this.addSpellBt.Name = "addSpellBt";
            this.addSpellBt.Size = new System.Drawing.Size(75, 23);
            this.addSpellBt.TabIndex = 1;
            this.addSpellBt.Text = "Add Spell";
            this.addSpellBt.UseVisualStyleBackColor = true;
            this.addSpellBt.Click += new System.EventHandler(this.addSpellBt_Click);
            // 
            // spellsDgv
            // 
            this.spellsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spellsDgv.BackgroundColor = System.Drawing.Color.White;
            this.spellsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spellsDgv.Location = new System.Drawing.Point(6, 48);
            this.spellsDgv.Name = "spellsDgv";
            this.spellsDgv.Size = new System.Drawing.Size(494, 115);
            this.spellsDgv.TabIndex = 0;
            // 
            // skillsBindingSource
            // 
            this.skillsBindingSource.DataMember = "Skills";
            this.skillsBindingSource.DataSource = this.characterBindingSource;
            // 
            // characterBindingSource
            // 
            this.characterBindingSource.DataSource = typeof(UESRPG_Character_Manager.Character);
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
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(992, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Equipment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.armorNameTb);
            this.groupBox4.Controls.Add(this.armorQualityCb);
            this.groupBox4.Controls.Add(this.armorMaterialCb);
            this.groupBox4.Controls.Add(this.armorTypeCb);
            this.groupBox4.Controls.Add(this.armorLocationCb);
            this.groupBox4.Controls.Add(this.addNewArmorBt);
            this.groupBox4.Controls.Add(this.armorDgv);
            this.groupBox4.Location = new System.Drawing.Point(484, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(502, 370);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Armor";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(90, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(61, 13);
            this.label33.TabIndex = 27;
            this.label33.Text = "Item Name:";
            // 
            // armorNameTb
            // 
            this.armorNameTb.Location = new System.Drawing.Point(157, 19);
            this.armorNameTb.Name = "armorNameTb";
            this.armorNameTb.Size = new System.Drawing.Size(97, 20);
            this.armorNameTb.TabIndex = 26;
            // 
            // armorQualityCb
            // 
            this.armorQualityCb.FormattingEnabled = true;
            this.armorQualityCb.Location = new System.Drawing.Point(368, 45);
            this.armorQualityCb.Name = "armorQualityCb";
            this.armorQualityCb.Size = new System.Drawing.Size(107, 21);
            this.armorQualityCb.TabIndex = 25;
            // 
            // armorMaterialCb
            // 
            this.armorMaterialCb.FormattingEnabled = true;
            this.armorMaterialCb.Location = new System.Drawing.Point(260, 45);
            this.armorMaterialCb.Name = "armorMaterialCb";
            this.armorMaterialCb.Size = new System.Drawing.Size(100, 21);
            this.armorMaterialCb.TabIndex = 24;
            // 
            // armorTypeCb
            // 
            this.armorTypeCb.FormattingEnabled = true;
            this.armorTypeCb.Location = new System.Drawing.Point(157, 45);
            this.armorTypeCb.Name = "armorTypeCb";
            this.armorTypeCb.Size = new System.Drawing.Size(97, 21);
            this.armorTypeCb.TabIndex = 23;
            // 
            // armorLocationCb
            // 
            this.armorLocationCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.armorLocationCb.FormattingEnabled = true;
            this.armorLocationCb.Location = new System.Drawing.Point(260, 18);
            this.armorLocationCb.Name = "armorLocationCb";
            this.armorLocationCb.Size = new System.Drawing.Size(100, 21);
            this.armorLocationCb.TabIndex = 22;
            // 
            // addNewArmorBt
            // 
            this.addNewArmorBt.Location = new System.Drawing.Point(368, 16);
            this.addNewArmorBt.Name = "addNewArmorBt";
            this.addNewArmorBt.Size = new System.Drawing.Size(107, 23);
            this.addNewArmorBt.TabIndex = 21;
            this.addNewArmorBt.Text = "Add New";
            this.addNewArmorBt.UseVisualStyleBackColor = true;
            this.addNewArmorBt.Click += new System.EventHandler(this.addNewArmorBt_Click);
            // 
            // armorDgv
            // 
            this.armorDgv.AllowUserToAddRows = false;
            this.armorDgv.AllowUserToDeleteRows = false;
            this.armorDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.armorDgv.BackgroundColor = System.Drawing.Color.White;
            this.armorDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.armorDgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.armorDgv.Location = new System.Drawing.Point(6, 72);
            this.armorDgv.Name = "armorDgv";
            this.armorDgv.Size = new System.Drawing.Size(490, 292);
            this.armorDgv.TabIndex = 20;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.addNewWeaponBt);
            this.groupBox7.Controls.Add(this.weaponMaterialCb);
            this.groupBox7.Controls.Add(this.weaponTypeCb);
            this.groupBox7.Controls.Add(this.weaponNameTb);
            this.groupBox7.Controls.Add(this.label37);
            this.groupBox7.Controls.Add(this.weaponsDgv);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 376);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Weapons";
            // 
            // addNewWeaponBt
            // 
            this.addNewWeaponBt.Location = new System.Drawing.Point(306, 18);
            this.addNewWeaponBt.Name = "addNewWeaponBt";
            this.addNewWeaponBt.Size = new System.Drawing.Size(75, 23);
            this.addNewWeaponBt.TabIndex = 5;
            this.addNewWeaponBt.Text = "Add New";
            this.addNewWeaponBt.UseVisualStyleBackColor = true;
            this.addNewWeaponBt.Click += new System.EventHandler(this.addNewWeaponBt_Click);
            // 
            // weaponMaterialCb
            // 
            this.weaponMaterialCb.FormattingEnabled = true;
            this.weaponMaterialCb.Location = new System.Drawing.Point(179, 45);
            this.weaponMaterialCb.Name = "weaponMaterialCb";
            this.weaponMaterialCb.Size = new System.Drawing.Size(121, 21);
            this.weaponMaterialCb.TabIndex = 4;
            // 
            // weaponTypeCb
            // 
            this.weaponTypeCb.FormattingEnabled = true;
            this.weaponTypeCb.Location = new System.Drawing.Point(179, 18);
            this.weaponTypeCb.Name = "weaponTypeCb";
            this.weaponTypeCb.Size = new System.Drawing.Size(121, 21);
            this.weaponTypeCb.TabIndex = 3;
            // 
            // weaponNameTb
            // 
            this.weaponNameTb.Location = new System.Drawing.Point(73, 19);
            this.weaponNameTb.Name = "weaponNameTb";
            this.weaponNameTb.Size = new System.Drawing.Size(100, 20);
            this.weaponNameTb.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(61, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "Item Name:";
            // 
            // weaponsDgv
            // 
            this.weaponsDgv.AllowUserToAddRows = false;
            this.weaponsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.weaponsDgv.AutoGenerateColumns = false;
            this.weaponsDgv.BackgroundColor = System.Drawing.Color.White;
            this.weaponsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weaponsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.numberOfDiceDataGridViewTextBoxColumn,
            this.diceSidesDataGridViewTextBoxColumn,
            this.damageModDataGridViewTextBoxColumn,
            this.penetrationDataGridViewTextBoxColumn,
            this.encumbranceValueDataGridViewTextBoxColumn,
            this.enchantmentLevelDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.reachDataGridViewTextBoxColumn,
            this.handednessDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.qualityDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.isDireDataGridViewCheckBoxColumn});
            this.weaponsDgv.DataSource = this.weaponsBindingSource;
            this.weaponsDgv.Location = new System.Drawing.Point(6, 72);
            this.weaponsDgv.Name = "weaponsDgv";
            this.weaponsDgv.Size = new System.Drawing.Size(460, 298);
            this.weaponsDgv.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // numberOfDiceDataGridViewTextBoxColumn
            // 
            this.numberOfDiceDataGridViewTextBoxColumn.DataPropertyName = "NumberOfDice";
            this.numberOfDiceDataGridViewTextBoxColumn.HeaderText = "NumberOfDice";
            this.numberOfDiceDataGridViewTextBoxColumn.Name = "numberOfDiceDataGridViewTextBoxColumn";
            // 
            // diceSidesDataGridViewTextBoxColumn
            // 
            this.diceSidesDataGridViewTextBoxColumn.DataPropertyName = "DiceSides";
            this.diceSidesDataGridViewTextBoxColumn.HeaderText = "DiceSides";
            this.diceSidesDataGridViewTextBoxColumn.Name = "diceSidesDataGridViewTextBoxColumn";
            // 
            // damageModDataGridViewTextBoxColumn
            // 
            this.damageModDataGridViewTextBoxColumn.DataPropertyName = "DamageMod";
            this.damageModDataGridViewTextBoxColumn.HeaderText = "DamageMod";
            this.damageModDataGridViewTextBoxColumn.Name = "damageModDataGridViewTextBoxColumn";
            // 
            // penetrationDataGridViewTextBoxColumn
            // 
            this.penetrationDataGridViewTextBoxColumn.DataPropertyName = "Penetration";
            this.penetrationDataGridViewTextBoxColumn.HeaderText = "Penetration";
            this.penetrationDataGridViewTextBoxColumn.Name = "penetrationDataGridViewTextBoxColumn";
            // 
            // encumbranceValueDataGridViewTextBoxColumn
            // 
            this.encumbranceValueDataGridViewTextBoxColumn.DataPropertyName = "EncumbranceValue";
            this.encumbranceValueDataGridViewTextBoxColumn.HeaderText = "EncumbranceValue";
            this.encumbranceValueDataGridViewTextBoxColumn.Name = "encumbranceValueDataGridViewTextBoxColumn";
            // 
            // enchantmentLevelDataGridViewTextBoxColumn
            // 
            this.enchantmentLevelDataGridViewTextBoxColumn.DataPropertyName = "EnchantmentLevel";
            this.enchantmentLevelDataGridViewTextBoxColumn.HeaderText = "EnchantmentLevel";
            this.enchantmentLevelDataGridViewTextBoxColumn.Name = "enchantmentLevelDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // reachDataGridViewTextBoxColumn
            // 
            this.reachDataGridViewTextBoxColumn.DataPropertyName = "Reach";
            this.reachDataGridViewTextBoxColumn.HeaderText = "Reach";
            this.reachDataGridViewTextBoxColumn.Name = "reachDataGridViewTextBoxColumn";
            // 
            // handednessDataGridViewTextBoxColumn
            // 
            this.handednessDataGridViewTextBoxColumn.DataPropertyName = "Handedness";
            this.handednessDataGridViewTextBoxColumn.HeaderText = "Handedness";
            this.handednessDataGridViewTextBoxColumn.Name = "handednessDataGridViewTextBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // qualityDataGridViewTextBoxColumn
            // 
            this.qualityDataGridViewTextBoxColumn.DataPropertyName = "Quality";
            this.qualityDataGridViewTextBoxColumn.HeaderText = "Quality";
            this.qualityDataGridViewTextBoxColumn.Name = "qualityDataGridViewTextBoxColumn";
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            // 
            // isDireDataGridViewCheckBoxColumn
            // 
            this.isDireDataGridViewCheckBoxColumn.DataPropertyName = "IsDire";
            this.isDireDataGridViewCheckBoxColumn.HeaderText = "IsDire";
            this.isDireDataGridViewCheckBoxColumn.Name = "isDireDataGridViewCheckBoxColumn";
            // 
            // weaponsBindingSource
            // 
            this.weaponsBindingSource.DataMember = "Weapons";
            this.weaponsBindingSource.DataSource = this.characterBindingSource;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.healthLb);
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.groupBox3);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hitLocationLb);
            this.groupBox3.Controls.Add(this.extraDifficultyNud);
            this.groupBox3.Controls.Add(this.label42);
            this.groupBox3.Controls.Add(this.successOrFailLb);
            this.groupBox3.Controls.Add(this.skillsCb);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.rollSuccessesTb);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.rollBreakdownTb);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.rollResultTb);
            this.groupBox3.Controls.Add(this.rollBt);
            this.groupBox3.Controls.Add(this.characteristicCb);
            this.groupBox3.Controls.Add(this.skillRb);
            this.groupBox3.Controls.Add(this.characteristicRb);
            this.groupBox3.Location = new System.Drawing.Point(6, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 136);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rolls";
            // 
            // hitLocationLb
            // 
            this.hitLocationLb.AutoSize = true;
            this.hitLocationLb.Location = new System.Drawing.Point(104, 107);
            this.hitLocationLb.Name = "hitLocationLb";
            this.hitLocationLb.Size = new System.Drawing.Size(36, 13);
            this.hitLocationLb.TabIndex = 16;
            this.hitLocationLb.Text = "Head!";
            this.hitLocationLb.Visible = false;
            // 
            // extraDifficultyNud
            // 
            this.extraDifficultyNud.Location = new System.Drawing.Point(101, 73);
            this.extraDifficultyNud.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.extraDifficultyNud.Minimum = new decimal(new int[] {
            2000000000,
            0,
            0,
            -2147483648});
            this.extraDifficultyNud.Name = "extraDifficultyNud";
            this.extraDifficultyNud.Size = new System.Drawing.Size(120, 20);
            this.extraDifficultyNud.TabIndex = 15;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 75);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(77, 13);
            this.label42.TabIndex = 14;
            this.label42.Text = "Extra Difficulty:";
            // 
            // successOrFailLb
            // 
            this.successOrFailLb.AutoSize = true;
            this.successOrFailLb.Location = new System.Drawing.Point(413, 89);
            this.successOrFailLb.Name = "successOrFailLb";
            this.successOrFailLb.Size = new System.Drawing.Size(83, 13);
            this.successOrFailLb.TabIndex = 13;
            this.successOrFailLb.Text = "Crticial success!";
            this.successOrFailLb.Visible = false;
            // 
            // skillsCb
            // 
            this.skillsCb.FormattingEnabled = true;
            this.skillsCb.Location = new System.Drawing.Point(101, 45);
            this.skillsCb.Name = "skillsCb";
            this.skillsCb.Size = new System.Drawing.Size(121, 21);
            this.skillsCb.TabIndex = 12;
            this.skillsCb.SelectedIndexChanged += new System.EventHandler(this.skillsCb_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(251, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "Successes:";
            // 
            // rollSuccessesTb
            // 
            this.rollSuccessesTb.Location = new System.Drawing.Point(319, 41);
            this.rollSuccessesTb.Name = "rollSuccessesTb";
            this.rollSuccessesTb.Size = new System.Drawing.Size(177, 20);
            this.rollSuccessesTb.TabIndex = 10;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(249, 69);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 13);
            this.label28.TabIndex = 9;
            this.label28.Text = "Breakdown:";
            // 
            // rollBreakdownTb
            // 
            this.rollBreakdownTb.Location = new System.Drawing.Point(319, 66);
            this.rollBreakdownTb.Name = "rollBreakdownTb";
            this.rollBreakdownTb.Size = new System.Drawing.Size(177, 20);
            this.rollBreakdownTb.TabIndex = 8;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(273, 21);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 13);
            this.label27.TabIndex = 7;
            this.label27.Text = "Result:";
            // 
            // rollResultTb
            // 
            this.rollResultTb.Location = new System.Drawing.Point(319, 16);
            this.rollResultTb.Name = "rollResultTb";
            this.rollResultTb.Size = new System.Drawing.Size(177, 20);
            this.rollResultTb.TabIndex = 6;
            // 
            // rollBt
            // 
            this.rollBt.Location = new System.Drawing.Point(6, 102);
            this.rollBt.Name = "rollBt";
            this.rollBt.Size = new System.Drawing.Size(89, 23);
            this.rollBt.TabIndex = 3;
            this.rollBt.Text = "Roll!";
            this.rollBt.UseVisualStyleBackColor = true;
            this.rollBt.Click += new System.EventHandler(this.rollBt_Click);
            // 
            // characteristicCb
            // 
            this.characteristicCb.FormattingEnabled = true;
            this.characteristicCb.Location = new System.Drawing.Point(101, 18);
            this.characteristicCb.Name = "characteristicCb";
            this.characteristicCb.Size = new System.Drawing.Size(121, 21);
            this.characteristicCb.TabIndex = 2;
            // 
            // skillRb
            // 
            this.skillRb.AutoSize = true;
            this.skillRb.Location = new System.Drawing.Point(7, 46);
            this.skillRb.Name = "skillRb";
            this.skillRb.Size = new System.Drawing.Size(44, 17);
            this.skillRb.TabIndex = 1;
            this.skillRb.Text = "Skill";
            this.skillRb.UseVisualStyleBackColor = true;
            this.skillRb.CheckedChanged += new System.EventHandler(this.skillRb_CheckedChanged);
            // 
            // characteristicRb
            // 
            this.characteristicRb.AutoSize = true;
            this.characteristicRb.Checked = true;
            this.characteristicRb.Location = new System.Drawing.Point(6, 19);
            this.characteristicRb.Name = "characteristicRb";
            this.characteristicRb.Size = new System.Drawing.Size(89, 17);
            this.characteristicRb.TabIndex = 0;
            this.characteristicRb.TabStop = true;
            this.characteristicRb.Text = "Characteristic";
            this.characteristicRb.UseVisualStyleBackColor = true;
            this.characteristicRb.CheckedChanged += new System.EventHandler(this.characteristicRb_CheckedChanged);
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
            // skillListView_statsPage
            // 
            this.skillListView_statsPage.Location = new System.Drawing.Point(484, 37);
            this.skillListView_statsPage.Name = "skillListView_statsPage";
            this.skillListView_statsPage.Size = new System.Drawing.Size(504, 155);
            this.skillListView_statsPage.TabIndex = 4;
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
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spellsDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.armorDgv)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extraDifficultyNud)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox armorNameTb;
        private System.Windows.Forms.ComboBox armorQualityCb;
        private System.Windows.Forms.ComboBox armorMaterialCb;
        private System.Windows.Forms.ComboBox armorTypeCb;
        private System.Windows.Forms.ComboBox armorLocationCb;
        private System.Windows.Forms.Button addNewArmorBt;
        private System.Windows.Forms.DataGridView armorDgv;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button addNewWeaponBt;
        private System.Windows.Forms.ComboBox weaponMaterialCb;
        private System.Windows.Forms.ComboBox weaponTypeCb;
        private System.Windows.Forms.TextBox weaponNameTb;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.DataGridView weaponsDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfDiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diceSidesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn damageModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn penetrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn encumbranceValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enchantmentLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reachDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handednessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDireDataGridViewCheckBoxColumn;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button addSpellBt;
        private System.Windows.Forms.DataGridView spellsDgv;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label successOrFailLb;
        private System.Windows.Forms.ComboBox skillsCb;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox rollSuccessesTb;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox rollBreakdownTb;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox rollResultTb;
        private System.Windows.Forms.Button rollBt;
        private System.Windows.Forms.ComboBox characteristicCb;
        private System.Windows.Forms.RadioButton skillRb;
        private System.Windows.Forms.RadioButton characteristicRb;
        private System.Windows.Forms.NumericUpDown extraDifficultyNud;
        private System.Windows.Forms.Label label42;
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
        private System.Windows.Forms.Label hitLocationLb;
        private UI.CharacterViews.CharacteristicsView charaView_statsPage;
        private UI.MainWindow.CharacterSelector characterSelector;
        private AttributesView attributesView_statsPage;
        private CharacterViews.SkillListView skillListView_statsPage;
    }
}

