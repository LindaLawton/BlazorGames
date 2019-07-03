using System;
using System.Threading.Tasks;
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
}
