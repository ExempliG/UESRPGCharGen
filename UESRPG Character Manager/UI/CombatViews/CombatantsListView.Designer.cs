namespace UESRPG_Character_Manager.UI.CombatViews
{
    partial class CombatantsListView
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
            this.combatantsDgv = new System.Windows.Forms.DataGridView();
            this.addCombatantBt = new System.Windows.Forms.Button();
            this.removeCombatantBt = new System.Windows.Forms.Button();
            this.combatantUpBt = new System.Windows.Forms.Button();
            this.combatantDownBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.combatantsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // combatantsDgv
            // 
            this.combatantsDgv.AllowUserToAddRows = false;
            this.combatantsDgv.AllowUserToDeleteRows = false;
            this.combatantsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combatantsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.combatantsDgv.Location = new System.Drawing.Point(4, 4);
            this.combatantsDgv.MultiSelect = false;
            this.combatantsDgv.Name = "combatantsDgv";
            this.combatantsDgv.ReadOnly = true;
            this.combatantsDgv.Size = new System.Drawing.Size(250, 375);
            this.combatantsDgv.TabIndex = 0;
            this.combatantsDgv.SelectionChanged += new System.EventHandler(this.combatantsDgv_SelectionChanged);
            // 
            // addCombatantBt
            // 
            this.addCombatantBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCombatantBt.Location = new System.Drawing.Point(4, 385);
            this.addCombatantBt.Name = "addCombatantBt";
            this.addCombatantBt.Size = new System.Drawing.Size(75, 23);
            this.addCombatantBt.TabIndex = 1;
            this.addCombatantBt.Text = "Add";
            this.addCombatantBt.UseVisualStyleBackColor = true;
            this.addCombatantBt.Click += new System.EventHandler(this.addCombatantBt_Click);
            // 
            // removeCombatantBt
            // 
            this.removeCombatantBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeCombatantBt.Location = new System.Drawing.Point(85, 385);
            this.removeCombatantBt.Name = "removeCombatantBt";
            this.removeCombatantBt.Size = new System.Drawing.Size(75, 23);
            this.removeCombatantBt.TabIndex = 2;
            this.removeCombatantBt.Text = "Remove";
            this.removeCombatantBt.UseVisualStyleBackColor = true;
            this.removeCombatantBt.Click += new System.EventHandler(this.removeCombatantBt_Click);
            // 
            // combatantUpBt
            // 
            this.combatantUpBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.combatantUpBt.Location = new System.Drawing.Point(206, 385);
            this.combatantUpBt.Name = "combatantUpBt";
            this.combatantUpBt.Size = new System.Drawing.Size(21, 23);
            this.combatantUpBt.TabIndex = 3;
            this.combatantUpBt.Text = "▲";
            this.combatantUpBt.UseVisualStyleBackColor = true;
            this.combatantUpBt.Click += new System.EventHandler(this.combatantUpBt_Click);
            // 
            // combatantDownBt
            // 
            this.combatantDownBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.combatantDownBt.Location = new System.Drawing.Point(233, 385);
            this.combatantDownBt.Name = "combatantDownBt";
            this.combatantDownBt.Size = new System.Drawing.Size(21, 23);
            this.combatantDownBt.TabIndex = 4;
            this.combatantDownBt.Text = "▼";
            this.combatantDownBt.UseVisualStyleBackColor = true;
            this.combatantDownBt.Click += new System.EventHandler(this.combatantDownBt_Click);
            // 
            // CombatantsListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combatantDownBt);
            this.Controls.Add(this.combatantUpBt);
            this.Controls.Add(this.removeCombatantBt);
            this.Controls.Add(this.addCombatantBt);
            this.Controls.Add(this.combatantsDgv);
            this.Name = "CombatantsListView";
            this.Size = new System.Drawing.Size(257, 410);
            ((System.ComponentModel.ISupportInitialize)(this.combatantsDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView combatantsDgv;
        private System.Windows.Forms.Button addCombatantBt;
        private System.Windows.Forms.Button removeCombatantBt;
        private System.Windows.Forms.Button combatantUpBt;
        private System.Windows.Forms.Button combatantDownBt;
    }
}
