namespace Stock.Estimation.GUI
{
    partial class SettingsFrm
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
            this.txtStockDataPath = new System.Windows.Forms.TextBox();
            this.btnBrowseStockData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Data Path:";
            // 
            // txtStockDataPath
            // 
            this.txtStockDataPath.Location = new System.Drawing.Point(108, 10);
            this.txtStockDataPath.Name = "txtStockDataPath";
            this.txtStockDataPath.Size = new System.Drawing.Size(144, 20);
            this.txtStockDataPath.TabIndex = 1;
            // 
            // btnBrowseStockData
            // 
            this.btnBrowseStockData.Location = new System.Drawing.Point(258, 9);
            this.btnBrowseStockData.Name = "btnBrowseStockData";
            this.btnBrowseStockData.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseStockData.TabIndex = 2;
            this.btnBrowseStockData.Text = "Browse...";
            this.btnBrowseStockData.UseVisualStyleBackColor = true;
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 273);
            this.Controls.Add(this.btnBrowseStockData);
            this.Controls.Add(this.txtStockDataPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFrm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockDataPath;
        private System.Windows.Forms.Button btnBrowseStockData;
    }
}