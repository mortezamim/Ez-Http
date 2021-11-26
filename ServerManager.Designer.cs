namespace HttpServer
{
    partial class ServerManager
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.tbServerPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastReqPath = new System.Windows.Forms.Label();
            this.lblLastResponse = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(12, 12);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(277, 60);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // tbServerPath
            // 
            this.tbServerPath.Location = new System.Drawing.Point(416, 31);
            this.tbServerPath.Name = "tbServerPath";
            this.tbServerPath.Size = new System.Drawing.Size(253, 22);
            this.tbServerPath.TabIndex = 1;
            this.tbServerPath.Text = "http://localhost:8083";
            this.tbServerPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "AT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Request:";
            // 
            // lblLastReqPath
            // 
            this.lblLastReqPath.AutoSize = true;
            this.lblLastReqPath.Location = new System.Drawing.Point(107, 90);
            this.lblLastReqPath.Name = "lblLastReqPath";
            this.lblLastReqPath.Size = new System.Drawing.Size(50, 16);
            this.lblLastReqPath.TabIndex = 4;
            this.lblLastReqPath.Text = "Offline !";
            // 
            // lblLastResponse
            // 
            this.lblLastResponse.AutoSize = true;
            this.lblLastResponse.Location = new System.Drawing.Point(107, 124);
            this.lblLastResponse.Name = "lblLastResponse";
            this.lblLastResponse.Size = new System.Drawing.Size(50, 16);
            this.lblLastResponse.TabIndex = 6;
            this.lblLastResponse.Text = "Offline !";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last Request:";
            // 
            // ServerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 166);
            this.Controls.Add(this.lblLastResponse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLastReqPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbServerPath);
            this.Controls.Add(this.btnStartServer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox tbServerPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastReqPath;
        private System.Windows.Forms.Label lblLastResponse;
        private System.Windows.Forms.Label label4;
    }
}

