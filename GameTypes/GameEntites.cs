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

        private static Entity GetEntity(int entityX, int entityY, string entityType, string diraction) => entityType switch
        {
            "Door" => new Door(entityX, entityY, diraction),
            "Coin" => new Coin(entityX, entityY),
            _ => new UninitializedEntity(entityX, entityY),
        };

        public void AddEntity(int entityX, int entityY, string entityType, string diraction)
        {
            Entity entity = GetEntity(entityX, entityY, entityType, diraction);
            entitesList.Add(entity);
        }

        public void Clear()
        {
            entitesList.Clear();
        }
    }
}
