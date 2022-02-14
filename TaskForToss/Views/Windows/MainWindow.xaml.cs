using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskForToss.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnMenuItemClick(object sender, RoutedEventArgs e)
        {
            CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseOut };
            DoubleAnimation doubleAnimation = new DoubleAnimation();

            Button currentButton = (Button)sender;
            StackPanel panel;
            switch (currentButton.Name)
            {
                case nameof(btnInfo):
                    {
                        panel = stcInfo;
                        break;
                    }
                case nameof(btnReport):
                    {
                        panel = stcReport;
                        break;
                    }
               
                default: return;

            }

            int count = panel.Children.Count;
            if (panel.Height != 0)
            {
                doubleAnimation.To = 0;
            }
            else
            {
                doubleAnimation.To = count * 30;
            }

            doubleAnimation.Duration = TimeSpan.FromMilliseconds(count * 300);
            doubleAnimation.EasingFunction = ease;
            panel.BeginAnimation(HeightProperty, doubleAnimation);

        }
    }
}
