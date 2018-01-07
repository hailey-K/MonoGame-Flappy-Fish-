using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace HKFinalProject
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StartScene : GameScene
    {
        private MenuBackground menuBackground;
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        string[] menuItems = {"Start Game",
                                "Help",
                                "High Score",
                                "About",
                                "Quit"};
        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            
            ContentManager Content = game.Content;
            this.spriteBatch = g.spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts/hilightFont");
            menuBackground = new MenuBackground(game, spriteBatch, Content);

            Menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(Menu);

        }

        public override void Update(GameTime gameTime)
        {
            menuBackground.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            menuBackground.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
