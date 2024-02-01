using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;

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
            Collisional = true;
            base.Init();
            Manager.Events.OnKeyDown += KeyDown;
            Manager.Events.OnKeyUp += KeyUp;
        }

        private void KeyUp(VirtualKey key)
        {
            if(key == VirtualKey.Up)
            {
                
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
            if(_Y <= 435) //גבול
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
        public override void Collide(GameObject obj)
        {
            base.Collide(obj);
            if (obj is Obstacle2 ob2)
            {
                var intersect = RectHelper.Intersect(Rect, ob2.Rect);
                if(intersect != null)
                {
                    _scene.RemoveObject(this);
                }
            }
            else if (obj is Bird ob1)
            {
                var intersect = RectHelper.Intersect(Rect, ob1.Rect);
                if (intersect != null)
                {
                    _scene.RemoveObject(this);
                }
            }
        }
    }
}
 