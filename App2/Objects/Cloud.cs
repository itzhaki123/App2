using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Objects
{
    class Cloud:GameMovingObject
    {
        private double _speed;

        public Cloud(Scene scene, string fileName, double speed, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            _speed = speed;
            Image.Width = width;
            Image.Height = width;
            _dX = -1;
        }
        public override void Render()
        {
            base.Render();
            if (_X < 0)
                _X = _scene.ActualWidth;
        }
    }
}
