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

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        List<UserControl> pageSequence = new List<UserControl>();
        int sequenceIndex = 0;

        public MainWindow1()
        {
            InitializeComponent();

            WindowState = System.Windows.WindowState.Maximized;
            initalizeSequence();

            //then in full canvas, show the login screen         
            full_canvas.Children.Add(pageSequence[sequenceIndex]);
        }

        void MainWindow1_handle_next_control(object sender, EventArgs e)
        {
            full_canvas.Children.Clear();
            sequenceIndex++;

            if (sequenceIndex == pageSequence.Count)
            {
                int tally_value = 0;

                //go through each element in the sequence and get tally
                for (int i = 2; i < pageSequence.Count; i += 3)
                {
                    UserControl_GameQuestion check_page = pageSequence[i] as UserControl_GameQuestion;
                    if (check_page.correct)
                        tally_value++;
                }

                UserControl_score_screen final_screen = new UserControl_score_screen();
                final_screen.tally_value = tally_value;
                full_canvas.Children.Add(final_screen);
            }
            else
            {
                if (sequenceIndex > 0 && sequenceIndex % 3 == 0)
                {
                    UserControl_GameQuestion check_value =
                        pageSequence[sequenceIndex-1] as UserControl_GameQuestion;
                    if (check_value.correct)
                    {
                        UserControl_ClosingAnimation set_Value =
                            pageSequence[sequenceIndex] as UserControl_ClosingAnimation;
                        set_Value.correct = true;
                        pageSequence[sequenceIndex] = set_Value;
                    }
                }
                full_canvas.Children.Add(pageSequence[sequenceIndex]);
            }
        }

        private void initalizeSequence()
        {
            handle_next_control += MainWindow1_handle_next_control;

            pageSequence.Add(new UserControl_OpeningSequence(ref handle_next_control, this));

            for (int i = 0; i < 3; i++)
            {
                List<int> available_indices = new List<int>();
                for (int j = 0; j < (available_questions.questionLookup[i+1]).Count; j++)
                {
                    available_indices.Add(j);
                }

                for (int j = 0; j < QUESTIONS_PER_PERIOD; j++)
                {
                    Random nextRand = new Random(Environment.TickCount);
                    int randIndex = available_indices[nextRand.Next(0, available_indices.Count)];

                    pageSequence.Add(new UserControl_OpeningAnimation(i + 1, ref handle_next_control, this,
                        available_questions.questionLookup[i + 1][randIndex].zoom_selection));
                    pageSequence.Add(new UserControl_GameQuestion(i+1, ref handle_next_control, this, 
                        available_questions.questionLookup[i+1][randIndex]));
                    pageSequence.Add(new UserControl_ClosingAnimation(i + 1, ref handle_next_control, this));

                    available_indices.Remove(randIndex);
                }
            }
        }

        public event EventHandler handle_next_control;
        private GameDataPool available_questions = new GameDataPool();
        private const int QUESTIONS_PER_PERIOD = 4;
    }
}
