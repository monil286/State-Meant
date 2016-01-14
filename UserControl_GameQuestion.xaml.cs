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

using System.Timers;

namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl_GameQuestion.xaml
    /// </summary>
    public partial class UserControl_GameQuestion : UserControl
    {
        
        public UserControl_GameQuestion(int set_period, ref EventHandler set_finish_question, 
            MainWindow1 set_parent, GameData current_question)
        {
            InitializeComponent();

            fill_state_nameLookup();

            period = set_period;
            //set map image from input
            mapContent.Background = new ImageBrush(new BitmapImage(
                    new Uri("big_map" + period.ToString() + ".png", UriKind.Relative)));

            current_game_data = current_question;
            period = set_period;
            finished_question = set_finish_question;
            parent = set_parent;

            countdown_question.Enabled = false;
            Loaded += UserControl_game_map_Loaded;
        }

        void UserControl_game_map_Loaded(object sender, RoutedEventArgs e)
        {
            //set the timer here
            progress_bar.Minimum = 0;
            progress_bar.Maximum = total_time;

            countdown_question.Interval = time_step;
            countdown_question.Elapsed += countdown_question_Elapsed;

            start_game();
        }

        void start_game()
        {
            progress_bar.Value = 0;
            display_game_values();
            countdown_question.Enabled = true;
        }

        void countdown_question_Elapsed(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                current_elapsed += time_step;
                if (current_elapsed >= total_time)
                {
                    correct = false;
                    stop_game();
                }

                //then use the time step to change the progress bar
                progress_bar.Value = current_elapsed;
            });
        }

        private void stop_game()
        {
            finished_question(parent, null);
            countdown_question.Enabled = false;
        }

        private void display_game_values()
        {
            label_year.Visibility = Visibility.Visible;
            label_year.Content = current_game_data.title;

            text_block_question.Visibility = Visibility.Visible;
            text_block_question.Text = current_game_data.question;

            image_map_section.Visibility = Visibility.Visible;
            CroppedBitmap cb = new CroppedBitmap(
               (BitmapSource)this.Resources["masterImage"],
               new Int32Rect((int)current_game_data.clipped_selection.X,
                   (int)current_game_data.clipped_selection.Y,
                   (int)current_game_data.clipped_selection.Width,
                   (int)current_game_data.clipped_selection.Height));
            image_map_section.Source = cb;

            SolidColorBrush backgroundColorBrush = new SolidColorBrush(Colors.Black);
            backgroundColorBrush.Opacity = 0.5;
            label_year.Background = backgroundColorBrush;
            text_block_question.Background = backgroundColorBrush;
            stack_panel_solution_set.Background = backgroundColorBrush;

            //create solution set here
            set_question_value(ref text_block_option_1, 0);
            set_question_value(ref text_block_option_2, 1);
            set_question_value(ref text_block_option_3, 2);
            set_question_value(ref text_block_option_4, 3);

            progress_bar.Background = new ImageBrush(new BitmapImage(
                    new Uri("period_" + period.ToString() + "_texture_light.png", UriKind.Relative)));
            progress_bar.Foreground = new ImageBrush(new BitmapImage(
                    new Uri("period_" + period.ToString() + "_texture_dark.png", UriKind.Relative)));
        }

        private void set_question_value(ref TextBlock set_text_value, int option_index)
        {
            String solution_set_string = "";
            foreach (String option_solution in current_game_data.solution_set[option_index])
            {
                solution_set_string += state_name_lookup[option_solution] + '\t';
            }
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = colorSet[option_index];
            set_text_value.Foreground = mySolidColorBrush;
            set_text_value.Text = solution_set_string;

            //set font size according to number of solutions
            if (current_game_data.solution_set[option_index].Count == 1)
                set_text_value.FontSize = 30;
            else if (current_game_data.solution_set[option_index].Count >= 4 &&
                current_game_data.solution_set[option_index].Count <= 6)
                set_text_value.FontSize = 20;
            else
                set_text_value.FontSize = 16;
        }

        void text_block_option_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock selection_set = sender as TextBlock;
            countdown_question.Enabled = false;

            //check right or wrong answer here
            switch (selection_set.Name)
            {
                case "text_block_option_1":
                    if (current_game_data.correct_index == 0)
                    {
                        correct = true;
                    }
                    else
                        correct = false;
                    break;
                case "text_block_option_2":
                    if (current_game_data.correct_index == 1)
                    {
                        correct = true;
                    }
                    else
                        correct = false;
                    break;
                case "text_block_option_3":
                    if (current_game_data.correct_index == 2)
                    {
                        correct = true;
                    }
                    else
                        correct = false;
                    break;
                case "text_block_option_4":
                    if (current_game_data.correct_index == 3)
                    {
                        correct = true;
                    }
                    else
                        correct = false;
                    break;
            }

            stop_game();
        }

        void text_block_option_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock block_selection = sender as TextBlock;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            switch (block_selection.Name)
            {
                case "text_block_option_1":
                    mySolidColorBrush.Color = colorSet[0];
                    break;
                case "text_block_option_2":
                    mySolidColorBrush.Color = colorSet[1];
                    break;
                case "text_block_option_3":
                    mySolidColorBrush.Color = colorSet[2];
                    break;
                case "text_block_option_4":
                    mySolidColorBrush.Color = colorSet[3];
                    break;
            }
            block_selection.FontWeight = FontWeights.Normal;
            block_selection.Foreground = mySolidColorBrush;
        }

        private void text_block_option_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock solution_block = sender as TextBlock;

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.Red;
            solution_block.FontWeight = FontWeights.Bold;
            solution_block.Foreground = mySolidColorBrush;
        }

        private void fill_state_nameLookup()
        {
            //setup dictionary for state name lookup
            state_name_lookup.Add("ak", "Alaska");
            state_name_lookup.Add("al", "Alabama");
            state_name_lookup.Add("ar", "Arkansas");
            state_name_lookup.Add("az", "Arizona");
            state_name_lookup.Add("ca", "California");
            state_name_lookup.Add("co", "Colorado");
            state_name_lookup.Add("ct", "Connecticut");
            state_name_lookup.Add("de", "Delaware");
            state_name_lookup.Add("fl", "Florida");
            state_name_lookup.Add("ga", "Georgia");
            state_name_lookup.Add("hi", "Hawaii");
            state_name_lookup.Add("id", "Idaho");
            state_name_lookup.Add("il", "Illinois");
            state_name_lookup.Add("in_", "Indiana");
            state_name_lookup.Add("ia", "Iowa");
            state_name_lookup.Add("ks", "Kansas");
            state_name_lookup.Add("ky", "Kentucky");
            state_name_lookup.Add("la", "Louisiana");
            state_name_lookup.Add("or", "Oregon");
            state_name_lookup.Add("me", "Maine");
            state_name_lookup.Add("md", "Maryland");
            state_name_lookup.Add("ma", "Massachusetts");
            state_name_lookup.Add("mi", "Michigan");
            state_name_lookup.Add("mn", "Minnesota");
            state_name_lookup.Add("ms", "Mississippi");
            state_name_lookup.Add("mo", "Missouri");
            state_name_lookup.Add("mt", "Montana");
            state_name_lookup.Add("ne", "Nebraska");
            state_name_lookup.Add("nv", "Nevada");
            state_name_lookup.Add("nh", "New Hampshire");
            state_name_lookup.Add("nj", "New Jersey");
            state_name_lookup.Add("nm", "New Mexico");
            state_name_lookup.Add("ny", "New York");
            state_name_lookup.Add("nc", "North Carolina");
            state_name_lookup.Add("nd", "North Dakota");
            state_name_lookup.Add("oh", "Ohio");
            state_name_lookup.Add("ok", "Oklahoma");
            state_name_lookup.Add("pa", "Pennsylvania");
            state_name_lookup.Add("ri", "Rhode Island");
            state_name_lookup.Add("sc", "South Carolina");
            state_name_lookup.Add("sd", "South Dakota");
            state_name_lookup.Add("tn", "Tennessee");
            state_name_lookup.Add("tx", "Texas");
            state_name_lookup.Add("ut", "Utah");
            state_name_lookup.Add("vt", "Vermont");
            state_name_lookup.Add("va", "Virginia");
            state_name_lookup.Add("wa", "Washington");
            state_name_lookup.Add("wv", "West Virginia");
            state_name_lookup.Add("wi", "Wisconsin");
            state_name_lookup.Add("wy", "Wyoming");
        }

        private GameData current_game_data = new GameData();
        private Dictionary<string, string> state_name_lookup = new Dictionary<string, string>();
        private List<Color> colorSet = new List<Color>() { Colors.Aqua, Colors.Orange, Colors.LawnGreen, Colors.Violet };
        private int period;
        private event EventHandler finished_question;
        private MainWindow1 parent;

        private const double total_time = 8000;
        private double current_elapsed = 0;
        private double time_step = 1000;
        Timer countdown_question = new Timer();

        public bool correct = false;
    }
}
