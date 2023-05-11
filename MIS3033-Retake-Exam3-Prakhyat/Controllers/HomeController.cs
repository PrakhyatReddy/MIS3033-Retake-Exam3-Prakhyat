using Microsoft.AspNetCore.Mvc;
using MIS3033_Retake_Exam3_Prakhyat.Data;
using MIS3033_Retake_Exam3_Prakhyat.Models;

namespace MIS3033_Retake_Exam3_Prakhyat.Controllers
{
    public class HomeController : Controller
    {
        DbCon1 db = new DbCon1();
        //del
        public JsonResult delO(string ID)
        {
            if (ID == null || ID == "")
            {
                return Json(new { status = "fail", mes = "Patient ID is empty or null!" });
            }

            Patient pt = db.Patients.Where(x => x.ID == ID).FirstOrDefault();
            if (pt == null)
            {
                return Json(new { status = "fail", mes = "Patient ID does not exist!" });
            }

            db.Patients.Remove(pt);
            db.SaveChanges();

            return Json(new { status = "success", mes = "Patient Deleted!" });
        }

        //edit
        public JsonResult editO(string ID, string name, int age, double weight, double BMI)
        {
            if (ID == null || ID == "")
            {
                return Json(new { status = "fail", mes = "Patient ID is empty or null!" });
            }

            Patient pt = db.Patients.Where(x => x.ID == ID).FirstOrDefault();
            if (pt == null)
            {
                return Json(new { status = "fail", mes = "Patient ID does not exist!" });
            }


            pt.name = name;
            pt.age = age;
            pt.weight = weight;
            pt.BMI = BMI;
            pt.GetBMILevel(BMI);

            db.SaveChanges();

            return Json(new { status = "success", mes = "Patient info updated!" });
        }

        //add
        public JsonResult addO(string ID, string name, int age, double weight, double BMI)
        {
            if(ID==null|| ID=="")
            {
                return Json(new { status = "fail", mes = "Patient ID is empty or null!" });
            }

            Patient pt = db.Patients.Where(x=>x.ID==ID).FirstOrDefault();
            if(pt!=null)
            {
                return Json(new { status = "fail", mes = "Patient ID already exists!" });
            }

            pt=new Patient();
            pt.ID = ID;
            pt.name = name;
            pt.age = age;   
            pt.weight = weight;
            pt.BMI = BMI;
            pt.GetBMILevel(BMI);

            db.Patients.Add(pt);
            db.SaveChanges();

            return Json(new { status = "success", mes = "New patient added!" });
        }

        //db 
        public JsonResult getO()
        {
            var r = db.Patients;
            return Json(r);
        }

        //view for patient
        public IActionResult Index()
        {
            return View();
        }

        //view for chart
        public IActionResult Charts()
        {
            return View();
        }
    }
}
