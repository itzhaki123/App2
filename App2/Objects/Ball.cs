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
    public class Ball:GameMovingObject
    {
        private int _countlifes;
        private double _speed;

        public Ball(Scene scene, string fileName, double speed, double width, double placeX, double placeY):base(scene, fileName, placeX, placeY)
        {
            _countlifes = 3;
            _speed = speed;
            Image.Width = width;
            Image.Height = Height;
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
            Collisional = true;
            Manager.Events.OnKeyDown += KeyDown;
            Manager.Events.OnKeyUp += KeyUp;
        }

        private void KeyDown(VirtualKey key)
        {
            if(key == VirtualKey.Up)
            {
                MoveTo(_X, int.MinValue, _speed);
            }
        }
    }
}
