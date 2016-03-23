using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGameLibrairy;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Loxi
{
    class GameResources
    {
        #region Texture2D
        //Variable d'image  
        public static Texture2D Test, Niv1Plage, PageTitre, BambooForest, TestPatrouille, BackgroundEtoile;

        //Action Loxi
        public static Texture2D WalkLoxi, JumpLoxi, JumpForwardLoxi, NothingLoxi, Transformation, Hula,
                                SorsDeFosse1, SorsDeFosse2, Hula2, SuperCombo1, SuperCombo2;

        //Action Donald
        public static Texture2D NothingDonald, WalkingDonald, JumpDonald, JumpForwardDonald, Shoot, ShootUpward;

        //Action raphael,michelangelo,donatello,leonard0
        public static Texture2D WalkingRaph, RaphAttack, WalkingMich, MichAttack, WalkingDonatello, DonAttack, LeoWalking, LeoAttack,
                                AfterFightRaph, AfterFightMich, AfterFightDon, AfterFightLeo, MichAttack2, DonAttack2, RaphAttack2, LeoAttack2;

        //Daffy duck
        public static Texture2D DaffiDuck, DaffiExitLevel;

        //Bouton
        public static Texture2D MainMenuButton, ExplicationMainButton;

        //Pause 
        public static Texture2D PausedMenu;

        //HealthBar
        public static Texture2D HealtBar, HealtBarCombat;

        //Sprite Texte
        public static SpriteFont Texte, Texte2;

        //Pluie-ParticleGenerator
        public static Texture2D Rain;

        //Musique et sons
        public static Song SongImageTitre, SongCinematique1, SongNiv1, SongCinematique2, SongNiv2, SongCinematique3, Rasputin, FinalSong;
        public static SoundEffect JumpEffect, ShootEffect;

        //Balle
        public static Texture2D BalleJoueur;

        //Niveau Complexe Scientifique
        public static Texture2D BunkerUpperView, BunkerRightSide, BunkerLeftSide, Fleche, Cercle, Donald,
                                RifleSoldierCheck, RifleSoldierPatrouille, BulleParole, FouAnime, DragInNiv2, Machine, Machine2;

        //Niveau CombatTortueNinja
        public static Texture2D PresentCombatWarrior, PresentRaph, PresentLeonardo, PresentDonatello,
                                PresentMichelangelo, SplinterSingle, Perchoir, grotte, grotte2, grotte3, grotte4, grotte5,
                                DanseTransfo;
        //Wario 
        public static Texture2D WarioNormal, WarioSurpris, WarioExplique, WarioExplosion;
        #endregion

        #region LoadContent
        public static void LoadContent(ContentManager Content)
        {
            FinalSong = Content.Load<Song>("SkrillexOrchestral");
            SuperCombo1 = Content.Load<Texture2D>("superCombo1");
            SuperCombo2 = Content.Load<Texture2D>("superCombo2");
            WarioExplosion = Content.Load<Texture2D>("WarioDestruction");
            LeoAttack2 = Content.Load<Texture2D>("LeoAttack2");
            MichAttack2 = Content.Load<Texture2D>("MichAttack2");
            RaphAttack2 = Content.Load<Texture2D>("RaphAttack2");
            DonAttack2 = Content.Load<Texture2D>("DonAttack2");
            Hula2 = Content.Load<Texture2D>("Hula2");
            BackgroundEtoile = Content.Load<Texture2D>("Crazy");
            Rasputin = Content.Load<Song>("Rasputin");
            DaffiExitLevel = Content.Load<Texture2D>("ExitLevel");
            WarioNormal = Content.Load<Texture2D>("warionormal");
            WarioSurpris = Content.Load<Texture2D>("wariosurpris");
            WarioExplique = Content.Load<Texture2D>("warioexplique");
            SongCinematique3 = Content.Load<Song>("Anti Gravity");
            SorsDeFosse1 = Content.Load<Texture2D>("SorsDeFausse1");
            SorsDeFosse2 = Content.Load<Texture2D>("SorsDeFausse2");
            DanseTransfo = Content.Load<Texture2D>("DanseTransfo");
            AfterFightDon = Content.Load<Texture2D>("AfterFightDon");
            AfterFightLeo = Content.Load<Texture2D>("AfterFightLeo");
            AfterFightMich = Content.Load<Texture2D>("AfterFightMich");
            AfterFightRaph = Content.Load<Texture2D>("AfterFightRaph");
            LeoAttack = Content.Load<Texture2D>("leoattack");
            LeoWalking = Content.Load<Texture2D>("leowalking");
            grotte5 = Content.Load<Texture2D>("grotte5");
            DonAttack = Content.Load<Texture2D>("DonAttack");
            WalkingDonatello = Content.Load<Texture2D>("donwalking");
            WalkingMich = Content.Load<Texture2D>("walkingmich");
            MichAttack = Content.Load<Texture2D>("michattack");
            grotte4 = Content.Load<Texture2D>("grotte4");
            grotte3 = Content.Load<Texture2D>("grotte3");
            Perchoir = Content.Load<Texture2D>("perchoir");
            RaphAttack = Content.Load<Texture2D>("RaphAttack");
            WalkingRaph = Content.Load<Texture2D>("raphaelmarche");
            SongNiv2 = Content.Load<Song>("Electric Daisy Violin");
            SongCinematique2 = Content.Load<Song>("Shadows");
            SongNiv1 = Content.Load<Song>("Elements");
            grotte2 = Content.Load<Texture2D>("grotte2");
            grotte = Content.Load<Texture2D>("grotte");
            PresentCombatWarrior = Content.Load<Texture2D>("PresentationCombattant");
            SplinterSingle = Content.Load<Texture2D>("splinterSingle");
            PresentMichelangelo = Content.Load<Texture2D>("presentMichelangelo");
            PresentDonatello = Content.Load<Texture2D>("presentDonatello");
            PresentLeonardo = Content.Load<Texture2D>("presentLeonardo");
            PresentRaph = Content.Load<Texture2D>("PresentRaphaelle");
            Cercle = Content.Load<Texture2D>("Cercle");
            Texte2 = Content.Load<SpriteFont>("Parole");
            RifleSoldierCheck = Content.Load<Texture2D>("RifleSoldierCheck");
            RifleSoldierPatrouille = Content.Load<Texture2D>("RifleSoldierPatrouille");
            FouAnime = Content.Load<Texture2D>("fouanime");
            DragInNiv2 = Content.Load<Texture2D>("dragInNiv2");
            Machine = Content.Load<Texture2D>("Machine");
            Machine2 = Content.Load<Texture2D>("Machine2");
            Donald = Content.Load<Texture2D>("Donalduck");
            BunkerUpperView = Content.Load<Texture2D>("bunkerUpperView");
            BunkerRightSide = Content.Load<Texture2D>("bunkerRightSide");
            BunkerLeftSide = Content.Load<Texture2D>("bunkerLeftSide");
            Fleche = Content.Load<Texture2D>("fleche");
            BulleParole = Content.Load<Texture2D>("BulleDeParole");
            BalleJoueur = Content.Load<Texture2D>("BalleJoueur");
            SongImageTitre = Content.Load<Song>("SongLoxi");
            SongCinematique1 = Content.Load<Song>("LoveInMotion");
            JumpEffect = Content.Load<SoundEffect>("JumpEffect");
            ShootEffect = Content.Load<SoundEffect>("ShootEffect");
            TestPatrouille = Content.Load<Texture2D>("TestPatrouille");
            BambooForest = Content.Load<Texture2D>("foretbambous");
            Rain = Content.Load<Texture2D>("Goutte");
            Texte = Content.Load<SpriteFont>("fontCinematique");
            PageTitre = Content.Load<Texture2D>("ImageTitre");
            Test = Content.Load<Texture2D>("Test");
            Niv1Plage = Content.Load<Texture2D>("Plage");
            WalkLoxi = Content.Load<Texture2D>("WalkingLoxi");
            JumpLoxi = Content.Load<Texture2D>("JumpLoxi");
            JumpForwardLoxi = Content.Load<Texture2D>("JumpForwardLoxi");
            NothingLoxi = Content.Load<Texture2D>("NothingLoxi");
            Transformation = Content.Load<Texture2D>("Transform");
            Hula = Content.Load<Texture2D>("Hula");
            MainMenuButton = Content.Load<Texture2D>("btnStart");
            NothingDonald = Content.Load<Texture2D>("idleDonald");
            WalkingDonald = Content.Load<Texture2D>("WalkingDonald");
            JumpDonald = Content.Load<Texture2D>("JumpDonald");
            JumpForwardDonald = Content.Load<Texture2D>("JumpForwardDonald");
            Shoot = Content.Load<Texture2D>("ShootDonald");
            ShootUpward = Content.Load<Texture2D>("ShootDonaldUpward");
            DaffiDuck = Content.Load<Texture2D>("daffiduck");
            HealtBar = Content.Load<Texture2D>("HealtBar");
            HealtBarCombat = Content.Load<Texture2D>("HealtBarCombat");
            PausedMenu = Content.Load<Texture2D>("Donald_Original_Outfit");
            ExplicationMainButton = Content.Load<Texture2D>("btnExplication");

            DonaldNothingAnimation = new Animation(NothingDonald, 90, 1.5f, 2, true);
            DonaldWalkingAnimation = new Animation(WalkingDonald, 90, 0.1f, 2, true);
            DonaldJumpAnimation = new Animation(JumpDonald, 100, 0.2f, 2, true);
            DonaldJumpForwardAnimation = new Animation(JumpForwardDonald, 90, 0.2f, 2, true);
            DonaldShootAnimation = new Animation(Shoot, 90, 0.1f, 2, false);
            DonaldShootUpwardAnimation = new Animation(ShootUpward, 100, 0.1f, 2, false);
            SorsDefausse1 = new Animation(SorsDeFosse1, 100, 0.18f, 2, false);
            SorsDefausse2 = new Animation(SorsDeFosse2, 100, 0.18f, 2, false);
            TransfoNinja = new Animation(Transformation, 101, 0.15f, 2, false);

            LoxiwalkAnimation = new Animation(WalkLoxi, 90, 0.1f, 2, true);
            LoxiJumpAnimation = new Animation(JumpLoxi, 100, 0.1f, 2, true);
            LoxiNothingAnimation = new Animation(NothingLoxi, 80, 0.25f, 2, true);
            TransformationAnimation = new Animation(Transformation, 101, 0.15f, 2, true);
            LoxiJumpForwardAnimation = new Animation(JumpForwardLoxi, 85, 0.2f, 2, true);
            HulaAnimation = new Animation(Hula, 100, 0.1f, 2, false);
            Hula2Animation = new Animation(Hula2, 110, 0.1f, 2, false);
            SuperComboPart1 = new Animation(SuperCombo1, 180, 0.5f, 2, false);
            SuperComboPart2 = new Animation(SuperCombo2, 180, 0.5f, 2, false);

            WarioSurprisAnimation = new Animation(WarioSurpris, 60, 0.5f, 2, true);
            WarioExpliqueAnimation = new Animation(WarioExplique, 60, 0.5f, 2, true);
            WarioExploseAnimation = new Animation(WarioExplosion, 60, 1, 2, false);

            DanseTransformation = new Animation(DanseTransfo, 80, 0.9f, 2, true);
            NothingSplinter = new Animation(SplinterSingle, 80, 0.1f, 2, true);

            WalkingRaphAnimation = new Animation(WalkingRaph, 80, 0.5f, 2, true);
            RaphAttackAnimation = new Animation(RaphAttack, 90, 0.3f, 2, true);
            RaphAttenteAnimation = new Animation(AfterFightRaph, 80, 0.5f, 2, true);
            RaphAttack2Animation = new Animation(RaphAttack2, 110, 0.5f, 2, false);

            WalkingMichAnimation = new Animation(WalkingMich, 80, 0.5f, 2, true);
            MichAttackAnimation = new Animation(MichAttack, 100, 0.3f, 2, true);
            MichAttenteAnimation = new Animation(AfterFightMich, 80, 0.5f, 2, true);
            MichAttack2Animation = new Animation(MichAttack2, 120, 0.5f, 2, false);

            WalkingDonAnimation = new Animation(WalkingDonatello, 80, 0.5f, 2, true);
            DonAttackAnimation = new Animation(DonAttack, 105, 0.3f, 2, true);
            DonAttenteAnimation = new Animation(AfterFightDon, 80, 0.5f, 2, true);
            DonAttack2Animation = new Animation(DonAttack2, 110, 0.5f, 2, false);

            WalkingLeoAnimation = new Animation(LeoWalking, 80, 0.5f, 2, true);
            LeoAttackAnimation = new Animation(LeoAttack, 100, 0.3f, 2, true);
            LeoAttenteAnimation = new Animation(AfterFightLeo, 80, 0.5f, 2, true);
            LeoAttack2Animation = new Animation(LeoAttack2, 110, 0.5f, 2, false);

            RifleSoldierCheckAnimation = new Animation(GameResources.RifleSoldierCheck, 45, 1.0f, 1f, true);
            RifleSoldierPatrouilleAnimation = new Animation(GameResources.RifleSoldierPatrouille, 45, 0.10f, 2, true);
        }
        #endregion

        #region Animations
        #region DonaldAnimation
        public static Animation DonaldNothingAnimation;
        public static Animation DonaldWalkingAnimation;
        public static Animation DonaldJumpAnimation;
        public static Animation DonaldJumpForwardAnimation;
        public static Animation DonaldShootAnimation;
        public static Animation DonaldShootUpwardAnimation;
        public static Animation SorsDefausse1;
        public static Animation SorsDefausse2;
        public static Animation TransfoNinja;
        #endregion

        #region LoxiAnimation
        public static Animation LoxiwalkAnimation;
        public static Animation LoxiJumpAnimation;
        public static Animation LoxiNothingAnimation;
        public static Animation TransformationAnimation;
        public static Animation LoxiJumpForwardAnimation;
        public static Animation HulaAnimation;
        public static Animation Hula2Animation;
        public static Animation SuperComboPart1;
        public static Animation SuperComboPart2;
        #endregion

        #region Wario Animation
        public static Animation WarioSurprisAnimation;
        public static Animation WarioExpliqueAnimation;
        public static Animation WarioExploseAnimation;
        #endregion

        #region Splinter Animation
        public static Animation DanseTransformation;
        public static Animation NothingSplinter;
        #endregion

        #region Raphael Animation
        public static Animation WalkingRaphAnimation;
        public static Animation RaphAttackAnimation;
        public static Animation RaphAttenteAnimation;
        public static Animation RaphAttack2Animation;
        #endregion

        #region Michelangelo Animation
        public static Animation WalkingMichAnimation;
        public static Animation MichAttackAnimation;
        public static Animation MichAttenteAnimation;
        public static Animation MichAttack2Animation;
        #endregion

        #region Donatello Animation
        public static Animation WalkingDonAnimation;
        public static Animation DonAttackAnimation;
        public static Animation DonAttenteAnimation;
        public static Animation DonAttack2Animation;
        #endregion

        #region Leonardo Animation
        public static Animation WalkingLeoAnimation;
        public static Animation LeoAttackAnimation;
        public static Animation LeoAttenteAnimation;
        public static Animation LeoAttack2Animation;
        #endregion
        #endregion

        #region Soldier
        public static Animation RifleSoldierCheckAnimation;
        public static Animation RifleSoldierPatrouilleAnimation;
        #endregion
    }
}
