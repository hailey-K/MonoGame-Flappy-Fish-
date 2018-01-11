using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HKFinalProject
{
    class HighScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D aboutTex;
        private Rectangle highScoreBackground;
        SpriteFont highlightFont;
        File file;
        string fileInfo="";
        Vector2 position;
        SpriteFont title;
        public HighScoreScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            ContentManager Content = game.Content;
            this.spriteBatch = g.spriteBatch;
            highScoreBackground = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
             highlightFont = game.Content.Load<SpriteFont>("Fonts/hilightFont");
            aboutTex = g.Content.Load<Texture2D>("Images/highScore");
            file = new File();
            file.CreateNewFile();
            title = Content.Load<SpriteFont>("Fonts/title");
            position = new Vector2(350,245);
        }

        public override void Update(GameTime gameTime)
        {
            fileInfo = file.readFile();
            fileInfo = SortedByHighScore(fileInfo);
            base.Update(gameTime);
        }

        public string SortedByHighScore(string fileInfo)
        {
            string[] lines = Regex.Split(fileInfo, "\n");
            int highScoreIndex = 1;
            List<string[]> lineList = new List<string[]>();
            List<string[]> sortedByHighScore = new List<string[]>();

            foreach (string temp in lines)
            {
                if (!string.IsNullOrWhiteSpace(temp))
                { 
                string[] splitLine = Regex.Split(temp, ",");
                splitLine[0] = splitLine[0].Replace("\"","");
                lineList.Add(splitLine);
                }
            }

            while(lineList.Count != 0)
            {
                string[] temp = lineList[0];
                int max = int.Parse(temp[1]);
                int maxIndex = 0;

                for(int i=0;i< lineList.Count;i++)
                {
                    string[] tempFindMinS = lineList[i];
                    if(int.Parse(tempFindMinS[1]) >= max)
                    {
                        max = int.Parse(tempFindMinS[1]);
                        maxIndex = i;
                    }
                }
                sortedByHighScore.Add(lineList[maxIndex]);
                lineList.RemoveAt(maxIndex);
            }
            fileInfo = "";
            foreach (string[] highscoreS in sortedByHighScore)
            {
                if(highScoreIndex <= 10)
                {
                fileInfo += highScoreIndex + " ) " + highscoreS[0] + " , " + highscoreS[1]+"\n";
                }
                highScoreIndex++;
            }

            return fileInfo;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(aboutTex, highScoreBackground, Color.White);
            spriteBatch.DrawString(highlightFont, fileInfo, position, Color.Black);
            spriteBatch.DrawString(title, "Top 10 Records", new Vector2(280,73), Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
