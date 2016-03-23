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

    class cMovie4 : GameScreen
    {
        enum State
        {
            Rencontre, Combat
        }

        enum CouleurParole
        {
            Loxi, Splinter, Wario
        }

        int I = 0, P = 1;
        float Timer = 0;
        Color[] TabCouleur = new Color[3] { Color.Blue, Color.Green, Color.Red };
        State MovieState = State.Rencontre;
        CouleurParole fontColor = CouleurParole.Splinter;
        AnimationPlayer AnimationPlayer = new AnimationPlayer();
        AnimationPlayer APLeo = new AnimationPlayer(), APDon = new AnimationPlayer(), APMich = new AnimationPlayer(), APRaph = new AnimationPlayer();
        string[] TableParole = new string[12];
        Vector2[] TabPositionParole = new Vector2[2];
        Vector2 PositionLoxi = new Vector2(100, 400), PositionSplinter = new Vector2(700, 400),
                PositionDon = new Vector2(500, 100), Positionleo = new Vector2(800, 300),
                PositionMich = new Vector2(200, 100), PositionRaph = new Vector2(650, 450), PositionWario = new Vector2(300, 300);

        bool Repositionnement, AttackDon, AttackLeo, AttackMich, AttackRaph, SCPart2, AttackLoxi;
        SpriteEffects DonEffect, LeoEffect, RaphEffect;

        private AnimationPlayer m_AnimationPlayer;

        public cMovie4(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            TableParole[0] = "Splinter: EHH étranger...Loxi c'est ca??!";
            TableParole[1] = "Loxi: Mais comment avez-vous \nfait pour vous en sortir, vous aussi??";
            TableParole[2] = "Splinter: Vous avez laissé un gros \ntrou après vous être échappé.\non veut lui faire payer ce qu'il\n nous as fait";
            TableParole[3] = "Loxi: pour sûr ,il va payer, \nil n'a pas le droit de détruire \nmon île.";
            TableParole[4] = "Splinter: Nous ne savions pas \nqu'il voulais détruire la planète,\n raison de plus pour l'éliminer";
            TableParole[5] = "Loxi: Il a fallit tuer un innocent \nqu'il aille en enfer";
            TableParole[6] = "Wario: Quand est ce que tu va me laisser tranquille toi !!!!!";
            TableParole[7] = "Loxi:     Arrête tes plans de \ndestruction et je vais te laisser en paix";
            TableParole[8] = "Wario: Je suis presque prêt tu ne pourras rien contre moi";
            TableParole[9] = "Loxi: Nous allons t'arreter \nque tu le veuilles ou non";
            TableParole[10] = "Wario: Nous????";
            TableParole[11] = "";
            TabPositionParole[0] = new Vector2(50, 100);
            TabPositionParole[1] = new Vector2(400, 100);
        }

        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (KeyboardHelper.KeyPressed(Keys.Enter))
            //    I++;

            if (Timer >= 5)
            {
                I++;
                Timer = 0;
            }

            if (I >= TableParole.Length)
            {
                I = TableParole.Length - 1;
            }

            switch (MovieState)
            {
                #region Rencontre
                case State.Rencontre:
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.DanseTransformation);
                    break;
                #endregion
                #region Combat
                case State.Combat: if (I == 11)
                    {
                        #region AttackMich
                        if (APMich.m_Animation == RessourcesLoxi.MichAttack2Animation && APMich.m_FrameIndex == 3)
                        {
                            APMich.PlayAnimation(RessourcesLoxi.MichAttenteAnimation);
                            AttackMich = true;
                        }
                        else if (!AttackMich)
                            APMich.PlayAnimation(RessourcesLoxi.MichAttack2Animation);
                        #endregion

                        if (AttackMich)
                        {
                            #region AttackRaph
                            if (!AttackRaph)
                                PositionRaph.Y = PositionWario.Y + 40;
                            else
                                PositionRaph.Y = 450;

                            if (PositionRaph.Y <= PositionWario.Y + 80)
                                APRaph.PlayAnimation(RessourcesLoxi.RaphAttack2Animation);

                            if (APRaph.m_Animation == RessourcesLoxi.RaphAttack2Animation && APRaph.m_FrameIndex == 3)
                            {
                                APRaph.PlayAnimation(RessourcesLoxi.RaphAttenteAnimation);
                                AttackRaph = true;
                            }
                            #endregion
                        }

                        if (AttackRaph)
                        {
                            #region AttackDon
                            if (!AttackDon)
                            {
                                PositionDon.Y = PositionWario.Y + 40;
                                PositionDon.X = PositionWario.X + 40;
                            }
                            else
                            {
                                PositionDon.Y = 450;
                                PositionDon.X = 500;
                            }

                            if (PositionDon.Y <= PositionWario.Y + 80)
                                APDon.PlayAnimation(RessourcesLoxi.DonAttack2Animation);

                            if (APDon.m_Animation == RessourcesLoxi.DonAttack2Animation && APDon.m_FrameIndex == 3)
                            {
                                APDon.PlayAnimation(RessourcesLoxi.DonAttenteAnimation);
                                AttackDon = true;
                            }
                            #endregion
                        }

                        if (AttackDon)
                        {
                            #region AttackDon
                            if (!AttackLeo)
                            {
                                Positionleo.Y = PositionWario.Y + 40;
                                Positionleo.X = PositionWario.X + 40;
                            }
                            else
                            {
                                Positionleo.Y = 300;
                                Positionleo.X = 500;
                            }

                            if (PositionDon.Y <= PositionWario.Y + 80)
                                APLeo.PlayAnimation(RessourcesLoxi.LeoAttack2Animation);

                            if (APLeo.m_Animation == RessourcesLoxi.LeoAttack2Animation && APLeo.m_FrameIndex == 3)
                            {
                                APLeo.PlayAnimation(RessourcesLoxi.LeoAttenteAnimation);
                                AttackLeo = true;
                            }
                            #endregion
                        }

                        if (AttackLeo)
                        {
                            PositionLoxi.X = PositionWario.X - 60;
                            PositionLoxi.Y = PositionWario.Y + 60;
                            if (!SCPart2)
                            {
                                m_AnimationPlayer.PlayAnimation(RessourcesLoxi.SuperComboPart1);
                                if (m_AnimationPlayer.m_FrameIndex == 3)
                                {
                                    SCPart2 = true;
                                }
                            }
                            else
                            {
                                m_AnimationPlayer.PlayAnimation(RessourcesLoxi.SuperComboPart2);
                                if (m_AnimationPlayer.m_FrameIndex == 4)
                                {
                                    AttackLoxi = true;
                                }
                            }

                            if (AttackLoxi)
                                AnimationPlayer.PlayAnimation(RessourcesLoxi.WarioExploseAnimation);
                        }

                        if (AnimationPlayer.m_Animation == RessourcesLoxi.WarioExploseAnimation)

                            if (AnimationPlayer.m_FrameIndex == 3)
                                TableParole[I] = "NOOOOOOOOOOOOOOOOO";
                            else if (AnimationPlayer.m_FrameIndex == 6)
                            {
                                AddScreen(new cFinal(m_ServiceProvider, m_GraphicsDeviceManager));
                                RemoveScreen(this);
                            }

                    }
                    break;
                #endregion
            }

            #region changement de parole
            switch (I)
            {
                case 0: m_AnimationPlayer.PlayAnimation(RessourcesLoxi.LoxiNothingAnimation);
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.DanseTransformation);
                    break;
                case 1: fontColor = CouleurParole.Loxi;
                    m_AnimationPlayer.PlayAnimation(RessourcesLoxi.HulaAnimation);
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.NothingSplinter);
                    P = 0;
                    break;
                case 2: fontColor = CouleurParole.Splinter;
                    m_AnimationPlayer.PlayAnimation(RessourcesLoxi.LoxiNothingAnimation);
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.DanseTransformation);
                    P = 1;
                    break;
                case 3: fontColor = CouleurParole.Loxi;
                    m_AnimationPlayer.PlayAnimation(RessourcesLoxi.Hula2Animation);
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.NothingSplinter);
                    P = 0;
                    break;
                case 4: fontColor = CouleurParole.Splinter;
                    m_AnimationPlayer.PlayAnimation(RessourcesLoxi.LoxiNothingAnimation);
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.DanseTransformation);
                    P = 1;
                    break;
                case 5: fontColor = CouleurParole.Loxi;
                    P = 0;
                    PositionLoxi.X -= 4;
                    PositionSplinter.X -= 4;
                    if (PositionSplinter.X < 0)
                    {
                        MovieState = State.Combat;
                        AnimationPlayer.PlayAnimation(RessourcesLoxi.WarioExpliqueAnimation);
                        if (!Repositionnement)
                        {
                            Repositionnement = true;
                            PositionLoxi.X = 840;
                        }
                        else
                            PositionLoxi.X += 2;
                    }
                    break;
                case 6: fontColor = CouleurParole.Wario;
                    m_AnimationPlayer.PlayAnimation(RessourcesLoxi.LoxiNothingAnimation);

                    P = 0;
                    break;
                case 7: fontColor = CouleurParole.Loxi;
                    P = 1;
                    break;
                case 8: fontColor = CouleurParole.Wario;
                    P = 0;
                    break;
                case 9: fontColor = CouleurParole.Loxi;
                    P = 1;
                    break;
                case 10: fontColor = CouleurParole.Wario;
                    AnimationPlayer.PlayAnimation(RessourcesLoxi.WarioSurprisAnimation);
                    APDon.PlayAnimation(RessourcesLoxi.DonAttenteAnimation);
                    APLeo.PlayAnimation(RessourcesLoxi.LeoAttenteAnimation);
                    APRaph.PlayAnimation(RessourcesLoxi.RaphAttenteAnimation);
                    APMich.PlayAnimation(RessourcesLoxi.MichAttenteAnimation);

                    DonEffect = SpriteEffects.FlipHorizontally;
                    LeoEffect = SpriteEffects.FlipHorizontally;
                    RaphEffect = SpriteEffects.FlipHorizontally;

                    PositionDon.Y += 1;
                    PositionMich.Y += 1;
                    PositionRaph.X -= 1;
                    Positionleo.X -= 1;
                    if (PositionLoxi.X > 80)
                    {
                        PositionLoxi.X -= 2;
                    }
                    P = 0;
                    break;
                case 11:


                    break;
            }
            #endregion
        }



        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            switch (MovieState)
            {
                #region rencontre
                case State.Rencontre:
                    g.DrawString(RessourcesLoxi.Texte2, TableParole[I], TabPositionParole[P], TabCouleur[(int)fontColor]);
                    AnimationPlayer.Draw(gametime, g, PositionSplinter, SpriteEffects.None);
                    m_AnimationPlayer.Draw(gametime, g, PositionLoxi, SpriteEffects.None);
                    break;
                #endregion

                case State.Combat:
                    g.GraphicsDevice.Clear(Color.WhiteSmoke);
                    AnimationPlayer.Draw(gametime, g, PositionWario, SpriteEffects.None);

                    if (APDon.m_Animation != null || APMich.m_Animation != null || APLeo.m_Animation != null || APRaph.m_Animation != null)
                    {
                        APMich.Draw(gametime, g, PositionMich, SpriteEffects.None);
                        APDon.Draw(gametime, g, PositionDon, DonEffect);
                        APLeo.Draw(gametime, g, Positionleo, LeoEffect);
                        APRaph.Draw(gametime, g, PositionRaph, RaphEffect);
                    }
                    m_AnimationPlayer.Draw(gametime, g, PositionLoxi, SpriteEffects.None);
                    g.DrawString(RessourcesLoxi.Texte2, TableParole[I], TabPositionParole[P], TabCouleur[(int)fontColor]);
                    break;
            }
        }
    }
}
