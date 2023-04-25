using CLARogueLikeGame.GameMapTemplates;
using CLARogueLikeGame.GameTypes;
using CLARogueLikeGame.Models;

Game.Init();

namespace Core
{
    internal static class Game
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
        internal static void Init()
        {
            RandomizeGameMapTemplate();
            Draw();
            Loop();
        }

        internal static void RandomizeGameMapTemplate()
        {
            List<GameMapTemplate> gameMapTemplates = new()
            {
                new GameMapTemplate1(),
                new GameMapTemplate2(),
            };

            Random rnd = new();
            int tempGameMapTemplateID = rnd.Next(0, gameMapTemplates.Count);

            //Adds to the list of game entities, entities from a random template 
            foreach (GameMapTemplateEntity rawEntity in gameMapTemplates[tempGameMapTemplateID].GetEntitesList())
            {
                entites.AddEntity(rawEntity.x, rawEntity.y, rawEntity.type);
            }
        }

        //Main game loop
        private static void Loop()
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
