using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShortURLService.Models;

namespace ShortURLService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/{id}")]
        public IActionResult RedirectToService([FromRoute(Name = "id")] string ServiceID)
        {
            List<RedirectInfo> Infos = JsonConvert.DeserializeObject<RedirectInfos>(System.IO.File.ReadAllText("./wwwroot/config/redirect.json"));
            if (!Infos.Exists(r => r.ID == ServiceID)) return Redirect("/error/404");
            return Redirect(Infos.Find(r => r.ID == ServiceID).RedirectURL);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
