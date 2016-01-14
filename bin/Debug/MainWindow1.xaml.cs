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
                for (int i=1; i<pageSequence.Count-1; i++)
                {
                    UserControl_game_map temp_val = pageSequence[i] as UserControl_game_map;
                    tally_value += temp_val.full_tally;
                }
                UserControl_score_screen final_screen = new UserControl_score_screen();
                final_screen.tally_value = tally_value;
                full_canvas.Children.Add(final_screen);
            }
            else
                full_canvas.Children.Add(pageSequence[sequenceIndex]);
        }

        private void initalizeSequence()
        {
            handle_next_control += MainWindow1_handle_next_control;

            pageSequence.Add(new UserControl_OpeningSequence(ref handle_next_control, this));
            //pageSequence.Add(new UserControl_Login(ref handle_next_control, this));
            pageSequence.Add(new UserControl_game_map(ref handle_next_control, this, 1, ref tally_value));
            pageSequence.Add(new UserControl_game_map(ref handle_next_control, this, 2, ref tally_value));
            pageSequence.Add(new UserControl_game_map(ref handle_next_control, this, 3, ref tally_value));
        }

        public event EventHandler handle_next_control;
        private int tally_value = 0;
    }
}
