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
            character.Position.Y -= (int)pulo * velocity;
            if (position > character.Position.Y + character.Position.Width) ;
                salto = false;
        }
        public void Gravidade(Character character, bool collider)
        {
            if (!salto)
            {
                int gravidade = 0;
                if (collider == false)
                    gravidade = 5;
                else
                    gravidade = 0;
                character.Position.Y += gravidade;
            }
        }
        void UpdateGravity(Character character)
        {
            int spriteJumpPosition = 10;
            bool isJumping = true;
            if (isJumping == true)
            {
                if (spriteJumpPosition < 10)
                {
                    character.Position.Y += (float)gravity;
                    spriteJumpPosition += gravity;
                }
                else if (spriteJumpPosition >= 10)
                {
                    isJumping = false;
                    character.Position..Y -= (float)gravity;
                    spriteJumpPosition -= gravity;
                }
            }
            else if (isJumping == false)
            {
                if (spriteJumpPosition > 0)
                {
                    spriteJumpPosition -= (int)gravity;
                    character.Position.Y -= (float)gravity;
                }
            }
        }


    }
}
