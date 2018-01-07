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
        private List<Shark> sharks = new List<Shark>();
        private Background background;
        private Random rd = new Random();
        private Game1 g;
        private ContentManager Content;
        public ActionScene(Game game) : base(game)
        {
           g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            Content = game.Content;
            fish = new Fish(game, spriteBatch, Content);
            background = new Background(game, spriteBatch, Content);
            this.Components.Add(fish);
        }
        float interval = 0;
        public override void Update(GameTime gameTime)
        {
            interval += (float)gameTime.ElapsedGameTime.TotalSeconds;
            background.Update(gameTime);

            foreach (Shark shark in sharks)
            {
                shark.Update(gameTime);
            }
            LoadShark();

            base.Update(gameTime);
        }
        public void LoadShark()
        {

            int sharkY = rd.Next(110, GraphicsDevice.Viewport.Height - 110);

            if (interval >= 1)
            {
                interval = 0;
                if (sharks.Count < 5)
                    sharks.Add(new Shark(g, spriteBatch, Content, sharkY));
            }

            for(int i = 0; i < sharks.Count; i++)
            {
                if (sharks[i].sharkPositionX + 110 <= 0)
                {
                    sharks.RemoveAt(i);
                    i--;
                }
            }
        }
        public override void Draw(GameTime gameTime)
        {
           background.Draw(gameTime);
            fish.Draw(gameTime);
            foreach (Shark shark in sharks)
            {
                shark.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
