using MahApps.Metro.IconPacks;
using MODEL.Enumerators;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UI
{
    public partial class NotificationUserControl : UserControl
    {
        private NotificationEnum style;

        public static readonly DependencyProperty LeftLineColorProperty =
            DependencyProperty.Register("LeftLineColor", typeof(Brush), typeof(NotificationUserControl));

        public Brush LeftLineColor
        {
            get { return (Brush)GetValue(LeftLineColorProperty); }
            set { SetValue(LeftLineColorProperty, value); }
        }

        public static readonly DependencyProperty IconKindProperty =
            DependencyProperty.Register("IconKind", typeof(string), typeof(NotificationUserControl));

        public PackIconMaterialKind IconKind
        {
            get { return (PackIconMaterialKind)GetValue(IconKindProperty); }
            set { SetValue(IconKindProperty, value); }
        }

        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(Brush), typeof(NotificationUserControl));

        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NotificationUserControl));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty NotificationTextProperty =
            DependencyProperty.Register("NotificationText", typeof(string), typeof(NotificationUserControl));

        public string NotificationText
        {
            get { return (string)GetValue(NotificationTextProperty); }
            set { SetValue(NotificationTextProperty, value); }
        }

        public NotificationUserControl(NotificationEnum typeOfNotification)
        {
            InitializeComponent();
            style = typeOfNotification;
            setStyleNotification();
            DataContext = this;

        }

        private void setStyleNotification()
        {
            if (style.Equals(NotificationEnum.Success))
            {
                LeftLineColor =
                    IconColor = new SolidColorBrush(Color.FromRgb(37, 162, 73));
                IconKind = PackIconMaterialKind.CheckboxMarkedCircle;
                Title = NotificationEnum.Success.ToString();
                NotificationText = string.Empty;
            }
            if (style.Equals(NotificationEnum.Warning))
            {
                LeftLineColor =
                    IconColor = new SolidColorBrush(Color.FromRgb(240, 189, 9));
                IconKind = PackIconMaterialKind.AlertCircle;
                Title = NotificationEnum.Warning.ToString();
                NotificationText = string.Empty;
            }
            if (style.Equals(NotificationEnum.Informational))
            {
                LeftLineColor = 
                    IconColor = new SolidColorBrush(Color.FromRgb(0, 56, 203)); ;
                IconKind = PackIconMaterialKind.Information;
                Title = NotificationEnum.Informational.ToString();
                NotificationText = string.Empty;
            }
            if (style.Equals(NotificationEnum.Error))
            {
                LeftLineColor =
                    IconColor = new SolidColorBrush(Color.FromRgb(218, 30, 40));
                IconKind = PackIconMaterialKind.CloseCircle;
                Title = NotificationEnum.Error.ToString();
                NotificationText = string.Empty;
            }
        }
    }
}
