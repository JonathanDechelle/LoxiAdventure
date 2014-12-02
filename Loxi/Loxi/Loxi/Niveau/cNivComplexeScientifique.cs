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
    //cinematique de donald qui bute scorpions
    class cNivComplexeScientifique:GameScreen
    {
        Player Joueur = new Player(true, false);
        HealthBars BarreDeDetection;
        List<ObjCollisionable> Mur = new List<ObjCollisionable>();
        List<EnnemyPatrol> EnnemiesPatrols = new List<EnnemyPatrol>();
        Animation RifleSoldierCheck, RifleSoldierPatrouille;
        AnimationPlayer Animationplayer;
        Rectangle rDestinationb = new Rectangle(410, 0, 190, 100), rDestinationc = new Rectangle(650, 0, 150, 150),
                  rDestinationd = new Rectangle(250, 450, 200, 50);
        Rectangle rFlecheDroite = new Rectangle(710, 200, 80, 80), rFlecheGauche = new Rectangle(10, 200, 80, 80);
        float TimerFin = 0;
        int RetourAFront = 0;

        EnnemyPatrol EnnemiPatrouille1, EnnemiPatrouille2;
        
        enum Emplacement
        {
            inBase,outbase,ExplicationNiv1
        }

        enum EmplacementoutBase
        {
            frontside,leftside,rightside
        }

        enum EmplacementInBase
        {
            A,B,C
        }

        Emplacement CurrentEmplacement = Emplacement.outbase;
        EmplacementoutBase SideofOutBase = EmplacementoutBase.frontside;
        EmplacementInBase PartofInBase;
        string Parole;
        

         public cNivComplexeScientifique(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            RifleSoldierCheck = new Animation(RessourcesLoxi.RifleSoldierCheck, 45, 1.0f,1f, true);
            RifleSoldierPatrouille = new Animation(RessourcesLoxi.RifleSoldierPatrouille, 45, 0.5f, 2, true);
            /// Ennemi outbase
            #region OutBase
             //Ennemi LeftDoor
            EnnemiPatrouille1 = new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(500, 480), 400);
             //Ennemi RightDoor
            EnnemiPatrouille2 = new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(600, 480), 400);
            #endregion
           

        }

        public override void Load()
        {
            Joueur.Load(Content);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(RessourcesLoxi.SongNiv1);
        }

        public override void Update(GameTime gameTime)
        {

            if (CurrentEmplacement == Emplacement.outbase)
            {
                if (RetourAFront > 2)
                    RetourAFront = 2;
            }

            if (BarreDeDetection != null)
            {
                if (BarreDeDetection.GameOver)
                {
                    TimerFin += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (Convert.ToInt32(TimerFin) == 5)
                    {
                        RemoveScreen(this);
                        AddScreen(new cNivComplexeScientifique(serviceProvider, GraphicsDeviceManager));
                    }
                    
                }
            }

            Joueur.Update(Mur, RessourcesLoxi.JumpEffect, RessourcesLoxi.ShootEffect);
            foreach (EnnemyPatrol Ennemie in EnnemiesPatrols)
            {
                Ennemie.Update(Joueur, Mur);
                BarreDeDetection.Update(Ennemie.DiscoverYou,1);
                Animationplayer.PlayAnimation(RifleSoldierPatrouille);
            }

            foreach (ObjCollisionable muret in Mur)
            {
                muret.Update(gameTime);
            }

            switch(CurrentEmplacement)
            {
                #region OutBase
                case Emplacement.outbase:
                    switch (SideofOutBase)
                    {
                        case EmplacementoutBase.frontside:
                            Animationplayer.PlayAnimation(RifleSoldierCheck);
                            if (RetourAFront != 2)
                                Parole = "       Je dois \n    trouver un \n      moyen de \n      rentrer !!!";
                            else
                            {
                                Parole = "     Ce bunker \n  doit surment \n       mener à \n     l'intérieur";
                                if (KeyboardHelper.KeyPressed(Keys.Space))
                                {
                                    CurrentEmplacement = Emplacement.ExplicationNiv1;
                                }

                            }
                            if (RetourAFront != 2)
                            {
                                if (KeyboardHelper.KeyPressed(Keys.D))
                                    SideofOutBase = EmplacementoutBase.rightside;
                                else if (KeyboardHelper.KeyPressed(Keys.A))
                                    SideofOutBase = EmplacementoutBase.leftside;
                            }
                            break;
                        case EmplacementoutBase.leftside:
                            Animationplayer.PlayAnimation(RifleSoldierPatrouille);
                            EnnemiPatrouille1.Update(null,null);
                            if (KeyboardHelper.KeyPressed(Keys.D))
                            {
                                SideofOutBase = EmplacementoutBase.frontside;
                                RetourAFront++;
                            }
                            break;
                        case EmplacementoutBase.rightside:
                            Animationplayer.PlayAnimation(RifleSoldierPatrouille);
                            EnnemiPatrouille2.Update(null,null);
                            if (KeyboardHelper.KeyPressed(Keys.A))
                            {
                                SideofOutBase = EmplacementoutBase.frontside;
                                RetourAFront++;
                            }
                            break;
                    }
                    break;
                #endregion
                #region InBase
                case Emplacement.inBase:
                 
                    switch (PartofInBase)
                    {
                        case EmplacementInBase.A:

                            if (rDestinationb.Contains(Joueur.RecPerso))
                            {
                                PartofInBase = EmplacementInBase.B;
                                Mur.RemoveRange(0, Mur.Count);
                                EnnemiesPatrols.RemoveRange(0, EnnemiesPatrols.Count);
                                Joueur.Position = new Vector2(500, 540);
                                //B
                                Mur.Add(new ObjCollisionable(600, 360, RessourcesLoxi.Test, 10, 200, Color.Blue));
                                Mur.Add(new ObjCollisionable(150, 360, RessourcesLoxi.Test, 450, 10, Color.Blue));
                                Mur.Add(new ObjCollisionable(150, 150, RessourcesLoxi.Test, 10, 210, Color.Blue));
                                Mur.Add(new ObjCollisionable(150, 150, RessourcesLoxi.Test, 650, 10, Color.Blue));
                                EnnemiesPatrols.Add(new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(120, 460), 400));
                                EnnemiesPatrols.Add(new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(450, 130), 700));
                            }

                            break;
                        case EmplacementInBase.B:
                            if (rDestinationc.Contains(Joueur.RecPerso))
                            {
                                PartofInBase = EmplacementInBase.C;
                                Mur.RemoveRange(0, Mur.Count);
                                EnnemiesPatrols.RemoveRange(0, EnnemiesPatrols.Count);
                                Joueur.Position = new Vector2(0, 190);
                                //C
                                Mur.Add(new ObjCollisionable(0, 190, RessourcesLoxi.Test, 250, 10, Color.Blue));
                                Mur.Add(new ObjCollisionable(0, 350, RessourcesLoxi.Test, 250, 10, Color.Blue));
                                Mur.Add(new ObjCollisionable(450, 190, RessourcesLoxi.Test, 350, 10, Color.Blue));
                                Mur.Add(new ObjCollisionable(450, 350, RessourcesLoxi.Test, 350, 10, Color.Blue));
                                EnnemiesPatrols.Add(new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(800, 150), 400));
                                EnnemiesPatrols.Add(new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(300, 300), 350));
                                EnnemiesPatrols.Add(new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(400, 500), 500));

                            }
                            break;
                        case EmplacementInBase.C:
                            if (rDestinationd.Intersects(Joueur.RecPerso))
                            {
                                Mur.RemoveRange(0, Mur.Count);
                                EnnemiesPatrols.RemoveRange(0, EnnemiesPatrols.Count);
                                GameScreen.AddScreen(new cMovie2(serviceProvider, GraphicsDeviceManager));
                                GameScreen.RemoveScreen(this);
                            }
                            break;
                    }
                    break;
                #endregion
                #region ExplicationNiv1
                case Emplacement.ExplicationNiv1:

                    Parole = "Le but du niveau est de traverser chaque section \n(grâce aux touches WASD et shift)\n" +
                            "et de ne pas se faire reperer par les soldats......\n Si vous etes dans le champs de vision du soldat,\n" +
                            "votre bar de détection va descendre, si elle est à 0 \nc'est Game Over.\n\n !Bonne chance Loxi!\n\n\n" +
                            "Appuyer sur ENTER si vous etes prêt";
                    if (KeyboardHelper.KeyPressed(Keys.Enter))
                    {
                        #region InBase
                        BarreDeDetection = new HealthBars(RessourcesLoxi.HealtBar, new Vector2(100, 10), false, null, false);
                        Joueur.Position = new Vector2(200, 540);
                        ////A
                        PartofInBase = EmplacementInBase.A;
                        CurrentEmplacement = Emplacement.inBase;
                        EnnemiesPatrols.Add(new EnnemyPatrol(RessourcesLoxi.RifleSoldierPatrouille, new Vector2(850, 500), 300));
                        Mur.Add(new ObjCollisionable(0, 360, RessourcesLoxi.Test, 400, 10, Color.Blue));
                        Mur.Add(new ObjCollisionable(400, 0, RessourcesLoxi.Test, 10, 370, Color.Blue));
                        Mur.Add(new ObjCollisionable(600, 360, RessourcesLoxi.Test, 200, 10, Color.Blue));
                        Mur.Add(new ObjCollisionable(600, 0, RessourcesLoxi.Test, 10, 370, Color.Blue));
                        #endregion
                    }
                    break;
                #endregion
            }
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            Joueur.Draw(gametime, g);

            foreach (ObjCollisionable muret in Mur)
            {
                muret.Draw(g);
            }

            foreach (EnnemyPatrol Ennemie in EnnemiesPatrols)
            {
                Animationplayer.Draw(gametime, g, Ennemie.Position, Ennemie.Effect);
            }

            switch (CurrentEmplacement)
            {
                #region outBase
                case Emplacement.outbase:
                    switch (SideofOutBase)
                    {
                        case EmplacementoutBase.frontside:
                            g.Draw(RessourcesLoxi.BunkerUpperView, new Rectangle(0, 0, 800, 500), Color.White);
                            g.Draw(RessourcesLoxi.Donald, new Vector2(450, 200), Color.White);
                            Animationplayer.Draw(gametime, g,  new Vector2(350, 250), SpriteEffects.None);
                            Animationplayer.Draw(gametime, g, new Vector2(450, 250), SpriteEffects.FlipHorizontally);
                            Animationplayer.Draw(gametime, g, new Vector2(30, 150), SpriteEffects.None);
                            Animationplayer.Draw(gametime, g, new Vector2(600, 200), SpriteEffects.None);
                            Animationplayer.Draw(gametime, g, new Vector2(600, 100), SpriteEffects.FlipHorizontally);
                            g.Draw(RessourcesLoxi.BulleParole, new Vector2(200, 350), Color.White);
                            g.DrawString(RessourcesLoxi.Texte2, Parole, new Vector2(220, 380), Color.Blue);
                            if (RetourAFront == 2)
                            {
                                g.Draw(RessourcesLoxi.Cercle, new Rectangle(135, 245, 80, 80), Color.White);
                                g.DrawString(RessourcesLoxi.Texte, "APPUYER SUR ESPACE", new Vector2(220, 280), Color.Red);
                            }
                            else
                            {
                                g.Draw(RessourcesLoxi.Test, rFlecheDroite, Color.White);
                                g.Draw(RessourcesLoxi.Test, rFlecheGauche, Color.White);
                                g.Draw(RessourcesLoxi.Fleche, rFlecheDroite, Color.Blue);
                                g.Draw(RessourcesLoxi.Fleche, rFlecheGauche, null, Color.Red, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
                            }
                            break;
                        case EmplacementoutBase.leftside:
                            g.Draw(RessourcesLoxi.BunkerLeftSide, new Rectangle(0, 0, 800, 500), Color.White);
                             g.Draw(RessourcesLoxi.Test, rFlecheDroite, Color.White);
                             g.Draw(RessourcesLoxi.Fleche, rFlecheDroite, Color.Blue);
                             Animationplayer.Draw(gametime, g, EnnemiPatrouille1.Position, EnnemiPatrouille1.Effect);
                            break;
                        case EmplacementoutBase.rightside:
                            g.Draw(RessourcesLoxi.BunkerRightSide, new Rectangle(0, 0, 800, 500), Color.White);
                            g.Draw(RessourcesLoxi.Test, rFlecheGauche, Color.White);
                            g.Draw(RessourcesLoxi.Fleche, rFlecheGauche, null, Color.Red, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
                            Animationplayer.Draw(gametime, g, EnnemiPatrouille2.Position, EnnemiPatrouille2.Effect);
                            break;
                    }

                    g.DrawString(RessourcesLoxi.Texte, "A Pour Aller à gauche et D pour aller à droite",new Vector2(50,10),Color.White);
                    break;
                #endregion
                #region InBase
                case Emplacement.inBase:
                    Joueur.Draw(gametime, g);
                    g.DrawString(RessourcesLoxi.Texte2, "JAUGE DE\nDÉTECTION", new Vector2(10,10), Color.Blue);
                    foreach (ObjCollisionable muret in Mur)
                    {
                        muret.Draw(g);
                    }
                    switch (PartofInBase)
                    {
                        case EmplacementInBase.A:
                            g.GraphicsDevice.Clear(Color.DarkOrange);
                            g.Draw(RessourcesLoxi.Test, rDestinationb, Color.White);
                            g.DrawString(RessourcesLoxi.Texte, "PARTIE \n     A", new Vector2(100, 150), Color.Blue);
                            g.DrawString(RessourcesLoxi.Texte2, "Partie \n Suivante", new Vector2(rDestinationb.X+40, rDestinationb.Y+40), Color.Blue);
                            break;
                        case EmplacementInBase.B:
                            g.GraphicsDevice.Clear(Color.IndianRed);
                            g.Draw(RessourcesLoxi.Test, rDestinationc, Color.White);
                            g.DrawString(RessourcesLoxi.Texte, "PARTIE \n     B", new Vector2(200, 220), Color.Blue);
                            g.DrawString(RessourcesLoxi.Texte2, "Partie \n Suivante", new Vector2(rDestinationc.X + 40, rDestinationc.Y + 40), Color.Blue);
                            break;
                        case EmplacementInBase.C:
                            g.GraphicsDevice.Clear(Color.DarkGray);
                            g.Draw(RessourcesLoxi.Test, rDestinationd, Color.White);
                            g.DrawString(RessourcesLoxi.Texte, "PARTIE \n     C", new Vector2(600, 220), Color.Blue);
                            g.DrawString(RessourcesLoxi.Texte2, "Partie     Suivante", new Vector2(rDestinationd.X + 10, rDestinationd.Y + 10), Color.Blue);
                            break;
                    }
                    break;
                #endregion     
                #region ExplicationNiv1
                case Emplacement.ExplicationNiv1:
                    g.GraphicsDevice.Clear(Color.Black);
                    g.DrawString(RessourcesLoxi.Texte, Parole, new Vector2(), Color.Red);
                    break;
                #endregion
            }

            if (BarreDeDetection != null)
                BarreDeDetection.Draw(g);

           
           
        }
    }
    
}
