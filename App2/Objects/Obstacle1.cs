﻿using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Objects
{
    class Obstacle1 : GameMovingObject
    {
        private Random random = new Random();
        private int check;

        public Obstacle1(Scene scene, string fileName, double speed, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = width;
            _dX = -7;
            check = 0;

        }
        public int GenerateRandomNumberInRange(int minValue, int maxValue)
        {
            // Generate a random number within the specified range
            return random.Next(minValue, maxValue);
        }
        public override void Render()
        {
            base.Render();
            if (_X < 0)
            {
                _X = GenerateRandomNumberInRange(3200, 3700);
                _dX -= 1.6;
                check += 1;
                if (check > 17)
                {
                    _dX += 1.6;
                }
            }

        }
    }
}
