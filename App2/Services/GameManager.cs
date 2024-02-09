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
            var dino = new Dino(Scene, "Runner/running.gif", 2, 90, 20, 700);
            Scene.AddObject(dino);

            var obstacle2 = new Obstacle2(Scene, "Runner/obstacle-2.gif", 2, 50, 1000, 735);
            Scene.AddObject(obstacle2);

            var cloud1 = new Cloud(Scene, "Runner/Cloud.png", 100, 1000, 200);
            Scene.AddObject(cloud1);
            var cloud2 = new Cloud(Scene, "Runner/Cloud.png", 100, 650, 100);
            Scene.AddObject(cloud2);
            var cloud3 = new Cloud(Scene, "Runner/Cloud.png", 100, 250, 150);
            Scene.AddObject(cloud3);
            var sun1 = new Sun(Scene, "Runner/sun.png", 2, 100, Scene.ActualWidth-100, 0);
            Scene.AddObject(sun1);
            //var bird1 = new Bird(Scene, "Runner/bird-enemy.gif", 150, 1000, 600);
            //Scene.AddObject(bird1);

            var dead = new Dino(Scene, "Runner/dead.png", 2, 90, 20, 700);

        }
    }
}
 