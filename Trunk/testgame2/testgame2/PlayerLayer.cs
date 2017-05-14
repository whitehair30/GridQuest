﻿using System;
using System.Collections.Generic;
using CocosSharp;
using testgame2.Display;

namespace testgame2
{
    public class PlayerLayer : CCLayerColor
    {
        CCLabel positionDisplay;
        EnvironmentInputs environmentInputs;
        ScreenDetails screen; 
        CCSprite player;
     

        public PlayerLayer(ScreenDetails screen)
            : base(CCColor4B.Transparent)
        {
            this.screen = screen;
            environmentInputs = new EnvironmentInputs();

            positionDisplay = new CCLabel("", "Arial", 20, CCLabelFormat.SystemFont);
            positionDisplay.PositionX = 30;
            positionDisplay.PositionY = screen.Height - 20;
            positionDisplay.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(positionDisplay);

            player = new CCSprite("ball");
            player.Color = CCColor3B.Orange;
            //     player.Scale = 2;
            player.PositionX = screen.MiddleX;
            player.PositionY = screen.MiddleY;
            AddChild(player);

            Schedule(RunGameLogic);


        }

        void RunGameLogic(float frameTimeInSeconds)
        {

   //         ChangeVelocity(environmentInputs);
            positionDisplay.Text = $"Xpos: {player.PositionX} Ypos; {player.PositionY}";

           

        }
        protected override void AddedToScene()
        {
            base.AddedToScene();
            // Use the bounds to layout the positioning of our drawable assets
            CCRect bounds = VisibleBoundsWorldspace;
            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);


            var keylistener = new CCEventListenerKeyboard();
            keylistener.OnKeyPressed = OnKeyPressed;
            keylistener.OnKeyReleased = OnKeyReleased;
            AddEventListener(keylistener);

        }

        void OnKeyReleased(CCEventKeyboard keyevent)
        {

           // environmentInputs.CurrentInput.Remove(keyevent.Keys);
        }


        void OnKeyPressed(CCEventKeyboard keyevent)
        {
            //environmentInputs.CurrentInput.Add(keyevent.Keys);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
        
    }
}