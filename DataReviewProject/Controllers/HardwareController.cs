using System.Threading.Tasks;
using DataReviewProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataReviewProject.Views.Hardware;
using DataReviewProject.Utils.Factories;
using DataReviewProject.Utils.Types;
using DataReviewProject.Models.MetaDataModels;
using System;

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
        public IActionResult Create(){
            return View();
        }
        #endregion

        #region Http Post (Handle Submissions)
        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection form){
            HardwareMetaData temp = HardwareMetaDataFactory.GetMetaData(
                (HardwareTypes) Enum.Parse(typeof(HardwareTypes), form[CreateViewKeyStrings.HardwareType]),
                form[CreateViewKeyStrings.Id],
                (StatusTypes) Enum.Parse(typeof(StatusTypes), form[CreateViewKeyStrings.StatusType]),
                form[CreateViewKeyStrings.Name],
                form[CreateViewKeyStrings.Description],
                null
            );           
            if(temp!=null) await this._hdService.CreateHardwareAsync(temp);
            return View();
        }
        #endregion


    }
}