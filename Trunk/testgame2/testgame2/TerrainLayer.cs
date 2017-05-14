using System;
using System.Collections.Generic;
using CocosSharp;
using testgame2.Display;
using testgame2.Content.Extension;
using testgame2.Movement;

namespace testgame2
{
    public class TerrainLayer : CCLayerColor
    {
        EnvironmentInputs environmentInputs;
        DisplayTerrain[,] terrains;
        PlayerVelocity player;
        

        public TerrainLayer(ScreenDetails screen)
            : base(CCColor4B.Black)
        {
            terrains = new DisplayTerrain[4, 4];
            terrains.FillWithDefault(this);
            terrains.SetPosition();

            player = new PlayerVelocity();

            environmentInputs = new EnvironmentInputs();

            Schedule(RunGameLogic);


        }


        void RunGameLogic(float frameTimeInSeconds)
        {
            environmentInputs.FrameTimeInSeconds = frameTimeInSeconds;

            player.Handleinput(environmentInputs);

            terrains.RepositionPosition(player.VelocityX, player.VelocityY);

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

        bool leftButtonDown = false;
        bool rightButtonDown = false;
        void OnKeyReleased(CCEventKeyboard keyevent)
        {

            environmentInputs.CurrentInput.Remove(keyevent.Keys);
        }


        void OnKeyPressed(CCEventKeyboard keyevent)
        {
            environmentInputs.CurrentInput.Add(keyevent.Keys);
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