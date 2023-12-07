using GameEnginer.Services;
using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace GameEnginer.Objects
{
    public abstract class GameObject
    {
        protected double _X; //מיקום נוכחי
        protected double _Y; //מיקום נוכחי

        protected double _placeX; //מיקום התחלתי
        protected double _placeY; //מיקום התחלתי

        public Image Image { get; set; }

        private Scene _scene;
        protected string _fileName;

        public double Width => Image.ActualWidth;

        public double Height => Image.ActualHeight;


        public virtual Rect Rect => new Rect(_X, _Y, Width, Height); //המלבן שמקיף את העצם

        public bool Collisional { get; set; } = true; //אפשר להתנגש בו, לא שקוף

        protected Scene scene; //זירת המשחק

        /// <summary>
        /// הפעולה בונה עצם ומאתחלת תכונותיו 
        /// </summary>
        /// <param name="scene">במת המשחק</param>
        /// <param name="fileName">שם הקובץ של מראה הדמות</param>
        /// <param name="placeX">המיקום האופקי של הדמות</param>
        /// <param name="placeY">מיקום אנכי של הדמות</param>
        public GameObject(Scene scene, string fileName, double placeX, double placeY)
        {
            _scene = scene;
            _fileName = fileName;
            _X = placeX;
            _Y = placeY;
            _placeX = placeX;
            _placeY = placeY;
            Image = new Image();
            SetImage(fileName);
            Render();

        }
        /// <summary>
        /// פעולה מציירת את האובייקט על המסך. צריכה להתבצע על הזמן עבור העצמים הנעים
        /// </summary>
        public virtual void Render()
        {
            Canvas.SetLeft(Image, _X);
            Canvas.SetTop(Image, _Y);
        }
        public virtual void SetImage(string fileName)
        {
            Image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/{fileName}"));
        }
        public virtual void Init()
        {
            _X = _placeX;
            _Y = _placeY;
        }
        public virtual void Collide(GameObject gameObject)
        {
        }
    }
}
