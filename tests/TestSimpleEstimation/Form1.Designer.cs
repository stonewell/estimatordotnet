namespace TestSimpleEstimation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartEstimator = new System.Windows.Forms.Button();
            this.btnCreateRules = new System.Windows.Forms.Button();
            this.txtRulesCount = new System.Windows.Forms.TextBox();
            this.txtEventsCount = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEventsCount);
            this.panel1.Controls.Add(this.txtRulesCount);
            this.panel1.Controls.Add(this.btnCreateRules);
            this.panel1.Controls.Add(this.btnStartEstimator);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 69);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 432);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of SimpleRule:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Events:";
            // 
            // btnStartEstimator
            // 
            this.btnStartEstimator.Location = new System.Drawing.Point(503, 36);
            this.btnStartEstimator.Name = "btnStartEstimator";
            this.btnStartEstimator.Size = new System.Drawing.Size(89, 23);
            this.btnStartEstimator.TabIndex = 5;
            this.btnStartEstimator.Text = "Start Estimator";
            this.btnStartEstimator.UseVisualStyleBackColor = true;
            this.btnStartEstimator.Click += new System.EventHandler(this.btnStartEstimator_Click);
            // 
            // btnCreateRules
            // 
            this.btnCreateRules.Location = new System.Drawing.Point(503, 8);
            this.btnCreateRules.Name = "btnCreateRules";
            this.btnCreateRules.Size = new System.Drawing.Size(89, 23);
            this.btnCreateRules.TabIndex = 2;
            this.btnCreateRules.Text = "Create Rules";
            this.btnCreateRules.UseVisualStyleBackColor = true;
            this.btnCreateRules.Click += new System.EventHandler(this.btnCreateRules_Click);
            // 
            // txtRulesCount
            // 
            this.txtRulesCount.Location = new System.Drawing.Point(134, 10);
            this.txtRulesCount.Name = "txtRulesCount";
            this.txtRulesCount.Size = new System.Drawing.Size(363, 20);
            this.txtRulesCount.TabIndex = 1;
            // 
            // txtEventsCount
            // 
            this.txtEventsCount.Location = new System.Drawing.Point(134, 36);
            this.txtEventsCount.Name = "txtEventsCount";
            this.txtEventsCount.Size = new System.Drawing.Size(363, 20);
            this.txtEventsCount.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 501);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEventsCount;
        private System.Windows.Forms.TextBox txtRulesCount;
        private System.Windows.Forms.Button btnCreateRules;
        private System.Windows.Forms.Button btnStartEstimator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}

