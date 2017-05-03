using System;
using System.Collections.Generic;
using CocosSharp;
namespace testgame2
{
    public class PlayerLayer : CCLayerColor
    {
        Paddle paddle;
        Ball ball;
        CCLabel scoreLabel;
        EnvironmentInputs environmentInputs;

        CCSprite player1;
        CCSprite player
        {
            get
            {
                if (player1 == null)
                {
                    player1 = new CCSprite("ball");
                    player1.Color = CCColor3B.Orange;
                    //     player.Scale = 2;
                    player1.PositionX = 252;
                    player1.PositionY = 252;
                    AddChild(player1);
                    
                }
                return player1;
            }
        }

        public PlayerLayer()
            : base(CCColor4B.Transparent)
        {

            environmentInputs = new EnvironmentInputs();
            var test = player;

            scoreLabel = new CCLabel("Xpos: 0", "Arial", 20, CCLabelFormat.SystemFont);
            scoreLabel.PositionX = 30;
            scoreLabel.PositionY = 300;
            scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(scoreLabel);

            //     player = new CCSprite("ball");
            //     player.Color = CCColor3B.Orange;
            ////     player.Scale = 2;
            //     player.PositionX = 252;
            //     player.PositionY = 252; 
            //     AddChild(player);

            Schedule(RunGameLogic);


        }

        float ballXVelocity;
        float ballYVelocity;
        // How much to modify the ball's y velocity per second:
        const float gravity = 140;

        float paddleLeftVelocity = 0;
        float paddleRightVelocity = 0;

        void RunGameLogic(float frameTimeInSeconds)
        {

            ChangeVelocity(environmentInputs);
            scoreLabel.Text = $"Xpos: {player1.PositionX}";

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
        //long delta
        public  void ChangeVelocity(EnvironmentInputs inputs)
        {

            bool leftButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Left);
            bool rightButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Right);

            if (leftButtonDown && paddleLeftVelocity < 10)
            {
                paddleLeftVelocity++;
            }
            else if (!leftButtonDown && paddleLeftVelocity > 0)
            {
                paddleLeftVelocity--;
            }
            if (rightButtonDown && paddleRightVelocity < 10)
            {
                paddleRightVelocity++;
            }
            else if (!rightButtonDown && paddleRightVelocity > 0)
            {
                paddleRightVelocity--;
            }
            var DeltaPositionX = paddleRightVelocity - paddleLeftVelocity;
            player.PositionX = player.PositionX += DeltaPositionX;
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
            environmentInputs.CurrentInput.Add(keyevent.Keys);
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