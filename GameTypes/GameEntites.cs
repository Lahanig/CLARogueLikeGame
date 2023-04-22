using CLARogueLikeGame.Models;

namespace CLARogueLikeGame.GameTypes
{
    internal struct GameEntites
    {
        public List<Entity> entitesList;

        public GameEntites() 
        {
            entitesList = new();
        }

        public Entity GetEntity(Entity entity)
        {
            return entity.type switch
            {
                "Coin" => new Coin(),
                _ => new UninitializedEntity(),
            };
        }

        public void AddEntity(Entity entity)
        {
            entity = GetEntity(entity);
            entitesList.Add(entity);
        }
    }
}
