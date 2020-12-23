using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SES_Add_ON
{

    public class SIM
    {
        HazardInfo hazard = new HazardInfo();
        MapInfo mapin = new MapInfo();
        ColorInfo color = new ColorInfo();

        static public List<int[]> SIM_hazard = new List<int[]>();
        static public List<int[]> SIM_color = new List<int[]>();
        static public int[] SIM_position = new int[2];

        public void detectHidden(int width, int height)
        {
            detectHiddenHazard(width, height);
            detectHIddenColor(width, height);
            initPosition();             //처음 위치를 현재위치로 초기화
        }

        public void detectHiddenHazard(int witdth, int height)  //지도의 가로, 세로 입력
        {
            int[] hazard = new int[2];
            int[] temp = new int[2];
            int use = 0;
            Random random = new Random();
            for (; SIM_hazard.Count < 3;)
            {
                int x = random.Next(0, witdth);     //가로길이로 제한
                int y = random.Next(0, height);     //세로길이로 제한

                temp[0] = x;
                temp[1] = y;
                use = checkuse(temp);
                if (use != 0)
                {
                    hazard[0] = x;
                    hazard[1] = y;
                    SIM_hazard.Add(new int[] { hazard[0], hazard[1] }); //SIM의 hazard 정보에 추가
                }
            }
        }
        public void detectHIddenColor(int witdth, int height)   //지도의 가로, 세로 입력
        {
            //           SIM_color 
            int[] color = new int[2];
            int[] temp = new int[2];
            int use = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            for (; SIM_color.Count < 3;)
            {
                int x = random.Next(0, witdth);     //가로길이로 제한
                int y = random.Next(0, height);     //세로길이로 제한

                temp[0] = x;
                temp[1] = y;
                use = checkuse(temp);
                if (use != 0) //0이면 사용중
                {
                    color[0] = x;
                    color[1] = y;
                    SIM_color.Add(new int[] { color[0], color[1] });   //SIM의 color 정보에 추가
                }
            }
        }

        private int checkuse(int[] point)
        {
            int i = 0;
            int[] start = mapin.getStart();
            List<int[]> hazardset = hazard.getHazard();
            List<int[]> colorblobset = color.getColor();

            if ((start[0] == point[0]) && (start[1] == point[1]))
            {
                return 0;
            }

            for (i = 0; i < hazardset.Count; i++)
            {
                if ((hazardset[i][0] == point[0]) && (hazardset[i][1] == point[1]))
                {
                    return 0;
                }
            }
            for (i = 0; i < colorblobset.Count; i++)
            {
                if ((colorblobset[i][0] == point[0]) && (colorblobset[i][1] == point[1]))
                {
                    return 0;
                }
            }
            for (i = 0; i < SIM_color.Count; i++)
            {
                if ((SIM_color[i][0] == point[0]) && (SIM_color[i][1] == point[1]))
                {
                    return 0;
                }
            }
            for (i = 0; i < SIM_hazard.Count; i++)
            {
                if ((SIM_hazard[i][0] == point[0]) && (SIM_hazard[i][1] == point[1]))
                {
                    return 0;
                }
            }

            return 1;
        }

        public List<int[]> getHazard()  //hazard 리스트 반환
        {
            return SIM_hazard;
        }

        public List<int[]> getColor()   //color 리스트 반환
        {
            return SIM_color;
        }

        public void initPosition()   // 시작위치를 현재위치로 초기화
        {
            SIM_position=mapin.getStart();
        }

        public int[] getCurrentPostion()
        {
            return SIM_position;
        }
        public int[] getPosition(int[] position, int direction) //위치변경하고 현재위치로 반환
        {
            switch (direction)
            {
                case 0: //상
                    {
                        position[0] = position[0] - 1;
                        break;
                    }
                case 1:  //하
                    {
                        position[0] = position[0] + 1;
                        break;
                    }
                case 2: //좌
                    {
                        position[1] = position[1] - 1;
                        break;
                    }
                case 3: //우
                    {
                        position[1] = position[1] + 1;
                        break;
                    }
            }
            SIM_position = position;
            return position;
        }
    }
}
