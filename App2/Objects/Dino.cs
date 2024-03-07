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

        public enum StateType
        {
            Running, Bending, Dead
        }
        private StateType _state;
        private double _speed;
        public Dino(Scene scene, string fileName, double speed, double width, double placeX, double placeY):base(scene, fileName, placeX, placeY)
        {
            _state = StateType.Running;
            _speed = speed;
            Image.Width = width;
            Image.Height = width;
            Init();
            SetImage();
        }
        public override void Init() 
        {
            Stop();
            Collisional = true;
            base.Init();
            SetImage();
            Manager.Events.OnKeyDown += Key;
            Manager.Events.OnKeyUp += ReturnToRunState;
        }

        private void ReturnToRunState(VirtualKey key)
        {
            if(key== VirtualKey.Down)
            {
                Image.Height = 85;
                //_Y = _Y - 35;
                _state = StateType.Running;
                SetImage();
            }
            
        }

        private void SetImage()
        {
            switch(_state) 
            {
                case StateType.Running:
                    base.SetImage("Runner/running.gif");
                    break;
                case StateType.Bending:
                    base.SetImage("Runner/DinoBending.png");
                    break;
                case StateType.Dead:
                    base.SetImage("Runner/Dead.png");                    
                    break;
            }
        }


        private void Key(VirtualKey key)
        {
            var state = _state;
            switch (key)
            {
                case VirtualKey.Space:
                case VirtualKey.Up:
                    if (_Y == _scene.ActualHeight-Height)
                    {
                        //MoveTo(_X, 435, _speed);
                        _dY = -25;
                        _ddY = 1.85;
                        _state = StateType.Running;
                    }
                    break;
                case VirtualKey.Down:
                    _state = StateType.Bending;
                    if(_Y == _scene.ActualHeight - Height)
                    {
                        Image.Height = 40;
                        _state = StateType.Bending;
                        _Y = _Y + 45;
                    }
                    else if (_Y <= _scene.ActualHeight-Height) //גבול
                    {
                        Image.Height = 40;
                        _dY = 32.5;
                    }

                    if (Rect.Bottom >= _scene?.ActualHeight)//נגיעת הדינו בשול התחתון
                    {
                        _Y = _scene.ActualHeight - Image.Height;//החזרת הדינו למיקום התחלתי
                        Stop();
                    }
                    break;
            }
            if(state!=_state)
            { 
                SetImage();
            }
            
        } 
        public override void Render()
        {
            base.Render();
            if(_Y <= 450) //גבול
            {
                _dY =-_dY;
            }

            if (Rect.Bottom >= _scene?.ActualHeight)//נגיעת הדינו בשול התחתון
            {
                _Y = _scene.ActualHeight - Height;//החזרת הדינו למיקום התחלתי
                Stop();
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
                    Image.Height = 85;
                    _Y = _Y + 45;
                    _state = StateType.Dead;
                    SetImage();
                    Manager.Events.OnRun = null;
                    Manager.Events.OnKeyDown -= Key;
                    Manager.Events.OnKeyUp -= ReturnToRunState;
                    Manager.Events.CountTime = null;
                }
            }
            else if (obj is Bird ob1)
            {
                var intersect = RectHelper.Intersect(Rect, ob1.Rect);
                if (intersect != null)
                {
                    Image.Height = 85;
                    _Y = _Y + 45;
                    _state = StateType.Dead;
                    SetImage();
                    Manager.Events.OnRun = null;
                    Manager.Events.OnKeyDown -= Key;
                    Manager.Events.OnKeyUp -= ReturnToRunState;
                    Manager.Events.CountTime = null;
                }
            }
            else if (obj is Obstacle1 ob3)
            {
                var intersect = RectHelper.Intersect(Rect, ob3.Rect);
                if (intersect != null)
                {
                    Image.Height = 85;
                    _Y = _Y + 45;
                    _state = StateType.Dead;
                    SetImage();
                    Manager.Events.OnRun = null;
                    Manager.Events.OnKeyDown -= Key;
                    Manager.Events.OnKeyUp -= ReturnToRunState;
                    Manager.Events.CountTime = null;
                }
            }
        }
    }
}
 