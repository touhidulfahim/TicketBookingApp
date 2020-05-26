using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketBooking.Data.Gateway;
using TicketBooking.Domain.Entity;
using TicketBooking.Service.CountryRegion;

namespace TicketBooking.Web.Controllers
{
    public class CountryRegionController : Controller
    {
        private readonly ICountryRegionService _iCountryRegionService;

        public CountryRegionController(ICountryRegionService iCountryRegionService)
        {
            _iCountryRegionService = iCountryRegionService;
        }

        public ActionResult Index()
        {
            return View(_iCountryRegionService.GetAllCountryRegion());
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRegionModels countryRegionModels = _iCountryRegionService.GetDetailById(id);
            if (countryRegionModels == null)
            {
                return HttpNotFound();
            }
            return View(countryRegionModels);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryRegionModels countryRegionModels)
        {
            if (ModelState.IsValid)
            {
                _iCountryRegionService.Insert(countryRegionModels);
                _iCountryRegionService.SaveCountryRegion();
                return RedirectToAction("Index");
            }

            return View(countryRegionModels);
        }
        
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRegionModels countryRegionModels = _iCountryRegionService.GetDetailById(id);
            if (countryRegionModels == null)
            {
                return HttpNotFound();
            }
            return View(countryRegionModels);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryRegionModels countryRegionModels)
        {
            if (ModelState.IsValid)
            {
                _iCountryRegionService.Update(countryRegionModels);
                _iCountryRegionService.SaveCountryRegion();
                return RedirectToAction("Index");
            }
            return View(countryRegionModels);
        }

       
    }
}
