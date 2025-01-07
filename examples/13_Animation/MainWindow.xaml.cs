using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Animationen;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnAnimationText_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation animation = new DoubleAnimation(1, 5, TimeSpan.FromMilliseconds(1000));
        ScaleTransform scaleTransform = new ScaleTransform();
        lblHallo.RenderTransform = scaleTransform;

        scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
        scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
    }

    private void btnStartAnimation_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation doubleAnimation = new DoubleAnimation();
        doubleAnimation.From = -15;
        doubleAnimation.To = 15;
        doubleAnimation.By = 0;
        doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
        doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
        RotateTransform rotateTransform = new RotateTransform();
        rectangle1.RenderTransform = rotateTransform;
        rotateTransform.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);
    }
}