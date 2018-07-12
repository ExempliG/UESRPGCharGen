namespace UESRPG_Character_Manager.UI.ManagementElements
{
    partial class ImportCharactersWindow
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
            this.okBt = new System.Windows.Forms.Button();
            this.importBt = new System.Windows.Forms.Button();
            this.charactersDgv = new UESRPG_Character_Manager.UI.ManagementElements.CharactersDgv();
            this.SuspendLayout();
            // 
            // okBt
            // 
            this.okBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBt.Location = new System.Drawing.Point(283, 235);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(75, 23);
            this.okBt.TabIndex = 9;
            this.okBt.Text = "OK";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // importBt
            // 
            this.importBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importBt.Location = new System.Drawing.Point(202, 235);
            this.importBt.Name = "importBt";
            this.importBt.Size = new System.Drawing.Size(75, 23);
            this.importBt.TabIndex = 6;
            this.importBt.Text = "Import";
            this.importBt.UseVisualStyleBackColor = true;
            this.importBt.Click += new System.EventHandler(this.importBt_Click);
            // 
            // charactersDgv
            // 
            this.charactersDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charactersDgv.Location = new System.Drawing.Point(13, 13);
            this.charactersDgv.Name = "charactersDgv";
            this.charactersDgv.Size = new System.Drawing.Size(345, 216);
            this.charactersDgv.TabIndex = 10;
            // 
            // ImportCharactersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 271);
            this.Controls.Add(this.charactersDgv);
            this.Controls.Add(this.okBt);
            this.Controls.Add(this.importBt);
            this.Name = "ImportCharactersWindow";
            this.Text = "ImportCharactersWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBt;
        private System.Windows.Forms.Button importBt;
        private CharactersDgv charactersDgv;
    }
}