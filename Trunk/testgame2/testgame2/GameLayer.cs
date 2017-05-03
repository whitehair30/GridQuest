using System;
using System.Collections.Generic;
using CocosSharp;
namespace testgame2
{
    public class GameLayer : CCLayerColor
    {
        Paddle paddle;
        Ball ball;
        CCLabel scoreLabel;
        EnvironmentInputs environmentInputs;

        CCSprite[,] grasland;

        public GameLayer()
            : base(CCColor4B.Black)
        {
            grasland = new CCSprite[20, 20];

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    var grassSprite = new CCSprite("weed");
                    grassSprite.PositionX = 12 + (24 * x);
                    grassSprite.PositionY = 12 + (24 * y);
                    AddChild(grassSprite);
                    grasland[x, y] = grassSprite;
                }
            }
            Schedule(RunGameLogic);


        }

        float ballXVelocity;
        float ballYVelocity;
        // How much to modify the ball's y velocity per second:
        const float gravity = 140;

        float paddleLeftVelocity;
        float paddleRightVelocity;

        void RunGameLogic(float frameTimeInSeconds)
        {


            //   environmentInputs.FrameTimeInSeconds = frameTimeInSeconds;
            //var paddleSprite = new CCSprite("paddle");
            //paddleSprite.PositionX = 0;
            //paddleSprite.PositionY = 100;
            //AddChild(paddleSprite);
            //paddle = new Paddle(paddleSprite);
            //var ballSprite = new CCSprite("ball");
            //ballSprite.PositionX = 320;
            //ballSprite.PositionY = 600;
            //AddChild(ballSprite);
            //ball = new Ball(ballSprite);
            //scoreLabel = new CCLabel("Score: 0", "Arial", 20, CCLabelFormat.SystemFont);
            //scoreLabel.PositionX = 50;
            //scoreLabel.PositionY = 1000;
            //scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;
            //AddChild(scoreLabel);
            //environmentInputs = new EnvironmentInputs();
          //  Schedule(RunGameLogic);

           


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

         //   environmentInputs.CurrentInput.Remove(keyevent.Keys);
            //switch (keyevent.Keys)
            //{
            //    case CCKeys.Right:
            //        rightButtonDown = false;
            //        break;
            //    case CCKeys.Left:
            //        leftButtonDown = false;
            //        break;
            //}
        }


        void OnKeyPressed(CCEventKeyboard keyevent)
        {
         //   environmentInputs.CurrentInput.Add(keyevent.Keys);
            //switch (keyevent.Keys)
            //{
            //    case CCKeys.Right:
            //        rightButtonDown = true;
            //        break;
            //    case CCKeys.Left:
            //        leftButtonDown = true;
            //        break;
            //}
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