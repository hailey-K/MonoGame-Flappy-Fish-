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
    class Background : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        ContentManager content;
        // public Rectangle backgroundRec;
        public Rectangle backgroundRec1, backgroundRec2;
        public Texture2D backgroundTex;

        public Background(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
            Initialize();
            LoadContent();
        }
        public override void Initialize()
        {
            backgroundRec1 = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            backgroundRec2 = new Rectangle(backgroundRec1.Width, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            backgroundTex = content.Load<Texture2D>("Images/background");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {

            if (backgroundRec1.X + backgroundRec1.Width <= 0)
            {
                backgroundRec1.X = backgroundRec2.X+ backgroundRec2.Width;
            }
            if (backgroundRec2.X + backgroundRec1.Width <= 0)
            {
                backgroundRec2.X = backgroundRec1.X + backgroundRec1.Width;
            }

            backgroundRec1.X -= 2;
            backgroundRec2.X -= 2;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTex, backgroundRec1, Color.White);
            spriteBatch.Draw(backgroundTex, backgroundRec2, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}