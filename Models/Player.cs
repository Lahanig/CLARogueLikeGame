using System.Runtime.CompilerServices;

namespace CLARogueLikeGame.Models
{
    internal class Player : Entity
    {
        private new string diraction = "left";
        internal PlayerCollisionRay collisionRay;
        internal ConsoleKeyInfo currentKey;
        internal static int money = 0;
        internal static new int x = 2;
        internal static new int y = 2;
        internal static bool isBlockMoving = false;

        public Player() : base()
        {
            collisionRay = new(x, y, diraction);
            texture = "P";
            type = "Player";
        }

        public override void Print()
        {
            Console.WriteLine($"Debug log: \n" +
                $"Player x: {x}, y: {y}, diraction: {diraction}, collision ray x: {collisionRay.x}, y: {collisionRay.y}, diraction: {collisionRay.diraction}" +
            $"\n");

            Console.WriteLine($"Money: {money} \n");
        }

        public void Update()
        {   
            if (Console.KeyAvailable && isBlockMoving == false) 
            {
                currentKey = Console.ReadKey(true);

                if (currentKey.Key != ConsoleKey.Escape)
                {
                    texture = currentKey.KeyChar.ToString();
                }
                else
                {
                    Console.WriteLine("Quit game");
                    return;
                }

                switch (currentKey.Key)
                {
                    case ConsoleKey.W:
                        if (Game.map.area[y - 1, x] != "=") y--;
                        diraction = "top";
                        break;
                    case ConsoleKey.S:
                        if (Game.map.area[y + 1, x] != "=") y++;
                        diraction = "down";
                        break;
                    case ConsoleKey.A:
                        if (Game.map.area[y, x - 1] != "|") x--;
                        diraction = "left";
                        break;
                    case ConsoleKey.D:
                        if (Game.map.area[y, x + 1] != "|") x++;
                        diraction = "right";
                        break;
                }

                collisionRay.diraction = diraction;
                collisionRay.SetPosition(x, y);
            }
        }
    }

    internal struct PlayerCollisionRay
    {
        public int x; public int y;
        public string diraction;

        public PlayerCollisionRay(int playerX, int playerY, string playerDiraction)
        {
            x = playerX; y = playerY;
            diraction = playerDiraction;
        }

        public void SetPosition(int playerX, int playerY)
        {
            x = playerX; y = playerY;
            switch (diraction) 
            {
                case "left":
                    x--;
                    break;
                case "right":
                    x++;
                    break;
                case "top":
                    y--;
                    break;
                case "down":
                    y++;
                    break;
            }
        }
    }
}
