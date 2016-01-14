using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;

namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl_ClosingAnimation.xaml
    /// </summary>
    public partial class UserControl_ClosingAnimation : UserControl
    {
        public UserControl_ClosingAnimation(int set_period, 
            ref EventHandler set_finished_sequence, MainWindow1 set_parent)
        {
            InitializeComponent();

            animation_content.Background = new ImageBrush(new BitmapImage(
                new Uri("big_map" + set_period.ToString() + ".png", UriKind.Relative)));

            finished_sequence = set_finished_sequence;
            parent = set_parent;

            Loaded += UserControl_ClosingAnimation_Loaded;
        }

        void UserControl_ClosingAnimation_Loaded(object sender, RoutedEventArgs e)
        {
            if (correct)
            {
                result_label.Foreground = new SolidColorBrush(Colors.LimeGreen);
                result_label.Content = "CORRECT";
                result_sound_correct.Play();
            }
            else
            {
                result_label.Foreground = new SolidColorBrush(Colors.Red);
                result_label.Content = "WRONG";
                result_sound_wrong.Play();
            }

            DoubleAnimation da = new DoubleAnimation();
            da.From = 50;
            da.To = 200;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            da.Completed += da_Completed;
            result_label.BeginAnimation(Label.FontSizeProperty, da);
        }

        void da_Completed(object sender, EventArgs e)
        {
            finished_sequence(parent, null);
        }

        private event EventHandler finished_sequence;
        private MainWindow1 parent;
        public bool correct = false;
    }
}
