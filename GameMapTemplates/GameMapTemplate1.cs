namespace CLARogueLikeGame.GameMapTemplates
{
    internal class GameMapTemplate1 : IGameMapTemplate
    {
        private readonly List<GameMapTemplateEntity> EntitiesList = new() {
            new GameMapTemplateEntity (5, 5, "Coin"), new GameMapTemplateEntity (16, 8, "Coin")
        };
        List<GameMapTemplateEntity> IGameMapTemplate.GameMapTemplateEntities { get => EntitiesList; }

        public List<GameMapTemplateEntity> GetEntitesList() => EntitiesList;
    }
}
