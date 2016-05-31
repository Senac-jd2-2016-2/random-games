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
        public bool salto;
        public Rectangle position_Left;
        public Rectangle position_Right;
        public Rectangle position_Top;
        public Rectangle position_Bot;
        public Texture2D img_colid;

        public void Salto(Character character)
        {
            salto = true;
            int position = character.Position.Y;
            float pulo = 1f;
            character.Position.Y -= (int)pulo*velocity;
            if (position >= position + 80)
                character.Position.Y++;
                salto = false;
        }
        public void Gravidade()
        {
            int gravidade = 5;
            Position.Y += gravidade;
            
        }


    }
}
