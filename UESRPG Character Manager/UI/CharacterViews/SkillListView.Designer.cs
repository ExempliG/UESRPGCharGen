namespace UESRPG_Character_Manager.UI.CharacterViews
{
    partial class SkillListView
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.editSkillBt = new System.Windows.Forms.Button();
            this.addSkillBt = new System.Windows.Forms.Button();
            this.skillsDgv = new System.Windows.Forms.DataGridView();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.editSkillBt);
            this.groupBox6.Controls.Add(this.addSkillBt);
            this.groupBox6.Controls.Add(this.skillsDgv);
            this.groupBox6.Location = new System.Drawing.Point(1, 1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(502, 154);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Skills";
            // 
            // editSkillBt
            // 
            this.editSkillBt.Location = new System.Drawing.Point(87, 19);
            this.editSkillBt.Name = "editSkillBt";
            this.editSkillBt.Size = new System.Drawing.Size(75, 23);
            this.editSkillBt.TabIndex = 2;
            this.editSkillBt.Text = "Edit Skill";
            this.editSkillBt.UseVisualStyleBackColor = true;
            this.editSkillBt.Click += new System.EventHandler(this.editSkillBt_Click);
            // 
            // addSkillBt
            // 
            this.addSkillBt.Location = new System.Drawing.Point(6, 19);
            this.addSkillBt.Name = "addSkillBt";
            this.addSkillBt.Size = new System.Drawing.Size(75, 23);
            this.addSkillBt.TabIndex = 1;
            this.addSkillBt.Text = "Add Skill";
            this.addSkillBt.UseVisualStyleBackColor = true;
            this.addSkillBt.Click += new System.EventHandler(this.addSkillBt_Click);
            // 
            // skillsDgv
            // 
            this.skillsDgv.AllowUserToAddRows = false;
            this.skillsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skillsDgv.BackgroundColor = System.Drawing.Color.White;
            this.skillsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skillsDgv.Location = new System.Drawing.Point(7, 48);
            this.skillsDgv.Name = "skillsDgv";
            this.skillsDgv.ReadOnly = true;
            this.skillsDgv.Size = new System.Drawing.Size(489, 100);
            this.skillsDgv.TabIndex = 0;
            // 
            // SkillListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Name = "SkillListView";
            this.Size = new System.Drawing.Size(504, 155);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skillsDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button editSkillBt;
        private System.Windows.Forms.Button addSkillBt;
        private System.Windows.Forms.DataGridView skillsDgv;
    }
}
