using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Dwarf : Character
    {
        public StatePlayer State_Dwarf;

        public void Initialize(Rectangle dwarf, int life, int velocity)
        {
            State_Dwarf = StatePlayer.IDDLE;
            Position = new Rectangle(dwarf.X, dwarf.Y, dwarf.Width, dwarf.Height);
            this.life = life;
            this.velocity = velocity;
        }

        public void LoadContent(ContentManager Content, string value)
        {
            img = Content.Load<Texture2D>(value);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                State_Dwarf = StatePlayer.RUNRIGHT;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                State_Dwarf = StatePlayer.RUNLEFT;
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                State_Dwarf = StatePlayer.JUMP;
            else
                State_Dwarf = StatePlayer.IDDLE;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(img, Position, Color.White);
        }

    }
}
