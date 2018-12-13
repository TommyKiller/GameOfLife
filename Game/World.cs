using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    public class World
    {
        private readonly int _seed;
        private int _populationRate;
        private Random random;
        public int[,] Map { get; private set; }
        public int MapHeight { get; private set; }
        public int MapWidth { get; private set; }

        public World(int seed)
        {
            _seed = seed;
            random = new Random(seed);
        }

        public void GenerateNewMap(int mapHeight, int mapWidth, int populationRate)
        {
            _populationRate = populationRate;
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            Map = new int[MapHeight, MapWidth];

            for (int y = 0; y < MapHeight; ++y)
            {
                for (int x = 0; x < MapWidth; ++x)
                {
                    int chance = random.Next(101);
                    if (chance <= _populationRate)
                    {
                        Map[y, x] = 1;
                    }
                    else
                    {
                        Map[y, x] = 0;
                    }
                }
            }
        }

        public void SetMap(Type sender, int[,] newMap)
        {
            if (sender == typeof(Game))
            {
                Map = newMap;
            }
        }
    }
}
