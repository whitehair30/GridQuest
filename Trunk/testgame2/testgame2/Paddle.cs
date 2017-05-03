using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2
{
    public class Paddle :CollidableItem
    {
        public Paddle(CCSprite Sprite) : base(Sprite)
        {

        }


        float paddleLeftVelocity;
        float paddleRightVelocity;

        public override void ChangeVelocity(EnvironmentInputs inputs)
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
            XVelocity = paddleRightVelocity - paddleLeftVelocity;
        }

        public override float GetChangeInX
        {
            get { return XVelocity; }
        }

        public override float GetChangeInY
        {
            get {return 0;}
        }

        public override void Move()
        {
            Sprite.PositionX += GetChangeInX;
        }

        public override void HandleTopCollision(float distanceUntilCollision)
        {
            
        }

        public override void HandleBottomCollision(float distanceUntilCollision)
        {
            
        }

        public override void HandleLeftCollision(float distanceUntilCollision)
        {
            XVelocity = 0;
        }

        public override void HandleRightCollision(float distanceUntilCollision)
        {
            XVelocity = 0;
        }



    
    }
}
