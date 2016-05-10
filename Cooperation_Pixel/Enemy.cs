using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Enemy : Character
    {
        StateEnemy State_enemy;
        int steps, time, factor;

        public void LoadContent(ContentManager Content, string value)
        {
            img = Content.Load<Texture2D>(value);
        }

        public void Initialize(Rectangle enemy, int life, int velocity)
        {
            factor = 1;
            State_enemy = StateEnemy.WATCHING;
            steps = 5;
            Position = new Rectangle(enemy.X, enemy.Y, enemy.Width, enemy.Height);
            this.velocity = velocity;
            this.life = life;
        }
        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > 100)
            {
                time = 0;
                steps += factor;
                if (steps < 0)
                    factor = 1;
                else if (steps > 5)
                    factor = -1;
                Position.X += velocity * factor;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, Position, Color.White);
        }

    }
}
