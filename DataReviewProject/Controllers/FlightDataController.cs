// Wesley Murray
// 3/19/2021
// Controller for flight data.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataReviewProject.Models.Data;
using DataReviewProject.Models.DataFrameModels;
using DataReviewProject.Models.MetaDataModels;
using DataReviewProject.Models.SensorDataModels;
using DataReviewProject.Services;
using DataReviewProject.Utils.Types;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        [HttpGet]
        [Route("Review/{id}")]
        public async Task<IActionResult> Review(string id){
            return View(await this._fdService.GetFlightDataAsync(id));
        }
        #endregion

        #region Http Post (Handle Submissions)
        [HttpPost]
        public async Task<IActionResult> CreateAsync(FlightData flightData){
            await this._fdService.CreateFlightDataAsync(flightData);
            return View();
        }
        #endregion

        public async Task<IActionResult> GenerateMockData(){
            Random rand=new Random();
            List<HardwareMetaData> hardware= await this._fdService.GetHardwareAsync();
            List<SensorData> data = new List<SensorData>();
            foreach(HardwareMetaData item in hardware){
                if(item.GetType().Equals(typeof(SensorMetaData))){
                    var temp=(SensorMetaData) item;
                    switch(temp.Type){
                        case SensorTypes.Temperature:
                            data.Add(this.GenerateTempSensorData(rand.Next(80,140),4,0,0.2));
                            break;
                        case SensorTypes.Position:
                            data.Add(this.GeneratePositionSensorData(2,0,0.2));
                            break;
                        default:
                            Console.WriteLine("SensorData class for sensor of type "+SensorTypesToDisplayString.Map[temp.Type]+" not supported.");
                            break;
                    }
                }
            }
            await this._fdService.CreateFlightDataAsync(new FlightData(data));
            return View();
        }

        private TemperatureSensorData GenerateTempSensorData(int baseTemp,int err,int start,double step){
            Random rand=new Random();
            List<PeriodicNumericDataFrame<double>> tempData = new List<PeriodicNumericDataFrame<double>>();
            for(int i=0;i<100;i++){
                tempData.Add(new PeriodicNumericDataFrame<double>(baseTemp+rand.Next(-err,err+1),err));
            }
            return new TemperatureSensorData(TimeUnits.Seconds,TemperatureUnits.F,start,step,tempData);
        }

        private PositionSensorData GeneratePositionSensorData(int err,int start,double step){
            Random rand=new Random();
            double x=0,y=0,z=0;
            List<CartesianPositionDataFrame> posData = new List<CartesianPositionDataFrame>();
            for(int i=0;i<100;i++){
                posData.Add(new CartesianPositionDataFrame(x,err,y,err,z,err));
                x+=rand.Next(-2,2);
                y+=rand.Next(-2,2);
                z+=rand.Next(-2,2);
            }
            return new PositionSensorData(start,step,posData);
        }
    }
}