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
        public StatePlayer State_Viking;        //estado do personagem

        public void Initialize(Rectangle viking, int life, int velocity)
        {
            //Iniciando poição e atributos do personagem
            State_Viking = StatePlayer.IDDLE;
            Position = new Rectangle(viking.X, viking.Y, viking.Width, viking.Height);
            this.life = life;
            this.velocity = velocity;
        }

        public void LoadContent(ContentManager Content, string value)
        {
            //carregando a imagem do personagem
            img = Content.Load<Texture2D>(value);
        }

        public void Update(GameTime gameTime)
        {
            //Mudando o estado do personagem de acordo com a entrada do usuário
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
            //desenhando personagem
            spritebatch.Draw(img, Position, Color.White);
        }
    }
}
