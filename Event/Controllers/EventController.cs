using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Event.Models;
using Event.ViewModels;

namespace Event.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }


        [AllowAnonymous]
        public ActionResult Index(int id)
        {
            var eventDetails = _context.Events.Find(id);

            if (eventDetails == null)
                return HttpNotFound();

            return View(eventDetails);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EventViewModel eventViewModel)
        {
            if (eventViewModel.Id == 0)
            {
                var events = new Models.Event
                {
                    Name = eventViewModel.Name,
                    Description = eventViewModel.Description,
                    StartTime = eventViewModel.StartTime,
                    FinishTime = eventViewModel.FinishTime,
                    Location = eventViewModel.Location
                };


                CalculateAddress(eventViewModel, events);
                _context.Events.Add(events);
            }

//.......................................................Update post
            else
            {
                var eventUpdate = _context.Events.Single(c => c.Id == eventViewModel.Id);

                eventUpdate.Name = eventViewModel.Name;
                eventUpdate.Description = eventViewModel.Description;
                eventUpdate.StartTime = eventViewModel.StartTime;
                eventUpdate.FinishTime = eventViewModel.FinishTime;
                eventUpdate.Location = eventViewModel.Location;

                CalculateAddress(eventViewModel, eventUpdate);
            }


            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Edit(int id)
        {
            var events = _context.Events.SingleOrDefault(c => c.Id == id);
            if (events == null)
                return HttpNotFound();

            var eventViewModel = new EventViewModel
            {
                Name = events.Name,
                Description = events.Description,
                StartTime = events.StartTime,
                FinishTime = events.FinishTime,
                Location = events.Location
            };

            return View("Create", eventViewModel);
        }

        public ActionResult Delete(int id)
        {
            var events = _context.Events.SingleOrDefault(c => c.Id == id);
            var fileName = events.Pictures.Substring(14);

            var filePath = Path.Combine(Server.MapPath("/Image/Events"), fileName);

            System.IO.File.Delete(filePath);

            _context.Events.Remove(events);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        private void CalculateAddress(EventViewModel eventViewModel, Models.Event events)
        {
            var extension = Path.GetFileName(eventViewModel.HttpPictures.FileName);
            var fileName = DateTime.Now.ToString("yyMMddmmssfff");
            var filePath = Path.Combine(Server.MapPath("/Image/Events"), fileName + extension);

            eventViewModel.HttpPictures.SaveAs(filePath);
            events.Pictures = "/Image/Events/" + fileName + extension;


            extension = Path.GetFileName(eventViewModel.HttpOrganizers.FileName);
            fileName = DateTime.Now.ToString("yyMMddmmssfff");
            filePath = Path.Combine(Server.MapPath("/Image/Organizers"), fileName + extension);

            eventViewModel.HttpOrganizers.SaveAs(filePath);
            events.Organizers = "/Image/Organizers/" + fileName + extension;


            extension = Path.GetFileName(eventViewModel.HttpSponsor.FileName);
            fileName = DateTime.Now.ToString("yyMMddmmssfff");
            filePath = Path.Combine(Server.MapPath("/Image/Sponsor"), fileName + extension);

            eventViewModel.HttpSponsor.SaveAs(filePath);
            events.Sponsor = "/Image/Sponsor/" + fileName + extension;
        }
    }
}