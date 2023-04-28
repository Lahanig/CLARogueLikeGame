namespace CLARogueLikeGame.GameMapTemplates
{
    internal class GameMapTemplate2 : GameMapTemplate, IGameMapTemplate
    {
        internal GameMapTemplate2() 
        {
            EntitiesList = new() {
                new GameMapTemplateEntity (11, 8, "Coin"),
                new GameMapTemplateEntity (9, 8, "Coin"),
                new GameMapTemplateEntity (9, 7, "Rock"),
                new GameMapTemplateEntity (9, 10, "Door", "bottom")
            };
        }
    }
}
