using Homies.Data;
using Homies.Data.Models;
using Homies.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext _dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ICollection<EventViewModel>> GetAllEventsAsync()
        {
            return await this._dbContext.Events
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<ICollection<EventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await _dbContext.Events
                .Where(e => e.EventsParticipants.Any(ep => ep.HelperId == userId))
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<AddEventViewModel> GetAddEventViewModelAsync()
        {
            var types = await this._dbContext.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            var addEventViewModel = new AddEventViewModel
            {
                Types = types
            };

            return addEventViewModel;
        }

        public async Task AddEventAsync(AddEventViewModel addEventViewModel, string userId)
        {
            var eventData = new Event()
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description,
                Start = DateTime.Parse(addEventViewModel.Start),
                End = DateTime.Parse(addEventViewModel.End),
                CreatedOn = DateTime.Now,
                TypeId = addEventViewModel.TypeId,
                OrganiserId = userId
            };

            await this._dbContext.Events.AddAsync(eventData);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<AddEventViewModel?> GetAddEventViewModelByIdAsync(int id)
        {
            var types = await this._dbContext.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            var eventData = await this._dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new AddEventViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    TypeId = e.TypeId,
                    Types = types
                }).FirstOrDefaultAsync();

            return eventData;
        }

        public async Task EditEventAsync(int id, AddEventViewModel addEventViewModel)
        {
            var eventData = await this._dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventData != null)
            {
                eventData.Name = addEventViewModel.Name;
                eventData.Description = addEventViewModel.Description;
                eventData.Start = DateTime.Parse(addEventViewModel.Start);
                eventData.End = DateTime.Parse(addEventViewModel.End);
                eventData.TypeId = addEventViewModel.TypeId;

                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<EventViewModel?> GetEventViewModelByIdAsync(int id)
        {
            EventViewModel? eventViewModel = await _dbContext
                .Events
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                }).FirstOrDefaultAsync();

            return eventViewModel;
        }

        public async Task<EventParticipant?> AddToJoinedEventsAsync(string userId, EventViewModel eventViewModel)
        {
            if (_dbContext.EventsParticipants.Any(ep => ep.HelperId == userId && ep.EventId == eventViewModel.Id))
            {
                return null; //already joined -> return null to refresh the page
            }

            EventParticipant eventParticipant = new EventParticipant()
            {
                EventId = eventViewModel.Id,
                HelperId = userId
            };

            await this._dbContext.EventsParticipants.AddAsync(eventParticipant);
            await this._dbContext.SaveChangesAsync();

            return eventParticipant;
        }

        public async Task RemoveFromJoinedEventsAsync(string userId, EventViewModel eventViewModel)
        {
            EventParticipant? eventParticipant = await this._dbContext.EventsParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == eventViewModel.Id);

            if (eventParticipant != null)
            {
                this._dbContext.EventsParticipants.Remove(eventParticipant);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<DetailsEventViewModel?> GetDetailsViewModel(int id)
        {
            var detailsViewModel = await _dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new DetailsEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                }).FirstOrDefaultAsync();

            return detailsViewModel;
        }
    }
}