using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testgame2.Classes;

namespace UnitTests
{
    [TestClass]
    public class PlayerVelocityCalculations
    {
        [TestMethod]
        public void CalculatePlayerPosition_AboveLowerCoordinate()
        {
            float NewPosition = 105;
            float LowerCoordinate = 100;
            float HigherCoordinate = 200;
            float MiddlePositionScreen = 100;
            float ExpectedScreenPosition = 100;
            var CalculatedScreenPosition = MapCalculations.GetRelativePlayerPosition(NewPosition, LowerCoordinate,HigherCoordinate, MiddlePositionScreen);
            Assert.AreEqual(ExpectedScreenPosition, CalculatedScreenPosition);

        }

        [TestMethod]
        public void CalculatePlayerPosition_BelowLowerCoordinate()
        {
            float NewPosition = 95;
            float LowerCoordinate = 100;
            float HigherCoordinate = 200;
            float MiddlePositionScreen = 100;
            float ExpectedScreenPosition = 95;
            var CalculatedScreenPosition = MapCalculations.GetRelativePlayerPosition(NewPosition, LowerCoordinate, HigherCoordinate, MiddlePositionScreen);
            Assert.AreEqual(ExpectedScreenPosition, CalculatedScreenPosition);

        }

        [TestMethod]
        public void CalculatePlayerPosition_AboveHigherCoordinate()
        {
            float NewPosition = 205;
            float LowerCoordinate = 100;
            float HigherCoordinate = 200;
            float MiddlePositionScreen = 100;
            float ExpectedScreenPosition = 105;
            var CalculatedScreenPosition = MapCalculations.GetRelativePlayerPosition(NewPosition, LowerCoordinate, HigherCoordinate, MiddlePositionScreen);
            Assert.AreEqual(ExpectedScreenPosition, CalculatedScreenPosition);

        }

        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToLowerEdge_NegativeVelocity_VelocityAdjusted()
        {

            float CurrentPosition = 4;
            float NewVelocity = -10;
            float DimensionLength = 200;
            float ExpectedAdjustedVelocity = -4;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }

        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToLowerEdge_PositiveVelocity_NoVelocityChange()
        {

            float CurrentPosition = 5;
            float NewVelocity = 10;
            float DimensionLength = 200;
            float ExpectedAdjustedVelocity = 10;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }

        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToUpperEdge_PositiveVelocity_VelocityAdjusted()
        {

            float CurrentPosition = 196;
            float NewVelocity = 10;
            float DimensionLength = 200;
            float ExpectedAdjustedVelocity = 4;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }


        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToUpperEdge_NegativeVelocity_NoVelocityChange()
        {

            float CurrentPosition = 196;
            float NewVelocity = 10;
            float DimensionLength = 200;
            float ExpectedAdjustedVelocity = 4;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }
    }
}
