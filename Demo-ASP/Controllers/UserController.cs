using Demo_ASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol.Plugins;
using System.Text;
using System.Text.RegularExpressions;

namespace Demo_ASP.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserCreateForm form)
        {
            ValidatePassword(form, ModelState);
            if (!ModelState.IsValid) return View(form);
            return RedirectToAction("Details", new { id = 1 });
        }

        private void ValidatePassword(UserCreateForm form, ModelStateDictionary modelState)
        {
            if (form.Password is null)
            {
                modelState.AddModelError(nameof(UserCreateForm.Password), "Le mot de passe ne peut être null...");
                return;
            }
            if (!Regex.IsMatch(form.Password, "[0-9]"))
                modelState.AddModelError(nameof(UserCreateForm.Password), "Il faut au minimum un chiffre");
            if (!Regex.IsMatch(form.Password, "[a-z]"))
                modelState.AddModelError(nameof(UserCreateForm.Password), "Il faut au minimum une minuscule");
            if (!Regex.IsMatch(form.Password, "[A-Z]"))
                modelState.AddModelError(nameof(UserCreateForm.Password), "Il faut au minimum une majuscule");
            if (!Regex.IsMatch(form.Password, @"[\-\.=+*@?]"))
                modelState.AddModelError(nameof(UserCreateForm.Password), "Il faut au minimum un caratère spécial");

        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
