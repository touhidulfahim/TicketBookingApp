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
using TicketBooking.Service.City;
using TicketBooking.Service.Country;

namespace TicketBooking.Web.Controllers
{
    public class CityController : Controller
    {

        private readonly ICityService _iCityService;
        private readonly ICountryService _iCountryService;

        public CityController(ICityService iCityService, ICountryService iCountryService)
        {
            _iCityService = iCityService;
            _iCountryService = iCountryService;
        }


        // GET: City
        public ActionResult Index()
        {
            ViewBag.Module = "City";
            ViewBag.Page = "Index";
            return View(_iCityService.GetCityList());
        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Module = "City";
            ViewBag.Page = "Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityDto cityDto = _iCityService.GetCityDetails(id);
            if (cityDto == null)
            {
                return HttpNotFound();
            }
            return View(cityDto);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.Module = "City";
            ViewBag.Page = "Create";
            ViewBag.CountryList = _iCountryService.GetCountryList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityDto cityDto)
        {
            if (ModelState.IsValid)
            {
                if (!_iCityService.IsAlreadyExists(cityDto))
                {
                    _iCityService.Insert(cityDto);
                    _iCityService.Save();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "City info already exists in this systems...");
            }
            ViewBag.CountryList = _iCountryService.GetCountryList();
            return View(cityDto);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Module = "City";
            ViewBag.Page = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityDto cityDto = _iCityService.GetCityDetails(id);
            if (cityDto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryList = _iCountryService.GetCountryList();
            return View(cityDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityDto cityDto)
        {
            if (ModelState.IsValid)
            {
                _iCityService.Update(cityDto);
                _iCityService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CountryList = _iCountryService.GetCountryList();
            return View(cityDto);
        }


    }
}
