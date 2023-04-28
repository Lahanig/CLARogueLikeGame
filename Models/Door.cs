namespace CLARogueLikeGame.Models
{
    internal class Door : Entity
    {
        public Door(int x = 2, int y = 2, string? diraction = null) : base(x, y)
        {
            texture = "#";
            type = "Door";
            this.diraction = diraction??"left";
        }

        internal override void Collision()
        {
            _ = (y == 10 || y == 0) ? Game.map.area[y, x] = "=" : Game.map.area[y, x] = "|";

            switch (diraction) 
            {
                case "left":
                    Player.x = x + 2;
                    break;

                case "right":
                    Player.x = x - 2;
                    break;

                case "top":
                    Player.y = y + 2;
                    break;

                case "bottom":
                    Player.y = y - 2;
                    break;
            }

            Game.RandomizeGameMapTemplate();
            Game.entites.entitesList.Remove(this);
        }
    }
}
