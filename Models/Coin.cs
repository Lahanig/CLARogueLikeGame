namespace CLARogueLikeGame.Models
{
    internal class Coin : Entity
    {
        public int money = 5;

        public Coin(int x = 2, int y = 2) : base(x, y)
        {
            texture = "C";
            type = "Coin";
        }

        public override void Collision()
        {
            Player.money += money;
            Game.entites.entitesList.Remove(this);
        }
    }
}
