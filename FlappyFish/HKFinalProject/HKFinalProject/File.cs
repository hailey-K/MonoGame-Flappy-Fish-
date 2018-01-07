using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKFinalProject
{
    public class File
    {
        public string readFile()
        {
            //    StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "ScoreList.txt"));
            StreamReader reader = new StreamReader(@"C:\Users\RIM\Documents\MonoGame-Flappy-Fish-\FlappyFish\HKFinalProject\HKFinalProject\ScoreList.txt");

            string score = "";
            string temp = "";
            while ((temp = reader.ReadLine()) != null)
            {
                score += temp;
            }
            reader.Close();
            return score;

        }
    }
}
