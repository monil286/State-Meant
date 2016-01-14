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
using System.Media;
using System.Timers;

namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl_OpeningSequence.xaml
    /// </summary>
    public partial class UserControl_OpeningSequence : UserControl
    {
        public UserControl_OpeningSequence(ref EventHandler set_finished_sequence, MainWindow1 set_parent)
        {
            InitializeComponent();

            finished_sequence = set_finished_sequence;
            parent = set_parent;

            Keyboard.Focus(this);
        }

        private int sequence_index = 0;
        private List<string> background_images = new List<string>(){
            @"C:\Users\tmacedo\Documents\StateMeant\StateMeant\title1.jpg",
            @"C:\Users\tmacedo\Documents\StateMeant\StateMeant\title2.jpg",
            @"C:\Users\tmacedo\Documents\StateMeant\StateMeant\title3.jpg"};

        private List<string> title_labels = new List<string>(){
            "Founding America: 1500 - 1800", "Westward Expansion: 1800 - 1900",
            "Twentieth Century: 1900 - 2000"
        };

        private void opening_clip_MediaEnded(object sender, RoutedEventArgs e)
        {
            //hide the video clip
            opening_clip.Visibility = Visibility.Hidden;

            set_page_elements();

            cycleImage.Elapsed += cycleImage_Elapsed;
            cycleImage.Enabled = true;
        }

        void cycleImage_Elapsed(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
                {
                    if (sequence_index < background_images.Count)
                    {
                        set_page_elements();
                    }
                    else
                    {
                        finished_sequence(parent, null);
                        cycleImage.Enabled = false;
                    }
                });
        }

        private void set_page_elements()
        {
            opening_sequence_grid.Background = new ImageBrush(new BitmapImage(
                    new Uri(background_images[sequence_index])));
            title_label.Content = title_labels[sequence_index];
            title_label.Visibility = Visibility.Visible;
            sequence_index++;
        }

        Timer cycleImage = new Timer(2000);
        private event EventHandler finished_sequence;
        private MainWindow1 parent;
    }
}
