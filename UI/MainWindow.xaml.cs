using BLL;
using Model.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Utils;

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
            setVisibilyInfoCard(Visibility.Hidden);
        }

        private void callSearch()
        {
            try
            {
                    dividend = DividendBLL.createDividendFromList(textBox.Text);
                    fillInfoCards();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            setVisibilyInfoCard(Visibility.Visible);
        }

        private void setVisibilyInfoCard(Visibility visibility)
        {
            infoCard1.Visibility =
                infoCard2.Visibility =
                infoCard3.Visibility =
                infoCard4.Visibility =
                infoCard5.Visibility =
                infoCard6.Visibility = visibility;
        }

        #region WindowEvents
        private void btnAdd_Click(object sender, RoutedEventArgs e) => callSearch();

        private void Close_ButtonClick(object sender, EventArgs e) => this.Close();

        private void textBox_GotFocus(object sender, RoutedEventArgs e) => txtbSearch.Text = string.Empty;

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.IsEmpty())
                txtbSearch.Text = "Insira aqui o nome do dividendo ...";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals((Key.Enter)) && e.IsDown)
                callSearch();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton.Equals(MouseButton.Left))
                this.DragMove();
        }
        #endregion
    }
}

