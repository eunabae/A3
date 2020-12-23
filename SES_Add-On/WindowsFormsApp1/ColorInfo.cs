using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SES_Add_ON
{
    class ColorInfo
    {
        static public List<int[]> color;                            //탐색지점
        static public List<int[]> hiddenColor = new List<int[]>();  //새로 추가하는 중요지점

        public void initColor(List<int[]> colorset)                 //탐색지점 초기화함수
        {
            color = colorset;
        }

        public void addColor(int[] newColor)                       //Sensor에서 발견한 중요지점 추가함수
        {
            hiddenColor.Add(new int[] { newColor[0], newColor[1] });
        }
            
        public List<int[]> getColor()                               //탐색지점 얻어오는 함수
        {
            return color;
        }

        public List<int[]> getHiddenColor()                         //새로추가된 중요지점 얻어오는 함수
        {
            return hiddenColor;
        }
    }
}
