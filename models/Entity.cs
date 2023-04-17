namespace CLARogueLikeGame.Models
{
    internal abstract class Entity
    {
        internal int x; internal int y;
        internal string texture;

        public Entity()
        {
            x = 2; y = 2;
            texture = "E";
        }

        public virtual void Print()
        {
            Console.WriteLine("Entity.print");
        }

        public virtual void Draw(string texture)
        {
            this.texture = texture;
        }
    }
}
