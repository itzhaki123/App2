using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEnginer.Services
{
    public class GameEvents
    {
        public Action<int> CountTime;
        public Action OnRun; //מי שירשם לאירוע יוכל לזוז
        public Action<VirtualKey> OnKeyDown; //האירוע שיתרחש אם המשתמש ילחץ על מקש כלשהו
        public Action<VirtualKey> OnKeyUp; //האירוע שיתרחש אם המשתמש יעזוב מקש כלשהו

        public void RemoveEvents()
        {
            OnKeyDown = null;
            OnKeyUp = null;
        }
    }
} 
