using System.Threading.Tasks;
using DataReviewProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataReviewProject.Views.Hardware;
using DataReviewProject.Utils.Factories;
using DataReviewProject.Utils.Types;
using DataReviewProject.Models.MetaDataModels;
using System;
using DataReviewProject.Views.ViewModels;

namespace DataReviewProject.Controllers
{
    public class HardwareController : Controller
    {
        private readonly UAVDataService _hdService;

        public HardwareController(UAVDataService service){
            this._hdService=service;
        }
        
        #region Http Get (Page Generation)
        [HttpGet]
        public async Task<IActionResult> Index(){
            return View(await _hdService.GetHardwareAsync());
        }

        [HttpGet]
        public IActionResult CreateSensor(){
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSensorGroup(){
            return View(new SensorGroupViewModel(){
                Hardware = (await this._hdService.GetHardwareAsync()).ConvertAll(hardware => new CheckableItem<HardwareMetaData>(hardware))
            });
        }
        #endregion

        #region Http Post (Handle Submissions)
        [HttpPost]
        public async Task<IActionResult> CreateSensor(SensorMetaData smd){       
            await this._hdService.CreateHardwareAsync(smd);
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSensorGroup(SensorGroupViewModel sgvm){
            Console.WriteLine(sgvm.SensorGroupMetaData);
            Console.WriteLine(sgvm.Hardware);
            sgvm.SensorGroupMetaData.Sensors = sgvm.Hardware.FindAll(checkableItem => checkableItem.IsChecked)
                .ConvertAll(checkableItem => checkableItem.Item);
            await this._hdService.CreateHardwareAsync(sgvm.SensorGroupMetaData);
            ModelState.Clear();
            return View(new SensorGroupViewModel(){
                Hardware = (await this._hdService.GetHardwareAsync()).ConvertAll(hardware => new CheckableItem<HardwareMetaData>(hardware))
            });
        }
        #endregion


    }
}