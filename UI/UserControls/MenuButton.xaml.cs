using MahApps.Metro.IconPacks;
using System.Windows.Controls;
using System.Windows;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for Menubutton.xaml
    /// </summary>
    public partial class Menubutton : UserControl
    {
        public Menubutton()
        {
            InitializeComponent();
        }

        public PackIconMaterialKind Icon
        {
            get { return(PackIconMaterialKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PackIconMaterialKind), typeof(Menubutton));

        public bool isActive
        {
            get { return (bool)GetValue(isActiveProperty); }
            set { SetValue(isActiveProperty, value); }
        }

        public static readonly DependencyProperty isActiveProperty =
            DependencyProperty.Register("isActive", typeof(bool), typeof(Menubutton));

    }
}
