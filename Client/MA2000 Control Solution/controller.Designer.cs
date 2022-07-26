namespace MA2000_Control_Solution
{
    partial class controller
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
            this.rad_controller_gen = new System.Windows.Forms.RadioButton();
            this.rad_controller_spec = new System.Windows.Forms.RadioButton();
            this.txt_gen_kp = new System.Windows.Forms.TextBox();
            this.txt_gen_kd = new System.Windows.Forms.TextBox();
            this.txt_gen_ki = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpSpecific = new System.Windows.Forms.GroupBox();
            this.chkWaist = new System.Windows.Forms.CheckBox();
            this.chkShoulder = new System.Windows.Forms.CheckBox();
            this.chkElbow = new System.Windows.Forms.CheckBox();
            this.chkPitch = new System.Windows.Forms.CheckBox();
            this.chkYaw = new System.Windows.Forms.CheckBox();
            this.chkRoll = new System.Windows.Forms.CheckBox();
            this.txt_waist_ki = new System.Windows.Forms.TextBox();
            this.txt_waist_kd = new System.Windows.Forms.TextBox();
            this.txt_waist_kp = new System.Windows.Forms.TextBox();
            this.txt_shoulder_ki = new System.Windows.Forms.TextBox();
            this.txt_shoulder_kd = new System.Windows.Forms.TextBox();
            this.txt_shoulder_kp = new System.Windows.Forms.TextBox();
            this.txt_elbow_ki = new System.Windows.Forms.TextBox();
            this.txt_elbow_kd = new System.Windows.Forms.TextBox();
            this.txt_elbow_kp = new System.Windows.Forms.TextBox();
            this.txt_pitch_ki = new System.Windows.Forms.TextBox();
            this.txt_pitch_kd = new System.Windows.Forms.TextBox();
            this.txt_pitch_kp = new System.Windows.Forms.TextBox();
            this.txt_yaw_ki = new System.Windows.Forms.TextBox();
            this.txt_yaw_kd = new System.Windows.Forms.TextBox();
            this.txt_yaw_kp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_roll_ki = new System.Windows.Forms.TextBox();
            this.txt_roll_kd = new System.Windows.Forms.TextBox();
            this.txt_roll_kp = new System.Windows.Forms.TextBox();
            this.btn_controller_ok = new System.Windows.Forms.Button();
            this.btn_controller_apply = new System.Windows.Forms.Button();
            this.btn_controller_cancel = new System.Windows.Forms.Button();
            this.txt_sample_time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.grpSpecific.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // rad_controller_gen
            // 
            this.rad_controller_gen.AutoSize = true;
            this.rad_controller_gen.Checked = true;
            this.rad_controller_gen.Location = new System.Drawing.Point(28, 48);
            this.rad_controller_gen.Name = "rad_controller_gen";
            this.rad_controller_gen.Size = new System.Drawing.Size(62, 17);
            this.rad_controller_gen.TabIndex = 0;
            this.rad_controller_gen.TabStop = true;
            this.rad_controller_gen.Text = "General";
            this.rad_controller_gen.UseVisualStyleBackColor = true;
            this.rad_controller_gen.CheckedChanged += new System.EventHandler(this.rad_controller_gen_CheckedChanged);
            // 
            // rad_controller_spec
            // 
            this.rad_controller_spec.AutoSize = true;
            this.rad_controller_spec.Location = new System.Drawing.Point(28, 90);
            this.rad_controller_spec.Name = "rad_controller_spec";
            this.rad_controller_spec.Size = new System.Drawing.Size(61, 17);
            this.rad_controller_spec.TabIndex = 1;
            this.rad_controller_spec.Text = "Specific";
            this.rad_controller_spec.UseVisualStyleBackColor = true;
            this.rad_controller_spec.CheckedChanged += new System.EventHandler(this.rad_controller_spec_CheckedChanged);
            // 
            // txt_gen_kp
            // 
            this.txt_gen_kp.Location = new System.Drawing.Point(34, 36);
            this.txt_gen_kp.Name = "txt_gen_kp";
            this.txt_gen_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_gen_kp.TabIndex = 2;
            // 
            // txt_gen_kd
            // 
            this.txt_gen_kd.Location = new System.Drawing.Point(234, 36);
            this.txt_gen_kd.Name = "txt_gen_kd";
            this.txt_gen_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_gen_kd.TabIndex = 3;
            // 
            // txt_gen_ki
            // 
            this.txt_gen_ki.Location = new System.Drawing.Point(134, 36);
            this.txt_gen_ki.Name = "txt_gen_ki";
            this.txt_gen_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_gen_ki.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "KP :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "KI :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "KD :";
            // 
            // grpSpecific
            // 
            this.grpSpecific.Controls.Add(this.chkWaist);
            this.grpSpecific.Controls.Add(this.chkShoulder);
            this.grpSpecific.Controls.Add(this.chkElbow);
            this.grpSpecific.Controls.Add(this.chkPitch);
            this.grpSpecific.Controls.Add(this.chkYaw);
            this.grpSpecific.Controls.Add(this.chkRoll);
            this.grpSpecific.Controls.Add(this.txt_waist_ki);
            this.grpSpecific.Controls.Add(this.txt_waist_kd);
            this.grpSpecific.Controls.Add(this.txt_waist_kp);
            this.grpSpecific.Controls.Add(this.txt_shoulder_ki);
            this.grpSpecific.Controls.Add(this.txt_shoulder_kd);
            this.grpSpecific.Controls.Add(this.txt_shoulder_kp);
            this.grpSpecific.Controls.Add(this.txt_elbow_ki);
            this.grpSpecific.Controls.Add(this.txt_elbow_kd);
            this.grpSpecific.Controls.Add(this.txt_elbow_kp);
            this.grpSpecific.Controls.Add(this.txt_pitch_ki);
            this.grpSpecific.Controls.Add(this.txt_pitch_kd);
            this.grpSpecific.Controls.Add(this.txt_pitch_kp);
            this.grpSpecific.Controls.Add(this.txt_yaw_ki);
            this.grpSpecific.Controls.Add(this.txt_yaw_kd);
            this.grpSpecific.Controls.Add(this.txt_yaw_kp);
            this.grpSpecific.Controls.Add(this.label7);
            this.grpSpecific.Controls.Add(this.label8);
            this.grpSpecific.Controls.Add(this.label9);
            this.grpSpecific.Controls.Add(this.txt_roll_ki);
            this.grpSpecific.Controls.Add(this.txt_roll_kd);
            this.grpSpecific.Controls.Add(this.txt_roll_kp);
            this.grpSpecific.Enabled = false;
            this.grpSpecific.Location = new System.Drawing.Point(35, 113);
            this.grpSpecific.Name = "grpSpecific";
            this.grpSpecific.Size = new System.Drawing.Size(395, 212);
            this.grpSpecific.TabIndex = 11;
            this.grpSpecific.TabStop = false;
            this.grpSpecific.Text = "Specific Configuration";
            // 
            // chkWaist
            // 
            this.chkWaist.AutoSize = true;
            this.chkWaist.Location = new System.Drawing.Point(17, 164);
            this.chkWaist.Name = "chkWaist";
            this.chkWaist.Size = new System.Drawing.Size(53, 17);
            this.chkWaist.TabIndex = 69;
            this.chkWaist.Text = "Waist";
            this.chkWaist.UseVisualStyleBackColor = true;
            // 
            // chkShoulder
            // 
            this.chkShoulder.AutoSize = true;
            this.chkShoulder.Location = new System.Drawing.Point(17, 138);
            this.chkShoulder.Name = "chkShoulder";
            this.chkShoulder.Size = new System.Drawing.Size(68, 17);
            this.chkShoulder.TabIndex = 68;
            this.chkShoulder.Text = "Shoulder";
            this.chkShoulder.UseVisualStyleBackColor = true;
            // 
            // chkElbow
            // 
            this.chkElbow.AutoSize = true;
            this.chkElbow.Location = new System.Drawing.Point(17, 112);
            this.chkElbow.Name = "chkElbow";
            this.chkElbow.Size = new System.Drawing.Size(54, 17);
            this.chkElbow.TabIndex = 67;
            this.chkElbow.Text = "Elbow";
            this.chkElbow.UseVisualStyleBackColor = true;
            // 
            // chkPitch
            // 
            this.chkPitch.AutoSize = true;
            this.chkPitch.Location = new System.Drawing.Point(17, 86);
            this.chkPitch.Name = "chkPitch";
            this.chkPitch.Size = new System.Drawing.Size(49, 17);
            this.chkPitch.TabIndex = 66;
            this.chkPitch.Text = "Pitch";
            this.chkPitch.UseVisualStyleBackColor = true;
            // 
            // chkYaw
            // 
            this.chkYaw.AutoSize = true;
            this.chkYaw.Location = new System.Drawing.Point(17, 60);
            this.chkYaw.Name = "chkYaw";
            this.chkYaw.Size = new System.Drawing.Size(46, 17);
            this.chkYaw.TabIndex = 65;
            this.chkYaw.Text = "Yaw";
            this.chkYaw.UseVisualStyleBackColor = true;
            // 
            // chkRoll
            // 
            this.chkRoll.AutoSize = true;
            this.chkRoll.Location = new System.Drawing.Point(17, 34);
            this.chkRoll.Name = "chkRoll";
            this.chkRoll.Size = new System.Drawing.Size(43, 17);
            this.chkRoll.TabIndex = 64;
            this.chkRoll.Text = "Roll";
            this.chkRoll.UseVisualStyleBackColor = true;
            // 
            // txt_waist_ki
            // 
            this.txt_waist_ki.Location = new System.Drawing.Point(197, 161);
            this.txt_waist_ki.Name = "txt_waist_ki";
            this.txt_waist_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_waist_ki.TabIndex = 63;
            // 
            // txt_waist_kd
            // 
            this.txt_waist_kd.Location = new System.Drawing.Point(297, 161);
            this.txt_waist_kd.Name = "txt_waist_kd";
            this.txt_waist_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_waist_kd.TabIndex = 62;
            // 
            // txt_waist_kp
            // 
            this.txt_waist_kp.Location = new System.Drawing.Point(97, 161);
            this.txt_waist_kp.Name = "txt_waist_kp";
            this.txt_waist_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_waist_kp.TabIndex = 61;
            // 
            // txt_shoulder_ki
            // 
            this.txt_shoulder_ki.Location = new System.Drawing.Point(197, 135);
            this.txt_shoulder_ki.Name = "txt_shoulder_ki";
            this.txt_shoulder_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_shoulder_ki.TabIndex = 60;
            // 
            // txt_shoulder_kd
            // 
            this.txt_shoulder_kd.Location = new System.Drawing.Point(297, 135);
            this.txt_shoulder_kd.Name = "txt_shoulder_kd";
            this.txt_shoulder_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_shoulder_kd.TabIndex = 59;
            // 
            // txt_shoulder_kp
            // 
            this.txt_shoulder_kp.Location = new System.Drawing.Point(97, 135);
            this.txt_shoulder_kp.Name = "txt_shoulder_kp";
            this.txt_shoulder_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_shoulder_kp.TabIndex = 58;
            // 
            // txt_elbow_ki
            // 
            this.txt_elbow_ki.Location = new System.Drawing.Point(197, 109);
            this.txt_elbow_ki.Name = "txt_elbow_ki";
            this.txt_elbow_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_elbow_ki.TabIndex = 57;
            // 
            // txt_elbow_kd
            // 
            this.txt_elbow_kd.Location = new System.Drawing.Point(297, 109);
            this.txt_elbow_kd.Name = "txt_elbow_kd";
            this.txt_elbow_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_elbow_kd.TabIndex = 56;
            // 
            // txt_elbow_kp
            // 
            this.txt_elbow_kp.Location = new System.Drawing.Point(97, 109);
            this.txt_elbow_kp.Name = "txt_elbow_kp";
            this.txt_elbow_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_elbow_kp.TabIndex = 55;
            // 
            // txt_pitch_ki
            // 
            this.txt_pitch_ki.Location = new System.Drawing.Point(197, 83);
            this.txt_pitch_ki.Name = "txt_pitch_ki";
            this.txt_pitch_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_pitch_ki.TabIndex = 54;
            // 
            // txt_pitch_kd
            // 
            this.txt_pitch_kd.Location = new System.Drawing.Point(297, 83);
            this.txt_pitch_kd.Name = "txt_pitch_kd";
            this.txt_pitch_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_pitch_kd.TabIndex = 53;
            // 
            // txt_pitch_kp
            // 
            this.txt_pitch_kp.Location = new System.Drawing.Point(97, 83);
            this.txt_pitch_kp.Name = "txt_pitch_kp";
            this.txt_pitch_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_pitch_kp.TabIndex = 52;
            // 
            // txt_yaw_ki
            // 
            this.txt_yaw_ki.Location = new System.Drawing.Point(197, 57);
            this.txt_yaw_ki.Name = "txt_yaw_ki";
            this.txt_yaw_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_yaw_ki.TabIndex = 51;
            // 
            // txt_yaw_kd
            // 
            this.txt_yaw_kd.Location = new System.Drawing.Point(297, 57);
            this.txt_yaw_kd.Name = "txt_yaw_kd";
            this.txt_yaw_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_yaw_kd.TabIndex = 50;
            // 
            // txt_yaw_kp
            // 
            this.txt_yaw_kp.Location = new System.Drawing.Point(97, 57);
            this.txt_yaw_kp.Name = "txt_yaw_kp";
            this.txt_yaw_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_yaw_kp.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "KD :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "KI :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(94, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "KP :";
            // 
            // txt_roll_ki
            // 
            this.txt_roll_ki.Location = new System.Drawing.Point(197, 31);
            this.txt_roll_ki.Name = "txt_roll_ki";
            this.txt_roll_ki.Size = new System.Drawing.Size(78, 20);
            this.txt_roll_ki.TabIndex = 45;
            // 
            // txt_roll_kd
            // 
            this.txt_roll_kd.Location = new System.Drawing.Point(297, 31);
            this.txt_roll_kd.Name = "txt_roll_kd";
            this.txt_roll_kd.Size = new System.Drawing.Size(78, 20);
            this.txt_roll_kd.TabIndex = 44;
            // 
            // txt_roll_kp
            // 
            this.txt_roll_kp.Location = new System.Drawing.Point(97, 31);
            this.txt_roll_kp.Name = "txt_roll_kp";
            this.txt_roll_kp.Size = new System.Drawing.Size(78, 20);
            this.txt_roll_kp.TabIndex = 43;
            // 
            // btn_controller_ok
            // 
            this.btn_controller_ok.Location = new System.Drawing.Point(35, 387);
            this.btn_controller_ok.Name = "btn_controller_ok";
            this.btn_controller_ok.Size = new System.Drawing.Size(105, 31);
            this.btn_controller_ok.TabIndex = 12;
            this.btn_controller_ok.Text = "OK";
            this.btn_controller_ok.UseVisualStyleBackColor = true;
            this.btn_controller_ok.Click += new System.EventHandler(this.btn_controller_ok_Click);
            // 
            // btn_controller_apply
            // 
            this.btn_controller_apply.Location = new System.Drawing.Point(180, 387);
            this.btn_controller_apply.Name = "btn_controller_apply";
            this.btn_controller_apply.Size = new System.Drawing.Size(105, 31);
            this.btn_controller_apply.TabIndex = 13;
            this.btn_controller_apply.Text = "Apply";
            this.btn_controller_apply.UseVisualStyleBackColor = true;
            this.btn_controller_apply.Click += new System.EventHandler(this.btn_controller_apply_Click);
            // 
            // btn_controller_cancel
            // 
            this.btn_controller_cancel.Location = new System.Drawing.Point(325, 387);
            this.btn_controller_cancel.Name = "btn_controller_cancel";
            this.btn_controller_cancel.Size = new System.Drawing.Size(105, 31);
            this.btn_controller_cancel.TabIndex = 14;
            this.btn_controller_cancel.Text = "Cancel";
            this.btn_controller_cancel.UseVisualStyleBackColor = true;
            this.btn_controller_cancel.Click += new System.EventHandler(this.btn_controller_cancel_Click);
            // 
            // txt_sample_time
            // 
            this.txt_sample_time.Location = new System.Drawing.Point(132, 331);
            this.txt_sample_time.Name = "txt_sample_time";
            this.txt_sample_time.Size = new System.Drawing.Size(80, 20);
            this.txt_sample_time.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sampling Time  :";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.label6);
            this.grpGeneral.Controls.Add(this.label4);
            this.grpGeneral.Controls.Add(this.label2);
            this.grpGeneral.Controls.Add(this.txt_gen_ki);
            this.grpGeneral.Controls.Add(this.txt_gen_kd);
            this.grpGeneral.Controls.Add(this.txt_gen_kp);
            this.grpGeneral.Location = new System.Drawing.Point(96, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(334, 71);
            this.grpGeneral.TabIndex = 17;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General Configuration";
            // 
            // controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 461);
            this.ControlBox = false;
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sample_time);
            this.Controls.Add(this.btn_controller_cancel);
            this.Controls.Add(this.btn_controller_apply);
            this.Controls.Add(this.btn_controller_ok);
            this.Controls.Add(this.grpSpecific);
            this.Controls.Add(this.rad_controller_spec);
            this.Controls.Add(this.rad_controller_gen);
            this.Name = "controller";
            this.Text = "PID Controller Settings";
            this.Activated += new System.EventHandler(this.controller_Activate);
            this.Load += new System.EventHandler(this.controller_Load);
            this.grpSpecific.ResumeLayout(false);
            this.grpSpecific.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rad_controller_gen;
        private System.Windows.Forms.RadioButton rad_controller_spec;
        private System.Windows.Forms.TextBox txt_gen_kp;
        private System.Windows.Forms.TextBox txt_gen_kd;
        private System.Windows.Forms.TextBox txt_gen_ki;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpSpecific;
        private System.Windows.Forms.CheckBox chkWaist;
        private System.Windows.Forms.CheckBox chkShoulder;
        private System.Windows.Forms.CheckBox chkElbow;
        private System.Windows.Forms.CheckBox chkPitch;
        private System.Windows.Forms.CheckBox chkYaw;
        private System.Windows.Forms.CheckBox chkRoll;
        private System.Windows.Forms.TextBox txt_waist_ki;
        private System.Windows.Forms.TextBox txt_waist_kd;
        private System.Windows.Forms.TextBox txt_waist_kp;
        private System.Windows.Forms.TextBox txt_shoulder_ki;
        private System.Windows.Forms.TextBox txt_shoulder_kd;
        private System.Windows.Forms.TextBox txt_shoulder_kp;
        private System.Windows.Forms.TextBox txt_elbow_ki;
        private System.Windows.Forms.TextBox txt_elbow_kd;
        private System.Windows.Forms.TextBox txt_elbow_kp;
        private System.Windows.Forms.TextBox txt_pitch_ki;
        private System.Windows.Forms.TextBox txt_pitch_kd;
        private System.Windows.Forms.TextBox txt_pitch_kp;
        private System.Windows.Forms.TextBox txt_yaw_ki;
        private System.Windows.Forms.TextBox txt_yaw_kd;
        private System.Windows.Forms.TextBox txt_yaw_kp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_roll_ki;
        private System.Windows.Forms.TextBox txt_roll_kd;
        private System.Windows.Forms.TextBox txt_roll_kp;
        private System.Windows.Forms.Button btn_controller_ok;
        private System.Windows.Forms.Button btn_controller_apply;
        private System.Windows.Forms.Button btn_controller_cancel;
        private System.Windows.Forms.TextBox txt_sample_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpGeneral;
    }
}