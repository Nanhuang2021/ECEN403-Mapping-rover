using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECEN403_FormsApp
{
    public partial class InputCommandsForm : Form
    {
        public InputCommandsForm(string FormName)
        {
            InitializeComponent();
            this.Text = FormName;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void FormClosure(object sender, FormClosingEventArgs e)
        {
            MainMenuForm parentForm = new MainMenuForm();

            parentForm.Show();
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            // button will display commands on form in "sent commands"
            // if user input textbox is empty, display an error form to prompt user
            if (txtUserInput.Text == String.Empty) {
                txtTxCommands.AppendText("ERROR: Input Commands must be filled.");
            }
            
            // Can only tab, need to make new line
            string displayInput = txtUserInput.Text;
            txtTxCommands.AppendText(displayInput);
            txtTxCommands.AppendText(Environment.NewLine);

            // display sent commands that will be executed
            // if a valid input is found...
            if (txtUserInput.Text.ToLower() == "start" || txtUserInput.Text.ToLower() == "stop" || 
                txtUserInput.Text.ToLower() == "map room" || txtUserInput.Text.ToLower() == "hello" || 
                txtUserInput.Text.ToLower() == "roam")
            {
                // valid input, echo the input
                txtRxCommands.AppendText(txtUserInput.Text);
                txtRxCommands.AppendText(Environment.NewLine);
            }

            else
            {
                // invalid input
                txtRxCommands.AppendText("Sorry, \"" + txtUserInput.Text + "\" is not a valid input");
                txtRxCommands.AppendText(Environment.NewLine);
            }
        }
    }
}
