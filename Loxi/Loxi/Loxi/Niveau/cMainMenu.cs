using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyGameLibrairy;

namespace Loxi
{
    class cMainMenu : GameScreen
    {
        ParticleGenerator rain;
        
        enum GameState
        {
            MainMenu,
            Option,
            Playing,
        }

        GameState CurrentGameState = GameState.MainMenu;
        Button btnPlay,btnExplication;

        public cMainMenu(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
        }

        public override void Load()
        {
            btnPlay = new Button(GameResources.MainMenuButton, new Vector2(600, 20), 3);
            btnExplication = new Button(GameResources.ExplicationMainButton, new Vector2(600, 200), 3);
            rain = new ParticleGenerator(GameResources.Rain, m_GraphicsDeviceManager.GraphicsDevice.Viewport.Width, 80);
            MediaPlayer.IsRepeating = true;
            //MediaPlayer.Play(GameResources.SongImageTitre);
        }



        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
         
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.m_IsClicked)
                        CurrentGameState = GameState.Playing;

                    if (btnExplication.m_IsClicked)
                        CurrentGameState = GameState.Option;
                    

                    btnPlay.Update(mouse);
                    btnExplication.Update(mouse);
                    break;

                case GameState.Option: GameScreen.AddScreen(new cExplicationControle(m_ServiceProvider, m_GraphicsDeviceManager));
                                       GameScreen.RemoveScreen(this);
                    break;

                case GameState.Playing: GameScreen.AddScreen(new cMovie1(m_ServiceProvider, m_GraphicsDeviceManager));
                                        GameScreen.RemoveScreen(this);
                    break;

            }

            rain.Update(gameTime, m_GraphicsDeviceManager.GraphicsDevice);
        }


        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    g.Draw(GameResources.BambooForest, new Rectangle(0, 0, 800, 500), Color.White);
                    g.Draw(GameResources.PageTitre, new Rectangle(0, 0, 800, 500), Color.White);
                    btnPlay.Draw(g);
                    btnExplication.Draw(g);
                    rain.Draw(g);
                    break;

                case GameState.Option:
                    break;

                case GameState.Playing:
                    break;

            }
           
        }
    }

}
