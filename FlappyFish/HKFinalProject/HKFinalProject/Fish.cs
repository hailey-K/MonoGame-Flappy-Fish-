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
    class Fish: DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        ContentManager content;
        public List<Rectangle> fishRec;
        public Rectangle fish;
        List<Texture2D> fishTex;
        int currentFrame = 0;
        bool isJumping = false;
        int jumpPower=-15;
        readonly int fishkHeight = 90;
        readonly int fishWidth = 85;
        bool fishDead = false;
        public Fish(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            Initialize();
        }
        public override void Initialize()
        {
            fishRec = new List<Rectangle>();
            fishTex = new List<Texture2D>();
            fish = new Rectangle(50, 50, fishWidth, fishkHeight);
            Rectangle fish1 = new Rectangle(50, 50, fishWidth, fishkHeight);
            Rectangle fish2 = new Rectangle(50, 50, fishWidth, fishkHeight);
            fishRec.Add(fish1);
            fishRec.Add(fish2);
            base.Initialize();
            LoadContent();
        }
        public void setFishDead(bool fishDead)
        {
            this.fishDead = fishDead;
        }
        public override void Update(GameTime gameTime)
        {
         
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                currentFrame = 1;
                isJumping = true;
            }
            if (isJumping && !fishDead)      // compute a nice arc so that up-movement is gradual
            {
                if (jumpPower < 0)
                {
                    if (fish.Y <= 0)
                    {
                        fish.Y = 0;
                        jumpPower = 0;
                    }
                    else
                    {
                        fish.Y += jumpPower;
                        jumpPower++;
                    }
                }
                else
                { 
                    isJumping = false;
                    jumpPower = -15;
                }
            }
            else
            {
                fish.Y += 5;
                currentFrame = 0;
            }
            if (fishDead)
            {
                currentFrame = 3;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(fishTex.ElementAt<Texture2D>(currentFrame),
               fish,
                Color.White
                );
            spriteBatch.End();
            base.Draw(gameTime);
        }
        protected override void LoadContent()
        {
            Texture2D fishText1 = content.Load<Texture2D>("Images/fish2");
            Texture2D fishText2 = content.Load<Texture2D>("Images/fish1");
            Texture2D fishText3 = content.Load<Texture2D>("Images/fishScared");
            Texture2D fishText4 = content.Load<Texture2D>("Images/fishDead");
            fishTex.Add(fishText1);
            fishTex.Add(fishText2);
            fishTex.Add(fishText3);
            fishTex.Add(fishText4);

            base.LoadContent();
        }

     
    }
}
