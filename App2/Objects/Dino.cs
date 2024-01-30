using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace App2.Objects
{
    public class Dino:GameMovingObject
    {
        private double _speed;

        public Dino(Scene scene, string fileName, double speed, double width, double placeX, double placeY):base(scene, fileName, placeX, placeY)
        {
            _speed = speed;
            Image.Width = width;
            Image.Height = width;
            Init();
        }
        public override void Init() 
        {
            Stop();
            Collisional = false;
            base.Init();
            Manager.Events.OnKeyDown += KeyDown;
            Manager.Events.OnKeyUp += KeyUp;
        }

        private void KeyUp(VirtualKey key)
        {
            if(key == VirtualKey.Up)
            {
                
                _speed = 1;
                Collisional = true;
                Manager.Events.OnKeyDown -= KeyDown;
                Manager.Events.OnKeyUp -= KeyUp;
            }
            else
            {
                Stop();
            }
        }

        private void KeyDown(VirtualKey key)
        {
            switch(key)
            {
                case VirtualKey.Up:
                    MoveTo(_X, int.MinValue, _speed);
                    break;
            }
        }
        public override void Render()
        {
            base.Render();
             _X = 75;
            if(_Y <= 400) //נגיעת כדור בתקרה
            {
                _dY = -_dY;
            }

            if (Rect.Bottom >= _scene?.ActualHeight)//נגיעת הכדור בשול התחתון
            {
                _Y = _scene.ActualHeight - Height;
                Stop();
                Manager.Events.OnKeyDown += KeyDown;
                Manager.Events.OnKeyUp += KeyUp;
            }
        }
    }
}
 