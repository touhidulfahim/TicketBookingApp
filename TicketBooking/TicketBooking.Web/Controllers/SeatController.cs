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
using TicketBooking.Service.Seat;
using TicketBooking.Service.SeatType;

namespace TicketBooking.Web.Controllers
{
    public class SeatController : Controller
    {
        private readonly ISeatService _iSeatService;
        private readonly ISeatTypeService _iSeatTypeService;

        public SeatController(ISeatService iSeatService, ISeatTypeService iSeatTypeService)
        {
            _iSeatService = iSeatService;
            _iSeatTypeService = iSeatTypeService;
        }

        public ActionResult Index()
        {
            ViewBag.Module = "Seat";
            ViewBag.Page = "Index";
            return View(_iSeatService.GetSeatList());
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Module = "Seat";
            ViewBag.Page = "Details";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatDto seatDto = _iSeatService.GetSeatDetails(id);
            if (seatDto == null)
            {
                return HttpNotFound();
            }
            return View(seatDto);
        }
        
        public ActionResult Create()
        {
            ViewBag.Module = "Seat";
            ViewBag.Page = "Create";
            ViewBag.SeatTypeList = _iSeatTypeService.GetSeatTypeList();
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeatDto seatDto)
        {
            
            if (ModelState.IsValid)
            {
                if (!_iSeatService.IsSeatAlreadyExists(seatDto))
                {
                    _iSeatService.InsertSeat(seatDto);
                    _iSeatService.SaveSeat();
                    return RedirectToAction("Index");
                }ModelState.AddModelError("","Already exists...!!");
            }
            ViewBag.SeatTypeList = _iSeatTypeService.GetSeatTypeList();
            return View(seatDto);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Module = "Seat";
            ViewBag.Page = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatDto seatDto = _iSeatService.GetSeatDetails(id);
            if (seatDto == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeatTypeList = _iSeatTypeService.GetSeatTypeList();
            return View(seatDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeatDto seatDto)
        {
            if (ModelState.IsValid)
            {
                _iSeatService.UpdateSeat(seatDto);
                _iSeatService.SaveSeat();
                return RedirectToAction("Index");
            }
            ViewBag.SeatTypeList = _iSeatTypeService.GetSeatTypeList();
            return View(seatDto);
        }
    }
}
