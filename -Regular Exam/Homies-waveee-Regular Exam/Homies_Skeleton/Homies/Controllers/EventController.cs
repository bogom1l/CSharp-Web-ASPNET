using Homies.Services;
using Homies.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            var events = await this._eventService.GetAllEventsAsync();

            return this.View(events);
        }

        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var events = await this._eventService.GetJoinedEventsAsync(userId);

            return this.View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel addEventViewModel = await _eventService.GetAddEventViewModelAsync();

            return this.View(addEventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel addEventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(addEventViewModel);
            }

            string userId = GetUserId();

            await this._eventService.AddEventAsync(addEventViewModel, userId);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventViewModel = await this._eventService.GetAddEventViewModelByIdAsync(id);

            if (eventViewModel == null)
            {
                return RedirectToAction("All");
            }

            return this.View(eventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddEventViewModel addEventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(addEventViewModel);
            }

            await this._eventService.EditEventAsync(id, addEventViewModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Join(int id)
        {
            var eventViewModel = await this._eventService.GetEventViewModelByIdAsync(id);

            if (eventViewModel == null)
            {
                return RedirectToAction("All");
            }

            string userId = GetUserId();

            if (await this._eventService.AddToJoinedEventsAsync(userId, eventViewModel) == null)
            {
                return this.RedirectToAction("All");
            }

            return this.RedirectToAction("Joined");
        }

        public async Task<IActionResult> Leave(int id)
        {
            var eventViewModel = await this._eventService.GetEventViewModelByIdAsync(id);

            if (eventViewModel == null)
            {
                return RedirectToAction("Joined");
            }

            string userId = GetUserId();

            await this._eventService.RemoveFromJoinedEventsAsync(userId, eventViewModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            var detailsEventViewModel = await this._eventService.GetDetailsViewModel(id);

            if (detailsEventViewModel == null)
            {
                return RedirectToAction("All");
            }

            return this.View(detailsEventViewModel);
        }
    }
}