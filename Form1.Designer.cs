namespace Anomaly_Finder_CSV
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtZThreshold = new System.Windows.Forms.TextBox();
            this.lblZThreshold = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.txtNZT = new System.Windows.Forms.TextBox();
            this.lblNZT = new System.Windows.Forms.Label();
            this.txtIgnore = new System.Windows.Forms.TextBox();
            this.lblIgnore = new System.Windows.Forms.Label();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtZThreshold
            // 
            this.txtZThreshold.Location = new System.Drawing.Point(188, 27);
            this.txtZThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZThreshold.Name = "txtZThreshold";
            this.txtZThreshold.Size = new System.Drawing.Size(132, 22);
            this.txtZThreshold.TabIndex = 0;
            this.txtZThreshold.Text = "5.0";
            // 
            // lblZThreshold
            // 
            this.lblZThreshold.AutoSize = true;
            this.lblZThreshold.Location = new System.Drawing.Point(53, 31);
            this.lblZThreshold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZThreshold.Name = "lblZThreshold";
            this.lblZThreshold.Size = new System.Drawing.Size(126, 17);
            this.lblZThreshold.TabIndex = 1;
            this.lblZThreshold.Text = "Z Score Threshold";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(97, 237);
            this.btnAnalyze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(200, 57);
            this.btnAnalyze.TabIndex = 2;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // txtNZT
            // 
            this.txtNZT.Location = new System.Drawing.Point(188, 76);
            this.txtNZT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNZT.Name = "txtNZT";
            this.txtNZT.Size = new System.Drawing.Size(132, 22);
            this.txtNZT.TabIndex = 3;
            // 
            // lblNZT
            // 
            this.lblNZT.AutoSize = true;
            this.lblNZT.Location = new System.Drawing.Point(40, 80);
            this.lblNZT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNZT.Name = "lblNZT";
            this.lblNZT.Size = new System.Drawing.Size(140, 17);
            this.lblNZT.TabIndex = 4;
            this.lblNZT.Text = "Binary Data Columns";
            // 
            // txtIgnore
            // 
            this.txtIgnore.Location = new System.Drawing.Point(188, 126);
            this.txtIgnore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIgnore.Name = "txtIgnore";
            this.txtIgnore.Size = new System.Drawing.Size(132, 22);
            this.txtIgnore.TabIndex = 5;
            // 
            // lblIgnore
            // 
            this.lblIgnore.AutoSize = true;
            this.lblIgnore.Location = new System.Drawing.Point(65, 129);
            this.lblIgnore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIgnore.Name = "lblIgnore";
            this.lblIgnore.Size = new System.Drawing.Size(114, 17);
            this.lblIgnore.TabIndex = 6;
            this.lblIgnore.Text = "Ignored Columns";
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.Location = new System.Drawing.Point(188, 175);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.Size = new System.Drawing.Size(57, 22);
            this.txtTimestamp.TabIndex = 7;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.AutoSize = true;
            this.lblTimestamp.Location = new System.Drawing.Point(45, 178);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(134, 17);
            this.lblTimestamp.TabIndex = 8;
            this.lblTimestamp.Text = "Time Stamp Column";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 307);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.txtTimestamp);
            this.Controls.Add(this.lblIgnore);
            this.Controls.Add(this.txtIgnore);
            this.Controls.Add(this.lblNZT);
            this.Controls.Add(this.txtNZT);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblZThreshold);
            this.Controls.Add(this.txtZThreshold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Anomaly Finder CSV v1.20";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtZThreshold;
        private System.Windows.Forms.Label lblZThreshold;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.TextBox txtNZT;
        private System.Windows.Forms.Label lblNZT;
        private System.Windows.Forms.TextBox txtIgnore;
        private System.Windows.Forms.Label lblIgnore;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.Label lblTimestamp;
    }
}

