using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    class Personagem
    {
        public int x, y, altura, largura;
        private Vector2 Velocity;
        public Vector2 Position;
        public Texture2D texture;
        private bool pulou; 

        public Personagem(int x1, int y1, int larg, int alt)
        {
            x = x1;
            y = y1;
            altura = alt;
            largura = larg;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(x, y,largura, altura);
        }

        public void moverX(int qtdPassos)
        {
            x += qtdPassos;
        }
        
        public void Update(GameTime gameTime)
        {
            Input(gameTime);
        }

        public void Input(GameTime gameTime)
        {
            if (Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Up) && !pulou)
            {
                Contexto.Anao.y -= 9;
                pulou = true;
            }
        }
        

    }
}
