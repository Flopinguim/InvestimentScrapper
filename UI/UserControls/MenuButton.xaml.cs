using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }
        
        public PackIconMaterialKind Icon
        {
            get { return(PackIconMaterialKind) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("", typeof(PackIconMaterialKind), typeof(MenuButton));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("", typeof(PackIconMaterialKind), typeof(MenuButton));
    }
}
