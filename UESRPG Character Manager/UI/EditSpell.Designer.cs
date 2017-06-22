namespace UESRPG_Character_Manager
{
    partial class EditSpell
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
            this.spellNameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spellLevelNud = new System.Windows.Forms.NumericUpDown();
            this.spellDescriptionRtb = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.damageCb = new System.Windows.Forms.CheckBox();
            this.numberOfDiceNud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.diceSidesNud = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.penNud = new System.Windows.Forms.NumericUpDown();
            this.confirmBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.costNud = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.difficultyNud = new System.Windows.Forms.NumericUpDown();
            this.associatedSkillCb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spellLevelNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfDiceNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceSidesNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNud)).BeginInit();
            this.SuspendLayout();
            // 
            // spellNameTb
            // 
            this.spellNameTb.Location = new System.Drawing.Point(56, 12);
            this.spellNameTb.Name = "spellNameTb";
            this.spellNameTb.Size = new System.Drawing.Size(146, 20);
            this.spellNameTb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // spellLevelNud
            // 
            this.spellLevelNud.Location = new System.Drawing.Point(225, 12);
            this.spellLevelNud.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.spellLevelNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spellLevelNud.Name = "spellLevelNud";
            this.spellLevelNud.Size = new System.Drawing.Size(47, 20);
            this.spellLevelNud.TabIndex = 2;
            this.spellLevelNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spellDescriptionRtb
            // 
            this.spellDescriptionRtb.Location = new System.Drawing.Point(12, 109);
            this.spellDescriptionRtb.Name = "spellDescriptionRtb";
            this.spellDescriptionRtb.Size = new System.Drawing.Size(260, 136);
            this.spellDescriptionRtb.TabIndex = 6;
            this.spellDescriptionRtb.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // damageCb
            // 
            this.damageCb.AutoSize = true;
            this.damageCb.Location = new System.Drawing.Point(197, 254);
            this.damageCb.Name = "damageCb";
            this.damageCb.Size = new System.Drawing.Size(72, 17);
            this.damageCb.TabIndex = 7;
            this.damageCb.Text = "Damage?";
            this.damageCb.UseVisualStyleBackColor = true;
            this.damageCb.CheckedChanged += new System.EventHandler(this.damageCb_CheckedChanged);
            // 
            // numberOfDiceNud
            // 
            this.numberOfDiceNud.Enabled = false;
            this.numberOfDiceNud.Location = new System.Drawing.Point(18, 252);
            this.numberOfDiceNud.Name = "numberOfDiceNud";
            this.numberOfDiceNud.Size = new System.Drawing.Size(38, 20);
            this.numberOfDiceNud.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "d";
            // 
            // diceSidesNud
            // 
            this.diceSidesNud.Enabled = false;
            this.diceSidesNud.Location = new System.Drawing.Point(81, 253);
            this.diceSidesNud.Name = "diceSidesNud";
            this.diceSidesNud.Size = new System.Drawing.Size(38, 20);
            this.diceSidesNud.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "pen";
            // 
            // penNud
            // 
            this.penNud.Enabled = false;
            this.penNud.Location = new System.Drawing.Point(81, 279);
            this.penNud.Name = "penNud";
            this.penNud.Size = new System.Drawing.Size(38, 20);
            this.penNud.TabIndex = 10;
            // 
            // confirmBt
            // 
            this.confirmBt.Location = new System.Drawing.Point(116, 319);
            this.confirmBt.Name = "confirmBt";
            this.confirmBt.Size = new System.Drawing.Size(75, 23);
            this.confirmBt.TabIndex = 11;
            this.confirmBt.Text = "Confirm";
            this.confirmBt.UseVisualStyleBackColor = true;
            this.confirmBt.Click += new System.EventHandler(this.confirmBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(197, 319);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 12;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // costNud
            // 
            this.costNud.Location = new System.Drawing.Point(56, 38);
            this.costNud.Name = "costNud";
            this.costNud.Size = new System.Drawing.Size(44, 20);
            this.costNud.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cost:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Difficulty:";
            // 
            // difficultyNud
            // 
            this.difficultyNud.Location = new System.Drawing.Point(162, 38);
            this.difficultyNud.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.difficultyNud.Name = "difficultyNud";
            this.difficultyNud.Size = new System.Drawing.Size(44, 20);
            this.difficultyNud.TabIndex = 4;
            // 
            // associatedSkillCb
            // 
            this.associatedSkillCb.FormattingEnabled = true;
            this.associatedSkillCb.Location = new System.Drawing.Point(102, 64);
            this.associatedSkillCb.Name = "associatedSkillCb";
            this.associatedSkillCb.Size = new System.Drawing.Size(170, 21);
            this.associatedSkillCb.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Associated Skill:";
            // 
            // EditSpell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 353);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.associatedSkillCb);
            this.Controls.Add(this.difficultyNud);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.costNud);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.confirmBt);
            this.Controls.Add(this.penNud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diceSidesNud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberOfDiceNud);
            this.Controls.Add(this.damageCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spellDescriptionRtb);
            this.Controls.Add(this.spellLevelNud);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spellNameTb);
            this.Name = "EditSpell";
            this.Text = "Edit Spell";
            ((System.ComponentModel.ISupportInitialize)(this.spellLevelNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfDiceNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceSidesNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox spellNameTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown spellLevelNud;
        private System.Windows.Forms.RichTextBox spellDescriptionRtb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox damageCb;
        private System.Windows.Forms.NumericUpDown numberOfDiceNud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown diceSidesNud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown penNud;
        private System.Windows.Forms.Button confirmBt;
        private System.Windows.Forms.Button cancelBt;
        private System.Windows.Forms.NumericUpDown costNud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown difficultyNud;
        private System.Windows.Forms.ComboBox associatedSkillCb;
        private System.Windows.Forms.Label label7;
    }
}