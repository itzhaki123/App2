using App2.Objects;
using GameEnginer.Services;
using System;

namespace App2.Services
{
    public class GameManager : Manager
    {
        public GameManager(Scene scene) : base(scene)
        {
            scene.Ground = scene.ActualHeight - 40;
            Init();
        }

        private void Init()
        {
            CreateJelliesFeild();
            var Bar = new Bar(Scene, "Bar/Bar.png",1 , 100, Scene.ActualWidth / 2 - 50, Scene.Ground);
            Scene.AddObject(Bar);

            var ball = new Ball(Scene, "Ball/Ball.png", 1, 35, Scene.ActualWidth / 2 - 17.5, Bar.Rect.Top - 35);
            Scene.AddObject(ball);
           
        }
        private void CreateJelliesFeild()
        {
            Random rnd = new Random();

            int PlaceX = 50;
            int PlaceX2 = 50;
            int PlaceX3 = 50;
            for (int i = 0; i < 15; i++)
            {
                var jelly = new Jelly(Scene, (Jelly.JellyType)rnd.Next(3), 100, PlaceX, 50);
                Scene.AddObject(jelly);
                PlaceX += 100;
            }
            for (int i = 0; i < 15; i++)
            {
                var jelly2 = new Jelly(Scene, (Jelly.JellyType)rnd.Next(3), 100, PlaceX2, 150);
                Scene.AddObject(jelly2);
                PlaceX2 += 100;
            }
            for (int i = 0; i < 15; i++)
            {
                var jelly3 = new Jelly(Scene, (Jelly.JellyType)rnd.Next(3), 100, PlaceX3, 250);
                Scene.AddObject(jelly3);
                PlaceX3 += 100;
            }
        }
    }
}
 