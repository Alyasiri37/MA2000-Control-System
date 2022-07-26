namespace MA2000_Control_Solution
{
    partial class tuneProgress
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
            this.components = new System.ComponentModel.Container();
            this.prgTune = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIteration = new System.Windows.Forms.Label();
            this.lblParticle = new System.Windows.Forms.Label();
            this.lblJoint = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRequired = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblEapsed = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblIterations = new System.Windows.Forms.Label();
            this.lblSwarm = new System.Windows.Forms.Label();
            this.lblJoints = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tmrTunePrg = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgTune
            // 
            this.prgTune.Location = new System.Drawing.Point(12, 98);
            this.prgTune.Name = "prgTune";
            this.prgTune.Size = new System.Drawing.Size(530, 23);
            this.prgTune.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elapsed Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estimated Remaining Time :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Current Particle  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Current Iteration :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Current Joint :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIteration);
            this.groupBox1.Controls.Add(this.lblParticle);
            this.groupBox1.Controls.Add(this.lblJoint);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(213, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Cycle";
            // 
            // lblIteration
            // 
            this.lblIteration.BackColor = System.Drawing.Color.White;
            this.lblIteration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIteration.Location = new System.Drawing.Point(113, 59);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(60, 16);
            this.lblIteration.TabIndex = 9;
            this.lblIteration.Text = "label11";
            this.lblIteration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblParticle
            // 
            this.lblParticle.BackColor = System.Drawing.Color.White;
            this.lblParticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblParticle.Location = new System.Drawing.Point(113, 38);
            this.lblParticle.Name = "lblParticle";
            this.lblParticle.Size = new System.Drawing.Size(60, 16);
            this.lblParticle.TabIndex = 8;
            this.lblParticle.Text = "label10";
            this.lblParticle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJoint
            // 
            this.lblJoint.BackColor = System.Drawing.Color.White;
            this.lblJoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJoint.Location = new System.Drawing.Point(113, 15);
            this.lblJoint.Name = "lblJoint";
            this.lblJoint.Size = new System.Drawing.Size(60, 16);
            this.lblJoint.TabIndex = 7;
            this.lblJoint.Text = "label9";
            this.lblJoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Joints to Tune :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRequired);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblRemaining);
            this.groupBox2.Controls.Add(this.lblEapsed);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(414, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timing Info";
            // 
            // lblRequired
            // 
            this.lblRequired.BackColor = System.Drawing.Color.White;
            this.lblRequired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRequired.Location = new System.Drawing.Point(150, 14);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(80, 16);
            this.lblRequired.TabIndex = 16;
            this.lblRequired.Text = "label15";
            this.lblRequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Required Time :";
            // 
            // lblRemaining
            // 
            this.lblRemaining.BackColor = System.Drawing.Color.White;
            this.lblRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemaining.Location = new System.Drawing.Point(150, 60);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(80, 16);
            this.lblRemaining.TabIndex = 14;
            this.lblRemaining.Text = "label16";
            this.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEapsed
            // 
            this.lblEapsed.BackColor = System.Drawing.Color.White;
            this.lblEapsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEapsed.Location = new System.Drawing.Point(150, 36);
            this.lblEapsed.Name = "lblEapsed";
            this.lblEapsed.Size = new System.Drawing.Size(80, 16);
            this.lblEapsed.TabIndex = 13;
            this.lblEapsed.Text = "label15";
            this.lblEapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblIterations);
            this.groupBox3.Controls.Add(this.lblSwarm);
            this.groupBox3.Controls.Add(this.lblJoints);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 80);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tune Info";
            // 
            // lblIterations
            // 
            this.lblIterations.BackColor = System.Drawing.Color.White;
            this.lblIterations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIterations.Location = new System.Drawing.Point(113, 59);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(60, 16);
            this.lblIterations.TabIndex = 12;
            this.lblIterations.Text = "label14";
            this.lblIterations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSwarm
            // 
            this.lblSwarm.BackColor = System.Drawing.Color.White;
            this.lblSwarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSwarm.Location = new System.Drawing.Point(113, 38);
            this.lblSwarm.Name = "lblSwarm";
            this.lblSwarm.Size = new System.Drawing.Size(60, 16);
            this.lblSwarm.TabIndex = 11;
            this.lblSwarm.Text = "label13";
            this.lblSwarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJoints
            // 
            this.lblJoints.BackColor = System.Drawing.Color.White;
            this.lblJoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJoints.Location = new System.Drawing.Point(113, 16);
            this.lblJoints.Name = "lblJoints";
            this.lblJoints.Size = new System.Drawing.Size(60, 16);
            this.lblJoints.TabIndex = 10;
            this.lblJoints.Text = "label12";
            this.lblJoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "No. of Iterations :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Swarm Size :";
            // 
            // tmrTunePrg
            // 
            this.tmrTunePrg.Interval = 1000;
            this.tmrTunePrg.Tick += new System.EventHandler(this.tmrTunePrg_Tick);
            // 
            // tuneProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 134);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prgTune);
            this.Name = "tuneProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "tuneProgress";
            this.Activated += new System.EventHandler(this.tuneProgress_Activated);
            this.Load += new System.EventHandler(this.tuneProgress_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgTune;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer tmrTunePrg;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.Label lblParticle;
        private System.Windows.Forms.Label lblJoint;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblEapsed;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.Label lblSwarm;
        private System.Windows.Forms.Label lblJoints;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label label10;
    }
}