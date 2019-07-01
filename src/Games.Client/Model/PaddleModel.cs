using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Games.Client.Model
{
    public class PaddleModel : ComponentBase
    {

        [Parameter]
        public string Location { get; set; }

        internal string Id;
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
        }

        public void SetActive()
        {
            Style = "fill:rgb(0,255,0);stroke-width:1;stroke:rgb(0,0,0)";
        }

        public void SetInActive()
        {
            Style = "fill:rgb(0,0,255);stroke-width:1;stroke:rgb(0,0,0)";
        }

        public bool IsPaddleNew(int x, int y)
        {
            //var points = GetAllPoints();

            //if (points.Any(p => p.X.Equals(x) && p.Y.Equals(y)))
            //    return true;

            //return false;

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
            LastMove = DateTime.UtcNow;
            return new Point(CurrentPosition.X - Speed, CurrentPosition.Y);
        }

        public Point GetNextRightPoint()
        {
            LastMove = DateTime.UtcNow;
            return new Point(CurrentPosition.X + Speed, CurrentPosition.Y);
        }

        public Point GetNextUpPoint()
        {
            LastMove = DateTime.UtcNow;
            return new Point(CurrentPosition.X, CurrentPosition.Y - Speed);
        }

        public Point GetNextDownPoint()
        {
            LastMove = DateTime.UtcNow;
            return new Point(CurrentPosition.X, CurrentPosition.Y + Speed);
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
