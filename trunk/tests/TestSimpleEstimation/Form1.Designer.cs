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
            this.txtEventsCount = new System.Windows.Forms.TextBox();
            this.txtRulesCount = new System.Windows.Forms.TextBox();
            this.btnCreateRules = new System.Windows.Forms.Button();
            this.btnStartEstimator = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentEventValue = new System.Windows.Forms.TextBox();
            this.txtCurrentUpDown = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCurrentUpDown);
            this.panel1.Controls.Add(this.txtCurrentEventValue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEventsCount);
            this.panel1.Controls.Add(this.txtRulesCount);
            this.panel1.Controls.Add(this.btnCreateRules);
            this.panel1.Controls.Add(this.btnStartEstimator);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 98);
            this.panel1.TabIndex = 0;
            // 
            // txtEventsCount
            // 
            this.txtEventsCount.Location = new System.Drawing.Point(134, 36);
            this.txtEventsCount.Name = "txtEventsCount";
            this.txtEventsCount.Size = new System.Drawing.Size(363, 20);
            this.txtEventsCount.TabIndex = 4;
            // 
            // txtRulesCount
            // 
            this.txtRulesCount.Location = new System.Drawing.Point(134, 10);
            this.txtRulesCount.Name = "txtRulesCount";
            this.txtRulesCount.Size = new System.Drawing.Size(363, 20);
            this.txtRulesCount.TabIndex = 1;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Events:";
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
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 403);
            this.panel2.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Event:";
            // 
            // txtCurrentEventValue
            // 
            this.txtCurrentEventValue.Location = new System.Drawing.Point(134, 62);
            this.txtCurrentEventValue.Name = "txtCurrentEventValue";
            this.txtCurrentEventValue.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentEventValue.TabIndex = 7;
            // 
            // txtCurrentUpDown
            // 
            this.txtCurrentUpDown.Location = new System.Drawing.Point(313, 62);
            this.txtCurrentUpDown.Name = "txtCurrentUpDown";
            this.txtCurrentUpDown.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentUpDown.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Up/Down:";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentUpDown;
        private System.Windows.Forms.TextBox txtCurrentEventValue;
        private System.Windows.Forms.Label label3;

    }
}

