using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace QuadTrees
{
    /// <summary>
    /// A generic sprite type
    /// </summary>
    public class GenericSprite : IQuadTreeElement
    {
        /// <summary>
        /// Sprite's bounding box
        /// </summary>
        public Rectangle boundingBox { get; set; }   // The bounding box

        /// <summary>
        /// Sprite's constructor
        /// </summary>
        /// <param name="boundingBox"></param>
        public GenericSprite(Rectangle boundingBox)
        {
            this.boundingBox = boundingBox;
        }
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// Graphics manager
        /// </summary>
        GraphicsDeviceManager graphics;

        /// <summary>
        /// Sprite batch to draw onto
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// Display font
        /// </summary>
        SpriteFont displayFont;

        /// <summary>
        /// Quad tree
        /// </summary>
        QuadTree quadTree;

        /// <summary>
        /// Blank texture
        /// </summary>
        Texture2D blankTexture;

        /// <summary>
        /// Circle texture
        /// </summary>
        Texture2D circleTexture;

        /// <summary>
        /// Random number generator
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Window width
        /// </summary>
        private const int windowWidth = 1280;

        /// <summary>
        /// Window height
        /// </summary>
        private const int windowHeight = 720;
        
        /// <summary>
        /// List of sprites in circle
        /// </summary>
        List<IQuadTreeElement> listSelection = new List<IQuadTreeElement>();

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferHeight = windowHeight;
            this.graphics.PreferredBackBufferWidth = windowWidth;
            this.Content.RootDirectory = "Content";

            this.quadTree = new QuadTree(new Vector2(0, 0), new Vector2(windowWidth, windowHeight), 10);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.blankTexture = this.GenerateBlankTexture();
            this.circleTexture = Content.Load<Texture2D>("CircleSelection");
            this.displayFont = Content.Load<SpriteFont>("DisplayFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Update input
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter) || mouseState.LeftButton == ButtonState.Pressed)
                this.quadTree.InsertElement(new GenericSprite(new Rectangle(this.random.Next(0, windowWidth - 1), this.random.Next(0, windowHeight - 1), this.random.Next(1, 25), this.random.Next(1, 25))));

            // Query all sprites in circle
            this.listSelection = this.quadTree.ElementsInCircle(new Vector2(mouseState.X, mouseState.Y), 75);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            // Draw quad tree
            this.quadTree.DrawTree(this.spriteBatch, this.blankTexture);

            // Draw all sprites in circle
            foreach (IQuadTreeElement element in this.listSelection)
                spriteBatch.Draw(blankTexture, element.boundingBox, Color.Yellow);

            // Draw circle
            MouseState mouseState = Mouse.GetState();
            this.spriteBatch.Draw(this.circleTexture, new Vector2(mouseState.X - 75, mouseState.Y - 75), Color.White);

            // Draw message
            this.spriteBatch.DrawString(this.displayFont, "Hold left mouse button to generate random sprites", new Vector2(20, 20), Color.Yellow);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Generate a blank texture
        /// </summary>
        /// <returns>Returns a blank texutre, 1 pixel in height and width</returns>
        Texture2D GenerateBlankTexture()
        {
            Texture2D blankTexture = new Texture2D(this.GraphicsDevice, 1, 1);

            blankTexture.SetData<Color>(new Color[] { new Color(1.0f, 1.0f, 1.0f, 1.0f) });

            return blankTexture;
        }
    }
}
