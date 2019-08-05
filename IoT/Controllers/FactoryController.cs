using IoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IoT.Controllers
{
    public class FactoryController : Controller
    {
        // GET: Factory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Devices()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }
        //[HttpGet]
        //public JsonResult LoadData1()
        //{
        //    IoTDbContext db = new IoTDbContext();
                 
        //    var startTime = DateTime.Now.Date + new TimeSpan(07, 30, 00);
        //    var endTime = DateTime.Now.Date + new TimeSpan(18, 00, 00);

        //    var CurrentDay = DateTime.Now.Date;
        //    var query = db.DisplayDatas.Where(x=>x.CreateTime == CurrentDay).FirstOrDefault();

        //    var model = db.CycleTimes
        //       .Where(x => x.TimeRevCycleTime >= startTime && x.TimeRevCycleTime <= endTime).ToList();

        //    var totalTime = model.Sum(x => x.RealTimeCycleTime) / 1000;

        //    CycleTimeViewModel cycleTimeVM = new CycleTimeViewModel();
                                                                                                                                                                                    
        //    cycleTimeVM.AverageTimeCycleTime = Math.Round((totalTime / model.Count()).Value, 3);
        //    cycleTimeVM.Availability = Math.Round((model.OrderByDescending(x => x.TimeRevCycleTime).ToList()[0].RealTimeCycleTime).Value/1000,3);

        //    string json = JsonConvert.SerializeObject(cycleTimeVM);

        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public JsonResult LoadData()
        {
            IoTDbContext db = new IoTDbContext();

            var startTime = DateTime.Now.Date + new TimeSpan(07, 30, 00);
            var endTime = DateTime.Now.Date + new TimeSpan(18, 00, 00);

            var CurrentDay = DateTime.Now.Date;
            var query = db.DisplayDatas.Where(x => x.CreateTime == CurrentDay).FirstOrDefault();

            var model = db.CycleTimes
               .Where(x => x.TimeRevCycleTime >= startTime && x.TimeRevCycleTime <= endTime).ToList();
            TimeSpan totalCurrent = DateTime.Now - startTime;

            decimal TotalHours = Convert.ToDecimal(totalCurrent.TotalHours);

            CycleTimeViewModel cycleTimeVM = new CycleTimeViewModel();
            cycleTimeVM.AverageTimeCycleTime = Math.Round((query.TotalTime / query.Count)/1000, 3);
            cycleTimeVM.Availability = Math.Round((Convert.ToDecimal((query.TotalTime/3600000))/ TotalHours) *100, 3);
            cycleTimeVM.MinRealTime = Math.Round(query.MinRealTime/ 1000,3);
            cycleTimeVM.RealTimeCycleTime = Math.Round(query.RealTime / 1000, 3);

            string json = JsonConvert.SerializeObject(cycleTimeVM);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}