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
        public StatePlayer State_Dwarf;     //estado do personagem

        public void Initialize(Rectangle dwarf, int life, int velocity)
        {
            //iniciando posição e atributos do personagem
            State_Dwarf = StatePlayer.IDDLE;
            Position = new Rectangle(dwarf.X, dwarf.Y, dwarf.Width, dwarf.Height);
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
            position_Left = new Rectangle(Position.X - (Position.Width / 7), Position.Y+(Position.Height/3), 20, 20);
            position_Right = new Rectangle(Position.X + (Position.Width / 2), Position.Y + (Position.Height/3), 20, 20);
            position_Bot = new Rectangle(Position.X + (Position.Width / 3), Position.Y + (Position.Height / 2), 20, 20);
            position_Top = new Rectangle((Position.X + Position.Width / 3), (Position.Y - Position.Height / 5), 20, 20);
            //mudando o estado do personagem de acordo com a entrada do usuário
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
            //desenhando o personagem
            spritebatch.Draw(img, Position, Color.White);
            //spritebatch.Draw(img_colid, position_Left, Color.White);
            //spritebatch.Draw(img_colid, position_Right, Color.White);
            //spritebatch.Draw(img_colid, position_Bot, Color.White);
            //spritebatch.Draw(img_colid, position_Top, Color.White);
        }

    }
}
