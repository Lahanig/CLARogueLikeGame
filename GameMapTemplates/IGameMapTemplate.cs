namespace CLARogueLikeGame.GameMapTemplates
{
    internal interface IGameMapTemplate
    {
        List<GameMapTemplateEntity> GameMapTemplateEntities { get; }

        public List<GameMapTemplateEntity> GetEntitesList();
    }

    internal class GameMapTemplate : IGameMapTemplate
    {
        internal List<GameMapTemplateEntity> EntitiesList = new();
        List<GameMapTemplateEntity> IGameMapTemplate.GameMapTemplateEntities { get => EntitiesList; }

        public List<GameMapTemplateEntity> GetEntitesList() => EntitiesList;
    }
}
