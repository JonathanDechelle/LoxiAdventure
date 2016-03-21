﻿using System;
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
            btnPlay = new Button(RessourcesLoxi.MainMenuButton, new Vector2(600, 20), 3);
            btnExplication = new Button(RessourcesLoxi.ExplicationMainButton, new Vector2(600, 200), 3);
            rain = new ParticleGenerator(RessourcesLoxi.Rain, GraphicsDeviceManager.GraphicsDevice.Viewport.Width,80);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(RessourcesLoxi.SongImageTitre);
        }



        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
         
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.IsCliked)
                        CurrentGameState = GameState.Playing;

                    if (btnExplication.IsCliked)
                        CurrentGameState = GameState.Option;
                    

                    btnPlay.Update(mouse);
                    btnExplication.Update(mouse);
                    break;

                case GameState.Option: GameScreen.AddScreen(new cExplicationControle(serviceProvider, GraphicsDeviceManager));
                                       GameScreen.RemoveScreen(this);
                    break;

                case GameState.Playing: GameScreen.AddScreen(new cMovie1(serviceProvider, GraphicsDeviceManager));
                                        GameScreen.RemoveScreen(this);
                    break;

            }

            rain.Update(gameTime, GraphicsDeviceManager.GraphicsDevice);
        }


        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    g.Draw(RessourcesLoxi.BambooForest, new Rectangle(0, 0, 800, 500), Color.White);
                    g.Draw(RessourcesLoxi.PageTitre, new Rectangle(0, 0, 800, 500), Color.White);
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