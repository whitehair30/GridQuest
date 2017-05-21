using System;
using System.Collections.Generic;
using CocosSharp;
using System.Linq;
using testgame2.Classes;

namespace testgame2.Layers
{
    public class PlayerLayer : AbstractLayer
    {
        CCLabel positionDisplay;
        CCSprite playerSprite;
        bool TacoEaten = false;
        CCSprite taco;
        int tacoseaten;
        
        public PlayerLayer(GameData data )
            : base(data, CCColor4B.Transparent)
        {
          
            positionDisplay = new CCLabel("", "Arial", 20, CCLabelFormat.SystemFont);
            positionDisplay.PositionX = 30;
            positionDisplay.PositionY = screen.Height - 20;
            positionDisplay.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(positionDisplay);

            playerSprite = new CCSprite("ball");
            playerSprite.Color = CCColor3B.Orange;
            playerSprite.PositionX = screen.MiddleX;
            playerSprite.PositionY = screen.MiddleY;
            AddChild(playerSprite);

            player.PositionX = screen.MiddleX;
            player.PositionY = screen.MiddleY;


            taco = new CCSprite("taco");
            
            taco.PositionX = MapCalculations.RandomizeCoordinate(playerSprite.PositionX, player.PositionX, screen.Width);
            taco.PositionY = MapCalculations.RandomizeCoordinate(playerSprite.PositionY, player.PositionY, screen.Height);
            AddChild(taco);

            Schedule(RunGameLogic);


        }
     

        void RunGameLogic(float frameTimeInSeconds)
        {
            //  positionDisplay.Text = $"Xpos: {player.PositionX} Ypos; {player.PositionY}";
            positionDisplay.Text = $"Tacos eaten: {tacoseaten}";
            playerSprite.PositionX = GameData.PlayerPositionX;
            playerSprite.PositionY = GameData.PlayerPositionY;
            
            if(TacoEaten)
            {
                taco.PositionX = MapCalculations.RandomizeCoordinate(playerSprite.PositionX, player.PositionX, screen.Width);
                taco.PositionY = MapCalculations.RandomizeCoordinate(playerSprite.PositionX, player.PositionX, screen.Height);
                tacoseaten++;
                TacoEaten = false;
            }
            else
            {
                taco.PositionX -= GameData.RelativeDisplaceMentX;
                taco.PositionY -= GameData.RelativeDisplacementY;
                TacoEaten = CanPlayerEatTaco(taco, playerSprite);
            }


        }

        public bool CanPlayerEatTaco(CCSprite taco, CCSprite player)
        {
            var tacoPosition = taco.ContentSize;
            var playerPosition  = player.ContentSize;
            return (DoesAxisOverlap(taco.PositionX, tacoPosition.Width, player.PositionX, playerPosition.Width) &&
                DoesAxisOverlap(taco.PositionY, tacoPosition.Height, player.PositionY, playerPosition.Height));
            
        }

        public static bool DoesAxisOverlap(float position1, float dimension1, float position2, float dimension2)
        {
            return (position1 <= position2 + dimension2 && position1 >= position2
                || position1 + dimension1 >= position2 && position1 <= position2);
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

        void OnKeyReleased(CCEventKeyboard keyevent)
        {

           // environmentInputs.CurrentInput.Remove(keyevent.Keys);
        }


        void OnKeyPressed(CCEventKeyboard keyevent)
        {
            //environmentInputs.CurrentInput.Add(keyevent.Keys);
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