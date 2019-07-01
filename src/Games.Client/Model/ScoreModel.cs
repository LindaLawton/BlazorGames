using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Games.Client.Model
{
    public class ScoreModel : ComponentBase
    {
        [Parameter]
        public int Left { get; set; }
        [Parameter]
        public int Right { get; set; }

    }
}
