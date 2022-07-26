namespace MA2000_Control_Solution
{
    partial class Logger
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
            this.txtLogDir = new System.Windows.Forms.TextBox();
            this.btnLogOk = new System.Windows.Forms.Button();
            this.btnLogBrowse = new System.Windows.Forms.Button();
            this.btnLogCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log Directory : ";
            // 
            // txtLogDir
            // 
            this.txtLogDir.Location = new System.Drawing.Point(108, 17);
            this.txtLogDir.Name = "txtLogDir";
            this.txtLogDir.Size = new System.Drawing.Size(198, 20);
            this.txtLogDir.TabIndex = 1;
            // 
            // btnLogOk
            // 
            this.btnLogOk.Location = new System.Drawing.Point(213, 55);
            this.btnLogOk.Name = "btnLogOk";
            this.btnLogOk.Size = new System.Drawing.Size(93, 23);
            this.btnLogOk.TabIndex = 2;
            this.btnLogOk.Text = "OK";
            this.btnLogOk.UseVisualStyleBackColor = true;
            this.btnLogOk.Click += new System.EventHandler(this.btnLogOk_Click);
            // 
            // btnLogBrowse
            // 
            this.btnLogBrowse.Location = new System.Drawing.Point(312, 15);
            this.btnLogBrowse.Name = "btnLogBrowse";
            this.btnLogBrowse.Size = new System.Drawing.Size(93, 23);
            this.btnLogBrowse.TabIndex = 3;
            this.btnLogBrowse.Text = "Browse";
            this.btnLogBrowse.UseVisualStyleBackColor = true;
            this.btnLogBrowse.Click += new System.EventHandler(this.btnLogBrowse_Click);
            // 
            // btnLogCancel
            // 
            this.btnLogCancel.Location = new System.Drawing.Point(312, 55);
            this.btnLogCancel.Name = "btnLogCancel";
            this.btnLogCancel.Size = new System.Drawing.Size(93, 23);
            this.btnLogCancel.TabIndex = 4;
            this.btnLogCancel.Text = "Cancel";
            this.btnLogCancel.UseVisualStyleBackColor = true;
            this.btnLogCancel.Click += new System.EventHandler(this.btnLogCancel_Click);
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 81);
            this.Controls.Add(this.btnLogCancel);
            this.Controls.Add(this.btnLogBrowse);
            this.Controls.Add(this.btnLogOk);
            this.Controls.Add(this.txtLogDir);
            this.Controls.Add(this.label1);
            this.Name = "Logger";
            this.Text = "Logger Configuration";
            this.Activated += new System.EventHandler(this.Logger_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogDir;
        private System.Windows.Forms.Button btnLogOk;
        private System.Windows.Forms.Button btnLogBrowse;
        private System.Windows.Forms.Button btnLogCancel;
    }
}