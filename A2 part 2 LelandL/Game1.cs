using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Dynamic;

namespace A2_part_2_LelandL
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Assigning my custom classes plus the textures/font their values
        private Player _player;
        private BananaPeel _bananaPeel;
        private Texture2D _playerSprite;
        private Texture2D _peelSprite;
        private SpriteFont _font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //loading in textures and the font
            _peelSprite = Content.Load<Texture2D>("shork");
            _playerSprite = Content.Load<Texture2D>("spr_amongUs");
            _font = Content.Load<SpriteFont>("font");

            //creating my banana and player
            _bananaPeel = new BananaPeel(200, 200, _peelSprite);
            _player = new Player(0, 0, 3, _playerSprite, _bananaPeel);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //my "hitbox" you showed me in class
            if (Vector2.Distance(new Vector2(_player.GetX(),_player.GetY()), new Vector2(_bananaPeel.GetX(),_bananaPeel.GetY())) < 50)
            {
                _player.SpeedBoost(_bananaPeel.GetBoost());
            }

            //calling the updates of the 2 objects so they continue their respective functions
            _player.Update();
            _bananaPeel.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
             
            //drawing the 2 objects
            _bananaPeel.Draw(_spriteBatch);
            _player.Draw(_spriteBatch);
            
            //writing the text in the top left of the screen
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Speed: " + _player.GetSpeed() + ", Timer: " + _player.GetTimer() + ", Max Boost: " + _bananaPeel.getMaxBoost(), new Vector2(100, 25), Color.Black);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
