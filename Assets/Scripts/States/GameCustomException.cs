using System;

namespace Assets.Scripts.States
{
    public class GameCustomException : Exception
    {
        public GameCustomException(string message): base(message)
        {
        }
    }
}
