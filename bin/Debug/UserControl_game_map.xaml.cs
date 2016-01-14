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

using System.Windows.Media.Animation;

namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl_game_map.xaml
    /// </summary>
    public partial class UserControl_game_map : UserControl
    {
        public UserControl_game_map(ref EventHandler set_finished_sequence,
            MainWindow1 set_parent, int set_period, ref int tally_value)
        {
            InitializeComponent();

            //controls related to stopping the game
            finished_sequence = set_finished_sequence;
            parent = set_parent;

            finished_question += UserControl_game_map_finished_question;
            initialize_questions(set_period);
            Loaded += UserControl_game_map_Loaded;
        }

        void UserControl_game_map_finished_question(object sender, EventArgs e)
        {
            cycle_next_page();
        }

        void UserControl_game_map_Loaded(object sender, RoutedEventArgs e)
        {
            cycle_next_page();
        }

        private void cycle_next_page()
        {
            //start with the current page index
            //index value 0
            if (page_index < QUESTIONS_PER_PERIOD)
            {
                //check current index and see where it lies in the sequence
                if (page_index % 2 == 0)
                {
                    //set opening animation in canvas here
                    question_content.Children.Clear();
                    question_content.Children.Add(opening_animations[page_index / 2]);
                }
                else if (page_index % 2 == 1)
                {
                    //set game question in canvas here
                    question_content.Children.Clear();
                    question_content.Children.Add(game_questions[(page_index-1) / 2]);
                }
                //else if (page_index % 3 == 2) 
                //{
                //    question_content.Children.Clear();
                //    question_content.Children.Add(closing_animations.First());
                //    closing_animations.RemoveAt(0);
                //}

                page_index++;
            }
            else
            {
                for (int i = 0; i < game_questions.Count; i++)
                {
                    if (game_questions[i].correct)
                        full_tally++;
                }
                finished_sequence(parent, null);
            }
        }

        private void initialize_questions(int set_period)
        {
            //set up available indices for questions
            List<int> available_indices = new List<int>();
            for (int i = 0; i < available_questions.questionLookup[set_period].Count; i++)
            {
                available_indices.Add(i);
            }

            for (int i = 0; i < QUESTIONS_PER_PERIOD; i++)
            {
                Random nextRand = new Random(Environment.TickCount);
                int randIndex = available_indices[nextRand.Next(0, available_indices.Count)];

                opening_animations.Add(new UserControl_OpeningAnimation(
                    set_period, ref finished_question, this,
                    available_questions.questionLookup[set_period][randIndex].zoom_selection));

                game_questions.Add(new UserControl_GameQuestion(set_period,
                    ref finished_question, this,
                    available_questions.questionLookup[set_period][randIndex],
                    ref latest_correct));

                //closing_animations.Add(new UserControl_ClosingAnimation(
                //    set_period, ref finished_question, this, ref latest_correct));

                //remove index here
                available_indices.Remove(randIndex);
            }
        }

        public event EventHandler finished_sequence;
        public event EventHandler finished_question;
        private MainWindow1 parent;
        private const int QUESTIONS_PER_PERIOD = 4;

        //data structures to hold sequence of events
        private List<UserControl_OpeningAnimation> opening_animations =
            new List<UserControl_OpeningAnimation>();
        private List<UserControl_GameQuestion> game_questions =
            new List<UserControl_GameQuestion>();

        private GameDataPool available_questions = new GameDataPool();

        private int page_index = 0;
        bool latest_correct = false;
        public int full_tally;
    }
}
