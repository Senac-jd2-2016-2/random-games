using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    class personagem
    {
        public int velocidade;
        public float gravidade;
        public string nome;
        public int x;
        public int y;

        public personagem(int x1, int y1)
        {
            x = x1;
            y = y1;
        }

        public Vector2 getVector()
        {
            return new Vector2(x, y);
        }

        public void moverX(int qtdPassos)
        {
            x += qtdPassos;
        }

        public void moverY(int qtdPassos)
        {
            y += qtdPassos;
        }
    }
}
