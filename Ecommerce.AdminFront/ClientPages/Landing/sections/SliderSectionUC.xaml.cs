using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class SliderSectionUC : UserControl
{
    private ObservableCollection<BitmapImage> _images = new();
    private int _currentIndex = 0;
    private DispatcherTimer _timer;
    
    public SliderSectionUC()
    {
        InitializeComponent();
             LoadImages();
        StartImageSliderTimer();
    }
    
    private void StartImageSliderTimer()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(3); // 3 seconds
        _timer.Tick += (s, e) =>
        {
            if (_images.Count == 0) return;
            _currentIndex = (_currentIndex - 1 + _images.Count) % _images.Count;
            ShowCurrentImage();
        }; // Replace with your method
        _timer.Start();
    }


    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        ImageDisplay.Source = LoadImage("Resources/ecommerce.jpeg");
    }

    private BitmapImage LoadImage(string relativePath)
    {
        var image = new BitmapImage();
        image.BeginInit();
        image.UriSource = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
        image.EndInit();
        return image;
    }

    private void LoadImages()
    {
        _images.Add(LoadImage("Resources/slide1.jpg"));
        _images.Add(LoadImage("Resources/slide2.jpg"));
        _images.Add(LoadImage("Resources/slide3.jpg"));
        _images.Add(LoadImage("Resources/slide4.png"));

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