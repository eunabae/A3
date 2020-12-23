using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SES_Add_ON
{
    class MapInfo
    {
        private ControlMap controlmap;

        static public char[,] MapInfo_map;
        static public int[] MapInfo_mapsize;
        static public int[] MapInfo_start;

        public MapInfo() { }

        public MapInfo(ControlMap controlmap)
        {
            this.controlmap = controlmap;
        }

        public void clearMap()
        {

        }
        public void setMapInfo()    // ControlMap에서 map을 받아 저장
        {
            MapInfo_map = controlmap.map;
        }

        public void setMapSize()    // ControlMap에서 mapsize를 받아 저장
        {
            MapInfo_mapsize = controlmap.mapsize;
        }

        public void setMapstart()
        {
            MapInfo_start = controlmap.start;
        }

        public char[,] getMap()     // map을 반환해주는 함수
        {
            return MapInfo_map;
        }

        public int[] getSize()      // mapsize를 반환해주는 함수
        {
            return MapInfo_mapsize;
        }

        public int[] getStart()      // start 반환해주는 함수
        {
            return MapInfo_start;
        }
    }
}
