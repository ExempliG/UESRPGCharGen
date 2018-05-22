namespace UESRPG_Character_Manager.UI.CharacterViews
{
    partial class CharacteristicsView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nbPersonality = new System.Windows.Forms.NumericUpDown();
            this.nbLuck = new System.Windows.Forms.NumericUpDown();
            this.nbWillpower = new System.Windows.Forms.NumericUpDown();
            this.nbPerception = new System.Windows.Forms.NumericUpDown();
            this.nbAgility = new System.Windows.Forms.NumericUpDown();
            this.nbIntelligence = new System.Windows.Forms.NumericUpDown();
            this.nbStrength = new System.Windows.Forms.NumericUpDown();
            this.nbEndurance = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbPersonality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbWillpower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPerception)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbEndurance)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nbPersonality);
            this.groupBox1.Controls.Add(this.nbLuck);
            this.groupBox1.Controls.Add(this.nbWillpower);
            this.groupBox1.Controls.Add(this.nbPerception);
            this.groupBox1.Controls.Add(this.nbAgility);
            this.groupBox1.Controls.Add(this.nbIntelligence);
            this.groupBox1.Controls.Add(this.nbStrength);
            this.groupBox1.Controls.Add(this.nbEndurance);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 229);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Characteristics";
            // 
            // nbPersonality
            // 
            this.nbPersonality.Location = new System.Drawing.Point(72, 176);
            this.nbPersonality.Name = "nbPersonality";
            this.nbPersonality.Size = new System.Drawing.Size(46, 20);
            this.nbPersonality.TabIndex = 7;
            this.nbPersonality.ValueChanged += new System.EventHandler(this.nbPersonality_ValueChanged);
            // 
            // nbLuck
            // 
            this.nbLuck.Location = new System.Drawing.Point(72, 202);
            this.nbLuck.Name = "nbLuck";
            this.nbLuck.Size = new System.Drawing.Size(46, 20);
            this.nbLuck.TabIndex = 8;
            this.nbLuck.ValueChanged += new System.EventHandler(this.nbLuck_ValueChanged);
            // 
            // nbWillpower
            // 
            this.nbWillpower.Location = new System.Drawing.Point(72, 124);
            this.nbWillpower.Name = "nbWillpower";
            this.nbWillpower.Size = new System.Drawing.Size(46, 20);
            this.nbWillpower.TabIndex = 5;
            this.nbWillpower.ValueChanged += new System.EventHandler(this.nbWillpower_ValueChanged);
            // 
            // nbPerception
            // 
            this.nbPerception.Location = new System.Drawing.Point(72, 150);
            this.nbPerception.Name = "nbPerception";
            this.nbPerception.Size = new System.Drawing.Size(46, 20);
            this.nbPerception.TabIndex = 6;
            this.nbPerception.ValueChanged += new System.EventHandler(this.nbPerception_ValueChanged);
            // 
            // nbAgility
            // 
            this.nbAgility.Location = new System.Drawing.Point(72, 72);
            this.nbAgility.Name = "nbAgility";
            this.nbAgility.Size = new System.Drawing.Size(46, 20);
            this.nbAgility.TabIndex = 3;
            this.nbAgility.ValueChanged += new System.EventHandler(this.nbAgility_ValueChanged);
            // 
            // nbIntelligence
            // 
            this.nbIntelligence.Location = new System.Drawing.Point(72, 98);
            this.nbIntelligence.Name = "nbIntelligence";
            this.nbIntelligence.Size = new System.Drawing.Size(46, 20);
            this.nbIntelligence.TabIndex = 4;
            this.nbIntelligence.ValueChanged += new System.EventHandler(this.nbIntelligence_ValueChanged);
            // 
            // nbStrength
            // 
            this.nbStrength.Location = new System.Drawing.Point(72, 20);
            this.nbStrength.Name = "nbStrength";
            this.nbStrength.Size = new System.Drawing.Size(46, 20);
            this.nbStrength.TabIndex = 1;
            this.nbStrength.ValueChanged += new System.EventHandler(this.nbStrength_ValueChanged);
            // 
            // nbEndurance
            // 
            this.nbEndurance.Location = new System.Drawing.Point(72, 46);
            this.nbEndurance.Name = "nbEndurance";
            this.nbEndurance.Size = new System.Drawing.Size(46, 20);
            this.nbEndurance.TabIndex = 2;
            this.nbEndurance.ValueChanged += new System.EventHandler(this.nbEndurance_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Luck";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Personality";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Perception";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Willpower";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Intelligence";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Endurance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Strength";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Agility";
            // 
            // CharacterCharacteristicsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CharacterCharacteristicsView";
            this.Size = new System.Drawing.Size(124, 229);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbPersonality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbWillpower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPerception)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbEndurance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nbPersonality;
        private System.Windows.Forms.NumericUpDown nbLuck;
        private System.Windows.Forms.NumericUpDown nbWillpower;
        private System.Windows.Forms.NumericUpDown nbPerception;
        private System.Windows.Forms.NumericUpDown nbAgility;
        private System.Windows.Forms.NumericUpDown nbIntelligence;
        private System.Windows.Forms.NumericUpDown nbStrength;
        private System.Windows.Forms.NumericUpDown nbEndurance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
