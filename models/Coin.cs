namespace CLARogueLikeGame.Models
{
    internal class Coin : Entity
    {
        public int money = 5;

        public Coin()
        {
            texture = "C";
            type = "Coin";
            x = 5; y = 5;
        }

        public override void Collision()
        {
            Player.money += money;
            Game.entites.entitesList.Remove(this);
        }
    }
}
