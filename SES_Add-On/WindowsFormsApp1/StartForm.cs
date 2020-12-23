using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SES_Add_ON
{
    public partial class StartForm : Form
    {
        ColorInfo color = new ColorInfo();
        HazardInfo hazard = new HazardInfo();
        public StartForm()
        {
            InitializeComponent();
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            MapForm mapform = new MapForm();
            mapform.Show();
        }

        private void Endbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Runbtn_Click(object sender, EventArgs e)
        {
            RunForm runform = new RunForm();
            runform.Show();
        }
    }
}
