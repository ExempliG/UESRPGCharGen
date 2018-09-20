namespace UESRPG_Character_Manager.UI.ManagementElements
{
    partial class ManageCharactersWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.importBt = new System.Windows.Forms.Button();
            this.exportBt = new System.Windows.Forms.Button();
            this.deleteBt = new System.Windows.Forms.Button();
            this.okBt = new System.Windows.Forms.Button();
            this.charactersDgv = new UESRPG_Character_Manager.UI.ManagementElements.CharactersDgv();
            this.SuspendLayout();
            // 
            // importBt
            // 
            this.importBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importBt.Location = new System.Drawing.Point(193, 207);
            this.importBt.Name = "importBt";
            this.importBt.Size = new System.Drawing.Size(84, 23);
            this.importBt.TabIndex = 1;
            this.importBt.Text = "Import/Export";
            this.importBt.UseVisualStyleBackColor = true;
            this.importBt.Click += new System.EventHandler(this.importBt_Click);
            // 
            // exportBt
            // 
            this.exportBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBt.Enabled = false;
            this.exportBt.Location = new System.Drawing.Point(283, 207);
            this.exportBt.Name = "exportBt";
            this.exportBt.Size = new System.Drawing.Size(75, 23);
            this.exportBt.TabIndex = 2;
            this.exportBt.Text = "Export";
            this.exportBt.UseVisualStyleBackColor = true;
            this.exportBt.Click += new System.EventHandler(this.exportBt_Click);
            // 
            // deleteBt
            // 
            this.deleteBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBt.Location = new System.Drawing.Point(193, 236);
            this.deleteBt.Name = "deleteBt";
            this.deleteBt.Size = new System.Drawing.Size(84, 23);
            this.deleteBt.TabIndex = 3;
            this.deleteBt.Text = "Delete";
            this.deleteBt.UseVisualStyleBackColor = true;
            this.deleteBt.Click += new System.EventHandler(this.deleteBt_Click);
            // 
            // okBt
            // 
            this.okBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBt.Location = new System.Drawing.Point(283, 236);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(75, 23);
            this.okBt.TabIndex = 4;
            this.okBt.Text = "OK";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // charactersDgv
            // 
            this.charactersDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charactersDgv.Location = new System.Drawing.Point(13, 13);
            this.charactersDgv.Name = "charactersDgv";
            this.charactersDgv.Size = new System.Drawing.Size(345, 188);
            this.charactersDgv.TabIndex = 5;
            // 
            // ManageCharactersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 271);
            this.Controls.Add(this.charactersDgv);
            this.Controls.Add(this.okBt);
            this.Controls.Add(this.deleteBt);
            this.Controls.Add(this.exportBt);
            this.Controls.Add(this.importBt);
            this.Name = "ManageCharactersWindow";
            this.Text = "ManageCharactersWindow";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button importBt;
        private System.Windows.Forms.Button exportBt;
        private System.Windows.Forms.Button deleteBt;
        private System.Windows.Forms.Button okBt;
        private CharactersDgv charactersDgv;
    }
}