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
    class cNiv1:GameScreen
    {
        Player Player;
        EnemyPatrol EnnemiePatrol;
        HealthBars BarreVie;
        Camera Camera;
       // Scrolling Scrolling1, Scrolling2;
        List<ObjCollisionable> Obstacles;
        List<Ennemi> ennemies = new List<Ennemi>();
        Random random = new Random();
        Vector2 BackgroundPosition;
       // Background Background1;

        //Pause 
        bool Paused = false;
        Texture2D pausedTexture;
        Rectangle pausedrectangle;
        Button btnPlay, btnQuit;
        Vector2 EcartbtnPlay,EcartbtnQuit;

        EnemyPatrolData m_patrolData;

        public cNiv1(IServiceProvider serviceProvider,GraphicsDeviceManager graphics)
            : base(serviceProvider,graphics)
        {
            Player = new Player(true, true);
            Player.Position = new Vector2(140, 140);


            m_patrolData.m_PatrolAnimation = GameResources.RifleSoldierPatrouilleAnimation;
            m_patrolData.m_PatrolDistance = 150f;
            m_patrolData.m_PatrolSpeed = 10f;

            EnnemiePatrol = new EnemyPatrol(GameResources.TestPatrouille, new Vector2(400, 300), m_patrolData);

            BarreVie = new HealthBars(GameResources.HealtBar, new Vector2(-80, -180));
            Obstacles = new List<ObjCollisionable>();
            Obstacles.Add(new ObjCollisionable(10, 200, GameResources.Test, 132, 132, Color.Blue));
            Obstacles.Add(new ObjCollisionable(600, 400, GameResources.Test, 62, 62, Color.Blue));
            Obstacles.Add(new ObjCollisionable(300, 200, GameResources.Test, 122, 122, Color.Blue));
            Camera = new Camera(graphics.GraphicsDevice.Viewport);
           // Background1 = new cBackground();
            //Background1.Rectangle = new Rectangle(-180, -90, 1000, 1000);
           // Background1.texture = cRessources.BG1;
            BackgroundPosition = new Vector2(0,0);
            
        }

        public override void Load()
        {
            Player.Load(m_Content);
            pausedTexture = GameResources.PausedMenu;
            pausedrectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
            btnPlay = new Button(GameResources.MainMenuButton, new Vector2(570, 125), 3);
            btnQuit = new Button(GameResources.MainMenuButton, new Vector2(570, 300), 3);
            EcartbtnPlay = btnPlay.m_Position;
            EcartbtnQuit = btnQuit.m_Position;
        }

        float spawn = 0;

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            if (KeyboardHelper.KeyHold(Keys.O))
                Camera.Zoom += 0.01f;
            else if (KeyboardHelper.KeyHold(Keys.L))
                Camera.Zoom -= 0.01f;

            if (KeyboardHelper.KeyHold(Keys.J))
                Camera.Rotation += 0.01f;
            else if (KeyboardHelper.KeyHold(Keys.K))
                Camera.Rotation -= 0.01f;

            if (!Paused)
            {
                if (KeyboardHelper.KeyPressed(Keys.Enter))
                {
                    Paused = true;
                    btnPlay.m_IsClicked = false;
                }

                //EnnemiePatrol.Update(Player,Obstacles);
                Player.Update(Obstacles, GameResources.JumpEffect, GameResources.ShootEffect);
                Camera.Update(Player.Position);
                //BarreVie.Update(false,1);
                //  LoadEnnemies();

                spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

                foreach (Ennemi enemy in ennemies)
                {
                    enemy.Update(m_GraphicsDeviceManager.GraphicsDevice, gameTime);
                }                
            }

            else if (Paused)
            {
                Camera.Zoom = 1;
                Camera.Rotation = 0;
                Camera.Update(new Vector2(pausedTexture.Width/2+100,pausedTexture.Height/2));
                if (KeyboardHelper.KeyPressed(Keys.Enter))
                {
                    Paused = false;
                    btnPlay.m_IsClicked = true;
                }

                if (btnPlay.m_IsClicked)
                {
                    Paused = false;
                }
                if (btnQuit.m_IsClicked)
                    RemoveScreen(this);
                
                btnPlay.Update(mouse);
                btnQuit.Update(mouse);
            }
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            g.End();
            g.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                     null, null, null, null, Camera.Transform);

            g.GraphicsDevice.Clear(Color.Black);
           
            //Si Pause
            if (Paused)
            {
                g.GraphicsDevice.Clear(Color.White);
                g.Draw(pausedTexture, pausedrectangle, Color.White);
                btnPlay.Draw(g);
                btnQuit.Draw(g);
            }
            else
            {
                Player.Draw(gametime, g);
               
                foreach (ObjCollisionable Object in Obstacles)
                {
                    Object.Draw(g);
                }

                BarreVie.Draw(g);
                EnnemiePatrol.Draw(gametime, g);

            }

          // Scrolling1.Draw(g);
           
         
        }

        public void LoadEnnemies()
        {
            int randY = random.Next(0, 450);

            if (spawn >= 1)
            {
                spawn = 0;
                if (ennemies.Count() < 6)
                {
                    ennemies.Add(new Ennemi(GameResources.Test, new Vector2(1100, randY), GameResources.Test));
                }

                for (int i = 0; i < ennemies.Count; i++)
                    if (!ennemies[i].isVisible)
                    {
                        ennemies.RemoveAt(i);
                        i--;
                    }
            }
        }
    }
}

