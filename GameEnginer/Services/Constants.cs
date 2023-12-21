using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEnginer.Services
{
    public static class Constants
    {
        public enum GameState //הגדרת מצב משחק
        {
            Loaded,
            Started,
            Paused,
            GameOver
        }
    }
}
