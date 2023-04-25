namespace CLARogueLikeGame.GameMapTemplates
{
    internal class GameMapTemplate2 : GameMapTemplate, IGameMapTemplate
    {
        internal GameMapTemplate2() 
        {
            EntitiesList = new() {
                new GameMapTemplateEntity (10, 8, "Coin"), new GameMapTemplateEntity (8, 8, "Coin")
            };
        }
    }
}
