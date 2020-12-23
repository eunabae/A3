using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SES_Add_ON
{
    class ControlMovement
    {
        ControlPath controlpath = new ControlPath();
        ColorInfo color = new ColorInfo();
        PositionInfo positioninfo = new PositionInfo();
        ControlSensor controlsensor = new ControlSensor();
        ControlMap controlmap = new ControlMap();
        SIM sim = new SIM();

        static private List<int> path = new List<int>();
        static private int index = 0;       // path의 인덱스

        public void getPath()
        {
            int[] position = positioninfo.getPosition();
            int i;
            controlpath.getPath(position, path);
        }

        public void initIndex() //인덱스 초기화
        {
            index = 0;
        }
        public int sensorPrint()
        {
            int[] move;
            int check;                                 //Sensor에서 확인 됐는지 여부
            move = positioninfo.getPosition();         //현재위치를 받아옴
            if (path.Count == index) { return 0; }     //경로 마지막 = 다음이동 없으므로 체크할것 없음
            check =checkSensor(move, path[index]);     //현재위치와 다음 경로를 보내 위험, 중요 체크
            if (check == 0)
                return 0;
            return check;
        }

        public int getNextMove()
        {
            int[] move;
            int[] twomove = new int[2];
            int compensate;

            move = positioninfo.getPosition();  //현재위치를 받아옴
            controlmap.clearPosition(move);     //현재위치 초기화
            compensate = makeImperfectMotion(index);    //오작동 확률적 실행
            if (compensate == 1)
            {//움직이지 않음
                controlmap.updatePosition(move);                //현재위치 표시
                positioninfo.initPosition(move);                //현재위치로 저장
                return compensate;
            }
            else if (compensate == 2)
            {//두 칸 이동
                twomove[0] = move[0];   twomove[1] = move[1];
                twomove = sim.getPosition(twomove, path[index]);    
                twomove = sim.getPosition(twomove, path[index]);    //두 칸 움직임
                controlmap.updatePosition(twomove);                //현재위치 표시
                return compensate;
            }
            else
            {//정상동작
                move = sim.getPosition(move, path[index++]);    //다음위치 얻어오기
                controlmap.updatePosition(move);                //현재위치 표시
                positioninfo.initPosition(move);                //현재위치로 저장
                return 0;
            }
        }

        public int checkSensor(int[] position, int nextPath)
        {
            int sensorHazard = 0;
            int sensorColor = 0;
            sensorHazard = controlsensor.checkHazard(position, nextPath);
            sensorColor = controlsensor.checkColor(position);

            if (sensorHazard == 1 && sensorColor == 1)  // 둘 다 발견
                return 1;
            else if (sensorHazard == 1)  //위험 발견
                return 2;
            else if (sensorColor == 1)   //중요 발견
                return 3;
            else
                return 0;
        }
        
        public void compensateMotion()
        {
            int[] move;
            move = sim.getCurrentPostion();                 //SIM에서 실제위치 받아옴
            controlmap.clearPosition(move);                 //현재위치 초기화
            move = positioninfo.getPosition();              //올바른 위치를 받아옴
            move = sim.getPosition(move, path[index++]);    //다음위치 얻어오기
            controlmap.updatePosition(move);                //현재위치 표시
            positioninfo.initPosition(move);                //현재위치로 저장
        }

        public int makeImperfectIndex()     //오작동할 주기 결정
        {   
            int randindex;      //오작동주기
            Random rand = new Random();
            randindex = rand.Next(3, 10);
            return randindex;
        }

        public int makeImperfectMotion(int index)
        {
            Random r = new Random();
            int errorIndex, choice;
            int count = 0;
            errorIndex = makeImperfectIndex();
            if (((index+1) % errorIndex) == 0)  // 오작동주기이면
            {
                //choice = r.Next(1, 3);  //1 또는 2
                if (count % 2 == 0) //짝수면
                    choice = 2;
                else choice = 1;

                return choice;          //1이면 미동작, 2면 두 칸 동작
            }
            return 0;
        }
    }
}
