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

        public void Initialize(string source, int size)
        {
            scenario = new Scenario();
            scenario.Initialize(source, size);
        }

        public void LoadContent(ContentManager Content, string[] value)
        {
            scenario.LoadContent(Content, value);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            scenario.Draw(spriteBatch);
        }

    }
}
