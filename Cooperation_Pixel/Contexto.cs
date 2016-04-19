﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    class Contexto
    {
        public static Personagem Viking = new Personagem(150, 240, 80, 159);

        public static Personagem Anao = new Personagem(200, 240, 80, 80);

        public static Texture2D background;

        public static void inicializar(ContentManager content)
        {
            Viking.texture = content.Load<Texture2D>("Viking");
            Anao.texture = content.Load<Texture2D>("Anao");
            background = content.Load<Texture2D>("background");

        }
    }
}
