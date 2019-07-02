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
        public PaddleOptons PaddleScore { get; set; }

       
    }
}
