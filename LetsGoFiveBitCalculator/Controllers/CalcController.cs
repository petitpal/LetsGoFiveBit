using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsGoFiveBitCalculator.Services;
using LetsGoFiveBit;

namespace LetsGoFiveBitCalculator.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSupportedBases()
        {
            return Json(CalculatorServices.AvailableNumberBases(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetValidDigitsForBase(int numberBase)
        {
            return Json(CalculatorServices.GetValidDigitsForBase(numberBase), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Calculate(char operation, string firstNumber, int firstBase, string secondNumber, int secondBase)
        {
            BasedNumber firstNum = new BasedNumber(firstBase, firstNumber);
            BasedNumber secondNum = new BasedNumber(secondBase, secondNumber);

            switch (operation)
            {
                case '+': return Json((firstNum + secondNum).ToString(), JsonRequestBehavior.AllowGet);
                case '-': return Json((firstNum - secondNum).ToString(), JsonRequestBehavior.AllowGet);
                case '/': return Json((firstNum / secondNum).ToString(), JsonRequestBehavior.AllowGet);
                case '*': return Json((firstNum * secondNum).ToString(), JsonRequestBehavior.AllowGet);
                default: return Json("", JsonRequestBehavior.AllowGet);
            }

        }
    }
}