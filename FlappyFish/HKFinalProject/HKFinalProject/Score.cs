using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HKFinalProject
{
    /// <summary>
    /// Score : Showing how far the fish moves from the start point
    /// </summary>
    class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont scoreLabel;
        public int score = 0;
        const int FRAMEDELAYTIMER = 3;
        int frameDelay = 0;
        KeyboardState previousState;
        string putName = "";
        Game1 g;
        private SoundEffectInstance typingSoundEffectInstance;
        public Score(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            g = (Game1)game;
            typingSoundEffectInstance = content.Load<SoundEffect>(@"Music\typingSound").CreateInstance();
            ContentManager Content = game.Content;
            this.spriteBatch = spriteBatch;
            scoreLabel = Content.Load<SpriteFont>("Fonts/hilightFont");
            previousState = Keyboard.GetState();
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
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
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(scoreLabel, Convert.ToString(score) + " M", new Vector2(GraphicsDevice.Viewport.Width - 200, 80), Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// SaveScoreIntoFile : Save score into File
        /// </summary>
        /// <param name="name"></param>
        public void SaveScoreIntoFile(string name)
        {
            File file = new File();
            file.SaveFile(name, score);
        }
        /// <summary>
        /// setPutName
        /// </summary>
        /// <param name="putName"></param>
        public void setPutName(String putName)
        {
            this.putName = putName;
        }
        /// <summary>
        /// enterName : Check which method is used
        /// </summary>
        /// <returns></returns>
        public string enterName()
        {
            KeyboardState state = Keyboard.GetState();
            if (putName.Length < 10)
            {
                if (state.IsKeyDown(Keys.A) && !previousState.IsKeyDown(Keys.A))
                {
                    putName += "A";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.B) && !previousState.IsKeyDown(Keys.B))
                {
                    putName += "B";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.C) && !previousState.IsKeyDown(Keys.C))
                {
                    putName += "C";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.D) && !previousState.IsKeyDown(Keys.D))
                {
                    putName += "D";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.E) && !previousState.IsKeyDown(Keys.E))
                {
                    putName += "E";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.F) && !previousState.IsKeyDown(Keys.F))
                {
                    putName += "F";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.G) && !previousState.IsKeyDown(Keys.G))
                {
                    putName += "G";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.H) && !previousState.IsKeyDown(Keys.H))
                {
                    putName += "H";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.I) && !previousState.IsKeyDown(Keys.I))
                {
                    putName += "I";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.J) && !previousState.IsKeyDown(Keys.J))
                {
                    putName += "J";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.K) && !previousState.IsKeyDown(Keys.K))
                {
                    putName += "K";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.L) && !previousState.IsKeyDown(Keys.L))
                {
                    putName += "L";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.M) && !previousState.IsKeyDown(Keys.M))
                {
                    putName += "M";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.N) && !previousState.IsKeyDown(Keys.N))
                {
                    putName += "N";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.O) && !previousState.IsKeyDown(Keys.O))
                {
                    putName += "O";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.P) && !previousState.IsKeyDown(Keys.P))
                {
                    putName += "P";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.Q) && !previousState.IsKeyDown(Keys.Q))
                {
                    putName += "Q";
                    typingSoundEffectInstance.Play();
                }

                else if (state.IsKeyDown(Keys.R) && !previousState.IsKeyDown(Keys.R))
                {
                    putName += "R";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.S) && !previousState.IsKeyDown(Keys.S))
                {
                    putName += "S";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.T) && !previousState.IsKeyDown(Keys.T))
                {
                    putName += "T";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.U) && !previousState.IsKeyDown(Keys.U))
                {
                    putName += "U";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.V) && !previousState.IsKeyDown(Keys.V))
                {
                    putName += "V";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.W) && !previousState.IsKeyDown(Keys.W))
                {
                    putName += "W";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.X) && !previousState.IsKeyDown(Keys.X))
                {
                    putName += "X";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.Y) && !previousState.IsKeyDown(Keys.Y))
                {
                    putName += "Y";
                    typingSoundEffectInstance.Play();
                }
                else if (state.IsKeyDown(Keys.Z) && !previousState.IsKeyDown(Keys.Z))
                {
                    putName += "Z";
                    typingSoundEffectInstance.Play();
                }
            }
            if (state.IsKeyDown(Keys.Back) && !previousState.IsKeyDown(Keys.Back) && !string.IsNullOrEmpty(putName))
            {
                putName = putName.Substring(0, putName.Length - 1);
            }
            if (state.IsKeyDown(Keys.Enter) && !previousState.IsKeyDown(Keys.Enter) && putName != "")
            {
                SaveScoreIntoFile(putName);
                putName += "#";
            }
            previousState = state;

            return putName;
        }

    }
}
