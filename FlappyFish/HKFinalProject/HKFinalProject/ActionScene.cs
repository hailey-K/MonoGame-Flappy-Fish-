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
        private Shark shark;
        private Background background;
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            ContentManager Content = game.Content;
            fish = new Fish(game, spriteBatch, Content);
            shark = new Shark(game, spriteBatch, Content);
            background = new Background(game, spriteBatch, Content);
            this.Components.Add(fish);
            this.Components.Add(shark);
        }

        public override void Update(GameTime gameTime)
        {
           background.Update(gameTime);
            shark.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
           background.Draw(gameTime);
            fish.Draw(gameTime);
            shark.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
