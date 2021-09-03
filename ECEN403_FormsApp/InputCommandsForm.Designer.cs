
namespace ECEN403_FormsApp
{
    partial class InputCommandsForm
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
            this.txtRxCommands = new System.Windows.Forms.TextBox();
            this.txtTxCommands = new System.Windows.Forms.TextBox();
            this.EnterBtn = new System.Windows.Forms.Button();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.InputCommLabel = new System.Windows.Forms.Label();
            this.RxLabel = new System.Windows.Forms.Label();
            this.TxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRxCommands
            // 
            this.txtRxCommands.AcceptsReturn = true;
            this.txtRxCommands.Location = new System.Drawing.Point(21, 31);
            this.txtRxCommands.Multiline = true;
            this.txtRxCommands.Name = "txtRxCommands";
            this.txtRxCommands.Size = new System.Drawing.Size(306, 317);
            this.txtRxCommands.TabIndex = 0;
            // 
            // txtTxCommands
            // 
            this.txtTxCommands.AcceptsReturn = true;
            this.txtTxCommands.AcceptsTab = true;
            this.txtTxCommands.Location = new System.Drawing.Point(350, 31);
            this.txtTxCommands.Multiline = true;
            this.txtTxCommands.Name = "txtTxCommands";
            this.txtTxCommands.Size = new System.Drawing.Size(306, 317);
            this.txtTxCommands.TabIndex = 1;
            // 
            // EnterBtn
            // 
            this.EnterBtn.Location = new System.Drawing.Point(679, 394);
            this.EnterBtn.Name = "EnterBtn";
            this.EnterBtn.Size = new System.Drawing.Size(91, 27);
            this.EnterBtn.TabIndex = 2;
            this.EnterBtn.Text = "Enter";
            this.EnterBtn.UseVisualStyleBackColor = true;
            this.EnterBtn.Click += new System.EventHandler(this.EnterBtn_Click);
            // 
            // txtUserInput
            // 
            this.txtUserInput.AcceptsReturn = true;
            this.txtUserInput.Location = new System.Drawing.Point(21, 394);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(634, 27);
            this.txtUserInput.TabIndex = 3;
            this.txtUserInput.Tag = "";
            // 
            // InputCommLabel
            // 
            this.InputCommLabel.AutoSize = true;
            this.InputCommLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InputCommLabel.Location = new System.Drawing.Point(21, 371);
            this.InputCommLabel.Name = "InputCommLabel";
            this.InputCommLabel.Size = new System.Drawing.Size(134, 20);
            this.InputCommLabel.TabIndex = 4;
            this.InputCommLabel.Text = "Input Commands:";
            // 
            // RxLabel
            // 
            this.RxLabel.AutoSize = true;
            this.RxLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RxLabel.Location = new System.Drawing.Point(21, 8);
            this.RxLabel.Name = "RxLabel";
            this.RxLabel.Size = new System.Drawing.Size(159, 20);
            this.RxLabel.TabIndex = 5;
            this.RxLabel.Text = "Executed Commands:";
            // 
            // TxLabel
            // 
            this.TxLabel.AutoSize = true;
            this.TxLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxLabel.Location = new System.Drawing.Point(350, 8);
            this.TxLabel.Name = "TxLabel";
            this.TxLabel.Size = new System.Drawing.Size(127, 20);
            this.TxLabel.TabIndex = 6;
            this.TxLabel.Text = "Sent Commands:";
            // 
            // InputCommandsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxLabel);
            this.Controls.Add(this.RxLabel);
            this.Controls.Add(this.InputCommLabel);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.EnterBtn);
            this.Controls.Add(this.txtTxCommands);
            this.Controls.Add(this.txtRxCommands);
            this.Name = "InputCommandsForm";
            this.Text = "Form4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosure);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRxCommands;
        private System.Windows.Forms.TextBox txtTxCommands;
        private System.Windows.Forms.Button EnterBtn;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Label InputCommLabel;
        private System.Windows.Forms.Label RxLabel;
        private System.Windows.Forms.Label TxLabel;
    }
}