using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Games.Client.Model
{

    public class Balldirections
    {
        public const string Plus = "plus";
        public const string Minus = "minus";
        public const string Equal = "equal";
    }

    public class BallModel : ComponentBase
    {


        [Parameter]
        public Point CurrentPosition { get; set; }
        [Parameter]
        public Point PreviousPosition { get; set; }
        [Parameter]
        public Point NextPosition { get; set; }

        [Parameter]
        public int Speed { get; set; }

        [Parameter]
        public int Radius { get; set; }

        [Parameter]
        public string Style { get; set; }

        public string IncreaseX()
        {
            if (PreviousPosition.X == CurrentPosition.X)
                return Balldirections.Equal;
            else if (PreviousPosition.X < CurrentPosition.X)
                return Balldirections.Plus;
            return Balldirections.Minus;
        }

        public string IncreaseY()
        {
            if (PreviousPosition.Y == CurrentPosition.Y)
                return Balldirections.Equal;
            else if (PreviousPosition.Y < CurrentPosition.Y)
                return Balldirections.Plus;
            return Balldirections.Minus;
        }

        public Dictionary<string, Point> GetNextMovement()
        {
            var x = NextPosition.X;
            if (CurrentPosition.X < NextPosition.X)
                x = NextPosition.X + Speed;
            else if (CurrentPosition.X > NextPosition.X)
                x = NextPosition.X - Speed;

            var y = NextPosition.Y;
            if (CurrentPosition.Y < NextPosition.Y)
                y = NextPosition.Y + Speed;
            else if (CurrentPosition.Y > NextPosition.Y)
                y = NextPosition.Y - Speed;

            var results = new Dictionary<string, Point>()
            {
               {"prevous", new Point(CurrentPosition.X, CurrentPosition.Y)},
               {"current", new Point(NextPosition.X, NextPosition.Y)},
               {"next",    new Point(x, y) }
            };

            return results;
        }


        public BallModel()
        {
            Style = "fill:rgb(255,0,0);stroke-width:1;stroke:rgb(0,0,0)";
            Radius = 5;

        }
    }
}
