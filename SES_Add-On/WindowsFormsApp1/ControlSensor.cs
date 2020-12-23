using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SES_Add_ON
{
    class ControlSensor
    {
        SIM sim = new SIM();
        ControlMap controlmap = new ControlMap();
        HazardInfo hazardinfo = new HazardInfo();
        ColorInfo colorinfo = new ColorInfo();

        public int checkHazard(int[] position, int nextPath)
        {
            int count = 0;
            List<int[]> simhazardset = sim.getHazard();
            int[] nextPosition = new int[2];
            switch (nextPath)   //현재위치에서 경로에 따른 다음 위치로 변경
            {
                case 0: //상
                    {
                        nextPosition[0] = position[0] - 1;
                        nextPosition[1] = position[1];
                        break;
                    }
                case 1:  //하
                    {
                        nextPosition[0] = position[0] + 1;
                        nextPosition[1] = position[1];
                        break;
                    }
                case 2: //좌
                    {
                        nextPosition[0] = position[0];
                        nextPosition[1] = position[1] - 1;
                        break;
                    }
                case 3: //우
                    {
                        nextPosition[0] = position[0];
                        nextPosition[1] = position[1] + 1;
                        break;
                    }
            }
            while (count < simhazardset.Count)
            {
                if (simhazardset[count][0] == nextPosition[0] && simhazardset[count][1] == nextPosition[1])
                {// SIM의 위험지점들 중에서 다음 위치가 있는지 확인
                    controlmap.updateHazard(nextPosition);      //있으면 지도에 표시
                    hazardinfo.addHazard(nextPosition);         // hazardset에 추가
                    return 1;
                }
                count++;
            }
            return 0;
        }

        public int checkColor(int[] position)
        {
            List<int[]> simcolorset = sim.getColor();
            int[] colorPosition = new int[2];
            int count = 0;
            int check = 0;
            colorPosition[0] = position[0];
            colorPosition[1] = position[1];

            while (count < simcolorset.Count)
            {
                if (simcolorset[count][0] == (colorPosition[0] - 1) && simcolorset[count][1] == colorPosition[1])
                {// 위가 중요지점인 경우
                    colorPosition[0] = colorPosition[0] - 1;
                    check = checkRe(colorPosition);
                    colorPosition[0] = position[0];
                    colorPosition[1] = position[1];
                }
                if (simcolorset[count][0] == (colorPosition[0] + 1) && simcolorset[count][1] == colorPosition[1])
                {// 아래가 중요지점인 경우
                    colorPosition[0] = colorPosition[0] + 1;
                    check = checkRe(colorPosition);
                    colorPosition[0] = position[0];
                    colorPosition[1] = position[1];
                }
                if (simcolorset[count][0] == colorPosition[0] && simcolorset[count][1] == (colorPosition[1] - 1))
                {// 왼쪽이 중요지점인 경우
                    colorPosition[1] = colorPosition[1] - 1;
                    check = checkRe(colorPosition);
                    colorPosition[0] = position[0];
                    colorPosition[1] = position[1];
                }
                if (simcolorset[count][0] == colorPosition[0] && simcolorset[count][1] == (colorPosition[1] + 1))
                {// 오른쪽이 중요지점인 경우
                    colorPosition[1] = colorPosition[1] + 1;
                    check = checkRe(colorPosition);
                    colorPosition[0] = position[0];
                    colorPosition[1] = position[1];
                }
                count++;
            }
            if (check == 1)
                return 1;
            return 0;
        }
        public int checkRe(int[] color)        
        {
            List<int[]> hiddencolorset = colorinfo.getHiddenColor();
            int count = 0;

            while (count < hiddencolorset.Count)    //이미 찾은 중요지점인지 체크
            {
                if (hiddencolorset[count][0] == color[0] && hiddencolorset[count][1] == color[1])
                    return 0;       //이미 존재하면 0리턴
                count++;
            }//처음 찾은 중요지점이면
            controlmap.updateColor(color);   //지도에 표시
            colorinfo.addColor(color);       //colorset에 추가
            return 1;
        }
    }
}
