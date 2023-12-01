using GameEnginer.Services;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace GameEnginer.Objects
{
    public abstract class GameObject
    {
        protected double _X; //מיקום נוכחי
        protected double _Y; //מיקום נוכחי

        protected double _placeX; //מיקום התחלתי
        protected double _placeY; //מיקום התחלתי

        public Image Image { get; set; }
        protected string _fileName;

        public double Width => Image.ActualWidth;

        public double Height => Image.ActualHeight;

        public virtual Rect Rect => new Rect(_X, _Y, Width, Height); //המלבן שמקיף את העצם

        public bool Collisional { get; set; } = true; //אפשר להתנגש בו, לא שקוף

        protected Scene scene; //זירת המשחק
    }
}
