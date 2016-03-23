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
    class cMovie3:GameScreen
    {
        #region Animation
        AnimationPlayer AnimationPlayer=new AnimationPlayer();
        AnimationPlayer AP2 = new AnimationPlayer();
        Vector2 PosAnim = new Vector2(100, 480);
        #endregion
        #region Blabla
        Rectangle BullePosition = new Rectangle(400, 0, (int)(GameResources.BulleParole.Width * 1.5), (int)(GameResources.BulleParole.Height * 1.5));
        Vector2 ParolePosition = new Vector2(270, 130);
        Color CouleurParole = Color.Red;
        SpriteEffects flip = SpriteEffects.None;
        float RotationBulle = 20;
        string []TabParole = new string[8];
        Vector2[] TabPositionBulle = new Vector2[2] { new Vector2(400, 0), new Vector2(200, 0) };
        Vector2[] TabPositionParole = new Vector2[2] { new Vector2(270, 130), new Vector2(80, 150) };
        int NumParole = 0;
        bool EnterVisible = true;
        #endregion
                  
                  
        bool SorsDeFaussePart2,SortieDefausse,TransfoNinjaComplete,WarioSexplique;
           
        public cMovie3(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            TabParole[0] = "Mais comment\nc'est possible !!! \ntu a reussi   à \n      battre mes \n       créatures ?!!";
            TabParole[1] = "J'ai quand mm \nprévu le coup!! ...\n\n   En Pensant,\n    beau costume";
            TabParole[2] = "Qu'est ce que tu\nme réserve\n encore??";
            TabParole[3] = "J'ai capturé un \ninnocent si tu ne \nle libere pas....";
            TabParole[4] = "Que va tu faire?? \n Je vais t'arreter \n de toute facon";
            TabParole[5] = "Je tue la victime  \n    Mouhaha \n  Mouhaha \nMouhahahahaha!!!!";
            TabParole[6] = "JE dois le sauver\nou la sauver ..\nj'espere qu'\nelle est belle\n      si c'est une\n          fille";
            TabParole[7] = "Je te laisse\nt'amuser je \ncontinue mes \npréparatifs pour la\n        destruction\n       de la terre";

        }
        public override void Load()
        {
            MediaPlayer.Play(GameResources.SongCinematique3);
            MediaPlayer.IsRepeating = true;
        }

        public override void Update(GameTime gameTime)
        {
            ///Sors de fausse animation
            if (AnimationPlayer.m_FrameIndex == 9 && !SorsDeFaussePart2)
                SorsDeFaussePart2 = true;
            else if (AnimationPlayer.m_FrameIndex == 9 && SorsDeFaussePart2)
                SortieDefausse = true; //Est sortie de fausse

            if (SortieDefausse)
            {
                if (AnimationPlayer.m_FrameIndex == 18)//si fin d'animation de tranfo
                    TransfoNinjaComplete = true;
                else
                    AnimationPlayer.PlayAnimation(GameResources.TransfoNinja);

                if (TransfoNinjaComplete)
                {
                    if (KeyboardHelper.KeyPressed(Keys.Enter))
                    {
                        NumParole++;
                        if (NumParole >= 7)
                            NumParole = 7;
                    }

                    if (!WarioSexplique)
                        AP2.PlayAnimation(GameResources.WarioSurprisAnimation);
                    else
                        AP2.PlayAnimation(GameResources.WarioExpliqueAnimation);

                    if (NumParole == 2)
                    {
                        flip = SpriteEffects.FlipVertically;
                        BullePosition.X = (int)TabPositionBulle[1].X;
                        ParolePosition = TabPositionParole[1];
                        CouleurParole = Color.Blue;
                    }

                    if (NumParole >= 3)
                    {
                        switch (NumParole)
                        {

                            case 3:
                                {
                                    flip = SpriteEffects.None;
                                    BullePosition.X = (int)TabPositionBulle[0].X;
                                    ParolePosition = TabPositionParole[0];
                                    CouleurParole = Color.Red;
                                }
                                break;
                            case 4:
                                {
                                    flip = SpriteEffects.FlipVertically;
                                    BullePosition.X = (int)TabPositionBulle[1].X;
                                    ParolePosition = TabPositionParole[1];
                                    CouleurParole = Color.Blue;
                                }
                                break;
                            case 5:
                                {
                                    flip = SpriteEffects.None;
                                    BullePosition.X = (int)TabPositionBulle[0].X;
                                    ParolePosition = TabPositionParole[0];
                                    CouleurParole = Color.Red;
                                }
                                break;
                            case 6:
                                {
                                    flip = SpriteEffects.FlipVertically;
                                    BullePosition.X = (int)TabPositionBulle[1].X;
                                    ParolePosition = TabPositionParole[1];
                                    CouleurParole = Color.Blue;
                                }
                                break;
                            case 7:
                                {
                                    EnterVisible = false;
                                    flip = SpriteEffects.None;
                                    BullePosition.X = (int)TabPositionBulle[0].X;
                                    ParolePosition = TabPositionParole[0];
                                    CouleurParole = Color.Red;
                                    PosAnim.X+=5;
                                    if (PosAnim.X >= 800)
                                    {
                                        EnterVisible = true;
                                        if (KeyboardHelper.KeyPressed(Keys.Enter))
                                        {
                                            AddScreen(new cNivLiberation(m_ServiceProvider, m_GraphicsDeviceManager));
                                            RemoveScreen(this);
                                        }
                                    }
                                }
                                break;
                        }
                        WarioSexplique = true;
                    }
                    
                }
            }
            else if (!SorsDeFaussePart2)
                AnimationPlayer.PlayAnimation(GameResources.SorsDefausse1);
            else
                AnimationPlayer.PlayAnimation(GameResources.SorsDefausse2);

           
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            if (!TransfoNinjaComplete)
                g.Draw(GameResources.WarioNormal, new Rectangle(500, 200, GameResources.WarioNormal.Width * 2, GameResources.WarioNormal.Height * 2), Color.White);
            else
            {
                g.Draw(GameResources.BulleParole, BullePosition, null, Color.White, RotationBulle, new Vector2(), flip, 0);
                g.DrawString(GameResources.Texte2, TabParole[NumParole], ParolePosition, CouleurParole);
                if(EnterVisible)
                    g.DrawString(GameResources.Texte, "APPUYER SUR ENTER", new Vector2(BullePosition.X, 10), CouleurParole);
                AP2.Draw(gametime, g, new Vector2(550, 330), SpriteEffects.FlipHorizontally);
            }

            AnimationPlayer.Draw(gametime, g, PosAnim, SpriteEffects.None);
        }
    }
}

