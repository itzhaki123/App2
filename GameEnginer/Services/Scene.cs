using GameEnginer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameEnginer.Services
{
    public abstract class Scene : Canvas
    {
        /// <summary>
        /// הפעולה מחזיקה במאגר כל האובייקטים
        /// כאן נמצאת הפעולה שמניעה את כל הפעולות הנעות run
        /// כאן נמצאת פעולה שבודקת התנגשות דמות אחת בשנייה. 
        /// היא מופעלת ללא הפסקה, אם מתגלה התנגשות, מופעלת פעולה תגובה של אותו דמות. CheckCollision
        /// </summary>
        private List<GameObject> _gameObjects = new List<GameObject>();//מאגר האובייקטים במשחק 

        public double Ground { get; set; }//רצפה

        public Scene()
        {
            Manager.Events.OnRun += Run;
        }

        private void Run()
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject is GameMovingObject movObj)
                {
                    movObj.Render();
                }
            }
        }

        public void Init() //פעולה מחזירה אובייקטים למיקום התחלתי
        {
            foreach (GameObject obj in _gameObjects)
            {
                obj.Init();
            }
        }

        public void RemoveObject(GameObject gameObject)
        {
            if (_gameObjects.Contains(gameObject))
            {
                _gameObjects.Remove(gameObject);
                Children.Remove(gameObject.Image);
            }
        }

        public void RemoveAllObjects()//פעולה מוחקת את כל האובייקטים
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                RemoveObject(gameObject);
            }
        }

        public void AddObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            Children.Add(gameObject.Image);
        }
    }
}
