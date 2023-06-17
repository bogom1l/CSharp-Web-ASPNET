using Homies.Data.Models;
using Homies.ViewModels;

namespace Homies.Services
{
    public interface IEventService
    {
        Task<ICollection<EventViewModel>> GetAllEventsAsync();
        Task<ICollection<EventViewModel>> GetJoinedEventsAsync(string userId);
        Task<AddEventViewModel> GetAddEventViewModelAsync();
        Task AddEventAsync(AddEventViewModel addEventViewModel,string userId);
        Task<AddEventViewModel?> GetAddEventViewModelByIdAsync(int id);
        Task EditEventAsync(int id, AddEventViewModel addEventViewModel);
        Task<EventViewModel?> GetEventViewModelByIdAsync(int id);
        Task<EventParticipant?> AddToJoinedEventsAsync(string userId, EventViewModel eventViewModel);
        Task RemoveFromJoinedEventsAsync(string userId, EventViewModel eventViewModel);
        Task<DetailsEventViewModel?> GetDetailsViewModel(int id);
    }
}
