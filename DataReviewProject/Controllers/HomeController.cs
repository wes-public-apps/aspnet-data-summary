using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataReviewProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DataReviewProject.Services;

namespace DataReviewProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UAVDataService _fdService;

        public HomeController(UAVDataService service){
            this._fdService=service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fdService.GetUavAsync());
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Http Post (Handle Submissions)
        [HttpPost]
        public async Task<IActionResult> Create(UAV uav){
            await this._fdService.CreateUavAsync(uav);
            ModelState.Clear();
            return View();
        }
        #endregion
    }
}