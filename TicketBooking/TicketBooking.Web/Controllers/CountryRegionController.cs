using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketBooking.Data.Gateway;
using TicketBooking.Domain.DTO;
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
            ViewBag.Module = "Region";
            ViewBag.Page = "Index";
            return View(_iCountryRegionService.GetAllCountryRegion());
        }

        public ActionResult Details(int id)
        {
            ViewBag.Module = "Region";
            ViewBag.Page = "Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRegionDto countryRegionDto = _iCountryRegionService.GetDetailById(id);
            if (countryRegionDto == null)
            {
                return HttpNotFound();
            }
            return View(countryRegionDto);
        }

        
        public ActionResult Create()
        {
            ViewBag.Module = "Region";
            ViewBag.Page = "Create";
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryRegionDto countryRegionDto)
        {
            if (ModelState.IsValid)
            {
                _iCountryRegionService.Insert(countryRegionDto);
                _iCountryRegionService.SaveCountryRegion();
                return RedirectToAction("Index");
            }

            return View(countryRegionDto);
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.Module = "Region";
            ViewBag.Page = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRegionDto countryRegionDto = _iCountryRegionService.GetDetailById(id);
            if (countryRegionDto == null)
            {
                return HttpNotFound();
            }
            return View(countryRegionDto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryRegionDto countryRegionDto)
        {
            if (ModelState.IsValid)
            {
                _iCountryRegionService.Update(countryRegionDto);
                _iCountryRegionService.SaveCountryRegion();
                return RedirectToAction("Index");
            }
            return View(countryRegionDto);
        }

       
    }
}
