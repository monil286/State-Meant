using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login
{
    class GameDataPool
    {
        public GameDataPool()
        {
            set_period_1_questions();
            set_period_2_questions();
            set_period_3_questions();
        }

        private void set_period_1_questions()
        {
            List<GameData> period_1_questions = new List<GameData>();

            GameData insertData = new GameData();
            insertData.title = "1620";
            insertData.question = " Where did the Pilgrims land on the Mayflower?";
            insertData.answer_cluster = new List<string>() { "ma" };
            insertData.correct_index = 3;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "ri" }, new List<string>() { "ct" }, new List<string>() { "nj" }, 
                new List<string>() { "ma" }
            };
            insertData.zoom_selection = new Rect(1650, 300, 220, 250);
            insertData.clipped_selection = new Rect(1150, 300, 255, 172);
            period_1_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1542";
            insertData.question = " Where did the explorer Juan Rodriguez Cabrillo land?";
            insertData.answer_cluster = new List<string>() { "ca" };
            insertData.correct_index = 3;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "or" }, new List<string>() { "wa" }, new List<string>() { "ak" },
                new List<string>() { "ca" }
            };
            insertData.zoom_selection = new Rect(0, 0, 450, 1200);
            insertData.clipped_selection = new Rect(420, 555, 800, 387);
            period_1_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1513";
            insertData.question = " Where did the explorer Juan Ponce de Leon land?";
            insertData.answer_cluster = new List<string>() { "fl" };
            insertData.correct_index = 0;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "fl" }, new List<string>() { "tx" }, new List<string>() { "ga" },
                new List<string>() { "la" }
            };
            insertData.zoom_selection = new Rect(530, 800, 1100, 400);
            insertData.clipped_selection = new Rect(420, 555, 800, 387);
            period_1_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1607";
            insertData.question = " Where was the first English settlement, Jamestown, founded?";
            insertData.answer_cluster = new List<string>() { "va" };
            insertData.correct_index = 0;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "va" }, new List<string>() { "nc" }, new List<string>() { "md" },
                new List<string>() { "nj" }
            };
            insertData.zoom_selection = new Rect(1520, 450, 290, 310);
            insertData.clipped_selection = new Rect(958, 400, 293, 242);
            period_1_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1682";
            insertData.question = " Where was the first French settlement?";
            insertData.answer_cluster = new List<string>() { "la" };
            insertData.correct_index = 1;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "tx" }, new List<string>() { "la" }, new List<string>() { "fl" },
                new List<string>() { "ga" }
            };
            insertData.zoom_selection = new Rect(530, 800, 1100, 400);
            insertData.clipped_selection = new Rect(430, 560, 733, 370);
            period_1_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1776";
            insertData.question = " Where was the Declaration of Indepence adopted?";
            insertData.answer_cluster = new List<string>() { "pa" };
            insertData.correct_index = 2;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "ny" }, new List<string>() { "nj" }, new List<string>() { "pa" },
                new List<string>() { "md" }
            };
            insertData.zoom_selection = new Rect(1450, 250, 404, 368);
            insertData.clipped_selection = new Rect(1080, 240, 223, 283);
            period_1_questions.Add(insertData);
            questionLookup.Add(1, period_1_questions);
        }

        private void set_period_2_questions()
        {
            List<GameData> period_2_questions = new List<GameData>();

            GameData insertData = new GameData();
            insertData.title = "1803";
            insertData.question = " What area was the Louisiana purchase from France?";
            insertData.answer_cluster = new List<string>() { "mt", "nd", "sd", "wy", "co", "nm", "tx",
                "ok", "la", "ak", "ne", "ks", "mn", "ia", "ms", "ok"};
            insertData.correct_index = 0;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "mt", "nd", "sd", "wy", "co", "nm", "tx", "ok", "la", "ak", "ne", 
                    "ks", "mn", "ia", "ms", "ok" }, 
                new List<string>() { "wa", "or", "id", "ak" }, 
                new List<string>() { "ca", "az", "ut", "nv", "hi" }, 
                new List<string>() { "ms", "al", "ga", "sc",  "fl" }};
            insertData.zoom_selection = new Rect(0, 0, 1730, 1200);
            insertData.clipped_selection = new Rect(770, 130, 633, 820);
            period_2_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1812";
            insertData.question = " Where did much of the War of 1812 occur?";
            insertData.answer_cluster = new List<string>() { "mi", "oh", "pa", "ny", "vt" };
            insertData.correct_index = 2;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "me", "nh", "ma", "ri", "ct" }, 
                new List<string>() { "nj", "de", "md", "va" }, 
                new List<string>() { "mi", "oh", "pa", "ny", "vt" }, 
                new List<string>() { "nc", "sc", "ga", "fl" }};
            insertData.zoom_selection = new Rect(1000, 0, 921, 1200);
            insertData.clipped_selection = new Rect(770, 130, 633, 820);
            period_2_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1831";
            insertData.question = " Where was the final destination of the Trail of Tears?";
            insertData.answer_cluster = new List<string>() { "ok" };
            insertData.correct_index = 3;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "tx" }, 
                new List<string>() { "nm" }, 
                new List<string>() { "ks" }, 
                new List<string>() { "ok" }};
            insertData.zoom_selection = new Rect(450, 500, 621, 765);
            insertData.clipped_selection = new Rect(340, 440, 481, 528);
            period_2_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1804";
            insertData.question = " Where did Lewis and Clark depart for their expedition?";
            insertData.answer_cluster = new List<string>() { "ms" };
            insertData.correct_index = 1;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "nc" }, 
                new List<string>() { "ms" }, 
                new List<string>() { "va" }, 
                new List<string>() { "la" }};
            insertData.zoom_selection = new Rect(1040, 600, 730, 550);
            insertData.clipped_selection = new Rect(720, 450, 560, 415);
            period_2_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1806";
            insertData.question = " Where was the final destination of Lewis and Clark?";
            insertData.answer_cluster = new List<string>() { "or" };
            insertData.correct_index = 0;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "or" }, 
                new List<string>() { "ca" }, 
                new List<string>() { "id" }, 
                new List<string>() { "mt" }};
            period_2_questions.Add(insertData);
            insertData.zoom_selection = new Rect(0, 0, 752, 782);
            insertData.clipped_selection = new Rect(10, 100, 546, 600);
            questionLookup.Add(2, period_2_questions);
        }

        private void set_period_3_questions()
        {
            List<GameData> period_3_questions = new List<GameData>();

            GameData insertData = new GameData();
            insertData.title = "1900";
            insertData.question = " Where did the Wright brothers fly their first plane?";
            insertData.answer_cluster = new List<string>() { "nc" };
            insertData.correct_index = 2;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "ny" }, 
                new List<string>() { "va" }, 
                new List<string>() { "nc" }, 
                new List<string>() { "ky" }};
            insertData.zoom_selection = new Rect(1170, 200, 571, 551);
            insertData.clipped_selection = new Rect(870, 240, 466, 419);
            period_3_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1935";
            insertData.question = " Where was the Hoover Dam built during the New Deal?";
            insertData.answer_cluster = new List<string>() { "nv" };
            insertData.correct_index = 3;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "ca" }, 
                new List<string>() { "or" }, 
                new List<string>() { "nm" }, 
                new List<string>() { "nv" }};
            insertData.zoom_selection = new Rect(0, 100, 750, 800);
            insertData.clipped_selection = new Rect(10, 300, 536, 452);
            period_3_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1941";
            insertData.question = " Where did the Japanese forces attack, bringing the US into World War II?";
            insertData.answer_cluster = new List<string>() { "hi" };
            insertData.correct_index = 2;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "ca" }, 
                new List<string>() { "or" }, 
                new List<string>() { "hi" }, 
                new List<string>() { "ak" }};
            insertData.zoom_selection = new Rect(10, 300, 451, 676);
            insertData.clipped_selection = new Rect(10, 170, 450, 820);
            period_3_questions.Add(insertData);

            insertData = new GameData();
            insertData.title = "1969";
            insertData.question = " Where the first moon landing mission launch from?";
            insertData.answer_cluster = new List<string>() { "fl" };
            insertData.correct_index = 1;
            insertData.solution_set = new List<List<string>>() {
                new List<string>() { "va" }, 
                new List<string>() { "fl" }, 
                new List<string>() { "tx" }, 
                new List<string>() { "al" }};
            insertData.zoom_selection = new Rect(590, 600, 1164, 563);
            insertData.clipped_selection = new Rect(420, 550, 868, 415);
            period_3_questions.Add(insertData);

            questionLookup.Add(3, period_3_questions);
        }

        public Dictionary<int, List<GameData>> questionLookup = 
            new Dictionary<int, List<GameData>>();
    }
}
