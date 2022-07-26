namespace MA2000_Control_Solution
{
    partial class tunePosition
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_roll_tune = new System.Windows.Forms.TextBox();
            this.txt_yaw_tune = new System.Windows.Forms.TextBox();
            this.txt_pitch_tune = new System.Windows.Forms.TextBox();
            this.txt_elbow_tune = new System.Windows.Forms.TextBox();
            this.txt_shoulder_tune = new System.Windows.Forms.TextBox();
            this.txt_waist_tune = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_tune_ok = new System.Windows.Forms.Button();
            this.btn_tune_cancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roll                   :";
            // 
            // txt_roll_tune
            // 
            this.txt_roll_tune.Location = new System.Drawing.Point(128, 16);
            this.txt_roll_tune.Name = "txt_roll_tune";
            this.txt_roll_tune.Size = new System.Drawing.Size(100, 20);
            this.txt_roll_tune.TabIndex = 1;
            // 
            // txt_yaw_tune
            // 
            this.txt_yaw_tune.Location = new System.Drawing.Point(128, 42);
            this.txt_yaw_tune.Name = "txt_yaw_tune";
            this.txt_yaw_tune.Size = new System.Drawing.Size(100, 20);
            this.txt_yaw_tune.TabIndex = 2;
            // 
            // txt_pitch_tune
            // 
            this.txt_pitch_tune.Location = new System.Drawing.Point(128, 68);
            this.txt_pitch_tune.Name = "txt_pitch_tune";
            this.txt_pitch_tune.Size = new System.Drawing.Size(100, 20);
            this.txt_pitch_tune.TabIndex = 3;
            // 
            // txt_elbow_tune
            // 
            this.txt_elbow_tune.Location = new System.Drawing.Point(128, 94);
            this.txt_elbow_tune.Name = "txt_elbow_tune";
            this.txt_elbow_tune.Size = new System.Drawing.Size(100, 20);
            this.txt_elbow_tune.TabIndex = 4;
            // 
            // txt_shoulder_tune
            // 
            this.txt_shoulder_tune.Location = new System.Drawing.Point(128, 120);
            this.txt_shoulder_tune.Name = "txt_shoulder_tune";
            this.txt_shoulder_tune.Size = new System.Drawing.Size(100, 20);
            this.txt_shoulder_tune.TabIndex = 5;
            // 
            // txt_waist_tune
            // 
            this.txt_waist_tune.Location = new System.Drawing.Point(128, 146);
            this.txt_waist_tune.Name = "txt_waist_tune";
            this.txt_waist_tune.Size = new System.Drawing.Size(100, 20);
            this.txt_waist_tune.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Yaw                  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pitch                 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Elbow               :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Shoulder          :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Waist               :";
            // 
            // btn_tune_ok
            // 
            this.btn_tune_ok.Location = new System.Drawing.Point(27, 174);
            this.btn_tune_ok.Name = "btn_tune_ok";
            this.btn_tune_ok.Size = new System.Drawing.Size(98, 25);
            this.btn_tune_ok.TabIndex = 12;
            this.btn_tune_ok.Text = "OK";
            this.btn_tune_ok.UseVisualStyleBackColor = true;
            this.btn_tune_ok.Click += new System.EventHandler(this.btn_tune_ok_Click);
            // 
            // btn_tune_cancel
            // 
            this.btn_tune_cancel.Location = new System.Drawing.Point(130, 174);
            this.btn_tune_cancel.Name = "btn_tune_cancel";
            this.btn_tune_cancel.Size = new System.Drawing.Size(98, 25);
            this.btn_tune_cancel.TabIndex = 13;
            this.btn_tune_cancel.Text = "Cancel";
            this.btn_tune_cancel.UseVisualStyleBackColor = true;
            this.btn_tune_cancel.Click += new System.EventHandler(this.btn_tune_cancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(222, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Note : Please enter tune position in degrees.";
            // 
            // tunePosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 234);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_tune_cancel);
            this.Controls.Add(this.btn_tune_ok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_waist_tune);
            this.Controls.Add(this.txt_shoulder_tune);
            this.Controls.Add(this.txt_elbow_tune);
            this.Controls.Add(this.txt_pitch_tune);
            this.Controls.Add(this.txt_yaw_tune);
            this.Controls.Add(this.txt_roll_tune);
            this.Controls.Add(this.label1);
            this.Name = "tunePosition";
            this.Text = "Tune Position";
            this.Activated += new System.EventHandler(this.tunePosition_Activated);
            this.Load += new System.EventHandler(this.tunePosition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_roll_tune;
        private System.Windows.Forms.TextBox txt_yaw_tune;
        private System.Windows.Forms.TextBox txt_pitch_tune;
        private System.Windows.Forms.TextBox txt_elbow_tune;
        private System.Windows.Forms.TextBox txt_shoulder_tune;
        private System.Windows.Forms.TextBox txt_waist_tune;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_tune_ok;
        private System.Windows.Forms.Button btn_tune_cancel;
        private System.Windows.Forms.Label label7;
    }
}