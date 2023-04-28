namespace CLARogueLikeGame.Models
{
    internal abstract class Entity
    {
        internal int x, y;
        internal string texture, type, diraction;

        internal Entity(int x = 2, int y = 2)
        {
            this.x = x; this.y = y;
            texture = "E";
            type = "Entity";
            diraction = "left";
        }

        internal virtual void Print()
        {
            Console.WriteLine("Entity.print");
        }

        internal virtual void Draw(string texture)
        {
            this.texture = texture;
        }

        internal virtual void Collision() 
        {
            Console.WriteLine("Collision!");
        }
    }
}
