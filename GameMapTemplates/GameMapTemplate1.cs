namespace CLARogueLikeGame.GameMapTemplates
{
    internal class GameMapTemplate1 : GameMapTemplate, IGameMapTemplate
    {
        internal GameMapTemplate1()
        {
            EntitiesList = new() {
                new GameMapTemplateEntity (5, 5, "Coin"), new GameMapTemplateEntity (16, 8, "Coin")
            };
        }
    }
}
