﻿namespace Physicist.Controls
{
    using Microsoft.Xna.Framework;
    using Physicist.Controls;
    using Physicist.Controls.GUIControls;
    using Physicist.Extensions;

    public partial class MenuScreen : GameScreen
    {
        /// <summary>
        /// LoadContent is called once per instance of screen and is used to 
        /// load all of the GUI elements 
        /// </summary>
        public override bool LoadGUI()
        {
            var success = true;

            this.AddGUIElement(new Label(this) { Bounds = new Rectangle(100, 50, 100, 25), TextColor = Color.White, Text = "Menu Screen:" });
            this.AddGUIElement(new Label(this) { Bounds = new Rectangle(100, 100, 100, 25), TextColor = Color.White, Text = "Esc to Quit:" });

            Button playButton = new Button(this, this.GraphicsDevice)
            {
                Bounds = new Rectangle((ScreenManager.GraphicsDevice.Viewport.Width / 2) - 155, this.GraphicsDevice.Viewport.Height - 130, 310, 50),
                BackgroundColor = Color.Goldenrod,
                HoverBackgroundColor = Color.Goldenrod.Brighten(15),
                BorderColor = Color.LightGray,
                BorderSize = 2,
                Text = "Play Game"
            };

            playButton.OnPressed += this.StartPhysicist;
            success &= this.AddGUIElement(playButton);

            Button optionsButton = new Button(this, this.GraphicsDevice)
            {
                Bounds = new Rectangle((ScreenManager.GraphicsDevice.Viewport.Width / 2) - 155, this.GraphicsDevice.Viewport.Height - 75, 153, 50),
                BackgroundColor = Color.Goldenrod,
                HoverBackgroundColor = Color.Goldenrod.Brighten(15),
                BorderColor = Color.LightGray,
                BorderSize = 2,
                Text = "Options"
            };

            optionsButton.OnPressed += this.StartOptions;
            success &= this.AddGUIElement(optionsButton);

            Button extrasButton = new Button(this, this.GraphicsDevice)
            {
                Bounds = new Rectangle((ScreenManager.GraphicsDevice.Viewport.Width / 2) + 3, this.GraphicsDevice.Viewport.Height - 75, 153, 50),
                BackgroundColor = Color.Goldenrod,
                HoverBackgroundColor = Color.Goldenrod.Brighten(15),
                BorderColor = Color.LightGray,
                BorderSize = 2,
                Text = "Extras"
            };

            extrasButton.OnPressed += this.StartExtras;
            success &= this.AddGUIElement(extrasButton);

            return success && base.LoadGUI();
        }

        /// <summary>
        /// Allows the screen to run updating logic on GUI element like making property changes,
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void UpdateGUI(GameTime gameTime)
        {
            base.UpdateGUI(gameTime);
            foreach (var element in this.GUIElements)
            {
                element.Update(gameTime);
            }
        }

        /// <summary>
        /// Called every time the screen is to re-draw itself
        /// </summary>
        /// <param name="sb">SpriteBatch for drawing</param>
        public override void DrawGUI(FCCSpritebatch sb)
        {
            base.DrawGUI(sb);
            foreach (var element in this.GUIElements)
            {
                element.Draw(sb);
            }
        }

        /// <summary>
        /// UnloadContent is called once per instance of screen and is used to 
        /// unload all of the GUI elements
        /// </summary>
        public override void UnloadGUI()
        {
            foreach (var element in this.GUIElements)
            {
                element.UnloadContent();
            }

            base.UnloadGUI();
        }
    }
}
