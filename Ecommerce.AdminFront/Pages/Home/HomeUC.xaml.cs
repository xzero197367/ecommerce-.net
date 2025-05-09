using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ecommerce.AdminFront.Pages.Home;

public partial class HomeUC : UserControl
{
    private ObservableCollection<BitmapImage> _images = new();
    private int _currentIndex = 0;

    public HomeUC()
    {
        InitializeComponent();
        LoadImages();
        ShowCurrentImage();
    }
    
    private void LoadImages()
    {
        _images.Add(new BitmapImage(new Uri("Images/image1.jpg", UriKind.Relative)));
        _images.Add(new BitmapImage(new Uri("Images/image2.jpg", UriKind.Relative)));
        _images.Add(new BitmapImage(new Uri("Images/image3.jpg", UriKind.Relative)));
    }

    private void ShowCurrentImage()
    {
        if (_images.Count > 0)
        {
            ImageDisplay.Source = _images[_currentIndex];
        }
    }

    private void PrevImage_Click(object sender, RoutedEventArgs e)
    {
        if (_images.Count == 0) return;
        _currentIndex = (_currentIndex - 1 + _images.Count) % _images.Count;
        ShowCurrentImage();
    }

    private void NextImage_Click(object sender, RoutedEventArgs e)
    {
        if (_images.Count == 0) return;
        _currentIndex = (_currentIndex + 1) % _images.Count;
        ShowCurrentImage();
    }
}