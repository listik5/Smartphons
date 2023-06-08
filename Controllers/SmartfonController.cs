using Microsoft.AspNetCore.Mvc;
using Smartphons.Models;

namespace Smartphons.Controllers
{
    public class SmartfonController : Controller
    {
        private readonly SmartfonsContext _smartfonsContext;

        public SmartfonController(SmartfonsContext smartfonsContext)
        {
            _smartfonsContext = smartfonsContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Smartfon> smartfons = _smartfonsContext.Smartfons.ToList();
            return View(smartfons);
        }

        [HttpGet]
        public IActionResult Adding()
        {
            ViewData["error"] = "";
            ViewData["hasError1"] = "0";
            ViewData["hasError"] = "0";
            return View();
        }

        [HttpPost]
        public IActionResult Adding(string name, string brend, string price, string diam, string ozy, string chast)
        {
            try
            {
                double d_price = Double.Parse(price);
                double d_diam = Double.Parse(diam);
                double d_ozy = Double.Parse(ozy);
                double d_chast = Double.Parse(chast);
                if(d_price < 0 || d_diam < 0 || d_ozy < 0 || d_chast < 0)
                {
                    ViewData["error"] = "Проверьте, что ввели все числа положительные!";
                    ViewData["hasError1"] = "1";
                    ViewData["hasError"] = "0";
                    return View();
                }
                Smartfon smartfon = new Smartfon { SName = name, Price = Double.Parse(price), Brend = brend, Diam = Double.Parse(diam), Ozy = Double.Parse(ozy), Chast = Double.Parse(chast) };
                _smartfonsContext.Smartfons.Add(smartfon);
                _smartfonsContext.SaveChanges();
                return RedirectPermanent("~/Smartfon");
            }
            catch
            {
                ViewData["error"] = "Проверьте, что ввели все числа верно!";
                ViewData["hasError"] = "1";
                ViewData["hasError1"] = "0";
                return View();
            }            
        }

        [HttpGet]
        public IActionResult Deleteview(string name)
        {
            ViewData["name"] = name;
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            Smartfon smartfon = _smartfonsContext.Smartfons.Where(smartfon => smartfon.SName == name).Single<Smartfon>();
            _smartfonsContext.Smartfons.Remove(smartfon);
            _smartfonsContext.SaveChanges();
            return RedirectPermanent("~/Smartfon");
        }

        [HttpGet]
        public IActionResult Editview(string name)
        {
            ViewData["name"] = name;
            Smartfon smartfon = _smartfonsContext.Smartfons.Where(smartfon => smartfon.SName == name).Single<Smartfon>();
            return View(smartfon);
        }

        [HttpPost]
        public IActionResult Editview(string sname, string name, string brend, string price, string diam, string ozy, string chast)
        {
            Smartfon smartfon = _smartfonsContext.Smartfons.Where(smartfon => smartfon.SName == sname).Single<Smartfon>();
            _smartfonsContext.Smartfons.Remove(smartfon);
            Smartfon smartfon1 = new Smartfon { SName = name, Price = Double.Parse(price), Brend = brend, Diam = Double.Parse(diam), Ozy = Double.Parse(ozy), Chast = Double.Parse(chast) };
            _smartfonsContext.Smartfons.Add(smartfon1);
            _smartfonsContext.SaveChanges();
            return RedirectPermanent("~/Smartfon");
        }
    }
}
