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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _peelSprite = Content.Load<Texture2D>("shork");
            _playerSprite = Content.Load<Texture2D>("spr_amongUs");
            _font = Content.Load<SpriteFont>("font");

            _player = new Player(0, 0, 5, _playerSprite);
            _bananaPeel = new BananaPeel(200, 200, 5, _peelSprite);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Vector2.Distance(new Vector2(_player.GetX(),_player.GetY()), new Vector2(_bananaPeel.GetX(),_bananaPeel.GetY())) < 50)
            {

                _player.SpeedBoost(_bananaPeel.GetBoost());

            }

            _player.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
             
            _bananaPeel.Draw(_spriteBatch);
            _player.Draw(_spriteBatch);
            
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "Speed: " + _player.GetSpeed() + ", Timer: " + _player.GetTimer(), new Vector2(100, 25), Color.Black);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
