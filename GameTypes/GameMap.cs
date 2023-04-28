namespace CLARogueLikeGame.GameTypes
{
    internal class GameMap
    {
        internal string[,] area;
        internal int rows, columns;
        internal GameMap(string[,] map)
        {
            area = map;

            rows = area.GetUpperBound(0) + 1;
            columns = area.Length / rows;
        }

        internal void View()
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

        internal void ToDefault()
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
