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
    /// Shark
    /// </summary>
    class Shark : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        ContentManager content;
        List<Texture2D> sharkTex;
        Rectangle shark;
        int currentFrame = 0;
        const int FRAMEDELAYTIMER = 10;
        int frameDelay = 0;
        public readonly int sharkHeight = 110;
        public readonly int sharkWidth = 120;
        int speed = 5;
        public int sharkPositionX;
        public int sharkPositionY;
        public Shark(Game game, SpriteBatch spriteBatch, ContentManager content, int sharkPositionY) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            sharkTex = new List<Texture2D>();
            this.sharkPositionY = sharkPositionY;
            sharkPositionX = GraphicsDevice.Viewport.Width - sharkWidth;
            shark = new Rectangle(sharkPositionX, sharkPositionY, sharkWidth, sharkHeight);
            LoadContent();
        }
        /// <summary>
        /// getBound : Get Rectangle (position, size)
        /// </summary>
        /// <returns></returns>
        public Rectangle getBound()
        {
            return new Rectangle(sharkPositionX + 10, sharkPositionY + 10, sharkWidth-15, sharkHeight-20);
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            sharkPositionX -= speed;

            frameDelay++;
            if (frameDelay > FRAMEDELAYTIMER)
            {
                frameDelay = 0;
                if (currentFrame == 0)
                {
                    currentFrame = 1;
                    sharkPositionY += 3;
                }
                else
                {
                    currentFrame = 0;
                    sharkPositionY -= 3;
                }
            }

            shark = new Rectangle(sharkPositionX, sharkPositionY, sharkWidth, sharkHeight);
            base.Update(gameTime);
        }
        /// <summary>
        /// setSpeed : set Shark's speed
        /// </summary>
        /// <param name="speed"></param>
        public void setSpeed(int speed)
        {
            this.speed = speed;
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sharkTex.ElementAt<Texture2D>(currentFrame),
             shark,
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
            Texture2D fishText1 = content.Load<Texture2D>("Images/shark1");
            Texture2D fishText2 = content.Load<Texture2D>("Images/shark2");
            sharkTex.Add(fishText1);
            sharkTex.Add(fishText2);

            base.LoadContent();
        }
    }
}
