using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElevenNote.WebMVC.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;

            //replaces 
            var currentUserId = Guid.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);

            //var userId = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();

            var service = new NoteService(currentUserId);
            var model = service.GetNotes();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoteCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            ClaimsPrincipal currentUser = this.User;
            var currentUserId = Guid.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);

            var service = new NoteService(currentUserId);

            service.CreateNote(model);

            return RedirectToAction("Index");
        }
    }
}
