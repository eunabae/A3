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
    public partial class RunForm : Form
    {
        MapInfo mapinfo = new MapInfo();
        PositionInfo positionInfo = new PositionInfo();
        ControlMovement controlmove = new ControlMovement();
        ControlPath controlpath = new ControlPath();
        SIM sim = new SIM();

        private static char[,] map;
        private static int[] mapsize;

        public RunForm()
        {
            InitializeComponent();
            init();
        }

        public void init()  
        {
            mapsize = mapinfo.getSize();
            map = mapinfo.getMap(); //지도정보 초기화
            sim.detectHidden(mapsize[0], mapsize[1]);   //랜덤 중요, 위험 생성
            controlpath.initPath();     // 길찾기 초기화
            controlmove.initIndex();    //인덱스 초기화
            controlmove.getPath();      // 초기 경로 생성
            printMap();
        }

        public void updateMap()
        {
            int checkMove;
            checkMove=controlmove.getNextMove();
            map = mapinfo.getMap();
            printMap();
            if (checkMove != 0) //정상작동이 아니면
            {
                PathForm pathform = new PathForm();
                pathform.printCompensate(checkMove);
                pathform.ShowDialog();
                controlmove.compensateMotion(); // 움직임 보정
                map = mapinfo.getMap();
            }
        }
        

        public void printMap()  //출력 
        {
            int i, j;
            RunConsole.Text = ""; // 지도 출력 화면 초기화
            for (i = 0; i < mapsize[0]; i++)
            { //행
                for (j = 0; j < mapsize[1]; j++)
                { //열
                    RunConsole.Text += String.Format(" {0} ", map[i, j]);
                }
                RunConsole.Text += " " + System.Environment.NewLine;
            }
        }
        public void checkSensor()
        {
            int sensor = 0;
            sensor = controlmove.sensorPrint();
            if (sensor != 0)
            {
                map = mapinfo.getMap();
                printMap();
                SensorForm sensorform = new SensorForm();
                if (sensor == 1)    //둘 다 발견
                {
                    sensorform.printColor();
                    sensorform.ShowDialog();
                    sensorform.printHazard();
                    sensorform.ShowDialog();
                    PathForm pathform = new PathForm();
                    pathform.ShowDialog();
                    controlmove.initIndex();    //인덱스 초기화
                    controlmove.getPath();      //경로 재탐색

                }
                else if (sensor == 2)   //위험만 발견
                {
                    sensorform.printHazard();
                    sensorform.ShowDialog();
                    PathForm pathform = new PathForm();
                    pathform.ShowDialog();
                    controlmove.initIndex();    //인덱스 초기화
                    controlmove.getPath();      //경로 재탐색

                }
                else     // 중요만 발견
                {
                    sensorform.printColor();
                    sensorform.ShowDialog();
                }
            }
        }
        private void Detectbtn_Click(object sender, EventArgs e)
        {
            checkSensor();
        }
        private void NextMovebtn_Click(object sender, EventArgs e)
        {
            try
            {
                updateMap();
                checkSensor();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("FINISH : Find All Colorblob", "end", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            printMap();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RunForm_Load(object sender, EventArgs e)
        {

        }
    }
}
