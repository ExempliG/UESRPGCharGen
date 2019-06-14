namespace UESRPG_Character_Manager.UI.CharacterViews
{
    partial class ArmorView
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.armorNameTb = new System.Windows.Forms.TextBox();
            this.armorQualityCb = new System.Windows.Forms.ComboBox();
            this.armorMaterialCb = new System.Windows.Forms.ComboBox();
            this.armorTypeCb = new System.Windows.Forms.ComboBox();
            this.armorLocationCb = new System.Windows.Forms.ComboBox();
            this.addNewArmorBt = new System.Windows.Forms.Button();
            this.armorDgv = new System.Windows.Forms.DataGridView();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.armorDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.armorNameTb);
            this.groupBox4.Controls.Add(this.armorQualityCb);
            this.groupBox4.Controls.Add(this.armorMaterialCb);
            this.groupBox4.Controls.Add(this.armorTypeCb);
            this.groupBox4.Controls.Add(this.armorLocationCb);
            this.groupBox4.Controls.Add(this.addNewArmorBt);
            this.groupBox4.Controls.Add(this.armorDgv);
            this.groupBox4.Location = new System.Drawing.Point(1, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(502, 370);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Armor";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(90, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(61, 13);
            this.label33.TabIndex = 27;
            this.label33.Text = "Item Name:";
            // 
            // armorNameTb
            // 
            this.armorNameTb.Location = new System.Drawing.Point(157, 19);
            this.armorNameTb.Name = "armorNameTb";
            this.armorNameTb.Size = new System.Drawing.Size(97, 20);
            this.armorNameTb.TabIndex = 26;
            // 
            // armorQualityCb
            // 
            this.armorQualityCb.FormattingEnabled = true;
            this.armorQualityCb.Location = new System.Drawing.Point(368, 45);
            this.armorQualityCb.Name = "armorQualityCb";
            this.armorQualityCb.Size = new System.Drawing.Size(107, 21);
            this.armorQualityCb.TabIndex = 25;
            // 
            // armorMaterialCb
            // 
            this.armorMaterialCb.FormattingEnabled = true;
            this.armorMaterialCb.Location = new System.Drawing.Point(260, 45);
            this.armorMaterialCb.Name = "armorMaterialCb";
            this.armorMaterialCb.Size = new System.Drawing.Size(100, 21);
            this.armorMaterialCb.TabIndex = 24;
            // 
            // armorTypeCb
            // 
            this.armorTypeCb.FormattingEnabled = true;
            this.armorTypeCb.Location = new System.Drawing.Point(157, 45);
            this.armorTypeCb.Name = "armorTypeCb";
            this.armorTypeCb.Size = new System.Drawing.Size(97, 21);
            this.armorTypeCb.TabIndex = 23;
            // 
            // armorLocationCb
            // 
            this.armorLocationCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.armorLocationCb.FormattingEnabled = true;
            this.armorLocationCb.Location = new System.Drawing.Point(260, 18);
            this.armorLocationCb.Name = "armorLocationCb";
            this.armorLocationCb.Size = new System.Drawing.Size(100, 21);
            this.armorLocationCb.TabIndex = 22;
            // 
            // addNewArmorBt
            // 
            this.addNewArmorBt.Location = new System.Drawing.Point(368, 16);
            this.addNewArmorBt.Name = "addNewArmorBt";
            this.addNewArmorBt.Size = new System.Drawing.Size(107, 23);
            this.addNewArmorBt.TabIndex = 21;
            this.addNewArmorBt.Text = "Add New";
            this.addNewArmorBt.UseVisualStyleBackColor = true;
            this.addNewArmorBt.Click += new System.EventHandler(this.addNewArmorBt_Click);
            // 
            // armorDgv
            // 
            this.armorDgv.AllowUserToAddRows = false;
            this.armorDgv.AllowUserToDeleteRows = false;
            this.armorDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.armorDgv.BackgroundColor = System.Drawing.Color.White;
            this.armorDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.armorDgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.armorDgv.Location = new System.Drawing.Point(6, 72);
            this.armorDgv.Name = "armorDgv";
            this.armorDgv.Size = new System.Drawing.Size(490, 292);
            this.armorDgv.TabIndex = 20;
            // 
            // ArmorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.MinimumSize = new System.Drawing.Size(504, 370);
            this.Name = "ArmorView";
            this.Size = new System.Drawing.Size(504, 370);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.armorDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox armorNameTb;
        private System.Windows.Forms.ComboBox armorQualityCb;
        private System.Windows.Forms.ComboBox armorMaterialCb;
        private System.Windows.Forms.ComboBox armorTypeCb;
        private System.Windows.Forms.ComboBox armorLocationCb;
        private System.Windows.Forms.Button addNewArmorBt;
        private System.Windows.Forms.DataGridView armorDgv;
    }
}
