using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SES_Add_ON
{
    class ControlMap
    {
        MapForm mapform;
        ControlPath controlpath = new ControlPath();

        static private char[,] ControlMap_map;
        static private int[] ControlMap_mapsize;
        static private int[] ControlMap_start;
        static private char temp;
        static int checkColor=0;     //이전 위치가 탐색지점인지 체크하는 변수
        static int count = 1;        //찾은 탐색지점의 개수를 체크하는 변수

        public ControlMap() { temp = ' '; }

        public ControlMap(MapForm mapform)      
        {
            this.mapform = mapform;
        }
        public char[,] map
        { 
            get { return ControlMap_map; }
        }

        public int[] mapsize
        { 
            get { return ControlMap_mapsize; }
        }

        public int[] start
        { 
            get { return ControlMap_start; }
        }

        public void setMapsize()    
        {
            MapInfo mapinfo = new MapInfo(this);
            ControlMap_mapsize = mapform.mapsize;   // MapForm의 mapsize를 받아 ControlMap_mapsize로 저장
            mapinfo.setMapSize();                   // MapInfo에 지도크기 저장
        }

        public void setMap() {
            MapInfo mapinfo = new MapInfo(this);
            ControlMap_map = mapform.maze;          //MapForm의 maze를 받아 ControlMap_mapdm로 저장
        }

        public void setMapstart()
        {
            MapInfo mapinfo = new MapInfo(this);
            ControlMap_start = mapform.start;       //MapForm의 start 받아 ControlMap_start로 저장
            mapinfo.setMapstart();
        }

        public void saveMap()   //MapInfo에 지도 저장
        {
            MapInfo mapinfo = new MapInfo(this);
            mapinfo.setMapInfo();           
        }

        public void createMap()   //지도 생성
        {
            int i, j;
            setMap();
            setMapsize();
            setMapstart();
            ControlMap_map = new char[ControlMap_mapsize[0], ControlMap_mapsize[1]]; 
            for (i = 0; i < ControlMap_mapsize[0]; i++)
            { //행
                for (j = 0; j < ControlMap_mapsize[1]; j++)
                { //열
                    ControlMap_map[i, j] = '□'; 
                }
            }
            saveMap();
            mapform.printmap(ControlMap_map); //생성된 지도 출력
        }

        public void initStart(int [] start)  // 시작위치 초기화
        {
            PositionInfo positioninfo = new PositionInfo(); 
            ControlMap_map[start[0], start[1]] = '▣'; //로봇을 시작위치에
            positioninfo.initPosition(start);          // PositionInfo에 현재위치로 초기화
            mapform.printmap(ControlMap_map);
        }

        public void initHazard(List<int[]> hazardset)  // MapForm에서 입력받은 위험지점 추가
        {
            HazardInfo hazardinfo = new HazardInfo();
            int i;
            int x, y;
            for (i = 0; i < hazardset.Count; i++)
            {
                x = hazardset[i][0];
                y = hazardset[i][1];
                ControlMap_map[x, y] = 'Ｘ'; //위험지역 표시
            }
            saveMap();
            hazardinfo.initHazard(hazardset);
            mapform.printmap(ControlMap_map);
        }


        public void initColorblob(List<int[]>  colorset)  // MapForm에서 입력받은 탐색지점 추가
        {
            ColorInfo colorinfo = new ColorInfo();
            int i;
            int x, y;
            for (i = 0; i < colorset.Count; i++)
            {
                x = colorset[i][0];
                y = colorset[i][1];
                ControlMap_map[x, y] = '★'; //탐색지점 표시
            }
            saveMap();
            colorinfo.initColor(colorset);
            mapform.printmap(ControlMap_map); //지도 출력
        }

        public void updateHazard(int[] hazard)  //Sensor로 발견된 위험지점을 지도에 추가
        {
            ControlMap_map[hazard[0], hazard[1]] = 'X';
            saveMap();
        }

        public void updateColor(int[] color)    //Sensor로 발견된 중요지점을 지도에 추가
        {
            ControlMap_map[color[0], color[1]] = '◆';
            saveMap();
        }

        public void clearPosition(int[] position)        //이전 위치 초기화
        {
            if (checkColor == 1)
            {
                ControlMap_map[position[0], position[1]] = '☆';
                checkColor = 0;
            }
            else
            {
                switch (temp)
                {
                    case '☆': ControlMap_map[position[0], position[1]] = '☆'; break;
                    case '★': ControlMap_map[position[0], position[1]] = '★'; break;
                    case '◆': ControlMap_map[position[0], position[1]] = '◆'; break;
                    case 'X': ControlMap_map[position[0], position[1]] = 'X'; break;
                    default: ControlMap_map[position[0], position[1]] = '□'; break;
                }
            }
            saveMap();
        }

        public void updatePosition(int[] position)    //움직인 위치 표시
        {
            if (ControlMap_map[position[0], position[1]] == '★')
            {
                checkColor = 1;
                controlpath.setCount(count++);    // 찾은 중요지점 개수를 넘김
            }
            temp = ControlMap_map[position[0], position[1]];
            ControlMap_map[position[0], position[1]] = '▣';     // 다음 위치 표시
            saveMap();  //지도저장
        }
    }
}
