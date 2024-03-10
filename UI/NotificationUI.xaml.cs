using MahApps.Metro.IconPacks;
using System.Windows;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for NotificationUI.xaml
    /// </summary>
    public partial class NotificationUI : Window
    {
        public NotificationUI(string text, PackIconMaterialKind icon, Color background)
        {
            InitializeComponent();
            txtNotification.Text = text;
            borderNotification.Background = new SolidColorBrush(background);
            iconNotification.Kind = icon;
        }
    }
}
