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
            ViewBag.Module = "Country";
            ViewBag.Page = "Index";
            var countryList = _iCountryService.GetCountryList();
            return View(countryList.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Module = "Country";
            ViewBag.Page = "Details";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryDto countryDto = _iCountryService.GetCountryDetails(id);
            if (countryDto == null)
            {
                return HttpNotFound();
            }
            return View(countryDto);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            ViewBag.Module = "Country";
            ViewBag.Page = "Create";
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                if (!_iCountryService.IsAlreadyExists(countryDto))
                {
                    _iCountryService.Insert(countryDto);
                    _iCountryService.SaveCountry();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("","Country info already exists...");
            }
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View(countryDto);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Module = "Country";
            ViewBag.Page = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryDto countryDto = _iCountryService.GetCountryDetails(id);
            if (countryDto == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View(countryDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                _iCountryService.Update(countryDto);
                _iCountryService.SaveCountry();
                return RedirectToAction("Index");
            }
            ViewBag.RegionList = _iCountryRegionService.GetAllCountryRegion();
            return View(countryDto);
        }
    }
}
