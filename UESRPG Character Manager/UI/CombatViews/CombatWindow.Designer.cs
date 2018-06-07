namespace UESRPG_Character_Manager.UI.CombatViews
{
    partial class CombatWindow
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
            this.combatantsListView = new UESRPG_Character_Manager.UI.CombatViews.CombatantsListView();
            this.SuspendLayout();
            // 
            // combatantsListView
            // 
            this.combatantsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.combatantsListView.Location = new System.Drawing.Point(12, 12);
            this.combatantsListView.Name = "combatantsListView";
            this.combatantsListView.Size = new System.Drawing.Size(250, 410);
            this.combatantsListView.TabIndex = 0;
            // 
            // CombatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.combatantsListView);
            this.Name = "CombatWindow";
            this.Text = "Combat";
            this.ResumeLayout(false);

        }

        #endregion

        private CombatantsListView combatantsListView;
    }
}