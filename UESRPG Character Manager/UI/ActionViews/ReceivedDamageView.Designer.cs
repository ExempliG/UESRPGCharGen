namespace UESRPG_Character_Manager.UI.ActionViews
{
    partial class ReceivedDamageView
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.applyDamageBt = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.finalDamageReceivedTb = new System.Windows.Forms.TextBox();
            this.hitLocationCb = new System.Windows.Forms.ComboBox();
            this.receivedPenTb = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.receivedDamageTb = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.applyDamageBt);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.finalDamageReceivedTb);
            this.groupBox5.Controls.Add(this.hitLocationCb);
            this.groupBox5.Controls.Add(this.receivedPenTb);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.receivedDamageTb);
            this.groupBox5.Location = new System.Drawing.Point(1, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 155);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Received Damage";
            // 
            // applyDamageBt
            // 
            this.applyDamageBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyDamageBt.Location = new System.Drawing.Point(61, 125);
            this.applyDamageBt.Name = "applyDamageBt";
            this.applyDamageBt.Size = new System.Drawing.Size(102, 23);
            this.applyDamageBt.TabIndex = 8;
            this.applyDamageBt.Text = "Apply Damage";
            this.applyDamageBt.UseVisualStyleBackColor = true;
            this.applyDamageBt.Click += new System.EventHandler(this.applyDamageBt_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 102);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 13);
            this.label36.TabIndex = 7;
            this.label36.Text = "Result:";
            // 
            // finalDamageReceivedTb
            // 
            this.finalDamageReceivedTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalDamageReceivedTb.Location = new System.Drawing.Point(63, 99);
            this.finalDamageReceivedTb.Name = "finalDamageReceivedTb";
            this.finalDamageReceivedTb.Size = new System.Drawing.Size(100, 20);
            this.finalDamageReceivedTb.TabIndex = 6;
            // 
            // hitLocationCb
            // 
            this.hitLocationCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hitLocationCb.FormattingEnabled = true;
            this.hitLocationCb.Location = new System.Drawing.Point(63, 72);
            this.hitLocationCb.Name = "hitLocationCb";
            this.hitLocationCb.Size = new System.Drawing.Size(100, 21);
            this.hitLocationCb.TabIndex = 5;
            this.hitLocationCb.SelectedIndexChanged += new System.EventHandler(this.hitLocationCb_SelectedIndexChanged);
            // 
            // receivedPenTb
            // 
            this.receivedPenTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receivedPenTb.Location = new System.Drawing.Point(63, 46);
            this.receivedPenTb.Name = "receivedPenTb";
            this.receivedPenTb.Size = new System.Drawing.Size(100, 20);
            this.receivedPenTb.TabIndex = 4;
            this.receivedPenTb.Text = "0";
            this.receivedPenTb.TextChanged += new System.EventHandler(this.receivedPenTb_TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 75);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(51, 13);
            this.label35.TabIndex = 3;
            this.label35.Text = "Location:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 49);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Pen:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 13);
            this.label32.TabIndex = 1;
            this.label32.Text = "Damage:";
            // 
            // receivedDamageTb
            // 
            this.receivedDamageTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receivedDamageTb.Location = new System.Drawing.Point(63, 20);
            this.receivedDamageTb.Name = "receivedDamageTb";
            this.receivedDamageTb.Size = new System.Drawing.Size(100, 20);
            this.receivedDamageTb.TabIndex = 0;
            this.receivedDamageTb.Text = "0";
            this.receivedDamageTb.TextChanged += new System.EventHandler(this.receivedDamageTb_TextChanged);
            // 
            // ReceivedDamageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Name = "ReceivedDamageView";
            this.Size = new System.Drawing.Size(175, 158);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button applyDamageBt;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox finalDamageReceivedTb;
        private System.Windows.Forms.ComboBox hitLocationCb;
        private System.Windows.Forms.TextBox receivedPenTb;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox receivedDamageTb;
    }
}
