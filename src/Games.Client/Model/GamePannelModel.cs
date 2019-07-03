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
        public GameModel Game { get; set; }
        [Parameter] public Action StartGameParentMethod { get; set; }

        public void InvokeStartGameParentMethod()
        {
            StartGameParentMethod?.Invoke();
        }
    }

    public class GameModel : ComponentBase
    {

        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public string Style { get; set; }

        //[Parameter]
        //public List<Paddle> Paddles { get; set; }

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

        //public void AddPaddle(int height, int width, int speed, string style, Point currentPosition, PaddleMovment paddleMovment, bool active = true)
        //{
        //    Paddles.Add(new Paddle() { Height = height, Width = width, Style = style, Speed = speed, CurrentPosition = currentPosition, PaddleMovment = paddleMovment });

        //    if (active)
        //        Active = Paddles.FirstOrDefault(p => p.Height.Equals(height) && p.Width.Equals(width) && p.Speed.Equals(speed) && p.Style.Equals(style) && p.CurrentPosition.Equals(currentPosition));
        //}

        public void AddBall(int radius, int speed, string style, Point currentPosition, Point nextPosition, Point previousPosition = null)
        {
            Balls.Add(new Ball() { Radius = radius, Speed = speed, Style = style, CurrentPosition = currentPosition, NextPosition = nextPosition, PreviousPosition = previousPosition });
        }

        public void MovePaddleLeft()
        {
            var pos = Active.Paddles.First().GetNextLeftPoint();

            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;

        }
        public void MovePaddleRight()
        {
            var pos = Active.Paddles.First().GetNextRightPoint();
            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
        }

        public void MovePaddleUp()
        {
            var pos = Active.Paddles.First().GetNextUpPoint();
            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
        }
        public void MovePaddleDown()
        {
            var pos = Active.Paddles.First().GetNextDownPoint();
            if (IsOnScreen(pos))
                Active.Paddles.First().CurrentPosition = pos;
        }

        private bool IsOnScreen(Point pos)
        {
            if (pos.X <= 0 || pos.X + Active.Paddles.First().Width >= Width)
                return false;
            if (pos.Y <= 0 || pos.Y + Active.Paddles.First().Height >= Height)
                return false;


            return true;
        }
    }
}
