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
    class cNiv1:GameScreen
    {
        Player Player;
        EnnemyPatrol EnnemiePatrol;
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

        public cNiv1(IServiceProvider serviceProvider,GraphicsDeviceManager graphics)
            : base(serviceProvider,graphics)
        {
            Player = new Player(true, true);
            Player.Position = new Vector2(140, 140);
            EnnemiePatrol = new EnnemyPatrol(RessourcesLoxi.TestPatrouille, new Vector2(400, 300), 150);
            BarreVie = new HealthBars(RessourcesLoxi.HealtBar, new Vector2(Player.Position.X-80, Player.Position.Y-180),true,Player,false);
            Obstacles = new List<ObjCollisionable>();
            Obstacles.Add(new ObjCollisionable(10, 200, RessourcesLoxi.Test, 132,132, Color.Blue));
            Obstacles.Add(new ObjCollisionable(600, 400, RessourcesLoxi.Test, 62,62, Color.Blue));
            Obstacles.Add(new ObjCollisionable(300, 200, RessourcesLoxi.Test, 122,122, Color.Blue));
            Camera = new Camera(graphics.GraphicsDevice.Viewport);
           // Background1 = new cBackground();
            //Background1.Rectangle = new Rectangle(-180, -90, 1000, 1000);
           // Background1.texture = cRessources.BG1;
            BackgroundPosition = new Vector2(0,0);
            
        }

        public override void Load()
        {
            Player.Load(m_Content);
            pausedTexture = RessourcesLoxi.PausedMenu;
            pausedrectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
            btnPlay = new Button(RessourcesLoxi.MainMenuButton,new Vector2(570,125),3);
            btnQuit = new Button(RessourcesLoxi.MainMenuButton, new Vector2(570, 300),3);
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

                EnnemiePatrol.Update(Player,Obstacles);
                Player.Update(Obstacles,RessourcesLoxi.JumpEffect,RessourcesLoxi.ShootEffect);
                Camera.Update(Player.Position);
                BarreVie.Update(false,1);
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
                EnnemiePatrol.Draw(g);

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
                    ennemies.Add(new Ennemi(RessourcesLoxi.Test, new Vector2(1100, randY), RessourcesLoxi.Test));
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

