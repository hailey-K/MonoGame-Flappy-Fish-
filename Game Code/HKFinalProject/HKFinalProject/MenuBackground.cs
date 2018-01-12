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
    /// MenuBackground
    /// </summary>
    class MenuBackground : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        ContentManager content;
        public List<Rectangle> backgroundRec;
        Rectangle background;
        List<Texture2D> BackgroundTex;
        int currentFrame = 0;
        int backgroundHeight;
        int backgroundWidth;
        const int FRAMEDELAYTIMER = 10;          //how many game loop iterations before we  
        int frameDelay = 0;
        public MenuBackground(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.backgroundWidth = GraphicsDevice.Viewport.Width;
            this.backgroundHeight = GraphicsDevice.Viewport.Height;
            backgroundRec = new List<Rectangle>();
            BackgroundTex = new List<Texture2D>();
            background = new Rectangle(0, 0, backgroundWidth, backgroundHeight);
            Rectangle background1 = new Rectangle(0, 0, backgroundWidth, backgroundHeight);
            Rectangle background2 = new Rectangle(0, 0, backgroundWidth, backgroundHeight);
            backgroundRec.Add(background1);
            backgroundRec.Add(background2);
            LoadContent();
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
                if (currentFrame == 0)
                {
                    currentFrame = 1;
                }
                else
                {
                    currentFrame = 0;
                }
            }
            background = new Rectangle(0, 0, backgroundWidth, backgroundHeight);

            base.Update(gameTime);
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BackgroundTex.ElementAt<Texture2D>(currentFrame),
               background,
                Color.White
                );
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// LoadContent
        /// </summary>
        protected override void LoadContent()
        {
            Texture2D backgroundText1 = content.Load<Texture2D>("Images/background_menu1");
            Texture2D backgroundText2 = content.Load<Texture2D>("Images/background_menu2");
            BackgroundTex.Add(backgroundText1);
            BackgroundTex.Add(backgroundText2);

            base.LoadContent();
        }
    }
}
