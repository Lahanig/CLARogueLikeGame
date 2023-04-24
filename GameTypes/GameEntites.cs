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

        private static Entity GetEntity(int entityX, int entityY, string entityType) => entityType switch
        {
            "Coin" => new Coin(entityX, entityY),
            _ => new UninitializedEntity(entityX, entityY),
        };

        public void AddEntity(int entityX, int entityY, string entityType)
        {
            Entity entity = GetEntity(entityX, entityY, entityType);
            entitesList.Add(entity);
        }
    }
}
