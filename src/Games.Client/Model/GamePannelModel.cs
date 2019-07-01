using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Client.Pages;
using Microsoft.AspNetCore.Components;

namespace Games.Client.Model
{
    public class GamePannelModel : ComponentBase
    {

        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public List<Paddle> Paddles { get; set; }

        [Parameter]
        public List<Ball> Balls { get; set; }

        [Parameter]
        public Paddle Active { get; set; }
        
       


        public GamePannelModel()
        {
            Style = "fill:rgb(220,220,220);stroke-width:3;stroke:rgb(0,0,0)";
            Paddles = new List<Paddle>();
            Balls = new List<Ball>();
        }

        public void AddPaddle(int height, int width, int speed, string style, Point currentPosition, bool active = true)
        {
            Paddles.Add(new Paddle() { Height = height, Width = width, Style = style, Speed = speed,  CurrentPosition = currentPosition });

            if (active)
                Active = Paddles.FirstOrDefault(p => p.Height.Equals(height) && p.Width.Equals(width) &&  p.Speed.Equals(speed)  && p.Style.Equals(style) && p.CurrentPosition.Equals(currentPosition));
        }

        public void AddBall(int radius, int speed, string style, Point currentPosition, Point nextPosition, Point previousPosition = null)
        {
            Balls.Add(new Ball() { Radius = radius, Speed = speed, Style = style, CurrentPosition = currentPosition, NextPosition = nextPosition, PreviousPosition = previousPosition });
        }

        public void MovePaddleLeft()
        {
            var pos = Active.GetNextLeftPoint();

            if (IsOnScreen(pos))
                Active.CurrentPosition = pos;

        }
        public void MovePaddleRight()
        {
            var pos = Active.GetNextRightPoint();
            if (IsOnScreen(pos))
                Active.CurrentPosition = pos;
        }

        public void MovePaddleUp()
        {
            var pos = Active.GetNextUpPoint();
            if (IsOnScreen(pos))
                Active.CurrentPosition = pos;
        }
        public void MovePaddleDown()
        {
            var pos = Active.GetNextDownPoint();
            if (IsOnScreen(pos))
                Active.CurrentPosition = pos;
        }

        private bool IsOnScreen(Point pos)
        {
            if (pos.X <= 0 || pos.X + Active.Width >= Width)
                return false;
            if (pos.Y <= 0 || pos.Y + Active.Height >= Height)
                return false;


            return true;
        }
    }
}
