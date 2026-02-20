using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_part_2_LelandL
{
    internal class BananaPeel
    {

        private float _peelX, _peelY;
        private Texture2D _peelTexture;
        private int _speedBoost = 5;

        public BananaPeel (float peelX, float peelY, int _speedBoost, Texture2D peelTexture)
        {
            _peelX = peelX;
            _peelY = peelY;
            _peelTexture = peelTexture;
        }

        public float GetX() { return _peelX; }
        public float GetY() { return _peelY; }
        public int GetBoost() { return _speedBoost; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_peelTexture, new Vector2(_peelX, _peelY), null, Color.Yellow, 0, new Vector2(0, 0), 0.1f, SpriteEffects.None, 0);

            spriteBatch.End();

        }

    }
}
