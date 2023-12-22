using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEnginer.Services
{
    public static class Constants
    {
        public static double SpeedUnit = 10;//הגברת המהירות


        public enum GameState //הגדרת מצב משחק
        {
            Loaded,
            Started,
            Paused,
            GameOver
        }

    }
}
