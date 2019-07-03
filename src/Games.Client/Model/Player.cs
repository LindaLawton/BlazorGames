using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Client.Pages;
using Microsoft.AspNetCore.Components;

namespace Games.Client.Model
{
    public class Player : ComponentBase
    {
        
        [Parameter]
        public PaddleOptons PlayerScore { get; set; }

        [Parameter]
        public int Score { get; set; }

        [Parameter]
        public bool IsHuman { get; set; }

        [Parameter]
        public List<Paddle> Paddles { get; set; }

        public static Player InitPlayer(List<Paddle> paddles, PaddleOptons playerScore, bool isHuman = true)
        {
            return new Player()
            {
                IsHuman = isHuman,
                Paddles = paddles,
                Score = 0,
                PlayerScore = playerScore
            };
        }

        public static Player InitSinglePlayer(Paddle paddles, PaddleOptons playerScore, bool isHuman = true)
        {
            return new Player()
            {
                IsHuman = isHuman,
                Paddles = new List<Paddle>() { paddles },
                Score = 0,
                PlayerScore = playerScore
            };

        }
    }
}
