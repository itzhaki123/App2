using App2.Services;
using DataBaseProject.Models;
using DataBaseProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class StorePage : Page
    {
        private List<Product> _productsList = null;
        public StorePage()
        {
            this.InitializeComponent();
        }

        private async void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = productsViewList.SelectedIndex;
            if (index == -1)  //לא נעשתה הבחירה
            {
                await new MessageDialog("MyGame", "You didn't choose!").ShowAsync();
            }
            else
            {
                Product desiredProduct = _productsList[index];                                 //זה המוצר שבחרת
                if (desiredProduct.ProductPrice > GameManager.Player.Score) //לא מספיק כסף
                {
                    await new MessageDialog("MyGame", "You don't have a budget, go work!").ShowAsync();
                }
                else
                {
                    //שנמצאים בבעלותו של המשתמש Fitchers -מקבלים רשימת מספרי ה
                    List<int> idOwnList = Server.GetOwnProductsId(GameManager.Player);

                    //יש לבדוק שהמוצר שבחרת נמצא כבר בבעלות השחקן, חבל לקנות את מה שיש לו כבר
                    if (idOwnList.Contains(desiredProduct.ProductId))
                    {
                        await new MessageDialog("MyGame", "The product you selected is already available!").ShowAsync();
                    }
                    else //אפשר ליקנות
                    {
                        GameManager.Player.UsingProduct = desiredProduct.ProductName;
                        GameManager.Player.Score -= desiredProduct.ProductPrice;
                        Server.AddUserProduct(GameManager.Player.UserId, desiredProduct.ProductId);
                        await new MessageDialog("MyGame", "Your purchase was successful!").ShowAsync();
                        Frame.Navigate(typeof(MenuPage));
                    }
                }
            }
        }

        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }

        private void ViewProducts(List<Product> products)
        {
            Image productImage = null;
            StackPanel stackPanel = null;
            TextBlock textBlock = null;
            foreach (Product product in products)
            {
                if (product != null)
                {
                    stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Width = productsViewList.ActualWidth;
                    stackPanel.Margin = new Thickness(14);

                    productImage = new Image();
                    productImage.Width = 200;
                    productImage.Height = 200;
                    productImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Runner/{product.ProductName}.png"));
                    productImage.Tag = product.ProductId;

                    textBlock = new TextBlock();
                    textBlock.FontSize = 60;
                    textBlock.Text = product.ProductPrice.ToString();
                    textBlock.Margin = new Thickness(10);
                    textBlock.FontFamily = new FontFamily("Broadway");
                    textBlock.Foreground = new SolidColorBrush(Colors.Red);

                    stackPanel.Children.Add(productImage);
                    stackPanel.Children.Add(textBlock);

                    productsViewList.Items.Add(stackPanel);
                }
            }
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            _productsList = Server.GetProducts(); //קבלת רשימת המוצרים שנמצאים בחנות
            ViewProducts(_productsList); //הצגת המוצרים על המסך כדי שהשתמש יוכל לבחור
        }
    }
    
}
