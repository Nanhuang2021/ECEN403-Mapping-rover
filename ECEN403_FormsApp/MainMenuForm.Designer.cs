﻿
namespace ECEN403_FormsApp
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChildFormLauncher = new System.Windows.Forms.Button();
            this.btnErrorLogs = new System.Windows.Forms.Button();
            this.btnRoverStatus = new System.Windows.Forms.Button();
            this.btnInputCommands = new System.Windows.Forms.Button();
            this.buttonSSHConnect = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChildFormLauncher
            // 
            this.btnChildFormLauncher.Location = new System.Drawing.Point(72, 133);
            this.btnChildFormLauncher.Name = "btnChildFormLauncher";
            this.btnChildFormLauncher.Size = new System.Drawing.Size(146, 52);
            this.btnChildFormLauncher.TabIndex = 1;
            this.btnChildFormLauncher.Text = "Generated Maps";
            this.btnChildFormLauncher.UseVisualStyleBackColor = true;
            this.btnChildFormLauncher.Click += new System.EventHandler(this.BtnGenMaps_Click);
            // 
            // btnErrorLogs
            // 
            this.btnErrorLogs.Location = new System.Drawing.Point(72, 276);
            this.btnErrorLogs.Name = "btnErrorLogs";
            this.btnErrorLogs.Size = new System.Drawing.Size(146, 52);
            this.btnErrorLogs.TabIndex = 2;
            this.btnErrorLogs.Text = "Error Log";
            this.btnErrorLogs.UseVisualStyleBackColor = true;
            this.btnErrorLogs.Click += new System.EventHandler(this.BtnErrorLogs_Click);
            // 
            // btnRoverStatus
            // 
            this.btnRoverStatus.Location = new System.Drawing.Point(72, 202);
            this.btnRoverStatus.Name = "btnRoverStatus";
            this.btnRoverStatus.Size = new System.Drawing.Size(146, 52);
            this.btnRoverStatus.TabIndex = 3;
            this.btnRoverStatus.Text = "Rover Status";
            this.btnRoverStatus.UseVisualStyleBackColor = true;
            this.btnRoverStatus.Click += new System.EventHandler(this.BtnRoverStatus_Click);
            // 
            // btnInputCommands
            // 
            this.btnInputCommands.Location = new System.Drawing.Point(72, 355);
            this.btnInputCommands.Name = "btnInputCommands";
            this.btnInputCommands.Size = new System.Drawing.Size(146, 52);
            this.btnInputCommands.TabIndex = 4;
            this.btnInputCommands.Text = "Input Commands";
            this.btnInputCommands.UseVisualStyleBackColor = true;
            this.btnInputCommands.Click += new System.EventHandler(this.BtnInputCommands_Click);
            // 
            // buttonSSHConnect
            // 
            this.buttonSSHConnect.Location = new System.Drawing.Point(72, 55);
            this.buttonSSHConnect.Name = "buttonSSHConnect";
            this.buttonSSHConnect.Size = new System.Drawing.Size(146, 52);
            this.buttonSSHConnect.TabIndex = 5;
            this.buttonSSHConnect.Text = "SSH Connect";
            this.buttonSSHConnect.UseVisualStyleBackColor = true;
            this.buttonSSHConnect.Click += new System.EventHandler(this.buttonSSHConnect_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelConnectionStatus.Location = new System.Drawing.Point(12, 9);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(110, 20);
            this.labelConnectionStatus.TabIndex = 6;
            this.labelConnectionStatus.Text = "Connected to: ";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 448);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonSSHConnect);
            this.Controls.Add(this.btnInputCommands);
            this.Controls.Add(this.btnRoverStatus);
            this.Controls.Add(this.btnErrorLogs);
            this.Controls.Add(this.btnChildFormLauncher);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EndProgram);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnChildFormLauncher;
        private System.Windows.Forms.Button btnErrorLogs;
        private System.Windows.Forms.Button btnRoverStatus;
        private System.Windows.Forms.Button btnInputCommands;
        private System.Windows.Forms.Button buttonSSHConnect;
        private System.Windows.Forms.Label labelConnectionStatus;
    }
}
