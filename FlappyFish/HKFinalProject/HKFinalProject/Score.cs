using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HKFinalProject
{
    class Score: DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont scoreLabel;
        public int score = 0;
        const int FRAMEDELAYTIMER = 3;          //how many game loop iterations before we  
        int frameDelay = 0;
        KeyboardState previousState;
        string putName = "";
        Game1 g;
        public Score(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            g = (Game1)game;

            ContentManager Content = game.Content;
            this.spriteBatch = spriteBatch;
            scoreLabel = Content.Load<SpriteFont>("Fonts/hilightFont");
            previousState = Keyboard.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            frameDelay++;
            if (frameDelay > FRAMEDELAYTIMER)
            {
                frameDelay = 0;                 //reset the frame counter
                score++;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(scoreLabel, Convert.ToString(score)+" M", new Vector2(GraphicsDevice.Viewport.Width - 200, 80), Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void SaveScoreIntoFile(string name)
        {
            File file = new File();
            file.SaveFile(name, score);
        }
        public void setPutName(String putName)
        {
            this.putName = putName;
        }
        public string enterName()
        {
            KeyboardState state = Keyboard.GetState();
            if(putName.Length < 10)
            { 
            if (state.IsKeyDown(Keys.A) && !previousState.IsKeyDown(Keys.A))
            {
                putName += "A";
            }
            else if (state.IsKeyDown(Keys.B) && !previousState.IsKeyDown(Keys.B))
            {
                putName += "B";
            }

            else if (state.IsKeyDown(Keys.C) && !previousState.IsKeyDown(Keys.C))
            {
                putName += "C";
            }

            else if (state.IsKeyDown(Keys.D) && !previousState.IsKeyDown(Keys.D))
            {
                putName += "D";
            }

            else if (state.IsKeyDown(Keys.E) && !previousState.IsKeyDown(Keys.E))
            {
                putName += "E";
            }

            else if (state.IsKeyDown(Keys.F) && !previousState.IsKeyDown(Keys.F))
            {
                putName += "F";
            }

            else if (state.IsKeyDown(Keys.G) && !previousState.IsKeyDown(Keys.G))
            {
                putName += "G";
            }

            else if (state.IsKeyDown(Keys.H) && !previousState.IsKeyDown(Keys.H))
            {
                putName += "H";
            }

            else if (state.IsKeyDown(Keys.I) && !previousState.IsKeyDown(Keys.I))
            {
                putName += "I";
            }

            else if (state.IsKeyDown(Keys.J) && !previousState.IsKeyDown(Keys.J))
            {
                putName += "J";
            }

            else if (state.IsKeyDown(Keys.K) && !previousState.IsKeyDown(Keys.K))
            {
                putName += "K";
            }
            else if (state.IsKeyDown(Keys.L) && !previousState.IsKeyDown(Keys.L))
            {
                putName += "L";
            }
            else if (state.IsKeyDown(Keys.M) && !previousState.IsKeyDown(Keys.M))
            {
                putName += "M";
            }

            else if (state.IsKeyDown(Keys.N) && !previousState.IsKeyDown(Keys.N))
            {
                putName += "N";
            }

            else if (state.IsKeyDown(Keys.O) && !previousState.IsKeyDown(Keys.O))
            {
                putName += "O";
            }

            else if (state.IsKeyDown(Keys.P) && !previousState.IsKeyDown(Keys.P))
            {
                putName += "P";
            }

            else if (state.IsKeyDown(Keys.Q) && !previousState.IsKeyDown(Keys.Q))
            {
                putName += "Q";
            }

            else if (state.IsKeyDown(Keys.R) && !previousState.IsKeyDown(Keys.R))
            {
                putName += "R";
            }
            else if (state.IsKeyDown(Keys.S) && !previousState.IsKeyDown(Keys.S))
            {
                putName += "S";
            }
            else if (state.IsKeyDown(Keys.T) && !previousState.IsKeyDown(Keys.T))
            {
                putName += "T";
            }
            else if (state.IsKeyDown(Keys.U) && !previousState.IsKeyDown(Keys.U))
            {
                putName += "U";
            }
            else if (state.IsKeyDown(Keys.V) && !previousState.IsKeyDown(Keys.V))
            {
                putName += "V";
            }
            else if (state.IsKeyDown(Keys.W) && !previousState.IsKeyDown(Keys.W))
            {
                putName += "W";
            }
            else if (state.IsKeyDown(Keys.X) && !previousState.IsKeyDown(Keys.X))
            {
                putName += "X";
            }
            else if (state.IsKeyDown(Keys.Y) && !previousState.IsKeyDown(Keys.Y))
            {
                putName += "Y";
            }
            else if (state.IsKeyDown(Keys.Z) && !previousState.IsKeyDown(Keys.Z))
            {
                putName += "Z";
            }
            else if (state.IsKeyDown(Keys.Back) && !previousState.IsKeyDown(Keys.Back) && !string.IsNullOrEmpty(putName))
            {
                    putName = putName.Substring(0,putName.Length-1);
            }
            }
            if (state.IsKeyDown(Keys.Enter) && !previousState.IsKeyDown(Keys.Enter) && putName != "")
            {
                SaveScoreIntoFile(putName);
                putName += "#";
                //g.setPressedESC(true);
            }
            previousState = state;

            return putName;
        }

    }
}
