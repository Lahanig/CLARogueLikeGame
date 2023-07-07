namespace CLARogueLikeGame.GameMapTemplates
{
    internal class GameMapTemplateEntity
    {
        internal int x, y;
        internal string type, direction;

        internal GameMapTemplateEntity(int x, int y, string type, string? direction = null)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.direction = direction??"left";
        }
    }
}
