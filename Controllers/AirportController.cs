using Airport_Project.Model;
using Airport_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Airport_Project.Controllers
{
    public class AirportController : Controller
    {
        private readonly IMethods context;
        // GET: AirportController
        public AirportController(IMethods context)
        {
            this.context = context;

        }
        public ActionResult Index1()
        {
            List<city> fs = context.GetAllCities();
            return View(fs);
        }


        // GET: AirportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AirportController/Create
        

        // POST: AirportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection FormCollection)
        {
            try
            {
                string From = FormCollection["From"].ToString();
                string To = FormCollection["To"].ToString();
                List<airport> k = context.airportsbtwcities(From, To);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AirportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AirportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AirportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AirportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
