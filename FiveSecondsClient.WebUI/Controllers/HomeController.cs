using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using FiveSecondsClient.WebUI.Models;
using FiveSecondsClient.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FiveSecondsClient.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult SetPlayer() => View();

        [HttpPost]
        public IActionResult SetPlayer(PlayerCountViewModel model)
        {
            if (ModelState.IsValid)
                return PartialView("_players", model.PlayerCount);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Game(List<string> playersNames)
        {
            var players = new List<Player>();
            foreach (var playerName in playersNames)
            {
                players.Add(new Player { Name = playerName, Score = 0} );
            }

            return View(players);
        } 

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionViewModel model)
        {
            if (ModelState.IsValid)
               await SendQuestionToApi(model.Question);

            return RedirectToAction("Index");
        }

        public IActionResult Get()
        {
            var model = GetRandomQuestionFromApi().Result;

            return PartialView("_questionCard", model );
        }

        private async Task<Uri> SendQuestionToApi(string question)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:51371/") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Question", question);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public async Task<string> GetRandomQuestionFromApi()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:51371/api/Question") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}