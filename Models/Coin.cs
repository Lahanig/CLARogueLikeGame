namespace CLARogueLikeGame.Models
{
    internal class Coin : Entity
    {
        internal int money = new Random().Next(0, 5);

        internal Coin(int x = 2, int y = 2) : base(x, y)
        {
            texture = "C";
            type = "Coin";
        }

        internal override void Collision()
        {
            Player.money += money;
            Game.entites.entitesList.Remove(this);
        }
    }
}
