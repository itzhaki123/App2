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
            var ball = new Dino(Scene, "Runner/running.gif", 2, 75, 20, Scene.Ground);
            Scene.AddObject(ball);
           
        }
    }
}
 