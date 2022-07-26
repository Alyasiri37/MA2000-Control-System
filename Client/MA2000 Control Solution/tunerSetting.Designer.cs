namespace MA2000_Control_Solution
{
    partial class tunerSetting
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
            this.btn_tuner_ok = new System.Windows.Forms.Button();
            this.btn_tuner_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoCycles = new System.Windows.Forms.TextBox();
            this.txtCycleDuration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkWaistTune = new System.Windows.Forms.CheckBox();
            this.chkShoulderTune = new System.Windows.Forms.CheckBox();
            this.chkElbowTune = new System.Windows.Forms.CheckBox();
            this.chkPitchTune = new System.Windows.Forms.CheckBox();
            this.chkYawTune = new System.Windows.Forms.CheckBox();
            this.chkRollTune = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtC1 = new System.Windows.Forms.TextBox();
            this.txtC2 = new System.Windows.Forms.TextBox();
            this.txtSwarmSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tuner_ok
            // 
            this.btn_tuner_ok.Location = new System.Drawing.Point(241, 179);
            this.btn_tuner_ok.Name = "btn_tuner_ok";
            this.btn_tuner_ok.Size = new System.Drawing.Size(105, 26);
            this.btn_tuner_ok.TabIndex = 0;
            this.btn_tuner_ok.Text = "OK";
            this.btn_tuner_ok.UseVisualStyleBackColor = true;
            this.btn_tuner_ok.Click += new System.EventHandler(this.btn_tuner_ok_Click);
            // 
            // btn_tuner_cancel
            // 
            this.btn_tuner_cancel.Location = new System.Drawing.Point(374, 179);
            this.btn_tuner_cancel.Name = "btn_tuner_cancel";
            this.btn_tuner_cancel.Size = new System.Drawing.Size(105, 26);
            this.btn_tuner_cancel.TabIndex = 1;
            this.btn_tuner_cancel.Text = "Cancel";
            this.btn_tuner_cancel.UseVisualStyleBackColor = true;
            this.btn_tuner_cancel.Click += new System.EventHandler(this.btn_tuner_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "No. of Cycles :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cycle Duration :";
            // 
            // txtNoCycles
            // 
            this.txtNoCycles.Location = new System.Drawing.Point(203, 22);
            this.txtNoCycles.Name = "txtNoCycles";
            this.txtNoCycles.Size = new System.Drawing.Size(80, 20);
            this.txtNoCycles.TabIndex = 4;
            // 
            // txtCycleDuration
            // 
            this.txtCycleDuration.Location = new System.Drawing.Point(203, 49);
            this.txtCycleDuration.Name = "txtCycleDuration";
            this.txtCycleDuration.Size = new System.Drawing.Size(80, 20);
            this.txtCycleDuration.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cycles";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkWaistTune);
            this.groupBox1.Controls.Add(this.chkShoulderTune);
            this.groupBox1.Controls.Add(this.chkElbowTune);
            this.groupBox1.Controls.Add(this.chkPitchTune);
            this.groupBox1.Controls.Add(this.chkYawTune);
            this.groupBox1.Controls.Add(this.chkRollTune);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 161);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Joints to Tune :";
            // 
            // chkWaistTune
            // 
            this.chkWaistTune.AutoSize = true;
            this.chkWaistTune.Location = new System.Drawing.Point(6, 134);
            this.chkWaistTune.Name = "chkWaistTune";
            this.chkWaistTune.Size = new System.Drawing.Size(53, 17);
            this.chkWaistTune.TabIndex = 5;
            this.chkWaistTune.Text = "Waist";
            this.chkWaistTune.UseVisualStyleBackColor = true;
            // 
            // chkShoulderTune
            // 
            this.chkShoulderTune.AutoSize = true;
            this.chkShoulderTune.Location = new System.Drawing.Point(6, 111);
            this.chkShoulderTune.Name = "chkShoulderTune";
            this.chkShoulderTune.Size = new System.Drawing.Size(68, 17);
            this.chkShoulderTune.TabIndex = 4;
            this.chkShoulderTune.Text = "Shoulder";
            this.chkShoulderTune.UseVisualStyleBackColor = true;
            // 
            // chkElbowTune
            // 
            this.chkElbowTune.AutoSize = true;
            this.chkElbowTune.Location = new System.Drawing.Point(6, 88);
            this.chkElbowTune.Name = "chkElbowTune";
            this.chkElbowTune.Size = new System.Drawing.Size(54, 17);
            this.chkElbowTune.TabIndex = 3;
            this.chkElbowTune.Text = "Elbow";
            this.chkElbowTune.UseVisualStyleBackColor = true;
            // 
            // chkPitchTune
            // 
            this.chkPitchTune.AutoSize = true;
            this.chkPitchTune.Location = new System.Drawing.Point(6, 65);
            this.chkPitchTune.Name = "chkPitchTune";
            this.chkPitchTune.Size = new System.Drawing.Size(49, 17);
            this.chkPitchTune.TabIndex = 2;
            this.chkPitchTune.Text = "Pitch";
            this.chkPitchTune.UseVisualStyleBackColor = true;
            // 
            // chkYawTune
            // 
            this.chkYawTune.AutoSize = true;
            this.chkYawTune.Location = new System.Drawing.Point(6, 42);
            this.chkYawTune.Name = "chkYawTune";
            this.chkYawTune.Size = new System.Drawing.Size(46, 17);
            this.chkYawTune.TabIndex = 1;
            this.chkYawTune.Text = "Yaw";
            this.chkYawTune.UseVisualStyleBackColor = true;
            // 
            // chkRollTune
            // 
            this.chkRollTune.AutoSize = true;
            this.chkRollTune.Location = new System.Drawing.Point(6, 19);
            this.chkRollTune.Name = "chkRollTune";
            this.chkRollTune.Size = new System.Drawing.Size(43, 17);
            this.chkRollTune.TabIndex = 0;
            this.chkRollTune.Text = "Roll";
            this.chkRollTune.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSwarmSize);
            this.groupBox2.Controls.Add(this.txtC2);
            this.groupBox2.Controls.Add(this.txtC1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNoCycles);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCycleDuration);
            this.groupBox2.Location = new System.Drawing.Point(129, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 161);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Settings :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cognitive Acceleration Factor (C1) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Social Acceleration Factor (C2) :";
            // 
            // txtC1
            // 
            this.txtC1.Location = new System.Drawing.Point(203, 76);
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(80, 20);
            this.txtC1.TabIndex = 12;
            // 
            // txtC2
            // 
            this.txtC2.Location = new System.Drawing.Point(203, 103);
            this.txtC2.Name = "txtC2";
            this.txtC2.Size = new System.Drawing.Size(80, 20);
            this.txtC2.TabIndex = 13;
            // 
            // txtSwarmSize
            // 
            this.txtSwarmSize.Location = new System.Drawing.Point(203, 130);
            this.txtSwarmSize.Name = "txtSwarmSize";
            this.txtSwarmSize.Size = new System.Drawing.Size(80, 20);
            this.txtSwarmSize.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Swarm Size : ";
            // 
            // tunerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 215);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_tuner_cancel);
            this.Controls.Add(this.btn_tuner_ok);
            this.Name = "tunerSetting";
            this.Text = "Tuner";
            this.Activated += new System.EventHandler(this.tunerSetting_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tuner_ok;
        private System.Windows.Forms.Button btn_tuner_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoCycles;
        private System.Windows.Forms.TextBox txtCycleDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkWaistTune;
        private System.Windows.Forms.CheckBox chkShoulderTune;
        private System.Windows.Forms.CheckBox chkElbowTune;
        private System.Windows.Forms.CheckBox chkPitchTune;
        private System.Windows.Forms.CheckBox chkYawTune;
        private System.Windows.Forms.CheckBox chkRollTune;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtC2;
        private System.Windows.Forms.TextBox txtC1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSwarmSize;
    }
}