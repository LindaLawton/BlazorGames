using System.Collections.Generic;
using System.Linq;
using Games.Client.Pages;
using Microsoft.AspNetCore.Components;

namespace Games.Client.Model
{
    public class GameModel : ComponentBase
    {

        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public Dictionary<string, Player> Players { get; set; }

        [Parameter]
        public List<Ball> Balls { get; set; }  // fix issue with game with no balls.

        [Parameter]
        public Player Active { get; set; }  //TODO fix null issue for game with no paddles

        public GameModel()
        {
            Style = "fill:rgb(220,220,220);stroke-width:3;stroke:rgb(0,0,0)";
            Players = new Dictionary<string, Player>();
            Balls = new List<Ball>();
        }

        public void AddBall(int radius, int speed, string style, Point currentPosition, Point nextPosition, Point previousPosition = null)
        {
            Balls.Add(new Ball() { Radius = radius, Speed = speed, Style = style, CurrentPosition = currentPosition, NextPosition = nextPosition, PreviousPosition = previousPosition });
        }

        public void MovePaddleLeft()
        {
            var pos = Active.Paddles.First().GetNextLeftPoint();

            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
            else
                Active.Paddles.First().CurrentPosition = new Point(0, pos.Y);

        }
        public void MovePaddleRight()
        {
            var pos = Active.Paddles.First().GetNextRightPoint();
            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
            else 
                Active.Paddles.First().CurrentPosition = new Point(Width - Active.Paddles.First().Width, pos.Y);
        }

        public void MovePaddleUp()
        {
            var pos = Active.Paddles.First().GetNextUpPoint();
            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
            else
                Active.Paddles.First().CurrentPosition = new Point(pos.X, 0);
        }
        public void MovePaddleDown()
        {
            var pos = Active.Paddles.First().GetNextDownPoint();
            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
            else
                Active.Paddles.First().CurrentPosition = new Point(pos.X, Height - Active.Paddles.First().Height);
        }

        private bool IsOnScreen(Point pos)
        {
            if (pos.X <= 0 || pos.X + Active.Paddles.First().Width >= Width)
                return false;
            if (pos.Y <= 0 || pos.Y + Active.Paddles.First().Height >= Height)
                return false;

            //TODO issue where paddle will over run if moved fully should pop to edge.

            return true;
        }
    }
}