using GameEnginer.Objects;
using GameEnginer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Objects
{
    public class Jelly : GameObject
    {
        public enum JellyType
        {
            Green = 0,
            Pink = 1,
            Yellow = 2,
        }

        private JellyType _JellyType;

        public Jelly(Scene scene, JellyType jellyType, double width, double placeX, double placeY):
            base(scene, string.Empty, placeX, placeY)
        {
            Image.Width = width;
            Image.Height = width;
            _JellyType = jellyType;
            SetImage();
        }
        /// <summary>
        /// הפעולה קובעת את שם הקובץ למראה העצם
        /// </summary>
        private void SetImage()
        {
            switch (_JellyType)
            {
                case JellyType.Green:
                    base.SetImage("Jelly//jelly_green.png");
                    break;
                case JellyType.Pink:
                    base.SetImage("Jelly//jelly_pink.png");
                    break;
                case JellyType.Yellow:
                    base.SetImage("Jelly//jelly_yellow.png");
                    break;
            }
        }
    }
}
