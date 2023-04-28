namespace CLARogueLikeGame.GameMapTemplates
{
    internal class GameMapTemplateEntity
    {
        internal int x, y;
        internal string type, diraction;

        internal GameMapTemplateEntity(int x, int y, string type, string? diraction = null)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.diraction = diraction??"left";
        }
    }
}
