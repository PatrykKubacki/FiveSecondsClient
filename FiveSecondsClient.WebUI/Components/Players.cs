using System.Collections.Generic;
using FiveSecondsClient.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiveSecondsClient.WebUI.Components
{
    public class Players : ViewComponent
    {
        public Players() {}

        public IViewComponentResult Invoke(List<Player> players) => View(players);
    }
}
