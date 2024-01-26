using BLL;
using Model.Entities;
using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dividend dividend;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton.Equals(MouseButton.Left))
                this.DragMove();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dividend = new Dividend();
            dividend =DividendBLL.scrapperValuesTolist(textBox.Text);
            fillInfoCards();
        }

        private void fillInfoCards()
        {
            infoCard1.Number = dividend.AverageDailytrading.ToString();
            infoCard2.Number = dividend.LastYield.ToString();
            infoCard3.Number = dividend.DividendYield.ToString();
        }

        private void Close_ButtonClick(object sender, System.EventArgs e) => this.Close();

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
