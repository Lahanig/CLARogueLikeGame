namespace CLARogueLikeGame.GameMapTemplates
{
    internal interface IGameMapTemplate
    {
        List<GameMapTemplateEntity> GameMapTemplateEntities { get; }

        public List<GameMapTemplateEntity> GetEntitesList();
    }
}
