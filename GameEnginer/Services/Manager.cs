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
        private static DispatcherTimer _runTimer = new DispatcherTimer();//ככה בונים טיימר; //טיימר שידליק אירוע onRun 
        public static GameEvents Events { get; private set; } = new GameEvents();//חבילת אירועים שניתן לגשת אליה מכל מקום
        public static GameState GameState { get; set; } = GameState.Loaded;

        public Manager(Scene scene)
        {
            Events.RemoveEvents();
            Scene = scene;
            _runTimer.Interval = TimeSpan.FromMilliseconds(1);
            _runTimer.Tick += _runTimer_Tick;
            _runTimer.Start();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (Events.OnKeyUp != null)
            {
                Events.OnKeyUp(args.VirtualKey);//כך הופעל האירוע שנעזוב את המקש
            }
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if(Events.OnKeyDown!=null)
            {
                Events.OnKeyDown(args.VirtualKey);//כך הופעל האירוע שנלחץ  על המקש
            }
        }

        private void _runTimer_Tick(object sender, object e)
        {
            if(Events.OnRun!=null) //כך מדליקים את האירוע והוא יתרחש 1000 פעמים בשנייה
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
        public void Unsubscribe()
        {
            _runTimer.Tick -= _runTimer_Tick;
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp -= CoreWindow_KeyUp;
        }

    }
}
