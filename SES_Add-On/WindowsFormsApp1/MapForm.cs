using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SES_Add_ON
{
    public partial class MapForm : Form
    {
        public int[] mapsize = new int[2];  // 지도크기
        public int[] start = new int[2] { -1,-1};    // 시작위치, -1,-1로 초기화 - 중복검사에 안걸리게
        public char[,] maze;                // 지도모양
        public List<int[]> hazardset = new List<int[]>();
        public List<int[]> colorblobset = new List<int[]>();

        public MapForm()
        {
            InitializeComponent();
            
            printExample();
        }

        public void myWriteLine(string s)
        {
            ConsoleBox.Text += s + System.Environment.NewLine;
        }
        private void myWrite(string s)
        {
            ConsoleBox.Text += s;
        }

        private void mapWriteLine(string s)
        {
            Mapconsole.Text += s + System.Environment.NewLine;
        }

        private void mapWrite(string s)
        {
            Mapconsole.Text += s;
        }

        private void printExample() // 입력방법 출력
        {
            myWriteLine("Enter MapSzie ex) x,y");
        }

        private void Mapbtn_Click(object sender, EventArgs e)
        {
            enterMapsize();
        }

        private void enterMapsize() // 지도크기 입력 
        {
            ControlMap contorlmap = new ControlMap(this);
            int i;
            try
            {
                string[] sinput = Maptxt.Text.Split(','); //입력데이터 ,기준으로 분리

                if ((int.Parse(sinput[0]) < 7) || (int.Parse(sinput[1]) < 7)) //지도 크기는 7*7이상
                {
                    Maptxt.Text = "";
                    MessageBox.Show("Please enter a number lager than 6", "Size Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (i = 0; i < sinput.Length; i++) //지도크기 배열에 값을 입력
                        mapsize[i] = int.Parse(sinput[i]);
                    myWrite(String.Format("{0}*", mapsize[0])); //행
                    myWriteLine(String.Format("{0}", mapsize[1])); //열
                    myWriteLine("Enter Start Point ex) x1,y1");
                    contorlmap.createMap();
                }
            }
            catch (SystemException)
            {
                Maptxt.Text = "";
                MessageBox.Show("MapSzie Format is x,y (use comma)", "Format Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void enterStart()
        {
            ControlMap contorlmap = new ControlMap(this);
            int i;
            int ok = 0; int use = 0;
            int[] temp = new int[2];
            try
            {
                string[] sinput = Starttxt.Text.Split(','); //입력데이터 ,기준으로 분리
                                                            //myWriteLine(string.Format("{0}",Input.Text.Length));
                ok = checkmapsize(sinput);
                if (ok != 0)
                {  //0이면 사이즈 에러
                    for (i = 0; i < sinput.Length; i++) //지도크기 배열에 값을 입력
                    {
                        temp[i] = int.Parse(sinput[i]);
                    }
                    use = checkuse(temp);
                    if (use == 0) { Starttxt.Text = ""; } //이미 사용중
                } //0이면 사이즈 에러

                else { Starttxt.Text = ""; }

                if (ok != 0 && use != 0)
                { // 둘다 에러 아니면
                    for (i = 0; i < sinput.Length; i++) //지도크기 배열에 값을 입력
                    {
                        start[i] = int.Parse(sinput[i]);
                    }
                    myWriteLine("Start Point is...");
                    myWrite(String.Format("{0}*", start[0])); //행
                    myWriteLine(String.Format("{0}", start[1])); //열
                    myWriteLine("Enter Hazardset ex) x1,y1 x2,y2");
                    contorlmap.initStart(start);


                }
            }
            catch (SystemException)
            {
                Starttxt.Text = "";
                MessageBox.Show("Start Format is x,y (use comma)", "Format Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void printmap(char[,] map)  //지도출력
        {
            int i, j;
            Mapconsole.Text = ""; // 지도 출력 화면 초기화
            for (i = 0; i < mapsize[0]; i++)
            { //행
                for (j = 0; j < mapsize[1]; j++)
                { //열
                    mapWrite(String.Format(" {0} ", map[i, j]));
                }
                mapWriteLine(" ");
            }
        }

        private void Hazardbtn_Click(object sender, EventArgs e)
        {
            enterHazard();
        }

        private void enterHazard()  //위험지역 입력
        {
            ControlMap controlMap = new ControlMap(this);
            int i; int ok = 0; int use = 0; int[] temp = new int[2];
            int[] hazard = new int[2]; //위험지역 좌표 한쌍

            try
            {
                string[] sinput = Hazardtxt.Text.Split(' ');//입력데이터 공백 기준으로 분리
                string data = string.Join(",", sinput); //공백으로 분리된 ,사용해 결합
                sinput = data.Split(','); //결합된 데이터 ,기준으로 재분리

                ok = checkmapsize(sinput);
                if (ok != 0)
                {
                    for (i = 0; i < sinput.Length; i = i + 2) //지도크기 배열에 값을 입력
                    {
                        temp[0] = int.Parse(sinput[i]);
                        temp[1] = int.Parse(sinput[i + 1]);
                        use = checkuse(temp);
                        if (use == 0) { Hazardtxt.Text = ""; break; } //이미 사용중
                    }
                } //0이면 사이즈 에러
                else { Hazardtxt.Text = ""; }

                if (ok != 0 && use != 0)
                { // 둘다 에러 아니면
                    for (i = 0; i < sinput.Length; i = i + 2)
                    {
                        hazard[0] = int.Parse(sinput[i]); //분리된 데이터 짝수번 인덱스 =행
                        hazard[1] = int.Parse(sinput[i + 1]); // 분리된 데이터 홀수번 인덱스 =열 
                        hazardset.Add(new int[] { hazard[0], hazard[1] }); // 집합에 추가
                    }
                    myWriteLine("HazardSet Is...");
                    for (i = 0; i < hazardset.Count; i++) //집합 크기만큼 반복
                    {
                        myWrite(string.Format("({0},", hazardset[i][0])); //행
                        myWriteLine(string.Format("{0})", hazardset[i][1])); //열
                    }
                    controlMap.initHazard(hazardset); //지도에 위험지역 추가
                }
            }
            catch (SystemException)
            {
                Hazardtxt.Text = "";
                MessageBox.Show("Hazardset Format is x1,y2 x2,y2 (use comma and separate one space bar)", "Format Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void Colorbtn_Click(object sender, EventArgs e)
        {
            enterColorblob();
        }

        private void enterColorblob()      //목표지점 입력
        {
            ControlMap controlMap = new ControlMap(this);
            int i; int ok = 0; int use = 0; int[] temp = new int[2];
            int[] color = new int[2];
            try
            {
                string[] sinput = Colortxt.Text.Split(' '); //공백 분리
                string data = string.Join(",", sinput); //, 결합
                sinput = data.Split(','); //, 분리
                ok = checkmapsize(sinput);
                if (ok != 0)
                {
                    for (i = 0; i < sinput.Length; i = i + 2) //지도크기 배열에 값을 입력
                    {
                        temp[0] = int.Parse(sinput[i]);
                        temp[1] = int.Parse(sinput[i + 1]);
                        use = checkuse(temp);
                        if (use == 0) { Colortxt.Text = ""; break; } //이미 사용중
                    }
                } //0이면 사이즈 에러
                else { Colortxt.Text = ""; }

                if (ok != 0 && use != 0)
                { // 둘다 에러 아니면
                    for (i = 0; i < sinput.Length; i = i + 2) //분리된 데이터 갯수만큼 반복
                    {
                        color[0] = int.Parse(sinput[i]); //행=x좌표
                        color[1] = int.Parse(sinput[i + 1]); //열=y좌표
                        colorblobset.Add(new int[] { color[0], color[1] }); //중요지점 추가
                    }

                    myWriteLine("ColorBlob Is...");
                    for (i = 0; i < colorblobset.Count; i++)
                    {
                        myWrite(string.Format("({0},", colorblobset[i][0]));
                        myWriteLine(string.Format("{0})", colorblobset[i][1]));
                    }//중요지점 좌표 출력
                    controlMap.initColorblob(colorblobset); //지도에 중요지역 표시 
                }
            }
            catch (SystemException)
            {
                Colortxt.Text = "";
                MessageBox.Show("Coloreblob set Format is x1,y2 x2,y2 (use comma and separate one space bar)", "Format Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private int checkmapsize(string[] sinput)
        {
            int i = 0;
            int rowindex, colindex;
            for (i = 0; i < sinput.Length; i = i + 2)
            {
                rowindex = int.Parse(sinput[i]);
                colindex = int.Parse(sinput[i + 1]);
                if ((mapsize[0] <= rowindex) || (mapsize[1] <= colindex))
                { //지도크기 벗어남
                    MessageBox.Show("IndexOutOfRange: mapsize is " + mapsize[0] + ", " + mapsize[1], "Size Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            for (i = 0; i < sinput.Length; i = i + 2)
            {
                rowindex = int.Parse(sinput[i]);
                colindex = int.Parse(sinput[i + 1]);
                if ((rowindex < 0) || (colindex < 0))
                { //음수
                    MessageBox.Show("IndexOutOfRange: Please enter a number lager than 0 ", "Size Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            return 1; //ok
        }

        private int checkuse(int[] point)
        {
            int i = 0;

            if ((start[0] == point[0]) && (start[1] == point[1]))
            {
                MessageBox.Show(point[0] + "," + point[1] + ": this point is start", "used Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            for (i = 0; i < hazardset.Count; i++)
            {
                if ((hazardset[i][0] == point[0]) && (hazardset[i][1] == point[1]))
                {
                    MessageBox.Show(point[0] + "," + point[1] + ": this point is hazard", "used Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            for (i = 0; i < colorblobset.Count; i++)
            {
                if ((colorblobset[i][0] == point[0]) && (colorblobset[i][1] == point[1]))
                {
                    MessageBox.Show(point[0] + "," + point[1] + ": this point is colorblob", "used Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            return 1;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            enterStart();
        }
    }
}
