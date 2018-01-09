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
    class Shark : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        ContentManager content;
        List<Texture2D> sharkTex;
        Rectangle shark;
        int currentFrame = 0;
        const int FRAMEDELAYTIMER = 10;          //how many game loop iterations before we  
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
        public override void Update(GameTime gameTime)
        {
            sharkPositionX-= speed;

            frameDelay++;
            if (frameDelay > FRAMEDELAYTIMER)
            {
                frameDelay = 0;                 //reset the frame counter
                if (currentFrame == 0) { 
                    currentFrame = 1;
                    sharkPositionY += 3;
                }
                else { 
                    currentFrame = 0;
                    sharkPositionY -= 3;
                }
            }

            shark = new Rectangle(sharkPositionX, sharkPositionY, sharkWidth, sharkHeight);
            base.Update(gameTime);
        }
        public void setSpeed(int speed)
        {
            this.speed = speed;
        }
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
