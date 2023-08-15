using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.HUD.Menu
{
    public enum CurrentGameState { Level1, Level2, Menu, Ended }
    public enum CurrentPlayerState { Won, Lost }
    internal interface IGameState
    {
        public CurrentGameState StateOfGame { get; set; }
        public CurrentPlayerState StateOfPlayer { get; set; }
    }
}
