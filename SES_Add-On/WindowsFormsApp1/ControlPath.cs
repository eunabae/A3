using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SES_Add_ON
{
    class ControlPath
    {
        HazardInfo hazard = new HazardInfo();
        MapInfo mapin = new MapInfo();
        ColorInfo color = new ColorInfo();
        static List<int[]> hazardset;
        static List<int[]> colorset;
        static int count = 0;
        public void getHazard()            //입력한 hazardset 세팅
        {
            hazardset = hazard.getHazard(); 
        }

        public void getColor()              // 입력한 colorset 세팅
        {
            colorset = color.getColor();
        }
        
        public void setCount(int setcount)  //몇개의 중요지점을 찾았는지 세팅
        {
            count = setcount;
        }
        public void initPath()      // 초기경로 초기화
        {
            getColor();
            setCount(0);
        }
        public void getPath(int[] robot, List<int> path)
        {
            int originalcount;
            originalcount = count;
            path.Clear();   // 경로 초기화
            while (count < colorset.Count)
            {
                robot=createPath(colorset[count], path, robot);
                count++;
            }
            setCount(originalcount);
        }

        public int[] createPath(int[] target, List<int> path, int[] robot) {
            int[] mapsize = mapin.getSize();
            int[] nextMove = new int[2];
            int x, y, gox, goy;
            int check;
            x = robot[0];
            y = robot[1];

            getHazard();

            Start:
            gox = target[0] - x; //가야할 x이동방향,횟수 (목표위치-현재위치)
            goy = target[1] - y; //가야할 y이동방향,횟수

            //직각이동
            if (gox >= 0 && goy >= 0) //둘다 0보다 크거나 같음 = 오른쪽, 아래 직선 + 오른쪽 아래방향의 직각이동
            {
                check = RDangle(target, gox, goy,x,y, path);

                if (check == 0)
                {// 길이 없음 + RD => 오른 아래
                    if (((xnoAngle(x, y, 1, mapsize)) > -1))  //-1보다 크면 x변경
                    {
                        x = xnoAngle(x, y, 1, mapsize); //x+1
                        updateX(x, robot[0], path);
                        goto Start;
                    } //x+1
                    else if (((ynoAngle(x, y, 1, mapsize)) > -1)) // x+1이 불가능하면 y+1 확인
                    {
                        y = ynoAngle(x, y, 1, mapsize); //y+1
                        updateY(y, robot[1], path);
                        goto Start;
                    } //y+1
                }
            }
            else if (gox <= 0 && goy <= 0) // 둘다 0보다 작거나 같음 = 왼쪽, 위 직선 + 왼쪽 위 방향의 직각이동
            {
                check = LUangle(target, gox, goy,x,y, path);

                if (check == 0)
                {// 길이 없음 +LU => 왼위
                    if (((xnoAngle(x, y, -1, mapsize)) > -1))  //-1보다 크면 x변경
                    {
                        x = xnoAngle(x, y, -1, mapsize); //x-1
                        updateX(x, robot[0], path);
                        goto Start;
                    } //x+1
                    else if (((ynoAngle(x, y, -1, mapsize)) > -1)) // x+1이 불가능하면 y+1 확인
                    {
                        y = ynoAngle(x, y, -1, mapsize); //y-1
                        updateY(y, robot[1], path);
                        goto Start;
                    } //y+1
                }                
            }
            else if (gox > 0 && goy < 0) // x는 증가(아래로) y는 감소(왼쪽) 이동
            {
                check = LDangle(target, gox, goy, x, y, path);
                if (check == 0)
                {// 길이 없음 + LD => 왼아래 
                    if (((xnoAngle(x, y, 1, mapsize)) > -1))  //-1보다 크면 x변경
                    {
                        x = xnoAngle(x, y, 1, mapsize); //x+1
                        updateX(x, robot[0], path);
                        goto Start;
                    } //x+1
                    else if (((ynoAngle(x, y, -1, mapsize)) > -1)) // x+1이 불가능하면 y+1 확인
                    {
                        y = ynoAngle(x, y, -1, mapsize); //y-1
                        updateY(y, robot[1], path);
                        goto Start;
                    } //y+1
                }                //길을 찾으면 확인
            }
            else if (gox < 0 && goy > 0) // x는 감소(위로) y는 증가(오른쪽) 이동
            {
                check = RUangle(target, gox, goy, x, y, path);
                if (check == 0)
                {// 길이 없음 + RU => 오른 위
                    if (((xnoAngle(x, y, -1, mapsize)) > -1))  //-1보다 크면 x변경
                    {
                        x = xnoAngle(x, y, -1, mapsize); //x-1
                        updateX(x, robot[0], path);
                        goto Start;
                    } //x+1
                    else if (((ynoAngle(x, y, 1, mapsize)) > -1)) // x+1이 불가능하면 y+1 확인
                    {
                        y = ynoAngle(x, y, 1, mapsize); //y+1
                        updateY(y, robot[1], path);
                        goto Start;
                    } //y+1
                }                //    if (path.Count > 0) return path;//길을 찾으면 리턴
            }

            nextMove[0] = target[0];
            nextMove[1] = target[1];
            return nextMove;
        }
        private void updateX(int x, int start, List<int> path) {

            if (x - start > 0) {
                path.Add(1); //아래 x+1= 행증가
            }
            else path.Add(0); //0보다 작으면 시작위치보다 작은 값 = 행 감소 = 위로
        }

        private void updateY(int y, int start, List<int> path)
        {
            if (y - start > 0)
            {
                path.Add(3); //아래 y+1= 열증가
            }
            else path.Add(2); //0보다 작으면 시작위치보다 작은 값
        }

        private int xnoAngle(int x, int y, int go, int[] mapsize)
        {
            int tempx;
            int tempy;
            int dir;
            //0상 1하 2좌 3우
            tempx = x; tempy = y;
            dir = updown(tempx, tempy, mapsize[0], go);
            if (dir == 1) //방향 = 0 이동 불가, 이동 불가가 아닌 경우
            {
                x = x + dir;
                return x;
            }
            else if (dir == -1) {
                x = x + dir;
                return x;
            }
            else return -1;
        }
        private int ynoAngle(int x, int y, int go, int[] mapsize) {
            int tempx;
            int tempy;
            int dir;
            tempx = x; tempy = y;

            dir = leftright(tempx, tempy, mapsize[1], go);
            if (dir == 1) //방향 = 0 이동 불가, 이동 불가가 아닌 경우
            {
                y = y + dir;
                return y;
            }
            else if (dir == -1)
            {
                y = y+ dir;
                return y;
            }
            else return -1;
        }

        private int updown(int tempx, int tempy, int maprow, int dir) {
            int danger = 0;

            if (tempx + dir < maprow) // 지도 행 개수 안 벗어나면
            {
                danger = checkhazard(tempx + dir, tempy, 0, 0);
                if (danger == 0) return dir;
            }
            else if (0<=tempx + dir) // 지도 행 개수 안 벗어나면
            {
                danger = checkhazard(tempx + dir, tempy, 0, 0);
                if (danger == 0) return dir;
            }
            else // 지도 행 개수 벗어나면
            {
                danger = checkhazard(tempx - dir, tempy, 0, 0);
                if (danger == 0) return -dir;
            }
            return 0;
        }

        private int leftright(int tempx, int tempy, int mapcol, int dir)
        {
            int danger = 0;
            
            if (tempy + dir < mapcol) // 지도 열 개수 안 벗어나면
            {
                danger = checkhazard(tempx, tempy + dir, 0, 0);
                if (danger == 0) return dir;
                else return 0;
            }
            else if (0 <= tempx + dir) // 지도 행 개수 안 벗어나면
            {
                danger = checkhazard(tempx, tempy + dir, 0, 0);
                if (danger == 0) return dir;
                else return 0;
            }
            else // 지도 열 개수 벗어나면
            {
                danger = checkhazard(tempx, tempy - dir, 0, 0);
                if (danger == 0) return -dir;
                else return 0;
            }
        }

        private int checkhazard(int tempx, int tempy, int gox, int goy) {
            int i;
            int hx, hy;
            int danger=0;
            for (i = 0; i < hazardset.Count; i++)
            {//현재위치에서 목표지점까지 좌표만 바꿔가며 위험지역 있는지 확인
                hx = hazardset[i][0];
                hy = hazardset[i][1];
                if ((hx == (tempx + gox)) &&( hy == (tempy+goy)))
                {
                    danger = 1; //위험지역 있음 표시 - 입력된 위험
                    break;
                }
                //센서체크 if(센서값)
            }//위험확인 종료
            return danger;
        }

        private int RDangle(int[] target, int gox, int goy, int x, int y,List<int> path) //gox, goy=양수
        {
            int tempx, tempy;
            int i, count=0;
            int rdanger = 0, cdanger = 0; //rdanger=x방향 위험 여부, cdanger=y방향 위험 여부

            //x->y
            for (i = 0; i <= gox; i++)
            {
                rdanger = checkhazard(x, y, i, 0);
                if (rdanger == 1) break;
                //현 위치 기준으로 gox만큼떨어진 곳까지 위험 존재 확인
            } //x방향 위험 확인 완료

            if (rdanger == 0)   //x방향으로는 위험지역이 없을 때
            {
                tempx = x + gox;
                for (i = 0; i <= goy; i++)
                {
                    cdanger = checkhazard(tempx, y, 0, i);
                    if (cdanger == 1) break;
                    //현 위치 기준으로 goy만큼떨어진 곳까지 위험 존재 확인
                }//y방향 위험 확인 완료
                if (cdanger == 0)
                {  //y방향으로도 위험지역이 없을 때
                   //x->y로 이동
                    for (i = 0; i < gox; i++)
                    {
                        path.Add(1);
                        count++;
                        //    x = x + 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                    for (i = 0; i < goy; i++)
                    {
                        path.Add(3);
                        count++;
                        // y = y + 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                }
            }
            if ((rdanger == 1) || (cdanger == 1))// x방향으로 위험지역이 있을 때
            {
                for (i = 0; i <= goy; i++)
                {
                    cdanger = checkhazard(x, y, 0, i);
                    if (cdanger == 1) break;
                }//y방향 위험 확인 완료

                if (cdanger == 0)       //y방향으로는 위험지역이 없을 때
                {
                    tempy = y + goy;
                    for (i = 0; i <= gox; i++)
                    {
                        rdanger = checkhazard(x, tempy, i, 0);
                        if (rdanger == 1) break;
                    } //x방향 위험 확인 완료

                    if (rdanger == 0)   //y방향으로 이동후 x방향으로 위험지역이 없을 때
                    {
                        //y->x로 이동
                        for (i = 0; i < goy; i++)
                        {
                            path.Add(3);
                            count++;
                            //y = y + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                        for (i = 0; i < gox; i++)
                        {
                            path.Add(1);
                            count++;
                            //x = x + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                    }
                }
            }
            if (count > 0) return 1;
            else return 0;
        }
        private int LUangle(int[] target, int gox, int goy, int x, int y, List<int> path) //gox, goy=음수
        {
            int tempx, tempy;
            int i, count=0;
            int rdanger = 0, cdanger = 0; //rdanger=x방향 위험 여부, cdanger=y방향 위험 여부

            //x->y
            for (i = gox; i <= 0; i++)
            {
                rdanger = checkhazard(x, y, i, 0);
                if (rdanger == 1) break;
                //현 위치 기준으로 gox만큼떨어진 곳까지 위험 존재 확인
            } //x방향 위험 확인 완료

            if (rdanger == 0)   //x방향으로는 위험지역이 없을 때
            {
                tempx = x + gox;
                for (i = goy; i <=0; i++)
                {
                    cdanger = checkhazard(tempx, y, 0, i);
                    if (cdanger == 1) break;
                    //현 위치 기준으로 goy만큼떨어진 곳까지 위험 존재 확인
                }//y방향 위험 확인 완료
                if (cdanger == 0)
                {  //y방향으로도 위험지역이 없을 때
                   //x->y로 이동
                    for (i = 0; i < Math.Abs(gox); i++)
                    {
                        path.Add(0);
                        count++;
                        // x = x - 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                    for (i = 0; i < Math.Abs(goy); i++)
                    {
                        path.Add(2);
                        count++;
                        // y = y - 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                }
            }
            if ((rdanger == 1) || (cdanger == 1))// x방향으로 위험지역이 있을 때
            {
                for (i = goy; i <= 0; i++)
                {
                    cdanger = checkhazard(x, y, 0, i);
                    if (cdanger == 1) break;
                }//y방향 위험 확인 완료

                if (cdanger == 0)       //y방향으로는 위험지역이 없을 때
                {
                    tempy = y + goy;
                    for (i = gox; i <= 0 ; i++)
                    {
                        rdanger = checkhazard(x, tempy, i, 0);
                        if (rdanger == 1) break;
                    } //x방향 위험 확인 완료

                    if (rdanger == 0)   //y방향으로 이동후 x방향으로 위험지역이 없을 때
                    {
                        //y->x로 이동
                        for (i = 0; i < Math.Abs(goy); i++)
                        {
                            path.Add(2);
                            count++;
                            //y = y + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                        for (i = 0; i < Math.Abs(gox); i++)
                        {
                            path.Add(0);
                            count++;
                            //x = x + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                    }
                }
            }
            if (count > 0) return 1;
            else return 0;
        }
        private int LDangle(int[] target, int gox, int goy, int x, int y, List<int> path) //gox=양수, goy=음수
        {
            int tempx, tempy;
            int i, count=0;
            int rdanger = 0, cdanger = 0; //rdanger=x방향 위험 여부, cdanger=y방향 위험 여부
            //x->y
            for (i = 0; i <=gox; i++)
            {
                rdanger = checkhazard(x, y, i, 0);
                if (rdanger == 1) break;
                //현 위치 기준으로 gox만큼떨어진 곳까지 위험 존재 확인
            } //x방향 위험 확인 완료

            if (rdanger == 0)   //x방향으로는 위험지역이 없을 때
            {
                tempx = x + gox;
                for (i = goy; i <=0; i++)
                {
                    cdanger = checkhazard(tempx, y, 0, i);
                    if (cdanger == 1) break;
                    //현 위치 기준으로 goy만큼떨어진 곳까지 위험 존재 확인
                }//y방향 위험 확인 완료
                if (cdanger == 0)
                {  //y방향으로도 위험지역이 없을 때
                   //x->y로 이동
                    for (i = 0; i < Math.Abs(gox); i++)
                    {
                        path.Add(1);
                        count++;
                        //    x = x + 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                    for (i = 0; i < Math.Abs(goy); i++)
                    {
                        path.Add(2);
                        count++;
                        // y = y - 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                }
            }
            if ((rdanger == 1) || (cdanger == 1))// x방향으로 위험지역이 있을 때
            {
                for (i = goy; i <=0; i++)
                {
                    cdanger = checkhazard(x, y, 0, i);
                    if (cdanger == 1) break;
                }//y방향 위험 확인 완료

                if (cdanger == 0)       //y방향으로는 위험지역이 없을 때
                {
                    tempy = y + goy;
                    for (i = 0; i <=gox; i++)
                    {
                        rdanger = checkhazard(x, tempy, i, 0);
                        if (rdanger == 1) break;
                    } //x방향 위험 확인 완료

                    if (rdanger == 0)   //y방향으로 이동후 x방향으로 위험지역이 없을 때
                    {
                        //y->x로 이동
                        for (i = 0; i < Math.Abs(goy); i++)
                        {
                            path.Add(2);
                            count++;
                            //y = y - 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                        for (i = 0; i < Math.Abs(gox); i++)
                        {
                            path.Add(1);
                            count++;
                            //x = x + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                    }
                }
            }
            if (count > 0) return 1;
            else return 0;
        }
        private int RUangle(int[] target, int gox, int goy, int x, int y, List<int> path) //gox=음수, goy=양수
        {
            int tempx, tempy;
            int i, count=0;
            int rdanger=0, cdanger=0;

            //x->y
            for (i = gox; i <=0; i++)
            {
                rdanger = checkhazard(x, y, i, 0);
                if (rdanger == 1) break;
                //현 위치 기준으로 gox만큼떨어진 곳까지 위험 존재 확인
            } //x방향 위험 확인 완료

            if (rdanger == 0)   //x방향으로는 위험지역이 없을 때
            {
                tempx = x + gox;
                for (i = 0; i <=goy; i++)
                {
                    cdanger = checkhazard(tempx, y, 0, i);
                    if (cdanger == 1) break;
                    //현 위치 기준으로 goy만큼떨어진 곳까지 위험 존재 확인
                }//y방향 위험 확인 완료
                if (cdanger == 0)
                {  //y방향으로도 위험지역이 없을 때
                   //x->y로 이동
                    for (i = 0; i < Math.Abs(gox); i++)
                    {
                        path.Add(0);
                        count++;
                        //    x = x - 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                    for (i = 0; i < Math.Abs(goy); i++)
                    {
                        path.Add(3);
                        count++;
                        // y = y - 1;
                        //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                    }
                }
            }
            if ((rdanger == 1)||(cdanger==1))// 앞의 검사에서 x나 y방향으로 위험지역이 있을 때
            {
                for (i = 0; i <=goy; i++)
                {
                    cdanger = checkhazard(x, y, 0, i);
                    if (cdanger == 1) break;
                }//y방향 위험 확인 완료

                if (cdanger == 0)       //y방향으로는 위험지역이 없을 때
                {
                    tempy = y + goy;
                    for (i = gox; i <=0; i++)
                    {
                        rdanger = checkhazard(x, tempy, i, 0);
                        if (rdanger == 1) break;
                    } //x방향 위험 확인 완료

                    if (rdanger == 0)   //y방향으로 이동후 x방향으로 위험지역이 없을 때
                    {
                        //y->x로 이동
                        for (i = 0; i < Math.Abs(goy); i++)
                        {
                            path.Add(3);
                            count++;
                            //y = y + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                        for (i = 0; i < Math.Abs(gox); i++)
                        {
                            path.Add(0);
                            count++;
                            //x = x + 1;
                            //센서체크 후 위험 발견시 start로 중요 발견시 표시, 없으면 진행
                        }
                    }
                }
            }
            if (count > 0) return 1;
            else return 0;
        }
    }
}
