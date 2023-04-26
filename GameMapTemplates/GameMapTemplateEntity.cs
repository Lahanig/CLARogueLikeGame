namespace CLARogueLikeGame.GameMapTemplates
{
    internal struct GameMapTemplateEntity
    {
        public int x, y;
        public string type, diraction;

        public GameMapTemplateEntity(int x, int y, string type, string? diraction = null)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.diraction = diraction??"left";
        }
    }
}
