using CLARogueLikeGame.GameMapTemplates;
using CLARogueLikeGame.GameTypes;
using CLARogueLikeGame.Models;

Game.Init();

namespace Core
{
    public static class Game
    {
        internal static GameEntites entites = new();
        internal static GameTimer timer = new();
        //Make 16x8 area (ignoring the walls)
        internal static GameMap map = new(new string[,]
        {
            {"|", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "|" }
        });

        private static Player player = new();

        //Game entry point
        public static void Init()
        {
            foreach (GameMapTemplateEntity rawEntity in new GameMapTemplate1().GetEntitesList())
            {
                entites.AddEntity(rawEntity.x, rawEntity.y, rawEntity.type);
            }

            Draw();
            Loop();
        }

        //Main game loop
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
            catch (InvalidOperationException)
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
