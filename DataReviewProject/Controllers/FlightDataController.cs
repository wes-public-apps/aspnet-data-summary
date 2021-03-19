// Wesley Murray
// 3/19/2021
// Controller for flight data.

using System.Collections.Generic;
using System.Threading.Tasks;
using DataReviewProject.Models;
using DataReviewProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataReviewProject.Controllers
{
    public class FlightDataController: Controller 
    {
        private readonly FlightDataService _fdService;

        public FlightDataController(FlightDataService service){
            this._fdService=service;
        }
        #region Http Get (Page Generation)
        [HttpGet]
        public async Task<IActionResult> Index(){
            List<FlightData> data = await _fdService.GetAsync();
            data.Add(new FlightData("Test 1"));
            data.Add(new FlightData("Test 2"));
            data.Add(new FlightData("Test 3"));
            return View(data);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }
        #endregion

        #region Http Post (Handle Submissions)
        [HttpPost]
        public ActionResult<CreatedAtRouteResult> Create(FlightData flightData){
            this._fdService.Create(flightData);
            return CreatedAtRoute("GetFlightData",new { id = flightData.Id.ToString() },flightData);
        }
        #endregion
    }
}