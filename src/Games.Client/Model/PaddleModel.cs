using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Games.Client.Model
{

    public class PaddleMovment
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public PaddleMovment(bool up, bool down, bool left, bool right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }

        public static PaddleMovment PaddleMovmentHorizontal()
        {
            return new PaddleMovment(false, false, true, true);
        }

        public static PaddleMovment PaddleMovmentVirtical()
        {
            return new PaddleMovment(true, true, false, false);
        }

        public static PaddleMovment PaddleMovmentAll()
        {
            return new PaddleMovment(true, true, true, true);
        }

    }

    public class PaddleOptons
    {
        public bool Top { get; set; }
        public bool Bottom { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public PaddleOptons(bool top, bool bottom, bool left, bool right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }
    }



    public class PaddleModel : ComponentBase
    {

        [Parameter]
        public string Location { get; set; }

        
        [Parameter]
        public Point CurrentPosition { get; set; }

        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public int Speed { get; set; }

        [Parameter]
        public PaddleMovment PaddleMovment { get; set; }

        [Parameter]
        public PaddleOptons PaddleOutOfBounds { get; set; }

        

        private DateTime LastMove;


        private List<Point> GetAllPoints()
        {
            var result = new List<Point>();

            for (int x = CurrentPosition.X; x <= CurrentPosition.X + Width; x++)
            {
                for (int y = CurrentPosition.Y; y <= CurrentPosition.Y + Height; y++)
                {
                    result.Add(new Point(x, y));
                }
            }
            return result;
        }



        public PaddleModel()
        {
            Height = 100;
            Width = 25;
            Style = "fill:rgb(0,0,255);stroke-width:1;stroke:rgb(0,0,0)";
            Speed = 5;
            LastMove = DateTime.UtcNow;
            PaddleMovment = PaddleMovment.PaddleMovmentAll();
            PaddleOutOfBounds = new PaddleOptons(false, false, false, false);
           
        }

        public void SetActive()
        {
            Style = "fill:rgb(0,255,0);stroke-width:1;stroke:rgb(0,0,0)";
        }

        public void SetInActive()
        {
            Style = "fill:rgb(0,0,255);stroke-width:1;stroke:rgb(0,0,0)";
        }

        public bool IsPaddleNew(int x, int y)  //TODO change this to point
        {
            var myObject = CurrentPosition;
            var width = Width;
            var height = Height;

            var testPos = new Point(x, y);

            if (((myObject.X <= testPos.X) && (myObject.X + width >= testPos.X) && (myObject.Y <= testPos.Y) && (myObject.Y + height >= testPos.Y)))
            {
                return true;
            }

            return false;
        }


        public bool IsPaddle(int pos, int y)
        {

            //if (pos.X == CurrentPosition.X)
            //    return true;

            if ((Location == "Left" && pos <= CurrentPosition.X + Width))
            {

                if (CurrentPosition.Y <= y && CurrentPosition.Y + Height >= y)
                    return true;

                return false;
            }


            if (Location == "Right" && pos >= CurrentPosition.X)
            {

                if (CurrentPosition.Y <= y && CurrentPosition.Y + Height >= y)
                    return true;

                return false;
            }

            return false;

        }

        public Point GetNextLeftPoint()
        {
            if (PaddleMovment.Left)
            {

                LastMove = DateTime.UtcNow;
                return new Point(CurrentPosition.X - Speed, CurrentPosition.Y);
            }

            return new Point(CurrentPosition.X, CurrentPosition.Y);
        }

        public Point GetNextRightPoint()
        {
            if (PaddleMovment.Right)
            {
                LastMove = DateTime.UtcNow;
                return new Point(CurrentPosition.X + Speed, CurrentPosition.Y);
            }

            return new Point(CurrentPosition.X, CurrentPosition.Y);
        }

        public Point GetNextUpPoint()
        {
            if (PaddleMovment.Up)
            {
                LastMove = DateTime.UtcNow;
                return new Point(CurrentPosition.X, CurrentPosition.Y - Speed);
            }

            return new Point(CurrentPosition.X, CurrentPosition.Y);
        }

        public Point GetNextDownPoint()
        {
            if (PaddleMovment.Down)
            {
                LastMove = DateTime.UtcNow;
                return new Point(CurrentPosition.X, CurrentPosition.Y + Speed);
            }
            return new Point(CurrentPosition.X, CurrentPosition.Y);
        }

        public bool IsMoving()
        {

            var total = (DateTime.UtcNow - LastMove).TotalMilliseconds;
            if ((DateTime.UtcNow - LastMove).TotalMilliseconds < 100)
                return true;

            return false;
        }


        

    }
}
