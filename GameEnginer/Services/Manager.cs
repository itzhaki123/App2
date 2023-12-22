using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
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
        public Scene Scene { get; private set; }//במה
        private DispatcherTimer _runTimer; //טיימר שידליק אירוע onRun 
        public static GameEvents Events { get; private set; } = new GameEvents();//חבילת אירועים שניתן לגשת אליה מכל מקום
        public static GameState GameState { get; set; } = GameState.Loaded;

        public Manager(Scene scene)
        {
            Scene = scene;
            _runTimer = new DispatcherTimer();//ככה בונים טיימר
            _runTimer.Interval = TimeSpan.FromMilliseconds(1);
            _runTimer.Start();
            _runTimer.Tick += _runTimer_Tick;
        }
        
        private void _runTimer_Tick(object sender, object e)
        {
            if(Events.OnRun!=null) //כך מדליקים את האירוע והאו יתרחש 1000 פעמים בשנייה
            {
                Events.OnRun();
            }
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
            if (GameState != GameState.GameOver)
            {
                GameState = GameState.GameOver;
                return true;
            }
            return false;
        }

    }
}
