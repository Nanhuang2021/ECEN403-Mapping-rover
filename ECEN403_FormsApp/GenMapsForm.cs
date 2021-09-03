using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECEN403_FormsApp
{
    public partial class GenMapsForm : Form
    {
        public GenMapsForm(string FormName)
        {
            InitializeComponent();

            this.Text = FormName;
        }

        private void GenMapsForm_Load(object sender, EventArgs e)
        {

        }

        private void FormClosure(object sender, FormClosingEventArgs e)
        {
            MainMenuForm parentForm = new MainMenuForm();
            parentForm.Show();
        }
    }
}
