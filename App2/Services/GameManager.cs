﻿using App2.Objects;
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
            var dino = new Dino(Scene, "Runner/running.gif", 2, 85, 20, 700);
            Scene.AddObject(dino);

            var obstacle2 = new Obstacle2(Scene, "Runner/obstacle-2.gif", 2, 50, 1200, 735);
            Scene.AddObject(obstacle2);
            var obstacle1 = new Obstacle1(Scene, "Runner/obstacle-1.gif", 2, 50, 700, 735);
            Scene.AddObject(obstacle1);

            var cloud1 = new Cloud(Scene, "Runner/Cloud.png", 100, 2000, 200);
            Scene.AddObject(cloud1);
            var cloud2 = new Cloud(Scene, "Runner/Cloud.png", 100, 650, 100);
            Scene.AddObject(cloud2);
            var cloud3 = new Cloud(Scene, "Runner/Cloud.png", 100, 250, 150);
            Scene.AddObject(cloud3);
            var sun1 = new Sun(Scene, "Runner/sun.png", 2, 100, Scene.ActualWidth-100, 0);
            Scene.AddObject(sun1);
            var bird1 = new Bird(Scene, "Runner/BirdEnemy.gif", 120, 3000, 200);
            Scene.AddObject(bird1);

        }
    }
}
 