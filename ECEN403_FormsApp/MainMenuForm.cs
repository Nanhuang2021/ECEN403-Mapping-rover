using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECEN403_FormsApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // NEED TO: Perform more dummy inputs, like have input that's more closely related to real input
            // Demo Video: Could've done more, needs improvement follow the above statement
        }

        private void BtnGenMaps_Click(object sender, EventArgs e)
        {
            // Form1 will be the Parent Form
            // Create an instance of the Child Form
            GenMapsForm ChildForm = new GenMapsForm("Generated Maps");

            ChildForm.Show();
            this.Hide();

        }

        private void BtnRoverStatus_Click(object sender, EventArgs e)
        {
            // Create an instance for RoverStatus Form
            // Refer to BtnGenMaps_Click
            RoverStatusForm ChildForm = new RoverStatusForm("Rover Status");

            ChildForm.Show();
            this.Hide();
        }

        private void BtnErrorLogs_Click(object sender, EventArgs e)
        {
            // Create an instance for ErrorLogs Form
            ErrorLogForm ChildForm = new ErrorLogForm("Error Logs");

            ChildForm.Show();
            this.Hide();
        }

        private void BtnInputCommands_Click(object sender, EventArgs e)
        {
            // Create an instance for InputCommands
            InputCommandsForm ChildForm = new InputCommandsForm("Input Commands & Logs");

            ChildForm.Show();
            this.Hide();
        }

        private void EndProgram(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonWifiConnect_Click(object sender, EventArgs e)
        {
            // Create an instance for WifiConnect window
            WlanNetworkForm ChildForm = new WlanNetworkForm("Wifi Connect");

            ChildForm.Show();
            this.Hide();
        }
    }
}
