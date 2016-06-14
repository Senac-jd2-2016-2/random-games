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
        int time = 0;
        int posicao = 0;
        Texture2D[] img_anao;
        SpriteEffects myEffect;
        string[] sprites;
           
        public void Atualizar_sprite(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > 300)
            {
                posicao++;
                if (posicao > 1)
                {
                    posicao = 0;
                }
                time = 0;
            }
        }

        public void Initialize(Rectangle dwarf, int life, int velocity)
        {
            //iniciando posição e atributos do personagem
            State_Dwarf = StatePlayer.IDDLE;
            Position = new Rectangle(dwarf.X, dwarf.Y, dwarf.Width, dwarf.Height);
            this.life = life;
            this.velocity = velocity;

            hasjumped = true;
            position_pulo = new Vector2(636, 170);

            direcao = 1;

            sprites = new string[2];
            sprites[0] = "Anão_1";
            sprites[1] = "Anão_2";
        }

        public void LoadContent(ContentManager Content, string[] value)
        {
            //carregando a imagem do personagem
            img = Content.Load<Texture2D>(value[0]);

            img_anao = new Texture2D[2];
            img_anao[0] = Content.Load<Texture2D>("Anão_1");
            img_anao[1] = Content.Load<Texture2D>("Anão_2");

        }

        public void Update(GameTime gameTime)
        {
            //colisores
            position_Left = new Rectangle(Position.X - (Position.Width / 7), Position.Y+(Position.Height/3), 20, 20);
            position_Right = new Rectangle(Position.X + (Position.Width / 2), Position.Y + (Position.Height/3), 20, 20);
            position_Bot = new Rectangle(Position.X + (Position.Width / 3), Position.Y + (Position.Height), 20, 20);
            position_Top = new Rectangle((Position.X + Position.Width / 3), (Position.Y - Position.Height / 5), 20, 20);

            //mudando o estado do personagem de acordo com a entrada do usuário
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                State_Dwarf = StatePlayer.RUNRIGHT;
                direcao = 1;
                Atualizar_sprite(gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                State_Dwarf = StatePlayer.RUNLEFT;
                direcao = -1;
                Atualizar_sprite(gameTime);
                myEffect = SpriteEffects.FlipHorizontally;
                //img_anao[0] = SpriteEffects.FlipHorizontally;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                State_Dwarf = StatePlayer.JUMP;
            else
                State_Dwarf = StatePlayer.IDDLE;



            //atualizando posição do Anão
            Position = new Rectangle((int)position_pulo.X, (int)position_pulo.Y, Position.Width, Position.Height);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            //desenhando o personagem
            spritebatch.Draw(img_anao[posicao], Position, Color.White);
            //spritebatch.Draw(img_colid, position_Left, Color.White);
            //spritebatch.Draw(img_colid, position_Right, Color.White);
            //spritebatch.Draw(img_colid, position_Bot, Color.White);
            //spritebatch.Draw(img_colid, position_Top, Color.White);
        }

    }
}
