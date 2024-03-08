using GameEnginer.Objects;
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
        private Obstacle2 o2;

        public Obstacle2(Scene scene, string fileName, double speed, int width, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = width;
            _dX = -10;
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
                if(check > 25)
                {
                    _dX += 2;
                }
            }
            
        } 
        public override void Collide(GameObject obj)
        {
            if (obj is Bullet bullet)
            {
                _scene.RemoveObject(this);
                _scene.RemoveObject(bullet);
                _X = GenerateRandomNumberInRange(2000, 3000);
                _scene.AddObject(this);
            }
        }
    }
}
