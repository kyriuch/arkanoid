using ArkanoidReplica;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidReplica.Sprites
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Speed { get; set; }
        public Color Color { get; set; }

        public Vector2 MaxVector;

        public void CaculateMaxVector()
        {
            int height = Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Height;
            int width = Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Width;

            int textureAfterScaleWidth = Texture.Width * (int)Scale.X;
            int textureAfterScaleHeight = Texture.Height * (int)Scale.Y;

            MaxVector = new Vector2(width - textureAfterScaleWidth, height - textureAfterScaleHeight);
        }

        public virtual void Update(GameTime gameTime)
        {
            Position = Vector2.Clamp(new Vector2(Position.X + Velocity.X, Position.Y + Velocity.Y), Vector2.Zero, MaxVector);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, (int)(Texture.Width * Scale.X), (int)(Texture.Height * Scale.Y)), Color); 
        }

    }
}