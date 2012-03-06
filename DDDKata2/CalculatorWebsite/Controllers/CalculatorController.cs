using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDDKata2;

namespace CalculatorWebsite.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add(string input)
        {
            StringCalculator c = new StringCalculator(null);
            int result = c.Add(input);
            return View(new CalculationResult() {Result=result});
        }

    }
    public class CalculationResult
    {
        public int Result { get; set; }
    }
}
