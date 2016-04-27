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
        public Texture2D texture;

        //Criando o personagem
        public Personagem(int x1, int y1, int larg, int alt)
        {
            x = x1;
            y = y1;
            altura = alt;
            largura = larg;
        }

        //Position do personagem
        public Rectangle GetRectangle()
        {
            return new Rectangle(x, y,largura, altura);
        }

        //Movimentação horizontal
        public void moverX(int qtdPassos)
        {
            x += qtdPassos;
        }   

    }
}
