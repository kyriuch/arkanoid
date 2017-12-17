using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkanoidReplica.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArkanoidReplica.Sprites
{
    public class Ball : Spirte
    {
        public Spirte player { get; set; }
        public Keys Start { get; set; }

        public void reset()
        {
            Position = new Vector2(player.Position.X, player.Position.Y - Texture.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.X <= 0 || Position.X >= Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Width - 35)
            {
                Velocity = new Vector2(Velocity.X * (-1), Velocity.Y);
            }

            if (Position.Y <= 0 || Position.Y >= Game1.graphics.GraphicsDevice.PresentationParameters.Bounds.Height - 35)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y * (-1));
            }

            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
