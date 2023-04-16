using Core;

string[,] gameMap = new string[,]
{
    {"|", "=", "=", "=", "=", "=", "=", "=", "|" },
    {"|", " ", " ", " ", " ", " ", " ", " ", "|" },
    {"|", " ", " ", " ", " ", " ", " ", " ", "|" },
    {"|", " ", " ", " ", " ", " ", " ", " ", "|" },
    {"|", "=", "=", "=", "=", "=", "=", "=", "|" }
};

Game game = new(gameMap);
game.Loop();

namespace Core
{
    public class Game
    {
        private GameMap map;
        public Game(string[,] area)
        {
            map = new(area);

            Init();
        }
        private void Init()
        {
            map.View();
        }

        public void Loop()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Clear();
                map.View();
                key = Console.ReadKey();
                Console.WriteLine("\\Quit game");

                if (key.Key != ConsoleKey.Escape)
                {
                    map.area[2, 4] = key.KeyChar.ToString();
                }
                else return;

                if (key.Key == ConsoleKey.R)
                {
                    map.ToDefault();
                }
            }
        }
    }

    internal struct GameMap
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