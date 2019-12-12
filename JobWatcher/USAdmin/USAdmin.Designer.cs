namespace USAdmin
{
    partial class USAdmin
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
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.btnGetServiceStatus = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(12, 428);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(76, 13);
            this.lblServiceStatus.TabIndex = 0;
            this.lblServiceStatus.Text = "Service Status";
            // 
            // btnGetServiceStatus
            // 
            this.btnGetServiceStatus.Location = new System.Drawing.Point(618, 377);
            this.btnGetServiceStatus.Name = "btnGetServiceStatus";
            this.btnGetServiceStatus.Size = new System.Drawing.Size(135, 61);
            this.btnGetServiceStatus.TabIndex = 1;
            this.btnGetServiceStatus.Text = "Get Service Status";
            this.btnGetServiceStatus.UseVisualStyleBackColor = true;
            this.btnGetServiceStatus.Click += new System.EventHandler(this.btnGetServiceStatus_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(618, 213);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(135, 61);
            this.btnStartService.TabIndex = 2;
            this.btnStartService.Text = "Start Service ";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(618, 292);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(135, 61);
            this.btnStopService.TabIndex = 3;
            this.btnStopService.Text = "Stop Service ";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // USAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.btnGetServiceStatus);
            this.Controls.Add(this.lblServiceStatus);
            this.Name = "USAdmin";
            this.Text = "Job Watcher Admin";
            this.Load += new System.EventHandler(this.USAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Button btnGetServiceStatus;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
    }
}

