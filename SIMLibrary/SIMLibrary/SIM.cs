using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIMLibrary
{

    public class SIM
    {
        static public List<int[]> SIM_hazard = new List<int[]>();
        static public List<int[]> SIM_color = new List<int[]>();
        static public int[] SIM_position = new int[2];

        public void detectHiddenHazard(int witdth, int height)  //지도의 가로, 세로 입력
        {
            int[] hazard = new int[2];
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x = random.Next(0, witdth);     //가로길이로 제한
                int y = random.Next(0, height);     //세로길이로 제한
                hazard[0] = x;
                hazard[1] = y;
                SIM_hazard.Add(new int[] { hazard[0], hazard[1] }); //SIM의 hazard 정보에 추가
            }
        }
        public void detectHIddenColor(int witdth, int height)   //지도의 가로, 세로 입력
        {
            //           SIM_color 
            int[] color = new int[2];
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x = random.Next(0, witdth);     //가로길이로 제한
                int y = random.Next(0, height);     //세로길이로 제한
                color[0] = x;
                color[1] = y;
                SIM_hazard.Add(new int[] { color[0], color[1] });   //SIM의 color 정보에 추가
            }
        }

        public List<int[]> getHazard()  //hazard 리스트 반환
        {
            return SIM_hazard;
        }

        public List<int[]> getColor()   //color 리스트 반환
        {
            return SIM_color;
        }

        public void initPosition(int[] start)   // 시작위치를 현재위치로 초기화
        {
            SIM_position[0] = start[0];
            SIM_position[1] = start[1];
        }

        public int[] getPosition(int direction) // 방향받아서 위치변경하고 현재위치 반환
        {
            switch (direction)
            {
                case 0: //상
                    {
                        SIM_position[0] = SIM_position[0]--;
                        break;
                    }
                case 1:  //하
                    {
                        SIM_position[0] = SIM_position[0]++;
                        break;
                    }
                case 2: //좌
                    {
                        SIM_position[1] = SIM_position[1]--;
                        break;
                    }
                case 3: //우
                    {
                        SIM_position[1] = SIM_position[1]++;
                        break;
                    }
            }
            return SIM_position;
        }
    }
}
