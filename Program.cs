using CLARogueLikeGame.GameTypes;
using CLARogueLikeGame.Models;

Game.Init();

namespace Core
{
    public static class Game
    {
        internal static GameEntites entites = new();
        internal static GameTimer timer = new();
        internal static GameMap map = new(new string[,]
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
            entites.AddEntity(new Coin());
            Draw();
            Loop();
        }

        public static void Loop()
        {
            while (true)
            {
                Update();
                if (timer.Timer(5300) == true)
                {
                    Draw();
                }

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

            try
            {
                foreach (Entity entity in entites.entitesList)
                {
                    map.area[entity.y, entity.x] = entity.texture;

                    Collision(entity);
                }
            }
            catch (System.InvalidOperationException)
            {
                foreach (Entity entity in entites.entitesList)
                {
                    map.area[entity.y, entity.x] = entity.texture;

                    Collision(entity);
                }
            }

            map.area[player.y, player.x] = player.texture;

            map.View();
            map.ToDefault();
        }

        public static void Collision(Entity entity) 
        {
            int Ex = entity.x;
            int Ey = entity.y;
            int Px = player.x;
            int Py = player.y;

            if ((Px == Ex) && (Py == Ey))
            {
                entity.Collision();
            };
        }
    } 
}
