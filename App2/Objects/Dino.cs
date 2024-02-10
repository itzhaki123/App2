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
                case VirtualKey.Up:
                    MoveTo(_X, 435, _speed);
                    _state = StateType.Running;
                    break;
                case VirtualKey.Down:
                    _state = StateType.Bending;
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
            if(_Y <= 435) //גבול
            {
                Manager.Events.OnKeyDown -= Key;
                Manager.Events.OnKeyUp -= ReturnToRunState;
                _dY = -_dY;
            }

            if (Rect.Bottom >= _scene?.ActualHeight)//נגיעת הדינו בשול התחתון
            {
                _Y = _scene.ActualHeight - Height;
                Manager.Events.OnKeyDown += Key;
                Manager.Events.OnKeyUp += ReturnToRunState;
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
                    _state = StateType.Dead;
                    SetImage();
                    Manager.Events.OnRun = null;
                    Manager.Events.OnKeyDown -= Key;
                    Manager.Events.OnKeyUp -= ReturnToRunState;
                }
            }
            else if (obj is Bird ob1)
            {
                var intersect = RectHelper.Intersect(Rect, ob1.Rect);
                if (intersect != null)
                {
                    _state = StateType.Dead;
                    SetImage();
                    Manager.Events.OnRun = null;
                    Manager.Events.OnKeyDown -= Key;
                    Manager.Events.OnKeyUp -= ReturnToRunState;
                }
            }
            else if (obj is Obstacle1 ob3)
            {
                var intersect = RectHelper.Intersect(Rect, ob3.Rect);
                if (intersect != null)
                {
                    _state = StateType.Dead;
                    SetImage();
                    Manager.Events.OnRun = null;
                    Manager.Events.OnKeyDown -= Key;
                    Manager.Events.OnKeyUp -= ReturnToRunState;
                }
            }
        }
    }
}
 