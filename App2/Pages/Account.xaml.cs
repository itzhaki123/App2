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

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Account : Page
    {
        public Account()
        {
            this.InitializeComponent();
        }
          private void loginBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
            loginBtnText.Foreground = new SolidColorBrush(Windows.UI.Colors.Orange);
        }

        private void loginBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
            loginBtnText.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
        }

        private void loginBtn_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            registerGrid.Visibility = Visibility.Collapsed;
            loginGrid.Visibility = Visibility.Visible;
        }

        private void ApplySign_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ApplySign.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Check (4).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void ApplySign_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ApplySign.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Check (4).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void ApplySign_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }

        private void PopUpSaveImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }

        private void PopUpSaveImage_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            PopUpSaveImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Save (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void PopUpSaveImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            PopUpSaveImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/Save (1).png"));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
    }
}
