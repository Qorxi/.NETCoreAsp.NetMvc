using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreKnowledge.Models;
using Microsoft.AspNetCore.Mvc;
using CoreKnowledge.Domain.Services.Interfaces;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

namespace CoreKnowledge.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDb;
        private readonly ISeacrhService _search;
        private readonly IHostingEnvironment _host;

        public HomeController(AppDbContext app, ISeacrhService search, IHostingEnvironment host)
        {
            appDb = app;
            _search = search;
            _host = host;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public CoreKnowledge.Models.ViewModels.SearchViewModel SearchAble(string term)
        {
            var res = _search.Search(term);
            return res;
        }
    }
}