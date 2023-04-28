using CLARogueLikeGame.Models;

namespace CLARogueLikeGame.GameTypes
{
    internal class GameEntites
    {
        internal List<Entity> entitesList;

        internal GameEntites() 
        {
            entitesList = new();
        }

        private static Entity GetEntity(int entityX, int entityY, string entityType, string diraction) => entityType switch
        {
            "Rock" => new Rock(entityX, entityY),
            "Door" => new Door(entityX, entityY, diraction),
            "Coin" => new Coin(entityX, entityY),
            _ => new UninitializedEntity(entityX, entityY),
        };

        internal void AddEntity(int entityX, int entityY, string entityType, string diraction)
        {
            Entity entity = GetEntity(entityX, entityY, entityType, diraction);
            entitesList.Add(entity);
        }

        internal void Clear()
        {
            entitesList.Clear();
        }
    }
}
