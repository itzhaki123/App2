using App2.Services;
using DataBaseProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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

        private async void ApplySign_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (SignInName.Text == String.Empty || SignInPass.Password == String.Empty)
            {
                await new MessageDialog("Missing Data", "Error").ShowAsync();
            }
            else
            {
                int? userId = Server.ValidateUser(SignInName.Text.Trim(), SignInPass.Password.Trim());
                if(userId==null)
                    await new MessageDialog("user doesnt exit", "Error").ShowAsync();
                else
                {
                    await new MessageDialog("Sign in seccesfully").ShowAsync();
                    GameManager.GameUser= Server.GetUser(userId.Value);
                    Frame.Navigate(typeof(MenuPage));
                }
            }
        }

        private async void PopUpSaveImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (userNameTextBox.Text == String.Empty || userMailTextBox.Text == String.Empty || pass1.Password == String.Empty || pass2.Password == String.Empty)
            {
                await new MessageDialog("Missing Data", "Error").ShowAsync();
            }
            else if (!pass2.Password.Equals(pass1.Password))
            {
                await new MessageDialog("Passwords don't match!", "Error").ShowAsync();
            }
            else if (!IsStrongPassword(pass1.Password))
            {
                await new MessageDialog("Password is not strong enough!", "Error").ShowAsync();
            }
            else if (!IsValidEmail(userMailTextBox.Text))
            {
                await new MessageDialog("Mail has not set correctly!", "Error").ShowAsync();
            }
            else
            {
                int? userId = Server.ValidateUser(userNameTextBox.Text.Trim(), pass1.Password.Trim());

                if (userId == null)//המשתמש לא נמצא במסד הנתונים ולכן יש להוסיפו למאגר
                {
                    //מוסיפים את המשתמש למסד הנתונים
                    GameManager.GameUser = Server.AddNewUser(userNameTextBox.Text, pass1.Password, pass2.Password);

                    await new MessageDialog("sign in seccesfully!", "Error").ShowAsync();
                    Frame.Navigate(typeof(MenuPage));
                }
                else //המשתמש כבר קיים במאגר, עליו יש להכנס לחשבון קיים
                {
                    await new MessageDialog("This account exist", "Eroor").ShowAsync();
                }
            }
        }

        public static bool IsStrongPassword(string password) { return password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Any(ch => !char.IsLetterOrDigit(ch)); }
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; return Regex.IsMatch(email, emailPattern);
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
