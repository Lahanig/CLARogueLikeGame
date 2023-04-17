using CLARogueLikeGame.Models;

string[,] gameMap = new string[,]
{
    {"|", "=", "=", "=", "=", "=", "=", "=", "|" },
    {"|", " ", " ", " ", " ", " ", " ", " ", "|" },
    {"|", " ", " ", " ", " ", " ", " ", " ", "|" },
    {"|", " ", " ", " ", " ", " ", " ", " ", "|" },
    {"|", "=", "=", "=", "=", "=", "=", "=", "|" }
};

Game game = new(gameMap);
game.Init();

namespace Core
{
    public class Game
    {
        private GameMap map;
        private Player player = new();

        public Game(string[,] area)
        {
            map = new(area);
        }

        public void Init()
        {
            map.View();

            Loop();
        }

        public void Loop()
        {
            while (true)
            {
                Update();
                Draw();

                if (player.currentKey.Key == ConsoleKey.Escape) return;
            }
        }

        private void Update()
        {
            player.Update();
        }

        private void Draw()
        {
            Console.Clear();

            player.Print();
            player.Draw("P");

            map.area[player.y, player.x] = player.texture;

            map.View();
            map.ToDefault();
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