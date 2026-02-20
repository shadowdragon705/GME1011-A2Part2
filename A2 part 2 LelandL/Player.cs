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
    internal class Player
    {

        private float _playerX, _playerY;
        private int _playerSpeed, _speedBoost;
        private Texture2D _playerSprite;

        private int _timer;

        public Player(float playerX, float playerY, int playerSpeed, Texture2D playerSprite)
        {
            _playerX = playerX;
            _playerY = playerY;
            _playerSpeed = playerSpeed;
            _playerSprite = playerSprite;
        }

        public float GetX() { return _playerX; }
        public float GetY() { return _playerY; }

        public int GetSpeed() { return _playerSpeed; }
        public int GetTimer() { return _timer; }

        public void Update()
        {
            //get the current state of the keyboard
            KeyboardState currentKeyboardState = Keyboard.GetState();

            //standard WASD keys
            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                _playerX -= _playerSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                _playerX += _playerSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                _playerY -= _playerSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                _playerY += _playerSpeed;
            }

            if (_timer > 0)
            {

                _timer--;
                _playerSpeed += _speedBoost;

            }

            if (_timer <= 0 && _playerSpeed > 5)
            {

                _playerSpeed -= _speedBoost;

            }

            if (_playerSpeed > 20)
            {
                _playerSpeed = 20;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_playerSprite, new Vector2(_playerX, _playerY), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);

            spriteBatch.End();

        }

        public void SpeedBoost(int speedBoost)
        {


            if (_timer <= 0)
            {

                _speedBoost = speedBoost;
                _timer = 300;

            }

        }
    }
}
