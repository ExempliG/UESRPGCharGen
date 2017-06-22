namespace UESRPG_Character_Manager
{
    partial class EditSkill
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
            this.skillCharacteristicsClb = new System.Windows.Forms.CheckedListBox();
            this.skillDescriptionRtb = new System.Windows.Forms.RichTextBox();
            this.skillNameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confirmBt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.skillRankNud = new System.Windows.Forms.NumericUpDown();
            this.cancelBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.skillRankNud)).BeginInit();
            this.SuspendLayout();
            // 
            // skillCharacteristicsClb
            // 
            this.skillCharacteristicsClb.FormattingEnabled = true;
            this.skillCharacteristicsClb.Location = new System.Drawing.Point(12, 155);
            this.skillCharacteristicsClb.Name = "skillCharacteristicsClb";
            this.skillCharacteristicsClb.Size = new System.Drawing.Size(260, 94);
            this.skillCharacteristicsClb.TabIndex = 4;
            // 
            // skillDescriptionRtb
            // 
            this.skillDescriptionRtb.Location = new System.Drawing.Point(12, 51);
            this.skillDescriptionRtb.Name = "skillDescriptionRtb";
            this.skillDescriptionRtb.Size = new System.Drawing.Size(260, 71);
            this.skillDescriptionRtb.TabIndex = 3;
            this.skillDescriptionRtb.Text = "";
            // 
            // skillNameTb
            // 
            this.skillNameTb.Location = new System.Drawing.Point(56, 12);
            this.skillNameTb.Name = "skillNameTb";
            this.skillNameTb.Size = new System.Drawing.Size(127, 20);
            this.skillNameTb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Governing Characteristic(s)";
            // 
            // confirmBt
            // 
            this.confirmBt.Location = new System.Drawing.Point(116, 255);
            this.confirmBt.Name = "confirmBt";
            this.confirmBt.Size = new System.Drawing.Size(75, 23);
            this.confirmBt.TabIndex = 5;
            this.confirmBt.Text = "Confirm";
            this.confirmBt.UseVisualStyleBackColor = true;
            this.confirmBt.Click += new System.EventHandler(this.confirmBt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rank:";
            // 
            // skillRankNud
            // 
            this.skillRankNud.Location = new System.Drawing.Point(231, 13);
            this.skillRankNud.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.skillRankNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.skillRankNud.Name = "skillRankNud";
            this.skillRankNud.Size = new System.Drawing.Size(41, 20);
            this.skillRankNud.TabIndex = 2;
            this.skillRankNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(197, 255);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 8;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // EditSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 291);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.skillRankNud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirmBt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skillNameTb);
            this.Controls.Add(this.skillDescriptionRtb);
            this.Controls.Add(this.skillCharacteristicsClb);
            this.Name = "EditSkill";
            this.Text = "Edit Skill";
            ((System.ComponentModel.ISupportInitialize)(this.skillRankNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox skillCharacteristicsClb;
        private System.Windows.Forms.RichTextBox skillDescriptionRtb;
        private System.Windows.Forms.TextBox skillNameTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button confirmBt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown skillRankNud;
        private System.Windows.Forms.Button cancelBt;
    }
}