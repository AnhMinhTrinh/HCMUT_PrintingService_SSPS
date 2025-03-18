using Microsoft.AspNetCore.Mvc;
using Printing_Service.Data;
using iTextSharp.text.pdf;
using Printing_Service.Models;
using System.Reflection.PortableExecutable;

namespace Printing_Service.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentData _dataAccess;
        // private readonly int _a;

        private readonly string filename = "Course3.pdf";
        public StudentController(StudentData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MainPage(string ID =null )
        {
            if (ID == null) ID= HttpContext.Session.GetString("ID");
            else HttpContext.Session.SetString("ID", ID);

            var Studenttemp = _dataAccess.GetStudentbyID(ID);
            var Printingtemp = _dataAccess.GetPrinting(ID);
            var viewModel = new StudentLoad
            {
                stu = Studenttemp,
                pri = Printingtemp
            };
            return View(viewModel);
        }
        public IActionResult Profile()
        {
            string ID = HttpContext.Session.GetString("ID");
            var Studenttemp = _dataAccess.GetStudentbyID(ID);
            return View(Studenttemp);
        }
        public IActionResult StudentHistory()
        {
            string ID = HttpContext.Session.GetString("ID");
            var StudentList = _dataAccess.GetPri(ID);
            return View(StudentList);

        }
        public IActionResult BuyPaper()
        {
            string ID = HttpContext.Session.GetString("ID");
            var Studenttemp = _dataAccess.GetSumBuy(ID);
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(Studenttemp);
        }

        [HttpPost]
        public IActionResult BuyPaper(int buypaper)
        {
            string ID = HttpContext.Session.GetString("ID");
            if (ModelState.IsValid)
            {
                _dataAccess.CreateTransaction(buypaper,ID);
                TempData["SuccessMessage"] = "Giao dich thanh cong!";
                return RedirectToAction("BuyPaper");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UploadConfig(string id)
        {
            TempData["ID"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult UploadConfig(Document addPrint)
        {
            string ID = HttpContext.Session.GetString("ID");
            addPrint.Name = filename;
            addPrint.Type = Path.GetExtension(filename);
            //using (PdfReader reader = new PdfReader(filename))
            //{
            addPrint.Page = 80;
            //}
            Console.Write(addPrint.A3page);
            string PID = TempData["ID"].ToString(); 
            _dataAccess.CreatePrint(addPrint, ID, PID);
            TempData["PrintSuccess"] = "In thanh cong!";
            return RedirectToAction("UploadConfig");
        }
        public IActionResult ConfirmConfig()
        {
            ViewBag.Filename = filename;
            return View();
        }

        public IActionResult Upload()
        {
            //string ID = HttpContext.Session.GetString("ID");
            
            return View();
        }

        public IActionResult UploadConfirm()
        {
            var Printer = _dataAccess.GetPrinter();
            return View(Printer);
        }

    }
}
