using MahApps.Metro.IconPacks;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace UI
{
    public partial class NotificationUI : Window
    {
        private DispatcherTimer timer;
        public NotificationUI(string text, PackIconMaterialKind icon, Color background)
        {
            InitializeComponent();
            txtNotification.Text = text;
            borderNotification.Background = new SolidColorBrush(background);
            iconNotification.Kind = icon;
            InitializeTimer();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Defina a posição no canto inferior direito da tela
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = screenWidth - windowWidth;
            this.Top = screenHeight - windowHeight;

            timer.Start();
        }
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1); // alterar casoprecise de uma animacao melhor
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Atualiza o valor da ProgressBar gradualmente
            pgTimer.Value += 0.5; // Ajuste conforme necessário

            // Verifica se a ProgressBar atingiu o valor máximo
            if (pgTimer.Value >= pgTimer.Maximum)
                Close();
        }
    }
}
