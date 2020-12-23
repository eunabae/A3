using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SES_Add_ON
{
    class PositionInfo
    {
        static int[] currentPosition;

        public void initPosition(int[] position)     
        {
            currentPosition = position;  // 시작위치를 현재위치로 초기화
        }
            
        public int[] getPosition() {    // 저장된 현재위치를 넘김
            return currentPosition;
        }
    }
}
