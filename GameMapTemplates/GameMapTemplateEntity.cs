namespace CLARogueLikeGame.GameMapTemplates
{
    internal struct GameMapTemplateEntity
    {
        public int x, y;
        public string type;

        public GameMapTemplateEntity(int x, int y, string type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }
    }
}
