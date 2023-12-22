using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEnginer.Objects
{
    public abstract class GameMovingObject : GameObject
    {
        protected double _dX; //מהירות אופקית
        protected double _dY; //מהירות אנכית
        protected double _ddX;//תאוצה אופקית
        protected double _ddY;//תאוצה אנכית
        protected double _toX;//מיקום היעד ציר אופקי
        protected double _toY;//מיקום היעד ציר אנכי

        protected GameMovingObject(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {

        }
        public override void Render()
        {
            _dX += _ddX;
            _dY += _ddY;

            _X += _dX;
            _Y += _dY;

            if (Math.Abs(_X - _toX) < 4 && Math.Abs(_Y - _toY) < 4)//אם העצם התקרב לנקודת היעד קרוב יותר מ4 פיקסלים
            {
                Stop();
                _X = _toX;
                _Y = _toY;
            }
            base.Render();
        }
        public virtual void Stop()
        {
            _dX = _dY = _ddX = _ddY = 0;
        }
    }
}
