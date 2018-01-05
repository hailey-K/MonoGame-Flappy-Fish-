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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Fish fish;
        private Rectangle fishRec;
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            ContentManager Content = game.Content;

            //  Texture2D fishTex = g.Content.Load<Texture2D>("Images/fish");
            //   batLeft = new Bat(this, spriteBatch, Content, batLeftRec, "images/BatLeft", 1, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth);
            fishRec = new Rectangle(0, 0, 2, 2);
            fish = new Fish(game, spriteBatch, Content, fishRec, "Images/fish");
            this.Components.Add(fish);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
