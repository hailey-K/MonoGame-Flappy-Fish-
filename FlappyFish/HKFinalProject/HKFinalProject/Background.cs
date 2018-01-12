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
    /// <summary>
    /// Background : Scrolling background class
    /// </summary>
    class Background : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        ContentManager content;
        public Rectangle backgroundRec1, backgroundRec2;
        public Texture2D backgroundTex;
        string imageSource;
        public Background(Game game, SpriteBatch spriteBatch, ContentManager content, string imageSource) : base(game)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
            this.imageSource = imageSource;
            Initialize();
            LoadContent();
        }
        /// <summary>
        /// Initialize
        /// </summary>
        public override void Initialize()
        {
            backgroundRec1 = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            backgroundRec2 = new Rectangle(backgroundRec1.Width, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            base.Initialize();
        }
        /// <summary>
        /// LoadContent
        /// </summary>
        protected override void LoadContent()
        {
            backgroundTex = content.Load<Texture2D>(imageSource);
            base.LoadContent();
        }
        /// <summary>
        /// Update : Changing the images' X and Y, It makes infinite background
        /// </summary>
        /// <param name="gameTime"></param>
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
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
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