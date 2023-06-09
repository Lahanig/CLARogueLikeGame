﻿using CLARogueLikeGame.GameMapTemplates;
using CLARogueLikeGame.GameTypes;
using CLARogueLikeGame.Models;

Game.Init();

namespace Core
{
    internal static class Game
    {
        internal static GameEntites entites = new();
        internal static GameTimer timer = new();
        //Make 17x9 area (ignoring the walls)
        internal static GameMap map = new(new string[,]
        {
            {"|", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
            {"|", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "=", "|" }
        });

        private static readonly Player player = new();

        //Game entry point
        internal static void Init()
        {
            RandomizeGameMapTemplate();
            Draw();
            Loop();
        }

        internal static void RandomizeGameMapTemplate()
        {
            Player.isBlockMoving = true;
            List<GameMapTemplate> gameMapTemplates = new()
            {
                new GameMapTemplate1(),
                new GameMapTemplate2(),
            };

            Random rnd = new();
            int tempGameMapTemplateID = rnd.Next(0, gameMapTemplates.Count);

            //Adds to the list of game entities, entities from a random template 
            entites.Clear();

            foreach (GameMapTemplateEntity rawEntity in gameMapTemplates[tempGameMapTemplateID].GetEntitesList())
            {
                entites.AddEntity(rawEntity.x, rawEntity.y, rawEntity.type, rawEntity.direction);
            }

            Player.isBlockMoving = false;
        }

        private static void GameEnd()
        {
            if (Player.money >= 100)
            {
                Console.WriteLine("You won!");
                return;
            }

            if (Player.hp <= 0)
            {
                Console.WriteLine("You lose!");
                return;
            }

            Console.WriteLine("Game closed");
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

                if (player.currentKey.Key == ConsoleKey.Escape || Player.hp < 0) 
                {
                    GameEnd(); 

                    return; 
                }
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

            DrawEntity();

            map.area[Player.y, Player.x] = player.texture;

            map.View();
            map.ToDefault();
        }

        private static void DrawEntity()
        {
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
                DrawEntity();
            }
        }

        internal static void Collision(Entity entity) 
        {
            int Ex = entity.x;
            int Ey = entity.y;
            int Px = Player.x;
            int Py = Player.y;

            if ((Px == Ex) && (Py == Ey))
            {
                entity.Collision();
            };
        }
    } 
}
