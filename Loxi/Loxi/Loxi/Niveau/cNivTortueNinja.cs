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
    class cNivTortueNinja : GameScreen
    {
        Player Joueur;
        float Timer = 0,TimerFin;
        bool IniTimer = false,ColorBackToNormal;
        #region BeforeFight--Intro
        string Parole;
        Rectangle BullePosition = new Rectangle(40, 170, (int)(RessourcesLoxi.BulleParole.Width * 1.5),(int)(RessourcesLoxi.BulleParole.Height * 1.5));
        Vector2 ParolePosition = new Vector2(100, 230);
        Color CouleurParole = Color.DarkGreen;
        float RotationBulle = 0;
        #endregion
        #region PresentationTortue-(15secondeavantcombat)
        bool Presentationfinie;
        #region Raphael
        Animation PresentationRaph = new Animation(RessourcesLoxi.PresentRaph, 130, 0.5f, 4, false);
        #endregion
        #region Leonardo
        Animation PresentationLeonardo = new Animation(RessourcesLoxi.PresentLeonardo, 130, 0.5f, 4, false);
        #endregion
        #region Donatello
        Animation PresentationDonatello = new Animation(RessourcesLoxi.PresentDonatello, 130, 0.5f, 4, false);
        #endregion
        #region Michelangelo
        Animation PresentationMichelangelo = new Animation(RessourcesLoxi.PresentMichelangelo, 130, 0.5f, 4, false);
        #endregion
        #endregion
        #region afterPresentation
        CombatIA Ennemi;
        HealthBars Vie, MechantVie;
        #endregion
        
        #region Animation 
        AnimationPlayer AnimationPlayer = new AnimationPlayer(),
                        AP2 = new AnimationPlayer(),
                        AP3 = new AnimationPlayer(),
                        AP4 = new AnimationPlayer(),
                        AP5 = new AnimationPlayer();
                        
        Animation PresentationCombattants = new Animation(RessourcesLoxi.PresentCombatWarrior, 120, 1.5f, 2, true);
       
        
        String OpponentName = "Raphaël";
        Color  OpponentColor = Color.Red;
       
        #endregion

        enum GameState
        {
            BeforeFight,Raphael,Leonardo,Donatello,Michelangelo,AfterFight
        }

        GameState StateOfGame=GameState.BeforeFight;

        public cNivTortueNinja(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            Joueur = new Player(true, true);
            Joueur.Position = new Vector2(200, 20);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(RessourcesLoxi.SongNiv2);
        }

        public override void Load()
        {
            Joueur.Load(m_Content);
        }

        public override void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //TRAITEMENT SELON LA PARTIE DU JEU OÙ ON EST RENDU
            switch (StateOfGame)
            {
                #region BeforeFight
                case GameState.BeforeFight:
                    if (Timer >= 3)
                        Parole = "Bienvenue étranger,\nToi aussi il ta jeté \ndans la fosse. on\n va pouvoir enfin \n s'amuser !!";
                    if (Timer >= 7)
                    {
                        Parole = "Han oui??\nQue voulez \nvous dire\n par là ?";
                        ParolePosition = new Vector2(Joueur.Position.X - 210, Joueur.Position.Y - 180);
                        BullePosition = new Rectangle((int)(Joueur.Position.X - 130), (int)(Joueur.Position.Y - 250), RessourcesLoxi.BulleParole.Width, RessourcesLoxi.BulleParole.Height);
                        RotationBulle = 20;
                        CouleurParole = Color.Blue;
                    }
                    if (Timer >= 10)
                    {
                        Parole = "Nous allons te\ntester. Nous allons \nvoir si tu vaux la\n peine de devenir\n comme nous\n      !DES NINJA!";
                        BullePosition = new Rectangle(40, 170, (int)(RessourcesLoxi.BulleParole.Width * 1.5), (int)(RessourcesLoxi.BulleParole.Height * 1.5));
                        ParolePosition = new Vector2(100, 230);
                        CouleurParole = Color.DarkGreen;
                        RotationBulle = 0;
                    }

                    if (Timer >= 15)
                    {
                        Parole = "Tu vas devoir\naffronter mes fils, \nUn apres l'autre\ndans un combat\nd'arene !!!";
                        AnimationPlayer.PlayAnimation(PresentationCombattants);
                    }
                    if (Timer >= 20)
                    {
                        Parole = "      Est tu pret\n\n  appuie sur Enter\n\nlorsque tu sera\n          prêt";
                        if (KeyboardHelper.KeyPressed(Keys.Enter))
                        {
                            StateOfGame = GameState.Raphael;
                            Timer = 0;
                        }
                    }
                    break;
                #endregion
                #region Fight
                case GameState.Raphael:
                    if (!Presentationfinie)
                    {
                        AnimationPlayer.PlayAnimation(PresentationRaph);
                        if (Timer >= 3)
                        {
                            Presentationfinie = true;
                            //Vie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(30, 50), false, null, false);
                            //MechantVie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(450, 50), false, null, true);
                            Ennemi = new CombatIA(new Vector2(600, 480), 1, 70,RessourcesLoxi.WalkingRaphAnimation,RessourcesLoxi.RaphAttackAnimation);
                        }

                    }
                    break;
                case GameState.Michelangelo:
                    if (!Presentationfinie)
                    {
                        AnimationPlayer.PlayAnimation(PresentationMichelangelo);
                        OpponentColor = Color.Yellow;
                        OpponentName = "Michelangelo";

                        if (Timer >= 6)
                        {
                            Presentationfinie = true;
                            Joueur.Position = new Vector2(200, 480);
                            //Vie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(30, 50), false, null, false);
                            //MechantVie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(450, 50), false, null, true);
                            Ennemi = new CombatIA(new Vector2(600, 480), 2, 90,RessourcesLoxi.WalkingMichAnimation,RessourcesLoxi.MichAttackAnimation);
                        }
                    }
                    break;
                case GameState.Donatello:
                    if (!Presentationfinie)
                    {
                        AnimationPlayer.PlayAnimation(PresentationDonatello);
                        OpponentColor = Color.Purple;
                        OpponentName = "Donatello";

                        if (Timer >= 6)
                        {
                            Presentationfinie = true;
                            Joueur.Position = new Vector2(200, 480);
                            //Vie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(30, 50), false, null, false);
                            //MechantVie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(450, 50), false, null, true);
                            Ennemi = new CombatIA(new Vector2(600, 480), 3, 110, RessourcesLoxi.WalkingDonAnimation, RessourcesLoxi.DonAttackAnimation);
                        }
                    }
                    break;
                case GameState.Leonardo:
                    if (!Presentationfinie)
                    {
                        AnimationPlayer.PlayAnimation(PresentationLeonardo);
                        OpponentColor = Color.Blue;
                        OpponentName = "Leonardo";

                        if (Timer >= 6)
                        {
                            Presentationfinie = true;
                            Joueur.Position = new Vector2(200, 480);
                            //Vie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(30, 50), false, null, false);
                            //MechantVie = new HealthBars(RessourcesLoxi.HealtBarCombat, new Vector2(450, 50), false, null, true);
                            Ennemi = new CombatIA(new Vector2(600, 480), 4, 120,RessourcesLoxi.WalkingLeoAnimation,RessourcesLoxi.LeoAttackAnimation);
                            Parole = "";
                        }
                    }
                    break;
                #endregion
                #region AfterFight
                case GameState.AfterFight:
                    if (Timer >= 1)
                    {
                        Parole = "Bravo étranger,\nTu as réussi a\nbattre tous mes\n fils je vais te\n récompenser!!";
                        BullePosition = new Rectangle(140, 20, (int)(RessourcesLoxi.BulleParole.Width *1.4), (int)(RessourcesLoxi.BulleParole.Height* 1.4));
                        ParolePosition = new Vector2(20, 130);
                        CouleurParole = Color.DarkGreen;
                        RotationBulle = 20;
                    }
                    if (Timer >= 4)
                    {
                        Parole = " Je vais te \n Transformer\n comme nous...\n EN NINJA !!! \n    Tiens toi pret";
                        AnimationPlayer.PlayAnimation(RessourcesLoxi.DanseTransformation);
                    }

                    if (Timer >= 10 && !Joueur.LoxiTransformation)
                    {
                        Joueur.Transformation = true;
                    }

                    if (Timer>=14)
                        Parole = "Maintenant tu \npourra peut être \nsortir de la fosse \n,avec ta force \n   actuelle plus \n      celle du \n          ninja";
                    if (Timer >= 18)
                    {
                        AddScreen(new cMovie3(m_ServiceProvider, m_GraphicsDeviceManager));
                        RemoveScreen(this);
                    }
                    break;
                #endregion
            }

            //CHANGEMENT DE NIVEAU SI MONSTRE MORT
            #region Traitement de Changement de niveau
            if (MechantVie != null && Presentationfinie && !ColorBackToNormal)
            {
                if (MechantVie.m_GameOver)
                {
                    if (IniTimer == false)
                    {
                        Timer = 0;
                        IniTimer = true;
                    }

                    if (Timer >= 3)
                    {
                        switch (StateOfGame)
                        {
                            case GameState.Raphael: StateOfGame = GameState.Michelangelo;
                                break;
                            case GameState.Michelangelo: StateOfGame = GameState.Donatello;
                                break;
                            case GameState.Donatello:StateOfGame = GameState.Leonardo;
                                break;
                            case GameState.Leonardo: 
                                                     Joueur.Position = new Vector2(200, 480);
                                                     ColorBackToNormal = true; 
                                                     StateOfGame=GameState.AfterFight;
                                                     Timer = 0;
                                 AP2.PlayAnimation(RessourcesLoxi.MichAttenteAnimation);
                                 AP3.PlayAnimation(RessourcesLoxi.LeoAttenteAnimation);
                                 AP4.PlayAnimation(RessourcesLoxi.DonAttenteAnimation);
                                 AP5.PlayAnimation(RessourcesLoxi.RaphAttenteAnimation);
                                break;
                        }

                        if (ColorBackToNormal)
                            Presentationfinie = true;
                        else
                        Presentationfinie = false;

                        IniTimer = false;
                    }
                }
            }
            #endregion

            Joueur.Update(null, RessourcesLoxi.JumpEffect, RessourcesLoxi.ShootEffect);

            #region Update Vie/Ennemi
            if (Ennemi != null && Vie != null && !ColorBackToNormal)
            {
                //Ennemi.Update(gameTime, Joueur);
                //Vie.Update(Ennemi.DamageYou,Ennemi.Force);

                if (Vie.m_GameOver && !MechantVie.m_GameOver)
                {
                    TimerFin += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (Convert.ToInt32(TimerFin) == 3)
                    {
                        RemoveScreen(this);
                        AddScreen(new cNivTortueNinja(m_ServiceProvider, m_GraphicsDeviceManager));
                    }

                }
            #endregion
               
            #region CheckBalle/UpdateMechantVie
                foreach (Bullets bullet in Joueur.bullets)
                { /*
                    if (bullet.m_Rectangle.Intersects(Ennemi.Rectangle))
                        MechantVie.Update(true,1);
                    else
                        MechantVie.Update(false,1);*/
                }
                #endregion

            }
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            switch (StateOfGame)
            {
                #region beforeFight
                case GameState.BeforeFight:
                    g.Draw(RessourcesLoxi.grotte, new Vector2 (), Color.SlateGray);
                    g.Draw(RessourcesLoxi.Perchoir, new Rectangle(300, 100, 140, 140), Color.SlateGray);
                    if (Timer >= 2)
                    {
                        g.Draw(RessourcesLoxi.SplinterSingle, new Rectangle(300, 100, RessourcesLoxi.SplinterSingle.Width * 2, RessourcesLoxi.SplinterSingle.Height * 2), Color.White);

                        if (Timer >= 3)
                        {
                            g.Draw(RessourcesLoxi.BulleParole, BullePosition, null, Color.White, RotationBulle, new Vector2(), SpriteEffects.None, 0);
                            g.DrawString(RessourcesLoxi.Texte2, Parole, ParolePosition, CouleurParole);
                        }

                        if (Timer >= 16)
                        {
                            AnimationPlayer.Draw(gametime, g, new Vector2(600, 300), SpriteEffects.None);
                        }

                        if(Timer>=20)
                        g.DrawString(RessourcesLoxi.Texte2, "Direction = A,D\n Sauter = Espace\n Tirer = C \n Courir=Shift+Direction", new Vector2(10, 10), Color.White);

                    }
                    break;
                #endregion
                #region Fight
                case GameState.Raphael:
                    if (Presentationfinie)
                    {
                        g.Draw(RessourcesLoxi.grotte2, new Vector2(), Color.OrangeRed);
                    }
                    break;
                case GameState.Michelangelo:
                    if(Presentationfinie)
                    {
                        g.Draw(RessourcesLoxi.grotte3, new Vector2(), Color.Orange);
                    }
                    break;
                case GameState.Donatello:
                    if (Presentationfinie)
                        g.Draw(RessourcesLoxi.grotte4, new Vector2(), Color.Purple);
                    break;
                case GameState.Leonardo:
                    {
                        if (Presentationfinie)
                        {
                           g.Draw(RessourcesLoxi.grotte5, new Vector2(), Color.Blue);
                        }
                    }
                    break;
                #endregion
                #region afterFight
                case GameState.AfterFight:
                    g.Draw(RessourcesLoxi.grotte5, new Vector2(), Color.Gray);

                    if(Timer<=7 || Timer>=14)
                    g.Draw(RessourcesLoxi.SplinterSingle, new Rectangle(190, 200, RessourcesLoxi.SplinterSingle.Width * 2, RessourcesLoxi.SplinterSingle.Height * 2), Color.White);
                    else
                    AnimationPlayer.Draw(gametime, g, new Vector2(270, 350), SpriteEffects.None);

                    if (Timer >= 1)
                    {
                        g.Draw(RessourcesLoxi.BulleParole, BullePosition, null, Color.White, RotationBulle, new Vector2(), SpriteEffects.None, 0);
                        g.DrawString(RessourcesLoxi.Texte2, Parole, ParolePosition, CouleurParole);
                    }
                   
                    AP2.Draw(gametime, g, new Vector2(400, 500), SpriteEffects.FlipHorizontally);
                    AP3.Draw(gametime, g, new Vector2(490, 500), SpriteEffects.FlipHorizontally);
                    AP4.Draw(gametime, g, new Vector2(580, 500), SpriteEffects.FlipHorizontally);
                    AP5.Draw(gametime, g, new Vector2(670, 500), SpriteEffects.FlipHorizontally);
                break;
                #endregion
            }

            #region Affichage lors des présentation
            if (StateOfGame != GameState.BeforeFight && StateOfGame!=GameState.AfterFight && !Presentationfinie)
            {
                g.GraphicsDevice.Clear(Color.Black);
                AnimationPlayer.Draw(gametime, g, new Vector2(g.GraphicsDevice.Viewport.Width / 2, g.GraphicsDevice.Viewport.Height), SpriteEffects.None);
                if (AnimationPlayer.m_FrameIndex == 3)
                {
                    g.DrawString(RessourcesLoxi.Texte, OpponentName, new Vector2(550, 100), OpponentColor);
                    g.DrawString(RessourcesLoxi.Texte2, "Direction = A,D\n Sauter = Espace\n Tirer = C \n Courir=Shift+Direction", new Vector2(10, 10), OpponentColor);
                }
            }
#endregion
            //Sinon
            #region Affiche Bonhomme et Ennemi
            else
            {
                Joueur.Draw(gametime, g);
                if (Vie != null && MechantVie != null && Ennemi != null&& !ColorBackToNormal)
                {
                    Vie.Draw(g);
                    MechantVie.Draw(g);
                    Ennemi.Draw(g,gametime);
                }
            }
            #endregion
        }
    }

}

