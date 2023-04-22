namespace CLARogueLikeGame.GameTypes
{
    internal struct GameTimer
    {
        public int time;
        public bool isTimeOut = false;

        public GameTimer()
        {
            time = 0;
        }

        public bool Timer(int timeOut = 40)
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
