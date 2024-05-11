using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace App2.Objects
{
    internal class Bird:GameMovingObject
    {
        private Random random = new Random();
        private int check;


        public Bird(Scene scene, string fileName, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = width;
            _dX = -17;
            check = 0;
        }
        public int GenerateRandomNumberInRange(int minValue, int maxValue)
        {
            // Generate a random number within the specified range
            return random.Next(minValue, maxValue);
        }
        public override void Render()
        {
            check = GenerateRandomNumberInRange(550, 650);
            base.Render();
            if (_X < 0)
            {
                _Y = check;
                _X = GenerateRandomNumberInRange(6000, 9000);
            }
        }
       
    }
}
