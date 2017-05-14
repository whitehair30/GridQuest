using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Movement
{
    public class PlayerVelocity
    {
        public float VelocityX { get; private set; }
        public float VelocityY { get; private set; }


        float leftVelocityX = 0;
        float rightVelocityX = 0;
        float upVelocityY= 0;
        float downVelocityY = 0;

        public void Handleinput(EnvironmentInputs inputs)
        {
            bool leftButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Left);
            bool rightButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Right);
            bool upButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Up);
            bool downButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Down);

            leftVelocityX = UpdateVelocity(leftButtonDown, leftVelocityX);
            rightVelocityX = UpdateVelocity(rightButtonDown, rightVelocityX);
            upVelocityY = UpdateVelocity(upButtonDown, upVelocityY);
            downVelocityY = UpdateVelocity(downButtonDown, downVelocityY);


            VelocityX = -1 * (rightVelocityX - leftVelocityX);
            VelocityY = -1 * (upVelocityY - downVelocityY);

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
