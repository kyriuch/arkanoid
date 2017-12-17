using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ArkanoidReplica.Sprites
{
    public class Player : Spirte
    {
        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys Ability { get; set; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Left))
            {
                Position = Vector2.Clamp(new Vector2(Position.X - Speed.X, Position.Y),
                Vector2.Zero, MaxVector);
            }
            else if (Keyboard.GetState().IsKeyDown(Right))
            {
                Position = Vector2.Clamp(new Vector2(Position.X + Speed.X, Position.Y),
                Vector2.Zero, MaxVector);
            }
            if (Keyboard.GetState().IsKeyDown(Ability))
            {

            }
        }


    }
}