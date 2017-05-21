﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testgame2.Display;
using testgame2.Layers;
using testgame2.Extension;

namespace testgame2.Classes
{
    /// <summary>
    /// Stuff like player data, screen info and settings
    /// </summary>
    public class GameData
    {
        public ScreenDetails Screen { get; set; }
        public PlayerPosition Player { get; set; }
        public EnvironmentInputs Input { get; set; }
        public Level CurrentLevel { get; set; }


        public void LoadLevel(AbstractLayer terrainLayer)
        {
            CurrentLevel = new Level();
            CurrentLevel.InitiateLevel(terrainLayer, 3, 2);

            // set player positions
            MinPlayerPositionX = Screen.MiddleX;
            MinPlayerPositionY = Screen.MiddleY;
            MaxPlayerPositionX = CurrentLevel.LevelWidth - Screen.MiddleX;
            MaxPlayerPositionY = CurrentLevel.LevelHeight - Screen.MiddleY;

        }

        private float MaxPlayerPositionX;

        private float MaxPlayerPositionY;

        private float MinPlayerPositionX;

        private float MinPlayerPositionY;

        public void CalculateGameStep()
        {

          
            PlayerPositionX = MapCalculations.GetRelativePlayerPosition(Player.PositionX, MinPlayerPositionX, MaxPlayerPositionX, Screen.MiddleX);
            PlayerPositionY = MapCalculations.GetRelativePlayerPosition(Player.PositionY, MinPlayerPositionY, MaxPlayerPositionY, Screen.MiddleY);

            RelativeDisplaceMentX = MapCalculations.GetMapDisplacement(Player.PositionX, MinPlayerPositionX, MaxPlayerPositionX, Player.VelocityX);
            RelativeDisplacementY = MapCalculations.GetMapDisplacement(Player.PositionY, MinPlayerPositionY, MaxPlayerPositionY, Player.VelocityY);
        }


        // get player positions
        // TODO Create testable Functions
        public float PlayerPositionX { get; set; }
        public float PlayerPositionY { get; set; }

        // work out mechanics beter
        public float RelativeDisplaceMentX { get; set; }
        public float RelativeDisplacementY { get; set; }

    
    }
}
