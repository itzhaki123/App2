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
            base.Render(); //מצייר את הגוף כל פעם
        }
        public virtual void Stop()
        {
            _dX = _dY = _ddX = _ddY = 0;
        }
        /// <summary>
        /// מחשבת מרחק בין 2 נקודות 
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        /// <param name="speed"></param>
        /// <param name="acceleration"></param>
        public void MoveTo(double toX, double toY, double speed = 1, double acceleration = 0)
        {
            _toX = toX;
            _toY = toY;

            var len = Math.Sqrt(Math.Pow(_toX - _X, 2) + Math.Pow(_toY - _Y, 2)); //בודק אם העצם הגיע לנקודה שבה הוא אמור להפגש
            var cos = (_toX - _X) / len;
            var sin = (_toY - _Y) / len;

            speed *= Constants.SpeedUnit; //הגברת מהירות
            _dX = speed * cos;
            _dY = speed * sin;
            _ddX = acceleration * cos;
            _ddY = acceleration * sin;
       }    }
}
