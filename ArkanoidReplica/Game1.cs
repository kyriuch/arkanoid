using ArkanoidReplica.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ArkanoidReplica
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Ball ball;
        List<Sprite> sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 600;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            sprites = new List<Sprite>();

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

            // TODO: use this.Content to load your game content here
            player = new Player
            {
                Color = Color.White,
                Left = Keys.Left,
                Right = Keys.Right,
                Ability = Keys.Space,
                Position = new Vector2(300, 800),
                Scale = new Vector2(1.0f, 1.0f),
                Speed = new Vector2(10, 0),
                Texture = Content.Load<Texture2D>("VausSpacecraftLarge2")
            };
            player.CaculateMaxVector();
            sprites.Add(player);

            Random random = new Random();

            Vector2 ballVelocityVector = new Vector2(random.Next(2, 5) * (random.Next(2) == 1 ? 1 : -1), random.Next(2, 5)*(-1));
            ballVelocityVector.Normalize();
            ballVelocityVector *= 5;

            ball = new Ball
            {
                Color = Color.White,
                Texture = Content.Load<Texture2D>("ball"),
                Start = Keys.Space,
                Position = new Vector2(player.Position.X, player.Position.Y - player.Texture.Height-36),
                Scale = new Vector2(1.0f, 1.0f),
                Speed = Vector2.Zero,
                Velocity = ballVelocityVector,
                Player = player
            };
            sprites.Add(ball);
            Console.WriteLine(player.Texture.Height + " " + player.Texture.Width);
            ball.CaculateMaxVector();


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (var sprite in sprites)
            {
                sprite.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}