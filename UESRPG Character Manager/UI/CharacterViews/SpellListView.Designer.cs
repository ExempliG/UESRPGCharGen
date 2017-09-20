namespace UESRPG_Character_Manager.UI.CharacterViews
{
    partial class SpellListView
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.addSpellBt = new System.Windows.Forms.Button();
            this.spellsDgv = new System.Windows.Forms.DataGridView();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spellsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.addSpellBt);
            this.groupBox9.Controls.Add(this.spellsDgv);
            this.groupBox9.Location = new System.Drawing.Point(1, 1);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(502, 169);
            this.groupBox9.TabIndex = 27;
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
            // SpellListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox9);
            this.Name = "SpellListView";
            this.Size = new System.Drawing.Size(504, 170);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spellsDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button addSpellBt;
        private System.Windows.Forms.DataGridView spellsDgv;
    }
}
