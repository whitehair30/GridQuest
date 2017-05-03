using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2
{
    public class Ball : CollidableItem
    {

        public Ball(CCSprite Sprite) : base(Sprite){}
        // How much to modify the ball's y velocity per second:
        const float gravity = 140;
        float frameTimeInSeconds;
        public override void Move()
        {
            Sprite.PositionX += GetChangeInX;
            Sprite.PositionY += GetChangeInY;
            YDistanceBeforeCollision = 0F;
            XDistanceBeforeCollision = 0F;
        }


        public override void ChangeVelocity(EnvironmentInputs inputs)
        {
            frameTimeInSeconds = inputs.FrameTimeInSeconds;
            YVelocity += inputs.FrameTimeInSeconds * -gravity;
        }


        public override float GetChangeInX
        {
            get { return (XVelocity * frameTimeInSeconds) - XDistanceBeforeCollision; }
        }

        public override float GetChangeInY
        {
            get { return (YVelocity * frameTimeInSeconds) - YDistanceBeforeCollision; }
        }

        public override void HandleTopCollision(float distanceUntilCollision)
        {
            YDistanceBeforeCollision = distanceUntilCollision;
            YVelocity *= -1;
            Sprite.PositionY += distanceUntilCollision;
        }

        public override void HandleBottomCollision(float distanceUntilCollision)
        {
            YDistanceBeforeCollision = distanceUntilCollision;
            YVelocity *= -1;
            Sprite.PositionY += distanceUntilCollision;
        }

        public override void HandleLeftCollision(float distanceUntilCollision)
        {
            XVelocity *= -1;
        }

        public override void HandleRightCollision(float distanceUntilCollision)
        {
            XVelocity *= -1;
        }


       
    }
}
