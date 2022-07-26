namespace MA2000_Control_Solution
{
    partial class Sequencer
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
            this.tmrPosition = new System.Windows.Forms.Timer(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbPath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.grbConfig = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.trkWst = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblCurrentPoint = new System.Windows.Forms.Label();
            this.cmbSavePath = new System.Windows.Forms.ComboBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblPtch = new System.Windows.Forms.Label();
            this.lblElb = new System.Windows.Forms.Label();
            this.lblShld = new System.Windows.Forms.Label();
            this.lblWst = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trkRol = new System.Windows.Forms.TrackBar();
            this.trkYaw = new System.Windows.Forms.TrackBar();
            this.trkPtch = new System.Windows.Forms.TrackBar();
            this.trkElb = new System.Windows.Forms.TrackBar();
            this.trkShld = new System.Windows.Forms.TrackBar();
            this.grbConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkWst)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPtch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkElb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkShld)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrPosition
            // 
            this.tmrPosition.Interval = 3;
            this.tmrPosition.Tick += new System.EventHandler(this.tmrPosition_Tick);
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(173, 50);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(531, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbPath
            // 
            this.cmbPath.Enabled = false;
            this.cmbPath.FormattingEnabled = true;
            this.cmbPath.Items.AddRange(new object[] {
            "Square",
            "Circle",
            "Sine"});
            this.cmbPath.Location = new System.Drawing.Point(21, 19);
            this.cmbPath.Name = "cmbPath";
            this.cmbPath.Size = new System.Drawing.Size(132, 21);
            this.cmbPath.TabIndex = 2;
            this.cmbPath.Text = "Select a path ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time Step (MilliSec) :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtInterval
            // 
            this.txtInterval.Enabled = false;
            this.txtInterval.Location = new System.Drawing.Point(106, 53);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(47, 20);
            this.txtInterval.TabIndex = 4;
            this.txtInterval.Text = "500";
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInterval.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // grbConfig
            // 
            this.grbConfig.Controls.Add(this.btnBrowse);
            this.grbConfig.Controls.Add(this.txtInterval);
            this.grbConfig.Controls.Add(this.lblStatus);
            this.grbConfig.Controls.Add(this.label1);
            this.grbConfig.Controls.Add(this.cmbPath);
            this.grbConfig.Controls.Add(this.btnOk);
            this.grbConfig.Location = new System.Drawing.Point(13, 10);
            this.grbConfig.Name = "grbConfig";
            this.grbConfig.Size = new System.Drawing.Size(631, 89);
            this.grbConfig.TabIndex = 5;
            this.grbConfig.TabStop = false;
            this.grbConfig.Text = "Configuration";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(173, 16);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(94, 24);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Load";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(314, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(285, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkWst
            // 
            this.trkWst.Location = new System.Drawing.Point(82, 35);
            this.trkWst.Maximum = 450;
            this.trkWst.Minimum = 50;
            this.trkWst.Name = "trkWst";
            this.trkWst.Size = new System.Drawing.Size(447, 45);
            this.trkWst.TabIndex = 7;
            this.trkWst.Value = 50;
            this.trkWst.Scroll += new System.EventHandler(this.trkWst_Scroll);
            this.trkWst.ValueChanged += new System.EventHandler(this.trkWst_ValueChanged);
            this.trkWst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkWst_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDone);
            this.groupBox1.Controls.Add(this.lblCurrentPoint);
            this.groupBox1.Controls.Add(this.cmbSavePath);
            this.groupBox1.Controls.Add(this.btnPrev);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lblRol);
            this.groupBox1.Controls.Add(this.lblYaw);
            this.groupBox1.Controls.Add(this.lblPtch);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblElb);
            this.groupBox1.Controls.Add(this.lblShld);
            this.groupBox1.Controls.Add(this.lblWst);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.trkRol);
            this.groupBox1.Controls.Add(this.trkYaw);
            this.groupBox1.Controls.Add(this.trkPtch);
            this.groupBox1.Controls.Add(this.trkElb);
            this.groupBox1.Controls.Add(this.trkShld);
            this.groupBox1.Controls.Add(this.trkWst);
            this.groupBox1.Location = new System.Drawing.Point(13, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 376);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnDone
            // 
            this.btnDone.Enabled = false;
            this.btnDone.Location = new System.Drawing.Point(231, 331);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(94, 24);
            this.btnDone.TabIndex = 41;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblCurrentPoint
            // 
            this.lblCurrentPoint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCurrentPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentPoint.Location = new System.Drawing.Point(148, 333);
            this.lblCurrentPoint.Name = "lblCurrentPoint";
            this.lblCurrentPoint.Size = new System.Drawing.Size(72, 21);
            this.lblCurrentPoint.TabIndex = 40;
            this.lblCurrentPoint.Text = ";-)";
            this.lblCurrentPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentPoint.Click += new System.EventHandler(this.label8_Click);
            // 
            // cmbSavePath
            // 
            this.cmbSavePath.FormattingEnabled = true;
            this.cmbSavePath.Items.AddRange(new object[] {
            "Square",
            "Circle",
            "Sine"});
            this.cmbSavePath.Location = new System.Drawing.Point(21, 334);
            this.cmbSavePath.Name = "cmbSavePath";
            this.cmbSavePath.Size = new System.Drawing.Size(121, 21);
            this.cmbSavePath.TabIndex = 39;
            this.cmbSavePath.Text = "Select a path";
            this.cmbSavePath.SelectedValueChanged += new System.EventHandler(this.cmbSavePath_SelectedValueChanged);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(331, 331);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(94, 24);
            this.btnPrev.TabIndex = 38;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(431, 331);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 24);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save Point";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRol
            // 
            this.lblRol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRol.Location = new System.Drawing.Point(537, 280);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(72, 23);
            this.lblRol.TabIndex = 36;
            this.lblRol.Text = ";-)";
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYaw
            // 
            this.lblYaw.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblYaw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYaw.Location = new System.Drawing.Point(537, 231);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(72, 23);
            this.lblYaw.TabIndex = 35;
            this.lblYaw.Text = ";-)";
            this.lblYaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPtch
            // 
            this.lblPtch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPtch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPtch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPtch.Location = new System.Drawing.Point(537, 182);
            this.lblPtch.Name = "lblPtch";
            this.lblPtch.Size = new System.Drawing.Size(72, 23);
            this.lblPtch.TabIndex = 34;
            this.lblPtch.Text = ";-)";
            this.lblPtch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblElb
            // 
            this.lblElb.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblElb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblElb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblElb.Location = new System.Drawing.Point(537, 133);
            this.lblElb.Name = "lblElb";
            this.lblElb.Size = new System.Drawing.Size(72, 23);
            this.lblElb.TabIndex = 33;
            this.lblElb.Text = ";-)";
            this.lblElb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShld
            // 
            this.lblShld.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblShld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShld.Location = new System.Drawing.Point(537, 84);
            this.lblShld.Name = "lblShld";
            this.lblShld.Size = new System.Drawing.Size(72, 23);
            this.lblShld.TabIndex = 32;
            this.lblShld.Text = ";-)";
            this.lblShld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWst
            // 
            this.lblWst.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWst.Location = new System.Drawing.Point(537, 35);
            this.lblWst.Name = "lblWst";
            this.lblWst.Size = new System.Drawing.Size(72, 23);
            this.lblWst.TabIndex = 31;
            this.lblWst.Text = ";-)";
            this.lblWst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Roll :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Yaw :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Pitch :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Elbow :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Shoulder :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Waist :";
            // 
            // trkRol
            // 
            this.trkRol.Location = new System.Drawing.Point(82, 280);
            this.trkRol.Maximum = 450;
            this.trkRol.Minimum = 50;
            this.trkRol.Name = "trkRol";
            this.trkRol.Size = new System.Drawing.Size(447, 45);
            this.trkRol.TabIndex = 12;
            this.trkRol.Value = 50;
            this.trkRol.ValueChanged += new System.EventHandler(this.trkRol_ValueChanged);
            this.trkRol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkRol_KeyDown);
            // 
            // trkYaw
            // 
            this.trkYaw.Location = new System.Drawing.Point(82, 231);
            this.trkYaw.Maximum = 450;
            this.trkYaw.Minimum = 50;
            this.trkYaw.Name = "trkYaw";
            this.trkYaw.Size = new System.Drawing.Size(447, 45);
            this.trkYaw.TabIndex = 11;
            this.trkYaw.Value = 50;
            this.trkYaw.ValueChanged += new System.EventHandler(this.trkYaw_ValueChanged);
            this.trkYaw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkYaw_KeyDown);
            // 
            // trkPtch
            // 
            this.trkPtch.Location = new System.Drawing.Point(82, 182);
            this.trkPtch.Maximum = 450;
            this.trkPtch.Minimum = 50;
            this.trkPtch.Name = "trkPtch";
            this.trkPtch.Size = new System.Drawing.Size(447, 45);
            this.trkPtch.TabIndex = 10;
            this.trkPtch.Value = 50;
            this.trkPtch.ValueChanged += new System.EventHandler(this.trkPtch_ValueChanged);
            this.trkPtch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkPtch_KeyDown);
            // 
            // trkElb
            // 
            this.trkElb.Location = new System.Drawing.Point(82, 133);
            this.trkElb.Maximum = 450;
            this.trkElb.Minimum = 50;
            this.trkElb.Name = "trkElb";
            this.trkElb.Size = new System.Drawing.Size(447, 45);
            this.trkElb.TabIndex = 9;
            this.trkElb.Value = 50;
            this.trkElb.ValueChanged += new System.EventHandler(this.trkElb_ValueChanged);
            this.trkElb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkElb_KeyDown);
            // 
            // trkShld
            // 
            this.trkShld.Location = new System.Drawing.Point(82, 84);
            this.trkShld.Maximum = 450;
            this.trkShld.Minimum = 50;
            this.trkShld.Name = "trkShld";
            this.trkShld.Size = new System.Drawing.Size(447, 45);
            this.trkShld.TabIndex = 8;
            this.trkShld.Value = 50;
            this.trkShld.ValueChanged += new System.EventHandler(this.trkShld_ValueChanged);
            this.trkShld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trkShld_KeyDown);
            // 
            // Sequencer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 498);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbConfig);
            this.Name = "Sequencer";
            this.Text = "Sequencer";
            this.Activated += new System.EventHandler(this.Sequencer_Activated);
            this.Load += new System.EventHandler(this.Sequencer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sequencer_KeyDown);
            this.grbConfig.ResumeLayout(false);
            this.grbConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkWst)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPtch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkElb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkShld)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrPosition;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.GroupBox grbConfig;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TrackBar trkWst;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblPtch;
        private System.Windows.Forms.Label lblElb;
        private System.Windows.Forms.Label lblShld;
        private System.Windows.Forms.Label lblWst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trkRol;
        private System.Windows.Forms.TrackBar trkYaw;
        private System.Windows.Forms.TrackBar trkPtch;
        private System.Windows.Forms.TrackBar trkElb;
        private System.Windows.Forms.TrackBar trkShld;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbSavePath;
        private System.Windows.Forms.Label lblCurrentPoint;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnBrowse;
    }
}