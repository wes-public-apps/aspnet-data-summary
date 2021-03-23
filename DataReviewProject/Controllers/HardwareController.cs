using System.Threading.Tasks;
using DataReviewProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataReviewProject.Models.HardwareModels;
using DataReviewProject.Views.Hardware;

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
        public async Task<IActionResult> CreateAsync(FormCollection form){
            Hardware temp = null;
            switch(form[CreateViewKeyStrings.Type]){
                case HardwareTypes.NumericSensor:
                    temp=new NumericSensor(new MetaData(form[CreateViewKeyStrings.Name],form[CreateViewKeyStrings.Description]));
                    break;
                default:
                    temp = null;
                    break;
            }
            await this._hdService.CreateHardwareAsync(temp);
            return View();
        }
        #endregion


    }
}