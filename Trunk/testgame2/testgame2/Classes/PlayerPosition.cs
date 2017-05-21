using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Classes
{
    public class PlayerPosition
    {

        public float VelocityX { get; private set; }
        public float VelocityY { get; private set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }

      

        float leftVelocityX = 0;
        float rightVelocityX = 0;
        float upVelocityY= 0;
        float downVelocityY = 0;

        public void Handleinput(EnvironmentInputs inputs, Level level)
        {
            bool leftButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Left);
            bool rightButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Right);
            bool upButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Up);
            bool downButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Down);

            leftVelocityX = UpdateVelocity(leftButtonDown, leftVelocityX);
            rightVelocityX = UpdateVelocity(rightButtonDown, rightVelocityX);
            upVelocityY = UpdateVelocity(upButtonDown, upVelocityY);
            downVelocityY = UpdateVelocity(downButtonDown, downVelocityY);


            VelocityX = AdjustVelocityForlevelEdge(PositionX, (rightVelocityX - leftVelocityX), level.LevelWidth);
            VelocityY = AdjustVelocityForlevelEdge(PositionY, (upVelocityY - downVelocityY), level.LevelHeight);
            
            // set position 
            PositionX += VelocityX;
            PositionY += VelocityY;
            
        }

        public static float AdjustVelocityForlevelEdge(float currentPostion, float newVelocity, float dimensionLength)
        {
            if(currentPostion + newVelocity < 0)
            {
                return -currentPostion;
            }
            if(currentPostion + newVelocity > dimensionLength)
            {
                return dimensionLength - currentPostion;
            }
            return newVelocity;
        }


        private static float UpdateVelocity(bool relevantButtonPreessed, float currentVelocity)
        {
            if (relevantButtonPreessed && currentVelocity < 10)
            {
                currentVelocity++;
            }
            else if (!relevantButtonPreessed && currentVelocity > 0)
            {
                currentVelocity--;
            }
            return currentVelocity;
        }


    }
}
