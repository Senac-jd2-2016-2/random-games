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

        public void LoadContent(ContentManager Content, string[] value)
        {
            //carregando a imagem do personagem
            img = Content.Load<Texture2D>(value[0]);
            img_colid = Content.Load<Texture2D>(value[1]);
        }

        public void Update(GameTime gameTime)
        {
            //colisores
            position_Left = new Rectangle(Position.X - (Position.Width / 7), Position.Y + (Position.Height / 3), 20, 50);
            position_Right = new Rectangle(Position.X + (Position.Width / 2), Position.Y + (Position.Height / 3), 20, 50);
            position_Bot = new Rectangle(Position.X + (Position.Width / 3), Position.Y + (Position.Height+20) - position_Bot.Height, 20, 20);
            position_Top = new Rectangle((Position.X + Position.Width / 3), Position.Y, 20, 20);
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
            //spritebatch.Draw(img_colid, position_Left, Color.White);
            //spritebatch.Draw(img_colid, position_Right, Color.White);
            spritebatch.Draw(img_colid, position_Bot, Color.White);
            //spritebatch.Draw(img_colid, position_Top, Color.White);
        }
    }
}
