namespace CLARogueLikeGame.GameTypes
{
    internal struct GameMap
    {
        public string[,] area;
        public int rows, columns;
        public GameMap(string[,] map)
        {
            area = map;

            rows = area.GetUpperBound(0) + 1;
            columns = area.Length / rows;
        }

        public void View()
        {
            try
            {
                rows = area.GetUpperBound(0) + 1;
                columns = area.Length / rows;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(area[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

        }

        public void ToDefault()
        {
            rows = area.GetUpperBound(0) + 1;
            columns = area.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (area[i, j] != "|" && area[i, j] != "=") area[i, j] = " ";
                }
            }
        }
    }
}
