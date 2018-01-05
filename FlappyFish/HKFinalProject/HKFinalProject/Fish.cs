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
     //   private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        ContentManager content;
        public Rectangle fishRec;
        Texture2D fishTex;
        string imageSources;
        //   public Fish(Game game, SpriteBatch spriteBatch,Texture2D tex) : base(game)
        //   fish = new Fish(game, spriteBatch, Content, fishRec, "Images/fish");
        public Fish(Game game, SpriteBatch spriteBatch, ContentManager content, Rectangle fishRec, string imageSources) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.fishRec = fishRec;
            this.imageSources = imageSources;
            LoadContent();

            /*   this.spriteBatch = spriteBatch;
               this.tex = tex;
               position = new Vector2((Shared.stage.X - tex.Width) / 2,
                   Shared.stage.Y - tex.Height);
               speed = new Vector2(4, 0);
               */
        }
        protected override void LoadContent()
        {
            fishTex = content.Load<Texture2D>(imageSources);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
          /*  KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;
                if (position.X > Shared.stage.X - tex.Width)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
            */
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(fishTex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
