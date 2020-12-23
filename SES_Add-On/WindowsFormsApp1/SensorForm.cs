using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SES_Add_ON
{
    public partial class SensorForm : Form
    {
        public SensorForm()
        {
            InitializeComponent();
        }

        public void printHazard()
        {
            Sensortxt.Text = "";
            Sensortxt.Text += "위험지역을 발견했습니다." ;
        }

        public void printColor()
        {
            Sensortxt.Text = "";
            Sensortxt.Text += "중요지역을 발견했습니다.";
        }

        private void Okbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SensorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
