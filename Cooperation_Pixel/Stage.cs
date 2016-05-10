using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooperation_Pixel
{
    public class Stage
    {
        public Scenario scenario;

        public void Initialize(string source, int size, int backWidth, int backHeigth)
        {
            //iniciando o cenário
            //backWidth e backHeigth são para armazenar o tamanho da tela do usuário para desenhar o background
            scenario = new Scenario();
            scenario.Initialize(source, size, backWidth, backHeigth);
        }

        public void LoadContent(ContentManager Content, string[] value)
        {
            //Carregando os arquivos do cenário
            scenario.LoadContent(Content, value);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //desenhando o cenário
            scenario.Draw(spriteBatch);
        }

    }
}
