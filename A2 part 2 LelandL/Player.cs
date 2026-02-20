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
        // the players attributes including location, speed/speed boost, sprite, color and a timer
        private float _playerX, _playerY;
        private int _playerSpeed, _speedBoost;
        private Texture2D _playerSprite;
        private Color _playerColor = Color.White;
        private int _timer;

        //this is so the player can communicate with the banana, something i wish i knew i could do earlier
        private BananaPeel _peel;

        //the players constructor 
        public Player(float playerX, float playerY, int playerSpeed, Texture2D playerSprite, BananaPeel peel)
        {
            _playerX = playerX;
            _playerY = playerY;
            _playerSpeed = playerSpeed;
            _playerSprite = playerSprite;
            _peel = peel;
        }

        //some accessors for the players location, speed and timer
        public float GetX() { return _playerX; }
        public float GetY() { return _playerY; }
        public int GetSpeed() { return _playerSpeed; }
        public int GetTimer() { return _timer; }

        public void Update()
        {
            //getting the current state of the keyboard
            KeyboardState currentKeyboardState = Keyboard.GetState();

            //WASD movement
            if (currentKeyboardState.IsKeyDown(Keys.A)) { _playerX -= _playerSpeed; }
            if (currentKeyboardState.IsKeyDown(Keys.D)) { _playerX += _playerSpeed; }
            if (currentKeyboardState.IsKeyDown(Keys.W)) { _playerY -= _playerSpeed; }
            if (currentKeyboardState.IsKeyDown(Keys.S)) { _playerY += _playerSpeed; }

            //Bunch of if's telling the player what to do with certain timer values and stopping the player from going over their current max speed boost
            if (_timer > 0)
            {
                _timer--;
                _playerColor = _peel.GetColor();
                _playerSpeed += _speedBoost;
            }

            if (_timer <= 0 && _playerSpeed > 3)
            {
                _playerColor = Color.White;
                _playerSpeed -= _speedBoost - 2;
            }

            if (_playerSpeed > _peel.getMaxBoost()) { _playerSpeed = _peel.getMaxBoost(); }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //drawing the Player
            spriteBatch.Begin();
            spriteBatch.Draw(_playerSprite, new Vector2(_playerX, _playerY), null, _playerColor, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        public void SpeedBoost(int speedBoost)
        {
            //my speedboost methode meant to set the timer for the speed boost and assign a new value to _speedboost

            if (_timer <= 0)
            {
                _speedBoost = speedBoost;
                _timer = 300;
            }
        }
    }
}
