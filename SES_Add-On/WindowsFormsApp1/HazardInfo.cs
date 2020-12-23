using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SES_Add_ON
{
    class HazardInfo
    {
        static public List<int[]> hazard;

        public void initHazard(List<int[]> hazardset)   //처음 위험지점 초기화
        {
            hazard = hazardset;
        }

        public void addHazard(int[] newHazard)     //Sensor에서 발견한 위험지점을 추가
        {
            hazard.Add(new int[] { newHazard[0], newHazard[1] });
        }
        

        public List<int[]> getHazard()             //위험지점을 넘김
        {
            return hazard;
        }

    }
}
