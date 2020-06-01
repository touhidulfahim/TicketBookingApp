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
using TicketBooking.Service.SeatType;

namespace TicketBooking.Web.Controllers
{
    public class SeatTypeController : Controller
    {
        private readonly ISeatTypeService _iSeatTypeService;

        public SeatTypeController(ISeatTypeService iSeatTypeService)
        {
            _iSeatTypeService = iSeatTypeService;
        }
        public ActionResult Index()
        {
            return View(_iSeatTypeService.GetSeatTypeList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatTypeDto seatTypeDto = _iSeatTypeService.GetSeatTypeDetails(id);
            if (seatTypeDto == null)
            {
                return HttpNotFound();
            }
            return View(seatTypeDto);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeatTypeDto seatTypeDto)
        {
            if (ModelState.IsValid)
            {
                if (!_iSeatTypeService.IsSeatTypeAlreadyExists(seatTypeDto))
                {
                    _iSeatTypeService.InsertSeatType(seatTypeDto);
                    _iSeatTypeService.SaveSeatType();
                    return RedirectToAction("Index");
                }
            }
            return View(seatTypeDto);
        }
        

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatTypeDto seatTypeDto = _iSeatTypeService.GetSeatTypeDetails(id);
            if (seatTypeDto == null)
            {
                return HttpNotFound();
            }
            return View(seatTypeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeatTypeDto seatTypeDto)
        {
            if (ModelState.IsValid)
            {
                _iSeatTypeService.UpdateSeatType(seatTypeDto);
                _iSeatTypeService.SaveSeatType();
                return RedirectToAction("Index");
            }
            return View(seatTypeDto);
        }

        
    }
}
