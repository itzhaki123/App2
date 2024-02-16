﻿using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Objects
{
    class Obstacle2 : GameMovingObject
    {
        private Random random = new Random();
        private int check;

        public Obstacle2(Scene scene, string fileName, double speed, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = width;
            _dX = -5;
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
                _X = GenerateRandomNumberInRange(1700, 2800);
                _dX -= 1.3;
                check += 1;
                if(check > 15)
                {
                    _dX += 1.3;
                }
            }
            
        }

    }
}
