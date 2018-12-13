using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    public class Game
    {
        public bool IsStarted { get; private set; }
        public World World { get; private set; }

        public Game()
        {
            IsStarted = false;
        }

        public void StartNew(int seed, int mapHeight, int mapWidth, int populationRate)
        {
            World = new World(seed);
            World.GenerateNewMap(mapHeight, mapWidth, populationRate);
            IsStarted = true;
        }

        public void EndGame()
        {
            World = null;
            IsStarted = false;
        }

        public void Iterate()
        {
            int[,] tempMap = new int[World.MapHeight, World.MapWidth];

            for (int y = 0; y < World.MapHeight; ++y)
            {
                for (int x = 0; x < World.MapWidth; ++x)
                {
                    int cellsAliveCounter = 0;
                    for (int y1 = y - 1; y1 <= y + 1; ++y1)
                    {
                        for (int x1 = x - 1; x1 <= x + 1; ++x1)
                        {
                            int xcoord, ycoord;

                            if (x1 < 0)
                            {

                                xcoord = (World.MapWidth - 1);
                            }
                            else if (x1 == World.MapWidth)
                            {
                                xcoord = 0;
                            }
                            else
                            {
                                xcoord = x1;
                            }

                            if (y1 < 0)
                            {
                                ycoord = (World.MapHeight - 1);
                            }
                            else if (y1 == World.MapHeight)
                            {
                                ycoord = 0;
                            }
                            else
                            {
                                ycoord = y1;
                            }

                            if (World.Map[ycoord, xcoord] == 1) ++cellsAliveCounter;
                        }
                    }

                    if (World.Map[y, x] == 0 && cellsAliveCounter == 3)
                        tempMap[y, x] = 1;
                    else if (World.Map[y, x] == 1 && (cellsAliveCounter == 3 || cellsAliveCounter == 4))
                        tempMap[y, x] = 1;
                    else
                        tempMap[y, x] = 0;
                }
            }

            World.SetMap(GetType(), tempMap);
        }
    }
}
