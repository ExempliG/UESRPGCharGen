namespace UESRPG_Character_Manager.UI.CharacterViews
{
    partial class WeaponsView
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.addNewWeaponBt = new System.Windows.Forms.Button();
            this.weaponMaterialCb = new System.Windows.Forms.ComboBox();
            this.weaponTypeCb = new System.Windows.Forms.ComboBox();
            this.weaponNameTb = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.weaponsDgv = new System.Windows.Forms.DataGridView();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.addNewWeaponBt);
            this.groupBox7.Controls.Add(this.weaponMaterialCb);
            this.groupBox7.Controls.Add(this.weaponTypeCb);
            this.groupBox7.Controls.Add(this.weaponNameTb);
            this.groupBox7.Controls.Add(this.label37);
            this.groupBox7.Controls.Add(this.weaponsDgv);
            this.groupBox7.Location = new System.Drawing.Point(1, 1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 376);
            this.groupBox7.TabIndex = 25;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Weapons";
            // 
            // addNewWeaponBt
            // 
            this.addNewWeaponBt.Location = new System.Drawing.Point(306, 18);
            this.addNewWeaponBt.Name = "addNewWeaponBt";
            this.addNewWeaponBt.Size = new System.Drawing.Size(75, 23);
            this.addNewWeaponBt.TabIndex = 5;
            this.addNewWeaponBt.Text = "Add New";
            this.addNewWeaponBt.UseVisualStyleBackColor = true;
            this.addNewWeaponBt.Click += new System.EventHandler(this.addNewWeaponBt_Click);
            // 
            // weaponMaterialCb
            // 
            this.weaponMaterialCb.FormattingEnabled = true;
            this.weaponMaterialCb.Location = new System.Drawing.Point(179, 45);
            this.weaponMaterialCb.Name = "weaponMaterialCb";
            this.weaponMaterialCb.Size = new System.Drawing.Size(121, 21);
            this.weaponMaterialCb.TabIndex = 4;
            // 
            // weaponTypeCb
            // 
            this.weaponTypeCb.FormattingEnabled = true;
            this.weaponTypeCb.Location = new System.Drawing.Point(179, 18);
            this.weaponTypeCb.Name = "weaponTypeCb";
            this.weaponTypeCb.Size = new System.Drawing.Size(121, 21);
            this.weaponTypeCb.TabIndex = 3;
            // 
            // weaponNameTb
            // 
            this.weaponNameTb.Location = new System.Drawing.Point(73, 19);
            this.weaponNameTb.Name = "weaponNameTb";
            this.weaponNameTb.Size = new System.Drawing.Size(100, 20);
            this.weaponNameTb.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(61, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "Item Name:";
            // 
            // weaponsDgv
            // 
            this.weaponsDgv.AllowUserToAddRows = false;
            this.weaponsDgv.AllowUserToDeleteRows = false;
            this.weaponsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.weaponsDgv.BackgroundColor = System.Drawing.Color.White;
            this.weaponsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weaponsDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.weaponsDgv.Location = new System.Drawing.Point(6, 72);
            this.weaponsDgv.Name = "weaponsDgv";
            this.weaponsDgv.ReadOnly = true;
            this.weaponsDgv.Size = new System.Drawing.Size(460, 298);
            this.weaponsDgv.TabIndex = 0;
            // 
            // WeaponsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox7);
            this.Name = "WeaponsView";
            this.Size = new System.Drawing.Size(474, 377);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponsDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button addNewWeaponBt;
        private System.Windows.Forms.ComboBox weaponMaterialCb;
        private System.Windows.Forms.ComboBox weaponTypeCb;
        private System.Windows.Forms.TextBox weaponNameTb;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.DataGridView weaponsDgv;
    }
}
