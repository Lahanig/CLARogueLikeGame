namespace CLARogueLikeGame.GameTypes
{
    internal class GameTimer
    {
        internal int time;
        internal bool isTimeOut = false;

        internal GameTimer()
        {
            time = 0;
        }

        internal bool Timer(int timeOut = 40)
        {
            time++;

            if (time > timeOut)
            {
                time = 0;
                isTimeOut = true;
                return true;
            }

            isTimeOut = false;
            return false;
        }
    }
}
