namespace UESRPG_Character_Manager.UI.ActionViews
{
    partial class CheckRollView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extraDifficultyNud)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox3.Location = new System.Drawing.Point(1, 1);
            this.groupBox3.MinimumSize = new System.Drawing.Size(0, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 136);
            this.groupBox3.TabIndex = 27;
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
            this.extraDifficultyNud.ValueChanged += new System.EventHandler(this.extraDifficultyNud_ValueChanged);
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
            this.successOrFailLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.rollSuccessesTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.rollBreakdownTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.rollResultTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rollResultTb.Location = new System.Drawing.Point(319, 16);
            this.rollResultTb.Name = "rollResultTb";
            this.rollResultTb.Size = new System.Drawing.Size(177, 20);
            this.rollResultTb.TabIndex = 6;
            this.rollResultTb.TextChanged += new System.EventHandler(this.rollResultTb_TextChanged);
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
            this.characteristicCb.SelectedIndexChanged += new System.EventHandler(this.characteristicCb_SelectedIndexChanged);
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
            // CheckRollView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "CheckRollView";
            this.Size = new System.Drawing.Size(504, 137);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extraDifficultyNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label hitLocationLb;
        private System.Windows.Forms.NumericUpDown extraDifficultyNud;
        private System.Windows.Forms.Label label42;
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
    }
}
