namespace CLARogueLikeGame.Models
{
    internal class Player : Entity
    {
        public ConsoleKeyInfo currentKey;
        public Player() : base()
        {
            Console.WriteLine($"{x} {y}");
        }

        public override void Print()
        {
            Console.WriteLine($"{x} {y}");
        }

        public void Update()
        {
            currentKey = Console.ReadKey(true);
            if (currentKey.Key != ConsoleKey.Escape)
            {
                texture = currentKey.KeyChar.ToString();
            }
            else
            {
                Console.WriteLine("\\Quit game");
                return;
            }

            switch (currentKey.Key) 
            {
                case ConsoleKey.W:
                    y--;
                    break;
                case ConsoleKey.S:
                    y++;
                    break;
                case ConsoleKey.A:
                    x--;
                    break;
                case ConsoleKey.D:
                    x++;
                    break;
            }
        }
    }
}
