using Contacts.Data;
using Contacts.Models;
using Contacts.Services;

namespace Contacts.Controllers
{
    using Contacts.Data.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : Controller
    {
        private readonly ContactsDbContext _context; //Not needed?
        private readonly IContactService _contactService;

        public ContactsController(ContactsDbContext context, IContactService contactService)    
        {
            this._context = context;
            this._contactService = contactService;
        }


        public async Task<IActionResult> All()
        {
            var contacts = await _contactService.GetAllContacts();

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ContactViewModel contact = new ContactViewModel();

            return View(contact);
        }


        [HttpPost]
        public async Task<IActionResult> Add(ContactViewModel contact)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("nevalidno modelche za addwane na contact, bratle ?");
            //}

            await _contactService.AddContactAsync(contact);

            return RedirectToAction("All");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var contactViewModel = await _contactService.FindContactAsync(id);

            return View(contactViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactViewModel contactViewModel)
        {
            await _contactService.EditContactAsync(id, contactViewModel);

            return RedirectToAction("All");
        }


    }
}
