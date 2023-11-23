using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LevelsPage : Page
    {
        public LevelsPage()
        {
            this.InitializeComponent();
        }
        private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Image img = (Image)sender;
            string name = img.Name;
            if (name == "exitImage")
            {
                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Cross (1).png"));
            }
            if (name == "LvlOneImage")
            {
                btn1.BorderThickness = new Thickness(0, 0, 0, 0);
                btn1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            if (name == "LvlTwoImage")
            {
                btn2.BorderThickness = new Thickness(0, 0, 0, 0);
                btn2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            if (name == "LvlThreeImage")
            {
                btn3.BorderThickness = new Thickness(0, 0, 0, 0);
                btn3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            if (name == "LvlFourImage")
            {
                btn4.BorderThickness = new Thickness(0, 0, 0, 0);
                btn4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
        }
        private void Image_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Image img = (Image)sender;
            string name = img.Name;
            if (name == "exitImage")
            {
                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Cross (2).png"));
            }
            if (name == "LvlOneImage")
            {
                btn1.BorderThickness = new Thickness(5, 5, 5, 5);
                btn1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 228, 5, 6));
            }
            if (name == "LvlTwoImage")
            {
                btn2.BorderThickness = new Thickness(5, 5, 5, 5);
                btn2.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 188, 15));
            }
            if (name == "LvlThreeImage")
            {
                btn3.BorderThickness = new Thickness(5, 5, 5, 5);
                btn3.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 253, 145, 19));
            }
            if (name == "LvlFourImage")
            {
                btn4.BorderThickness = new Thickness(5, 5, 5, 5);
                btn4.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 11, 132, 179));
            }
        }
        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Image img = (Image)sender;
            string name = img.Name;
            if (name == "exitImage")
            {
                Frame.Navigate(typeof(MenuPage));
            }
            if (name == "LvlOneImage")
            {
                btn1.BorderThickness = new Thickness(5, 5, 5, 5);
                btn1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 228, 5, 6));
                Frame.Navigate(typeof(MenuPage));
            }
            if (name == "LvlTwoImage")
            {
                btn2.BorderThickness = new Thickness(5, 5, 5, 5);
                btn2.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 120, 188, 15));
                Frame.Navigate(typeof(MenuPage));
            }
            if (name == "LvlThreeImage")
            {
                btn3.BorderThickness = new Thickness(5, 5, 5, 5);
                btn3.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 253, 145, 19));
                Frame.Navigate(typeof(MenuPage));
            }
            if (name == "LvlFourImage")
            {
                btn4.BorderThickness = new Thickness(5, 5, 5, 5);
                btn4.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 11, 132, 179));
                Frame.Navigate(typeof(MenuPage));
            }
        }
    }
}
