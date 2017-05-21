using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Classes
{
    public static class MapCalculations
    {
        /// <summary>
        /// Calculates the map displacement
        /// </summary>
        /// <param name="NewPosition">is already adjusted for the Velocity</param>
        /// <param name="LowerPlayerCoordinate">Distance of the player to the map edge, before the map stops moving, and the player starts moving</param>
        /// <param name="HigherPlayerCoordinate"></param>
        /// <param name="Veloctiy"></param>
        /// <returns></returns>
        public static float GetMapDisplacement(float NewPosition, float LowerPlayerCoordinate, float HigherPlayerCoordinate, float Veloctiy)
        {
            float oldPosition = NewPosition - Veloctiy;
            if (Veloctiy >= 0)
            {
                if (oldPosition >= HigherPlayerCoordinate || NewPosition <= LowerPlayerCoordinate)
                    return 0F;
                if (oldPosition >= LowerPlayerCoordinate && NewPosition <= HigherPlayerCoordinate)
                {
                    return Veloctiy;
                }
                if (oldPosition <= LowerPlayerCoordinate)
                {
                    return NewPosition - LowerPlayerCoordinate;
                }
                return HigherPlayerCoordinate - oldPosition;
            }
            else
            {
                if (NewPosition >= HigherPlayerCoordinate || oldPosition <= LowerPlayerCoordinate)
                    return 0F;
                if (NewPosition >= LowerPlayerCoordinate && oldPosition <= HigherPlayerCoordinate)
                {
                    return Veloctiy;
                }
                if (NewPosition <= LowerPlayerCoordinate)
                {
                    return LowerPlayerCoordinate - oldPosition;
                }
                return NewPosition - HigherPlayerCoordinate;
            }
        }

        /// <summary>
        /// Calculates the Player position on the screen
        /// </summary>
        /// <param name="NewCoorinate"></param>
        /// <param name="LowerCoordinate"></param>
        /// <param name="HigherCoordinate"></param>
        /// <param name="MiddlePosition"></param>
        /// <returns></returns>
        public static float GetRelativePlayerPosition(float NewCoorinate, float LowerCoordinate, float HigherCoordinate, float MiddlePosition)
        {
            if (NewCoorinate < LowerCoordinate)
            {
                return NewCoorinate;
            }
            if (NewCoorinate > HigherCoordinate)
            {
                return NewCoorinate - HigherCoordinate + MiddlePosition;
            }
            return MiddlePosition;
        }



        private static Random tacoCalc = new Random();
        public static float RandomizeCoordinate(float playerPosition, float PlayerCoordinate, float dimension)
        {
            float returnval = -1;
            int next;
            do
            {
                next = tacoCalc.Next(400);
                returnval = GetDistanceWithRandom(playerPosition, PlayerCoordinate,dimension,next );
            }
            while (!IsNewSeedAcceptable(playerPosition, PlayerCoordinate, dimension, next, returnval));
            return returnval;
        }

        public static float GetDistanceWithRandom(float playerPosition, float PlayerCoordinate, float dimension, int random)
        {
            float returnval = -1;
            if (random > 200)
            {
                returnval = playerPosition - 200 - random;
            }
            else
            {
                returnval = playerPosition + random;
            }
            return returnval;
        }

        public static bool IsNewSeedAcceptable(float playerPosition, float PlayerCoordinate, float dimension, int random, float seed)
        {
            return (seed > 0 && (random > 200 ? playerPosition + random < dimension : true)) ;
        }

    }
}
