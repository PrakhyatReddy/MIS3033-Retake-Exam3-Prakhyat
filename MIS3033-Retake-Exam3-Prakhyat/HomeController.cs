using Microsoft.AspNetCore.Mvc;
using MIS3033_Retake_Exam3_Prakhyat.Data;

namespace MIS3033_Retake_Exam3_Prakhyat
{
    public class ChartsController : Controller
    {
        DbCon1 db= new DbCon1();
        public JsonResult getcd(String ID)
        {
            var r = db.Patients.Where(x => x.ID == ID).GroupBy(x => x.BMILevel).Select(s => new { BMILevel = s.Key });
            return Json(r);
        }
        public IActionResult Charts()
        {
            return View();
        }
    }
}
