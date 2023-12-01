using App2.Pages;
using GameEngine.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame. 
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
            if (MusicPlayer.IsOn) backgroundMusicSw.IsOn = true; else backgroundMusicSw.IsOn = false;
        }
        private void exitImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            exitImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Cross (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void exitImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            exitImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Cross (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);

        }

        private void MusicImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            MusicImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Music (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void MusicImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            MusicImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Music (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void playImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            playImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Play (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void playImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            playImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Play (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }


        private void SignInImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            SignInImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Profile (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }


        private void SignInImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            SignInImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Profile (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PopUpNoImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            playImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Cross (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PopUpNoImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            playImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Cross (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PopUpNoImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Collapsed;
        }

        private void PopUpYesImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            playImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Check (4).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PopUpYesImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            playImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Check (4).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PopUpYesImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            App.Current.Exit();
        }

        private void exitImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            popupGrid.Visibility= Visibility.Visible;
        }

        private void SignInImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Account));
        }
        private void backgroundMusicSw_Toggled(object sender, RoutedEventArgs e)
        {
            if (backgroundMusicSw.IsOn)
            {
                MusicPlayer.Play("MixKit.mp3");
            }
            else
            {
                MusicPlayer.Stop();
            }
        }

        private void effectsMusicSw_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void volumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MusicPlayer.Volume = e.NewValue;
        }

        private void ApplyMusicImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ApplyMusicImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Check (4).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void ApplyMusicImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MusicGrid.Visibility = Visibility.Collapsed;
        }

        private void ApplyMusicImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ApplyMusicImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Check (4).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void MusicImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MusicGrid.Visibility = Visibility.Visible; 
        }

        private void LevelListImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            LevelListImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/LevelList (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void LevelListImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            LevelListImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/LevelList (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void LevelListImage_PointerPressed(object sender, PointerRoutedEventArgs e)   
        {
            Frame.Navigate(typeof(LevelsPage));
        }

        private void playImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void HelpImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            HelpImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Help (2).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void HelpImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            HelpImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Help (3).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void HelpImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Help));
        }
    }
}