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

namespace AStar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// Window width
        /// </summary>
        private const int windowWidth = 1280;

        /// <summary>
        /// Window height
        /// </summary>
        private const int windowHeight = 720;

        /// <summary>
        /// Graphics device
        /// </summary>
        GraphicsDeviceManager graphics;

        /// <summary>
        /// Sprite batch to draw onto
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// Texture of empty grid node
        /// </summary>
        Texture2D gridEmptyTexture;

        /// <summary>
        /// Texture of blocked grid node
        /// </summary>
        Texture2D gridBlockedTexture;

        /// <summary>
        /// Texture of cursor
        /// </summary>
        Texture2D cursorTexture;

        /// <summary>
        /// Texture of start pos
        /// </summary>
        Texture2D startPosTexture;

        /// <summary>
        /// Texture of target pos
        /// </summary>
        Texture2D targetPosTexture;

        /// <summary>
        /// A blank texture for drawing lines
        /// </summary>
        Texture2D blankTexture;

        /// <summary>
        /// Font for displaying text
        /// </summary>
        SpriteFont displayFont;

        /// <summary>
        /// Level grid
        /// </summary>
        bool[,] levelGrid = new bool[64,36];

        /// <summary>
        /// Path finding start pos
        /// </summary>
        Vector2 startPos;

        /// <summary>
        /// The next pos
        /// </summary>
        Vector2 nextPos;

        /// <summary>
        /// Path finding target pos
        /// </summary>
        Vector2 targetPos = new Vector2(32, 18);

        /// <summary>
        /// Path finder
        /// </summary>
        PathFinderComponent pathFinder;

        /// <summary>
        /// Next nodes on path
        /// </summary>
        List<Vector2> nextNodes;

        /// <summary>
        /// Is mouse currently clicking?
        /// </summary>
        bool isClicking;

        /// <summary>
        /// Last grid mouse was over
        /// </summary>
        Vector2 lastMouseGrid;

        /// <summary>
        /// Last FPS count
        /// </summary>
        float lastFPS = 60.0f;

        /// <summary>
        /// Accumulated FPS
        /// </summary>
        float accumulatedFPS = -1.0f;

        /// <summary>
        /// Reference time for measuring fps
        /// </summary>
        double referenceTimeFPS = 0.0f;

        /// <summary>
        /// Constructor
        /// </summary>
        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferHeight = Game1.windowHeight;
            this.graphics.PreferredBackBufferWidth = Game1.windowWidth;
            this.Content.RootDirectory = "Content"; 
            this.pathFinder = new PathFinderComponent(this.startPos, this.targetPos, this.levelGrid);
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.gridEmptyTexture = this.Content.Load<Texture2D>("GridEmpty");
            this.gridBlockedTexture = this.Content.Load<Texture2D>("GridBlocked");
            this.cursorTexture = this.Content.Load<Texture2D>("Cursor");
            this.startPosTexture = this.Content.Load<Texture2D>("StartPos");
            this.targetPosTexture = this.Content.Load<Texture2D>("TargetPos");
            this.blankTexture = this.GenerateBlankTexture();
            this.displayFont = this.Content.Load<SpriteFont>("DisplayFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Get mouse input
            MouseState mouseState = Mouse.GetState();

            // Set walls
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                Vector2 gridPos = new Vector2((int)(mouseState.X / 20.0f), (int)(mouseState.Y / 20.0f));

                if (!(this.isClicking) || gridPos != this.lastMouseGrid)
                {
                    if (gridPos.X >= 0.0f && gridPos.Y >= 0.0f && gridPos.X < this.levelGrid.GetLength(0) && gridPos.Y < this.levelGrid.GetLength(1))
                    {
                        if (gridPos != this.targetPos && gridPos != new Vector2((float)(Math.Round(this.startPos.X)), (float)(Math.Round(this.startPos.Y))))
                            this.levelGrid[(int)(gridPos.X), (int)(gridPos.Y)] = !this.levelGrid[(int)(gridPos.X), (int)(gridPos.Y)];
                        else if (this.levelGrid[(int)(gridPos.X), (int)(gridPos.Y)])
                            this.levelGrid[(int)(gridPos.X), (int)(gridPos.Y)] = !this.levelGrid[(int)(gridPos.X), (int)(gridPos.Y)];
                        this.pathFinder.UpdatedLevelGrid();
                    }
                }

                this.lastMouseGrid = gridPos;
                this.isClicking = true;
            }
            else
                this.isClicking = false;

            // Set target point
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Vector2 gridPos = new Vector2((int)(mouseState.X / 20.0f), (int)(mouseState.Y / 20.0f));

                if (gridPos.X >= 0.0f && gridPos.Y >= 0.0f && gridPos.X < this.levelGrid.GetLength(0) && gridPos.Y < this.levelGrid.GetLength(1))
                    this.targetPos = gridPos;
            }

            this.pathFinder.SetTargetPos(this.targetPos);

            // Find path and move
            this.MoveTowards(ref this.startPos, this.nextPos, gameTime.ElapsedGameTime.TotalSeconds);

            if (this.startPos == this.nextPos)
            {
                this.nextNodes = this.pathFinder.GetNextNodes(this.startPos);
                if (this.nextNodes != null && this.nextNodes.Count > 0)
                    this.nextPos = this.nextNodes[0];
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Move one point towards another one
        /// </summary>
        /// <param name="startPos">Start point</param>
        /// <param name="targetPos">Target point</param>
        /// <param name="deltaSeconds">Delta seconds</param>
        void MoveTowards(ref Vector2 startPos, Vector2 targetPos, double deltaSeconds)
        {
            Vector2 maximumMovement = targetPos - startPos;

            if (maximumMovement == Vector2.Zero)
                return;

            maximumMovement.Normalize();
            maximumMovement = maximumMovement * 10.0f * (float)(deltaSeconds);

            if (maximumMovement.Length() > (targetPos - startPos).Length())
                startPos = targetPos;
            else
                startPos = startPos + maximumMovement;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Measure FPS
            this.referenceTimeFPS += gameTime.ElapsedGameTime.TotalSeconds;
            this.accumulatedFPS += 1.0f;

            if (this.referenceTimeFPS >= 1.0d)
            {
                this.lastFPS = this.accumulatedFPS / (float)(this.referenceTimeFPS);
                this.accumulatedFPS = 0.0f;

                this.referenceTimeFPS = 0.0d;
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            // Draw grid
            for (int y = 0; y < this.levelGrid.GetLength(1); y++ )
            {
                for (int x = 0; x < this.levelGrid.GetLength(0); x++)
                {
                    Vector2 drawPos = new Vector2(x * 20.0f, y * 20.0f);

                    if (this.levelGrid[x, y])
                        this.spriteBatch.Draw(this.gridBlockedTexture, drawPos, Color.White);
                    else
                        this.spriteBatch.Draw(this.gridEmptyTexture, drawPos, Color.White);
                }
            }

            this.spriteBatch.End();

            this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            // Draw path
            if (this.nextNodes != null)
            {
                if (this.nextNodes.Count > 0)
                    this.DrawLine(this.spriteBatch, this.blankTexture, 5.0f, Color.Green, (this.startPos * 20.0f) + new Vector2(10.0f, 10.0f), (this.nextNodes[0] * 20.0f) + new Vector2(10.0f, 10.0f));

                for (int i = 0; i < this.nextNodes.Count - 1; i++)
                    this.DrawLine(this.spriteBatch, this.blankTexture, 5.0f, Color.Green, (this.nextNodes[i] * 20.0f) + new Vector2(10.0f, 10.0f), (this.nextNodes[i + 1] * 20.0f) + new Vector2(10.0f, 10.0f));
            }

            this.spriteBatch.End();

            this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            // Draw start and target point
            this.spriteBatch.Draw(this.targetPosTexture, this.targetPos * 20.0f, Color.White);
            this.spriteBatch.Draw(this.startPosTexture, this.startPos * 20.0f, Color.White);
            
            // Display instructions
            this.spriteBatch.DrawString(this.displayFont, "Right mouse button to draw or remove walls", new Vector2(20.0f, 10.0f), Color.Yellow);
            this.spriteBatch.DrawString(this.displayFont, "Left mouse button to set target point", new Vector2(20.0f, 30.0f), Color.Yellow);
            if (this.pathFinder.currentlySearching)
            {
                string searchingText = "Searching path";
                double gameTimeFactor = gameTime.TotalGameTime.TotalSeconds * 2.0f;
                double fraction = gameTimeFactor - Math.Floor(gameTimeFactor);
                if (fraction > 0.25f)
                    searchingText += ".";
                if (fraction > 0.50f)
                    searchingText += ".";
                if (fraction > 0.75f)
                    searchingText += ".";
                this.spriteBatch.DrawString(this.displayFont, searchingText, new Vector2(20.0f, 50.0f), Color.Red);
            }
            this.spriteBatch.DrawString(this.displayFont, this.lastFPS.ToString("00.00") + " FPS", new Vector2(windowWidth - 200.0f, 10.0f), Color.Yellow);

            // Draw mouse
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            this.spriteBatch.Draw(this.cursorTexture, mousePos, Color.White);

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

        /// <summary>
        /// Draw a line between two points
        /// </summary>
        /// <param name="batch">SpriteBatch to draw onto</param>
        /// <param name="width">Line width</param>
        /// <param name="blankTexture">A blank texture</param>
        /// <param name="color">Line color</param>
        /// <param name="point1">Point 1</param>
        /// <param name="point2">Point 2</param>
        void DrawLine(SpriteBatch batch, Texture2D blankTexture, float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)(Math.Atan2(point2.Y - point1.Y, point2.X - point1.X));
            float length = Vector2.Distance(point1, point2);

            point1.X += width * (float)(Math.Sin(angle)) / 2.0f;
            point1.Y -= width * (float)(Math.Cos(angle)) / 2.0f;

            batch.Draw(blankTexture, point1, null, color, angle, Vector2.Zero, new Vector2(length, width), SpriteEffects.None, 0);
        }
    }
}
