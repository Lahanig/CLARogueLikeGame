using CLARogueLikeGame.Models;

Game.Init();

namespace Core
{
    public static class Game
    {
        public static GameMap map = new(new string[,]
        {
            {"|", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "|" }
        });

        private static Player player = new();

        public static void Init()
        {
            Draw();
            Loop();
        }

        public static void Loop()
        {
            while (true)
            {
                Update();
                Draw();

                if (player.currentKey.Key == ConsoleKey.Escape) return;
            }
        }

        private static void Update()
        {
            player.Update();
        }

        private static void Draw()
        {
            Console.Clear();

            player.Print();
            player.Draw("P");

            map.area[player.y, player.x] = player.texture;

            map.View();
            map.ToDefault();
        }

        public static bool Collision() 
        {
            switch (map.area[player.collisionRay.y, player.collisionRay.x])
            {
                case " ":
                    return false;
                default: return true;
            }
        }
    }

    public struct GameMap
    {
        public string[,] area;
        public int rows, columns;
        public GameMap(string[,] map)
        {
            area = map;

            rows = area.GetUpperBound(0) + 1;
            columns = area.Length / rows;
        }

        public void View()
        {
            try
            {
                rows = area.GetUpperBound(0) + 1;
                columns = area.Length / rows;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(area[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            
        }

        public void ToDefault()
        {
            rows = area.GetUpperBound(0) + 1;
            columns = area.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (area[i, j] != "|" && area[i, j] != "=") area[i, j] = " ";
                }
            }
        }
    }
}