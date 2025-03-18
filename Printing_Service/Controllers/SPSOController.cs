using Microsoft.AspNetCore.Mvc;
using Printing_Service.Data;

namespace Printing_Service.Controllers
{
    public class SPSOController : Controller
    {
        private readonly StudentData _dataAccess;
        public SPSOController(StudentData dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IActionResult History()
        {
            var SumPrint = _dataAccess.GetPrint();
            return View(SumPrint);
        }
        public IActionResult MainPageSPSO()
        {
            var SumPrint = _dataAccess.GetPrint();
            return View(SumPrint);
        }
        public IActionResult EditPrinter()
        {
            var Printer = _dataAccess.GetPrinter();
            return View(Printer);
        }

    }
}
