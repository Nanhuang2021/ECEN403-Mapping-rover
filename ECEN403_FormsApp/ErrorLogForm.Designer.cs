
namespace ECEN403_FormsApp
{
    partial class ErrorLogForm
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
            this.btnTestLogs = new System.Windows.Forms.Button();
            this.txtMessageBox = new System.Windows.Forms.TextBox();
            this.btnCheckErrors = new System.Windows.Forms.Button();
            this.ErrorMessageLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestLogs
            // 
            this.btnTestLogs.Location = new System.Drawing.Point(50, 367);
            this.btnTestLogs.Name = "btnTestLogs";
            this.btnTestLogs.Size = new System.Drawing.Size(96, 29);
            this.btnTestLogs.TabIndex = 0;
            this.btnTestLogs.Text = "Test Logs";
            this.btnTestLogs.UseVisualStyleBackColor = true;
            this.btnTestLogs.Click += new System.EventHandler(this.BtnTestLogs_Click);
            // 
            // txtMessageBox
            // 
            this.txtMessageBox.Location = new System.Drawing.Point(50, 26);
            this.txtMessageBox.Multiline = true;
            this.txtMessageBox.Name = "txtMessageBox";
            this.txtMessageBox.Size = new System.Drawing.Size(385, 335);
            this.txtMessageBox.TabIndex = 2;
            this.txtMessageBox.TextChanged += new System.EventHandler(this.TxtMessageBox_TextChanged);
            // 
            // btnCheckErrors
            // 
            this.btnCheckErrors.Location = new System.Drawing.Point(152, 367);
            this.btnCheckErrors.Name = "btnCheckErrors";
            this.btnCheckErrors.Size = new System.Drawing.Size(106, 29);
            this.btnCheckErrors.TabIndex = 3;
            this.btnCheckErrors.Text = "Check Errors";
            this.btnCheckErrors.UseVisualStyleBackColor = true;
            this.btnCheckErrors.Click += new System.EventHandler(this.BtnCheckErrors_Click);
            // 
            // ErrorMessageLbl
            // 
            this.ErrorMessageLbl.AutoSize = true;
            this.ErrorMessageLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ErrorMessageLbl.Location = new System.Drawing.Point(50, 3);
            this.ErrorMessageLbl.Name = "ErrorMessageLbl";
            this.ErrorMessageLbl.Size = new System.Drawing.Size(120, 20);
            this.ErrorMessageLbl.TabIndex = 4;
            this.ErrorMessageLbl.Text = "Error Messages:";
            // 
            // ErrorLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ErrorMessageLbl);
            this.Controls.Add(this.btnCheckErrors);
            this.Controls.Add(this.txtMessageBox);
            this.Controls.Add(this.btnTestLogs);
            this.Name = "ErrorLogForm";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosure);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestLogs;
        private System.Windows.Forms.TextBox txtMessageBox;
        private System.Windows.Forms.Button btnCheckErrors;
        private System.Windows.Forms.Label ErrorMessageLbl;
    }
}