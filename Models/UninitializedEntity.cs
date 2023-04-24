namespace CLARogueLikeGame.Models
{
    internal class UninitializedEntity : Entity
    {
        internal UninitializedEntity(int x = 2, int y = 2) : base(x, y)
        {
            type = "UninitializedEntity";
        }
    }
}
