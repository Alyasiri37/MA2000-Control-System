namespace MA2000_Control_Solution
{
    partial class response
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
            this.txtMaxOvershoot = new System.Windows.Forms.TextBox();
            this.txtRiseTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_response_ok = new System.Windows.Forms.Button();
            this.btn_response_cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMaxOvershoot
            // 
            this.txtMaxOvershoot.Location = new System.Drawing.Point(130, 6);
            this.txtMaxOvershoot.Name = "txtMaxOvershoot";
            this.txtMaxOvershoot.Size = new System.Drawing.Size(77, 20);
            this.txtMaxOvershoot.TabIndex = 0;
            // 
            // txtRiseTime
            // 
            this.txtRiseTime.Location = new System.Drawing.Point(130, 32);
            this.txtRiseTime.Name = "txtRiseTime";
            this.txtRiseTime.Size = new System.Drawing.Size(77, 20);
            this.txtRiseTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum Overshoot :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rise Time :";
            // 
            // btn_response_ok
            // 
            this.btn_response_ok.Location = new System.Drawing.Point(12, 58);
            this.btn_response_ok.Name = "btn_response_ok";
            this.btn_response_ok.Size = new System.Drawing.Size(97, 23);
            this.btn_response_ok.TabIndex = 4;
            this.btn_response_ok.Text = "OK";
            this.btn_response_ok.UseVisualStyleBackColor = true;
            this.btn_response_ok.Click += new System.EventHandler(this.btn_response_ok_Click);
            // 
            // btn_response_cancel
            // 
            this.btn_response_cancel.Location = new System.Drawing.Point(134, 58);
            this.btn_response_cancel.Name = "btn_response_cancel";
            this.btn_response_cancel.Size = new System.Drawing.Size(97, 23);
            this.btn_response_cancel.TabIndex = 5;
            this.btn_response_cancel.Text = "Cancel";
            this.btn_response_cancel.UseVisualStyleBackColor = true;
            this.btn_response_cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sec";
            // 
            // response
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 93);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_response_cancel);
            this.Controls.Add(this.btn_response_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRiseTime);
            this.Controls.Add(this.txtMaxOvershoot);
            this.Name = "response";
            this.Text = "Required PID Response ";
            this.Activated += new System.EventHandler(this.response_Activate);
            this.Load += new System.EventHandler(this.response_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaxOvershoot;
        private System.Windows.Forms.TextBox txtRiseTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_response_ok;
        private System.Windows.Forms.Button btn_response_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}