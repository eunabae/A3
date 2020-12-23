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
    public partial class PathForm : Form
    {
        public PathForm()
        {
            InitializeComponent();
        }

        public void printCompensate(int imperfect)
        {
            Pathtxt.Text = ""; //초기화
            if (imperfect == 1)
            {
                Pathtxt.Text += "로봇이 움직이지 않았습니다.";
                Pathtxt.Text +=  System.Environment.NewLine;
                Pathtxt.Text += "움직임을 보정합니다.";
            }
            else
            {
                Pathtxt.Text += "로봇이 두 칸 움직였습니다.";
                Pathtxt.Text += System.Environment.NewLine;
                Pathtxt.Text += "움직임을 보정합니다.";
            }
        }
        private void OKbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PathForm_Load(object sender, EventArgs e)
        {

        }
    }
}
