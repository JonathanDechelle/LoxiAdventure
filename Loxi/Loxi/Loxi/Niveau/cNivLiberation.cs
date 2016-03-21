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
   
    class cNivLiberation : GameScreen
    {
        enum StateofGame
        {
            ExplicationLiberation, Game
        }

        StateofGame GameState = StateofGame.ExplicationLiberation;
        Player Joueur;
        Camera Camera;
        List<ObjCollisionable> Platforms = new List<ObjCollisionable>();
        AnimationPlayer AnimationPlayer = new AnimationPlayer();
        Animation DaffyAnimation, DaffiExit;
        Vector2 PositionDaffi = new Vector2(1100, 2220), DistanceDaffiDonald;
        float Seconde = 0;
        bool Reussi;
        TimeSpan TempsJeu = new TimeSpan(0, 0, 45);
        public cNivLiberation(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {

        }

        public override void Load()
        {
            //Load daffy
            DaffyAnimation = new Animation(RessourcesLoxi.DaffiDuck, 90, 0.3f, 2, true);
            DaffiExit = new Animation(RessourcesLoxi.DaffiExitLevel, 80, 0.28f, 2, true);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(RessourcesLoxi.Rasputin);
        }

        public override void Update(GameTime gameTime)
        {
            switch (GameState)
            {
                #region Explication
                case StateofGame.ExplicationLiberation: if (KeyboardHelper.KeyPressed(Keys.Space))
                    {
                        GameState = StateofGame.Game;
                        Joueur = new Player(false, true);
                        Joueur.Load(m_Content);
                        Camera = new Camera(m_GraphicsDeviceManager.GraphicsDevice.Viewport);
                         //Camera.Zoom -= 50;
                        Platforms.Add(new ObjCollisionable(0, 200, RessourcesLoxi.Test, 300, 300, Color.Blue));
                        Platforms.Add(new ObjCollisionable(400, 400, RessourcesLoxi.Test, 200, 200, Color.YellowGreen));
                        Platforms.Add(new ObjCollisionable(700, 700, RessourcesLoxi.Test, 200, 200, Color.OrangeRed));
                        Platforms.Add(new ObjCollisionable(1100, 700, RessourcesLoxi.Test, 600, 200, Color.SandyBrown));
                        Platforms.Add(new ObjCollisionable(1700, 700, RessourcesLoxi.Test, 200, 100, Color.Salmon));//Peut etre a inclure dans la deerniere platform
                        Platforms.Add(new ObjCollisionable(1800, 650, RessourcesLoxi.Test, 200, 200, Color.Blue));
                        Platforms.Add(new ObjCollisionable(2000, 600, RessourcesLoxi.Test, 300, 300, Color.DarkGoldenrod));
                        Platforms.Add(new ObjCollisionable(2300, 550, RessourcesLoxi.Test, 300, 300, Color.DarkBlue));
                        Platforms.Add(new ObjCollisionable(2600, 500, RessourcesLoxi.Test, 300, 300, Color.DarkGray));
                        Platforms.Add(new ObjCollisionable(3000, 420, RessourcesLoxi.Test, 200, 200, Color.DeepPink));
                        Platforms.Add(new ObjCollisionable(3500, 650, RessourcesLoxi.Test, 200, 200, Color.Gainsboro));
                        Platforms.Add(new ObjCollisionable(4000, 850, RessourcesLoxi.Test, 200, 200, Color.LawnGreen));
                        Platforms.Add(new ObjCollisionable(3700, 1200, RessourcesLoxi.Test, 100, 100, Color.Aqua));
                        Platforms.Add(new ObjCollisionable(3300, 1250, RessourcesLoxi.Test, 100, 100, Color.BurlyWood));
                        Platforms.Add(new ObjCollisionable(2400, 1250, RessourcesLoxi.Test, 600, 200, Color.Chartreuse));
                        Platforms.Add(new ObjCollisionable(1400, 1700, RessourcesLoxi.Test, 600, 200, Color.Cyan));
                        Platforms.Add(new ObjCollisionable(900, 1700, RessourcesLoxi.Test, 200, 200, Color.Crimson));
                        Platforms.Add(new ObjCollisionable(500, 1700, RessourcesLoxi.Test, 200, 200, Color.DarkGray));
                        Platforms.Add(new ObjCollisionable(400, 1650, RessourcesLoxi.Test, 100, 100, Color.DeepPink));
                        Platforms.Add(new ObjCollisionable(200, 1600, RessourcesLoxi.Test, 200, 200, Color.DarkOrange));
                        Platforms.Add(new ObjCollisionable(0, 1550, RessourcesLoxi.Test, 200, 200, Color.DarkSalmon));
                        Platforms.Add(new ObjCollisionable(-600, 1550, RessourcesLoxi.Test, 200, 200, Color.DodgerBlue));
                        Platforms.Add(new ObjCollisionable(-400, 2000, RessourcesLoxi.Test, 300, 200, Color.ForestGreen));
                        Platforms.Add(new ObjCollisionable(-100, 2200, RessourcesLoxi.Test, 1300, 100, Color.Blue));

                        Joueur.Position = new Vector2(150, 150);
                        Joueur.LoxiTransformation = true;
                    }
                    break;
                #endregion

                case StateofGame.Game: foreach (ObjCollisionable platform in Platforms) { platform.Update(gameTime); }
                    if (Joueur != null)
                    {
                        Seconde += (float)gameTime.ElapsedGameTime.TotalSeconds;

                        if (!Reussi)
                            Joueur.Update(Platforms, RessourcesLoxi.JumpEffect, RessourcesLoxi.ShootEffect);

                        DistanceDaffiDonald = PositionDaffi - Joueur.Position;

                        if (Seconde >= 1)
                        {
                            Seconde = 0;
                            TempsJeu = TempsJeu.Subtract(new TimeSpan(0, 0, 1));
                        }


                        if (DistanceDaffiDonald.X <= 200 && DistanceDaffiDonald.X >= 0 && DistanceDaffiDonald.Y <= -10)
                        {
                            if (!Reussi)
                            {
                                Reussi = true;
                                TempsJeu = new TimeSpan(0, 0, 3);
                            }
                            AnimationPlayer.PlayAnimation(DaffiExit);
                        }
                        else
                            AnimationPlayer.PlayAnimation(DaffyAnimation);

                        if (Joueur.Position.Y >= 3500 || TempsJeu.TotalSeconds == -1)
                        {
                            if (Reussi)
                            {
                                AddScreen(new cMovie4(m_ServiceProvider, m_GraphicsDeviceManager));
                                RemoveScreen(this);
                            }
                            else
                            {
                                AddScreen(new cNivLiberation(m_ServiceProvider, m_GraphicsDeviceManager));
                                RemoveScreen(this);
                            }
                        }
                        Camera.Update(Joueur.Position);

                    }
                    break;
            }
        }



        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            switch (GameState)
            {
                case StateofGame.ExplicationLiberation: g.GraphicsDevice.Clear(Color.LightBlue);
                    g.DrawString(RessourcesLoxi.Texte, "\nNiveau Liberation - \nAgent Loxi vous devrez sauver la victime \nen sautant de plateforme en platforme \navant la fin du temps imparti \n" +
                                    "sinon le prisonnier sera tué bonne chance !!! \n\nrappel des commande \nWASD=direction\nshift=courir \nEspace=Sauter \nC=Attaque                           Appuyer sur Espace", new Vector2(20, 0), Color.Black);

                    break;
                case StateofGame.Game:
                    g.End();
                    g.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                                    null, null, null, null, Camera.Transform);
                    g.GraphicsDevice.Clear(Color.DimGray);
                    g.Draw(RessourcesLoxi.BackgroundEtoile, new Rectangle(-1000, 0,3000,1500), null, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
                    g.Draw(RessourcesLoxi.BackgroundEtoile, new Rectangle(-1000, 1500, 3000, 1500), null, Color.White, 0, new Vector2(), SpriteEffects.None, 0);
                    g.Draw(RessourcesLoxi.BackgroundEtoile, new Rectangle(2000, 0, 3000, 1500), null, Color.White, 0, new Vector2(), SpriteEffects.FlipVertically, 0);
                    g.Draw(RessourcesLoxi.BackgroundEtoile, new Rectangle(2000, 1500, 3000, 1500), null, Color.White, 0, new Vector2(), SpriteEffects.FlipVertically, 0);
                    foreach (ObjCollisionable platform in Platforms) { platform.Draw(g); }
                    if (Joueur != null && AnimationPlayer.m_Animation != null)
                    {
                        if (Reussi)
                            g.DrawString(RessourcesLoxi.Texte, "Win                                                      thankyou!!!", new Vector2(Camera.X - 350, Camera.Y - 220), Color.Red);
                        else
                        {
                            g.DrawString(RessourcesLoxi.Texte, TempsJeu.ToString(), new Vector2(Camera.X - 350, Camera.Y - 220), Color.Red);
                            Joueur.Draw(gametime, g);
                        }

                        
                        AnimationPlayer.Draw(gametime, g, PositionDaffi, SpriteEffects.FlipHorizontally);
                    }
                    break;
            }
        }
    }
}
