using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagement.Models;
using ContactManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManagement.Controllers
{
    public class HomeController : Controller
    {
        private IContactRepository _contactRepository;

        // Dependency Injection Used to get the data 
        public HomeController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        // Index method call start of the application
        public IActionResult Index()
        {
            // ViewBag.Title = "Manage Contacts";
            var allcontact = _contactRepository.GetAllContacts();
            if (allcontact != null)
            {
                var contacts = _contactRepository.GetAllContacts().OrderBy(c => c.FisrtName).ToList();               
                var homeViewModel = new HomeViewModel()
                {
                    Title = "Welcome To Contact Management System",
                    Contact = contacts.ToList()
                };

                return View(homeViewModel);
            }

            else
            {
                var homeViewModel = new HomeViewModel()
                {
                    Title = "Welcome To Contact Management System",
                  
                };
                return View(homeViewModel);
            }
                
            
            
        }
        // Insert Get  method is called to navigate ti Insert View for inserting data
        [HttpGet]
        public ActionResult Insert()
        {
            return View(new Contact());
        }
        // Insert method is called on Insert operation to Insert the data
        [HttpPost]
        public ActionResult Insert(Contact contact)
        {
            //check for model state valid state
            if(ModelState.IsValid)
            {
                _contactRepository.Insert(contact);
                var contacts = _contactRepository.GetAllContacts().OrderBy(c => c.FisrtName).ToList();               
                return RedirectToAction("index");
            }

            return View(contact);
        }
        // Update method is called on Update operation which take to update view persisting the current data
        [HttpGet]
        public ActionResult Update(int contactId)
        {
           
            var contacts = _contactRepository.GetAllContacts().Where(c => c.ContactId == contactId).FirstOrDefault();           
            return View(contacts);
        }
        // Update method is called on Update operation to update the data
        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            _contactRepository.Update(contact);
            return RedirectToAction("index");

        }
        // Delete method is called on Delete operation
        public ActionResult Delete(int contactId)
        {
            var contact = _contactRepository.GetAllContacts().FirstOrDefault(x => x.ContactId == contactId);

            _contactRepository.Remove(contact);
            return RedirectToAction("index");

        }
    }
}
