﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKFinalProject
{
    public class File
    {
        string path;
        FileStream file;
        StreamWriter w;
        StreamReader r;

        public File()
        {
            path = Environment.CurrentDirectory + @"\ScoreList.txt";
        }

        public string readFile()
        {
          file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            r = new StreamReader(file);
            string highScore = "";
            while (r.Peek() >= 0)
            {
                highScore+=r.ReadLine()+"\n";
            }
            r.Close();
            return highScore;
        }
     public void SaveFile(string name, int score)
    {
            file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            w = new StreamWriter(file);
            long endPoint = file.Length;
            file.Seek(endPoint, SeekOrigin.Begin);
            w.WriteLine("\"" + name + "\"," + score);
            w.Close();
        }
    public void CreateNewFile()
    {
            file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            w = new StreamWriter(file);
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            w.WriteLine("\"AAA\",400");
            w.WriteLine("\"BBB\",1000");
            w.WriteLine("\"CCC\",300");
            w.WriteLine("\"DDD\",200");
            w.WriteLine("\"EEE\",700");
            w.Close();
        }
    }
}
