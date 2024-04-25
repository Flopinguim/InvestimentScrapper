using MahApps.Metro.IconPacks;
using MODEL.Enumerators;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UI
{
    public partial class NotificationUI : Window
    {
        private const int FadeInDuration = 500; 
        private const int FadeOutDuration = 500; 
        private const int DisplayDuration = 15000; 

        public NotificationUI(NotificationEnum style, string message)
        {
            InitializeComponent();
            setStyleNotification(style);
            txtNotificationText.Text = message;
            this.Opacity = 0;
            AnimateIn(); 
        }

        private void setStyleNotification(NotificationEnum style)
        {
            if (style.Equals(NotificationEnum.Success))
            {
                leftLineColor.Background =
                    iconNotification.Foreground = new SolidColorBrush(Color.FromRgb(37, 162, 73));
                iconNotification.Kind = PackIconMaterialKind.CheckboxMarkedCircle;
                txtTitle.Text = NotificationEnum.Success.ToString();
            }
            else if (style.Equals(NotificationEnum.Warning))
            {
                leftLineColor.Background =
                    iconNotification.Foreground = new SolidColorBrush(Color.FromRgb(240, 189, 9));
                iconNotification.Kind = PackIconMaterialKind.AlertCircle;
                txtTitle.Text = NotificationEnum.Warning.ToString();
            }
            else if (style.Equals(NotificationEnum.Informational))
            {
                leftLineColor.Background =
                    iconNotification.Foreground = new SolidColorBrush(Color.FromRgb(0, 56, 203));
                iconNotification.Kind = PackIconMaterialKind.Information;
                txtTitle.Text = NotificationEnum.Informational.ToString();
            }
            else if (style.Equals(NotificationEnum.Error))
            {
                leftLineColor.Background =
                    iconNotification.Foreground = new SolidColorBrush(Color.FromRgb(218, 30, 40));
                iconNotification.Kind = PackIconMaterialKind.CloseCircle;
                txtTitle.Text = NotificationEnum.Error.ToString();
            }
        }

        private async void AnimateIn()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(FadeInDuration),
                FillBehavior = FillBehavior.HoldEnd
            };

            this.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
            await Task.Delay(FadeInDuration);
        }

        private async void AnimateOut()
        {
            // Criando a animação de fade out
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(FadeOutDuration),
                FillBehavior = FillBehavior.HoldEnd
            };

            this.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
            await Task.Delay(FadeOutDuration);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double windowHeight = this.Height;
            this.Left = screenWidth;
            this.Top = SystemParameters.PrimaryScreenHeight - windowHeight;

            DoubleAnimation slideAnimation = new DoubleAnimation
            {
                From = this.Left,
                To = screenWidth - this.Width,
                Duration = TimeSpan.FromMilliseconds(FadeInDuration)
            };

            this.BeginAnimation(Window.LeftProperty, slideAnimation);
        }

        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            await Task.Delay(DisplayDuration);
            AnimateOut();
        }
    }
}
