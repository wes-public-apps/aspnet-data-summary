// Wesley Murray
// 3/19/2021
// Controller for flight data.

using System.Collections.Generic;
using System.Threading.Tasks;
using DataReviewProject.Models.Data;
using DataReviewProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataReviewProject.Controllers
{
    public class FlightDataController: Controller 
    {
        private readonly UAVDataService _fdService;

        public FlightDataController(UAVDataService service){
            this._fdService=service;
        }

        #region Http Get (Page Generation)
        [HttpGet]
        public async Task<IActionResult> Index(){
            List<FlightData> data = await _fdService.GetFlightDataAsync();
            data.Add(new FlightData());
            data.Add(new FlightData());
            data.Add(new FlightData());
            return View(data);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }
        #endregion

        #region Http Post (Handle Submissions)
        [HttpPost]
        public async Task<IActionResult> CreateAsync(FlightData flightData){
            await this._fdService.CreateFlightDataAsync(flightData);
            // return CreatedAtRoute("GetFlightData",new { id = flightData.Id.ToString() },flightData);
            return View();
        }
        #endregion
    }
}