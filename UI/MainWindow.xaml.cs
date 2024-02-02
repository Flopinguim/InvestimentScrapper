using BLL;
using Model.Entities;
using System;
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
            try
            {
                dividend = DividendBLL.createDividendFromList(textBox.Text);
                fillInfoCards();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillInfoCards()
        {
            infoCard1.Number = dividend.AverageDailytrading.ToString();
            infoCard2.Number = dividend.LastYield.ToString();
            infoCard3.Number = dividend.DividendYield.ToString();
            infoCard4.Number = dividend.LastYield.ToString();
            infoCard5.Number = dividend.AssetValue.ToString();
            infoCard6.Number = dividend.RentabilityPerMonth.ToString();
        }

        private void Close_ButtonClick(object sender, System.EventArgs e) => this.Close();
    }
}
