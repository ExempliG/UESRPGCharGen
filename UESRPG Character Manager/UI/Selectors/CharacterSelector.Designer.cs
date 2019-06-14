namespace UESRPG_Character_Manager.UI.Selectors
{
    partial class CharacterSelector
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
            this.label30 = new System.Windows.Forms.Label();
            this.charactersCb = new System.Windows.Forms.ComboBox();
            this.btAddCharacter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(2, 3);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(101, 13);
            this.label30.TabIndex = 4;
            this.label30.Text = "Selected Character:";
            // 
            // charactersCb
            // 
            this.charactersCb.FormattingEnabled = true;
            this.charactersCb.Location = new System.Drawing.Point(123, 1);
            this.charactersCb.Margin = new System.Windows.Forms.Padding(2);
            this.charactersCb.Name = "charactersCb";
            this.charactersCb.Size = new System.Drawing.Size(114, 21);
            this.charactersCb.TabIndex = 3;
            this.charactersCb.SelectedIndexChanged += new System.EventHandler(this.charactersCb_SelectedIndexChanged);
            // 
            // btAddCharacter
            // 
            this.btAddCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddCharacter.Location = new System.Drawing.Point(241, 1);
            this.btAddCharacter.Margin = new System.Windows.Forms.Padding(2);
            this.btAddCharacter.Name = "btAddCharacter";
            this.btAddCharacter.Size = new System.Drawing.Size(80, 19);
            this.btAddCharacter.TabIndex = 5;
            this.btAddCharacter.Text = "Add Character";
            this.btAddCharacter.UseVisualStyleBackColor = true;
            this.btAddCharacter.Click += new System.EventHandler(this.btAddCharacter_Click);
            // 
            // CharacterSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btAddCharacter);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.charactersCb);
            this.Name = "CharacterSelector";
            this.Size = new System.Drawing.Size(322, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox charactersCb;
        private System.Windows.Forms.Button btAddCharacter;
    }
}
