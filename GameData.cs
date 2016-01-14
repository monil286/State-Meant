using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login
{
    public class GameData
    {
        public Rect zoom_selection;
        public Rect clipped_selection;
        public string title;
        public string question;
        public int correct_index;
        public List<string> answer_cluster;
        public List<List<string>> solution_set;
    }
}
