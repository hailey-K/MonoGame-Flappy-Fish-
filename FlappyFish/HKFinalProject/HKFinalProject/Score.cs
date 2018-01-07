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

        public Score(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            Game1 g = (Game1)game;

            ContentManager Content = game.Content;
            this.spriteBatch = spriteBatch;
            scoreLabel = Content.Load<SpriteFont>("Fonts/hilightFont");
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
            spriteBatch.DrawString(scoreLabel, Convert.ToString(score)+" M", new Vector2(GraphicsDevice.Viewport.Width - 100, 80), Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
