namespace CLARogueLikeGame.Models
{
    public abstract class Entity
    {
        internal int x, y;
        internal string texture, type;

        public Entity()
        {
            x = 2; y = 2;
            texture = "E";
            type = "Entity";
        }

        public virtual void Print()
        {
            Console.WriteLine("Entity.print");
        }

        public virtual void Draw(string texture)
        {
            this.texture = texture;
        }

        public virtual void Collision() 
        {
            Console.WriteLine("Collision!");
        }
    }
}
