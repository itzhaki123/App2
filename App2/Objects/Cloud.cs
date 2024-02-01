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

        public Cloud(Scene scene, string fileName, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
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
