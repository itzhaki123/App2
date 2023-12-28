using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Objects
{
    class Bar : GameMovingObject
    {
        public double dX => _dX;
        private double _speed;

        public Bar(Scene scene, string fileName, double speed, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            _speed = speed;
            Image.Height = 20;
            Image.Width = width;
            Image.Stretch = Windows.UI.Xaml.Media.Stretch.Fill; //מותחים את מראה המחבט
            
        }
        public override void Render()
        {
            base.Render();
            //בדיקת קצוות הזירה
            if (_X <=0)
            {
                _X = 0;
                Stop();
            }
            else if (_X >= _scene?.ActualWidth - Width)
            {
                _X = _scene.ActualWidth - Width;
                Stop();
            }
        }
    }
}