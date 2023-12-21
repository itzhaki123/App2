using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEnginer.Services.Constants;

namespace GameEnginer.Services
{
    /// <summary>
    /// המחלקה המופשטת, שדורשת שיהיה לה
    /// היא מחזיקה בבמה, שני טיימרים, חבילת אירועים סטטית ומצב המשחק
    /// המחלקת יוצרת שני טיימרים, יוצרת חבילת אירועים סטטית, מכילת פעולות התחלת המשחק, עצירה, המשך וסיום
    /// שני הטיימרים במידה ופועלים מפעילים ללא הפסקה שני אירועים בהתאמה OnClock, OnRun
    /// אם מתרחשת עזיבה או לחיצה על המקש, מתבצעים שני אירועים בהתאמה. כל מי שנרשם לאירועים הללו מגיב אחרת. בנוסף במקלחה זו נעשית הרשמה ללחיצה ועזיבת המקשים 
    /// </summary>
    public abstract class Manager
    {
        public Scene Scene { get; private set; }
        public static GameState GameState { get; set; } = GameState.Loaded;

        public Manager(Scene scene)
        {
            Scene = scene;
        }
        public void Start()
        {
            Scene.Init();               //החזרת כל האובייקטים למיקום התחלתי
            GameState = GameState.Started;
        }
        public void Pause()
        {
            GameState = GameState.Paused;
        }

        public void Resume()
        {
            GameState = GameState.Started;
        }

        public bool GameOver()
        {
            if(GameState != GameState.GameOver)
            {
                GameState = GameState.GameOver;
                return true;
            }
            return false;
        }
    }
}
