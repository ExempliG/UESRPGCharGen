namespace UESRPG_Character_Manager.UI.ActionViews
{
    partial class WeaponDamageView
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.weaponResultBreakdownTb = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.weaponResultTb = new System.Windows.Forms.TextBox();
            this.weaponRollBt = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.weaponCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ammoCb = new System.Windows.Forms.ComboBox();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ammoCb);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label39);
            this.groupBox8.Controls.Add(this.weaponResultBreakdownTb);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Controls.Add(this.weaponResultTb);
            this.groupBox8.Controls.Add(this.weaponRollBt);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.weaponCb);
            this.groupBox8.Location = new System.Drawing.Point(1, 1);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(248, 155);
            this.groupBox8.TabIndex = 25;
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
            this.weaponResultBreakdownTb.TabIndex = 2;
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
            this.weaponResultTb.TabIndex = 1;
            // 
            // weaponRollBt
            // 
            this.weaponRollBt.Enabled = false;
            this.weaponRollBt.Location = new System.Drawing.Point(167, 126);
            this.weaponRollBt.Name = "weaponRollBt";
            this.weaponRollBt.Size = new System.Drawing.Size(75, 23);
            this.weaponRollBt.TabIndex = 4;
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
            this.weaponCb.DisplayMember = "Name";
            this.weaponCb.FormattingEnabled = true;
            this.weaponCb.Location = new System.Drawing.Point(76, 19);
            this.weaponCb.Name = "weaponCb";
            this.weaponCb.Size = new System.Drawing.Size(166, 21);
            this.weaponCb.TabIndex = 0;
            this.weaponCb.SelectedIndexChanged += new System.EventHandler(this.weaponCb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ammo:";
            // 
            // ammoCb
            // 
            this.ammoCb.FormattingEnabled = true;
            this.ammoCb.Location = new System.Drawing.Point(76, 98);
            this.ammoCb.Name = "ammoCb";
            this.ammoCb.Size = new System.Drawing.Size(166, 21);
            this.ammoCb.TabIndex = 3;
            // 
            // WeaponDamageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Name = "WeaponDamageView";
            this.Size = new System.Drawing.Size(250, 156);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox weaponResultBreakdownTb;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox weaponResultTb;
        private System.Windows.Forms.Button weaponRollBt;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox weaponCb;
        private System.Windows.Forms.ComboBox ammoCb;
        private System.Windows.Forms.Label label1;
    }
}
