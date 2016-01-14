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
    /// Interaction logic for UserControl_OpeningAnimation.xaml
    /// </summary>
    public partial class UserControl_OpeningAnimation : UserControl
    {
        public UserControl_OpeningAnimation(int period, ref EventHandler set_finished_sequence,
            MainWindow1 set_parent, Rect selection_set)
        {
            InitializeComponent();

            animation_content.Background = new ImageBrush(new BitmapImage(
                    new Uri("big_map" + period.ToString() + ".png", UriKind.Relative)));
            finished_sequence = set_finished_sequence;
            parent = set_parent;
            draw_selection_set = selection_set;

            Loaded += UserControl_OpeningAnimation_Loaded;
        }

        void UserControl_OpeningAnimation_Loaded(object sender, RoutedEventArgs e)
        {
            //draw rectangle on the screen
            animation_content.Children.Clear();

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());
            RectangleGeometry rGeom = new RectangleGeometry(draw_selection_set);
            this.RegisterName("MyAnimatedRectangleGeometry", rGeom);

            Path rectPath = new Path();
            rectPath.Fill = Brushes.Black;
            rectPath.Opacity = 0.5;
            rectPath.StrokeThickness = 1;
            rectPath.Stroke = Brushes.Black;
            rectPath.Data = rGeom;

            //then expand to fill the screen
            RectAnimation draw_animation = new RectAnimation();
            draw_animation.Duration = TimeSpan.FromSeconds(1);
            draw_animation.From = new Rect(draw_selection_set.X, draw_selection_set.Y,
                draw_selection_set.Width, draw_selection_set.Height);
            draw_animation.To = new Rect(0, 0, 1920, 1080);
            draw_animation.FillBehavior = FillBehavior.HoldEnd;

            Storyboard.SetTargetName(draw_animation, "MyAnimatedRectangleGeometry");
            Storyboard.SetTargetProperty(
                draw_animation, new PropertyPath(RectangleGeometry.RectProperty));

            // Create a storyboard to apply the animation.
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(draw_animation);
            ellipseStoryboard.Completed += ellipseStoryboard_Completed;

            // Start the storyboard when the Path loads.
            rectPath.Loaded += delegate(object sender_sub, RoutedEventArgs e_sub)
            {
                ellipseStoryboard.Begin(this);
            };

            animation_content.Children.Add(rectPath);
            Content = animation_content;
        }

        void ellipseStoryboard_Completed(object sender, EventArgs e)
        {
            finished_sequence(parent, null);
        }

        private Rect draw_selection_set = new Rect();
        private event EventHandler finished_sequence;
        private MainWindow1 parent;
    }
}
