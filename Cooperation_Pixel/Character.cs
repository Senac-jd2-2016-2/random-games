using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Character
    {
        //atributos dos personagens
        public Rectangle Position;
        public Texture2D img;
        public int velocity;
        public int life;
        public int salto;
        public Rectangle position_Left;
        public Rectangle position_Right;
        public Rectangle position_Top;
        public Rectangle position_Bot;
        public Texture2D img_colid;

        public void Salto(Character character)
        {
            float pulo = 1f;
            character.Position.Y -= (int)pulo * salto;
        }
        public void Gravidade(Character character, bool collider)
        {
            int gravidade = 0;
            if (collider == false)
                gravidade = 5;
            else
                gravidade = 0;
            character.Position.Y += gravidade;
        }
    }
}
