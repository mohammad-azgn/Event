using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Event.Models;
using Event.ViewModels;
using Microsoft.AspNet.Identity;

namespace Event.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var user = _context.Users.Find(User.Identity.GetUserId());


            var viewModel = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                NationalId = user.NationalId,
                PhoneNumber = user.PhoneNumber,
                Image = user.Image,
                UserEvents = _context.UserEvents.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProfileViewModel profileViewModel)
        {
            if (profileViewModel.HttpPostedFileBase == null)
                return RedirectToAction("Index");

            var user = _context.Users.Find(User.Identity.GetUserId());

            var extension = Path.GetFileName(profileViewModel.HttpPostedFileBase.FileName);
            var fileName = DateTime.Now.ToString("yyMMddmmssfff");
            var filePath = Path.Combine(Server.MapPath("/Image/Profile"), fileName + extension);

            profileViewModel.HttpPostedFileBase.SaveAs(filePath);

            user.Image = "/Image/Profile/" + fileName + extension;
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public ActionResult Participation(int id)
        {
            var userEvent = new UserEvent
            {
                EventId = id,
                ApplicationUserId = _context.Users.Find(User.Identity.GetUserId()).Id,
                Request = Models.Request.None
            };

            _context.UserEvents.Add(userEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Allow(string userId, string eventId)
        {
            var userEvent = _context.UserEvents.Find(userId, int.Parse(eventId));
            userEvent.Request = Models.Request.Allow;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(string userId, string eventId)
        {
            var userEvent = _context.UserEvents.Find(userId, int.Parse(eventId));
            userEvent.Request = Models.Request.Deny;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}