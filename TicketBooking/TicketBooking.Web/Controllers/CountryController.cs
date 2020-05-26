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
using TicketBooking.Service.Country;
using TicketBooking.Service.CountryRegion;

namespace TicketBooking.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRegionService _iCountryRegionService;
        private readonly ICountryService _iCountryService;

        public CountryController(ICountryRegionService iCountryRegionService, ICountryService iCountryService)
        {
            _iCountryRegionService = iCountryRegionService;
            _iCountryService = iCountryService;
        }

        // GET: Country
        public ActionResult Index()
        {
            var countryList = _iCountryService.GetCountryList();
            return View(countryList.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = _iCountryService.GetCountryDetails(id);
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                if (!_iCountryService.IsAlreadyExists(countryModel))
                {
                    _iCountryService.Insert(countryModel);
                    _iCountryService.SaveCountry();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("","Country info already exists...");
            }
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View(countryModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = _iCountryService.GetCountryDetails(id);
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View(countryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                _iCountryService.Update(countryModel);
                _iCountryService.SaveCountry();
                return RedirectToAction("Index");
            }
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View(countryModel);
        }
    }
}
