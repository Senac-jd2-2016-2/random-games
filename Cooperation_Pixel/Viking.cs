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
    public class Viking : Character
    {
        public StatePlayer State_Viking;

        public void Initialize(Rectangle viking, int life, int velocity)
        {
            State_Viking = StatePlayer.IDDLE;
            Position = new Rectangle(viking.X, viking.Y, viking.Width, viking.Height);
            this.life = life;
            this.velocity = velocity;
        }

        public void LoadContent(ContentManager Content, string value)
        {
            img = Content.Load<Texture2D>(value);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                State_Viking = StatePlayer.RUNRIGHT;
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                State_Viking = StatePlayer.RUNLEFT;
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
                State_Viking = StatePlayer.JUMP;
            else
                State_Viking = StatePlayer.IDDLE;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(img, Position, Color.White);
        }
    }
}
