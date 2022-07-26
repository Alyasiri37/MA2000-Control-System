namespace MA2000_Control_Solution
{
    partial class status
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
            this.radStatusOn = new System.Windows.Forms.RadioButton();
            this.RadStatusOff = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefreshRate = new System.Windows.Forms.TextBox();
            this.btnStatusOk = new System.Windows.Forms.Button();
            this.btnStatusApply = new System.Windows.Forms.Button();
            this.btnStatusCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radStatusOn
            // 
            this.radStatusOn.AutoSize = true;
            this.radStatusOn.Checked = true;
            this.radStatusOn.Location = new System.Drawing.Point(12, 12);
            this.radStatusOn.Name = "radStatusOn";
            this.radStatusOn.Size = new System.Drawing.Size(39, 17);
            this.radStatusOn.TabIndex = 0;
            this.radStatusOn.TabStop = true;
            this.radStatusOn.Text = "On";
            this.radStatusOn.UseVisualStyleBackColor = true;
            this.radStatusOn.CheckedChanged += new System.EventHandler(this.radStatusOn_CheckedChanged);
            // 
            // RadStatusOff
            // 
            this.RadStatusOff.AutoSize = true;
            this.RadStatusOff.Location = new System.Drawing.Point(12, 35);
            this.RadStatusOff.Name = "RadStatusOff";
            this.RadStatusOff.Size = new System.Drawing.Size(41, 17);
            this.RadStatusOff.TabIndex = 1;
            this.RadStatusOff.Text = "Off";
            this.RadStatusOff.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Refresh Rate  ( ms) :";
            // 
            // txtRefreshRate
            // 
            this.txtRefreshRate.Location = new System.Drawing.Point(177, 11);
            this.txtRefreshRate.Name = "txtRefreshRate";
            this.txtRefreshRate.Size = new System.Drawing.Size(100, 20);
            this.txtRefreshRate.TabIndex = 3;
            // 
            // btnStatusOk
            // 
            this.btnStatusOk.Location = new System.Drawing.Point(12, 64);
            this.btnStatusOk.Name = "btnStatusOk";
            this.btnStatusOk.Size = new System.Drawing.Size(88, 28);
            this.btnStatusOk.TabIndex = 4;
            this.btnStatusOk.Text = "OK";
            this.btnStatusOk.UseVisualStyleBackColor = true;
            this.btnStatusOk.Click += new System.EventHandler(this.btnStatusOk_Click);
            // 
            // btnStatusApply
            // 
            this.btnStatusApply.Location = new System.Drawing.Point(106, 64);
            this.btnStatusApply.Name = "btnStatusApply";
            this.btnStatusApply.Size = new System.Drawing.Size(88, 28);
            this.btnStatusApply.TabIndex = 5;
            this.btnStatusApply.Text = "Apply";
            this.btnStatusApply.UseVisualStyleBackColor = true;
            this.btnStatusApply.Click += new System.EventHandler(this.btnStatusApply_Click);
            // 
            // btnStatusCancel
            // 
            this.btnStatusCancel.Location = new System.Drawing.Point(200, 64);
            this.btnStatusCancel.Name = "btnStatusCancel";
            this.btnStatusCancel.Size = new System.Drawing.Size(88, 28);
            this.btnStatusCancel.TabIndex = 6;
            this.btnStatusCancel.Text = "Cancel";
            this.btnStatusCancel.UseVisualStyleBackColor = true;
            this.btnStatusCancel.Click += new System.EventHandler(this.btnStatusCancel_Click);
            // 
            // status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 104);
            this.ControlBox = false;
            this.Controls.Add(this.btnStatusCancel);
            this.Controls.Add(this.btnStatusApply);
            this.Controls.Add(this.btnStatusOk);
            this.Controls.Add(this.txtRefreshRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RadStatusOff);
            this.Controls.Add(this.radStatusOn);
            this.Name = "status";
            this.Text = "status";
            this.Activated += new System.EventHandler(this.status_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radStatusOn;
        private System.Windows.Forms.RadioButton RadStatusOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefreshRate;
        private System.Windows.Forms.Button btnStatusOk;
        private System.Windows.Forms.Button btnStatusApply;
        private System.Windows.Forms.Button btnStatusCancel;
    }
}