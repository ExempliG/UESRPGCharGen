namespace UESRPG_Character_Manager.UI.ActionViews
{
    partial class SpellDamageView
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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.spellRollBt = new System.Windows.Forms.Button();
            this.spellResultBreakdownTb = new System.Windows.Forms.TextBox();
            this.spellResultTb = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.spellsCb = new System.Windows.Forms.ComboBox();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox10.Location = new System.Drawing.Point(1, 1);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(248, 155);
            this.groupBox10.TabIndex = 28;
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
            this.spellsCb.FormattingEnabled = true;
            this.spellsCb.Location = new System.Drawing.Point(76, 19);
            this.spellsCb.Name = "spellsCb";
            this.spellsCb.Size = new System.Drawing.Size(166, 21);
            this.spellsCb.TabIndex = 0;
            this.spellsCb.SelectedIndexChanged += new System.EventHandler(this.spellsCb_SelectedIndexChanged);
            // 
            // SpellDamageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox10);
            this.Name = "SpellDamageView";
            this.Size = new System.Drawing.Size(249, 156);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button spellRollBt;
        private System.Windows.Forms.TextBox spellResultBreakdownTb;
        private System.Windows.Forms.TextBox spellResultTb;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox spellsCb;
    }
}
