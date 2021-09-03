using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECEN403_FormsApp
{
    public partial class ErrorLogForm : Form
    {
        public ErrorLogForm(string FormName)
        {
            InitializeComponent();
            this.Text = FormName;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void FormClosure(object sender, FormClosingEventArgs e)
        {
            MainMenuForm parentForm = new MainMenuForm();

            parentForm.Show();
        }

        private void TxtMessageBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnTestLogs_Click(object sender, EventArgs e)
        {
            txtMessageBox.AppendText("----TESTING LOG OUTPUT----");
            txtMessageBox.AppendText(Environment.NewLine);

            for (int count = 0; count < 10; count++)
            {
                txtMessageBox.AppendText("TEST: Test " + count.ToString() + " successful!");
                txtMessageBox.AppendText(Environment.NewLine);
            }
        }

        private void BtnCheckErrors_Click(object sender, EventArgs e)
        {
            // thinking should display any errors rover sends
            // sample data for validation can be created as
            string sampleData;
            txtMessageBox.AppendText("----SAMPLE DATA BELOW----");
            txtMessageBox.AppendText(Environment.NewLine);

            for (int count = 0; count < 10; count++)
            {
                // display time at which the error occurred
                // time will be displayed as Hour:Minute:Seconds ; Month:Day:Year
                sampleData = "ERROR: Type " + count.ToString() + " occurred @ HH:MM:SS ; MM:DD:YY";
                txtMessageBox.AppendText(sampleData);
                txtMessageBox.AppendText(Environment.NewLine);
            }

        }

    }
}
