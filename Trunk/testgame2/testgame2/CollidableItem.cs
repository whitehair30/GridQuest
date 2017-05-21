using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testgame2.Classes;

namespace testgame2
{
    public abstract class CollidableItem
    {

        protected float XVelocity;
        protected float YVelocity;

        protected float XDistanceBeforeCollision;
        protected float YDistanceBeforeCollision;

        public CollidableItem(CCSprite Sprite)
        {
            this.Sprite = Sprite;
        }

        protected CCSprite Sprite { get; private set; }

        public abstract float GetChangeInX { get; }
        public abstract float GetChangeInY { get; }


        public abstract void HandleTopCollision(float distanceUntilCollision);
        public abstract void HandleBottomCollision(float distanceUntilCollision);
        public abstract void HandleLeftCollision(float distanceUntilCollision);
        public abstract void HandleRightCollision(float distanceUntilCollision);

        public float GetBottom { get { return Sprite.PositionY - Sprite.ContentSize.Height * 0.5F; } }
        public float GetTop { get { return Sprite.PositionY + Sprite.ContentSize.Height * 0.5F; } }
        public float GetLeft { get { return Sprite.PositionX - Sprite.ContentSize.Width* 0.5F; } }
        public float GetRight { get { return Sprite.PositionX + Sprite.ContentSize.Width * 0.5F; } }


        public abstract void ChangeVelocity(EnvironmentInputs inputs);

        public abstract void Move();

        public static bool DoItemsCollideOnX(CollidableItem item1, CollidableItem item2)
        {

            return false;


        }

        public static bool DoItemsCollideOnY(CollidableItem item1, CollidableItem item2)
        {
            // is collistion possible?
            if(item1.GetRight >= item2.GetLeft
                && item1.GetLeft <=item2.GetRight)
            {
                // yes colli
                if (item1.GetBottom >= item2.GetTop
                    && item1.GetBottom + item1.GetChangeInY <= item2.GetTop + item2.GetChangeInY)
                {
                    float distance = item1.GetBottom - item2.GetTop;
                    item1.HandleBottomCollision(distance);
                    item2.HandleTopCollision(distance);
                }
            }
            return false;
        }




    }
}
