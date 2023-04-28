namespace CLARogueLikeGame.Models
{
    internal class Rock : Entity
    {
        private int damage = 10;
        internal Rock(int x = 2, int y = 2) : base(x, y)
        {
            texture = "^";
            type = "Rock";
        }

        internal override void Collision()
        {
            Player.hp -= damage;
        }
    }
}
