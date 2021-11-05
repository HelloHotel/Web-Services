using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Repositories;
using HelloHotel.API.Domain.Services;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Services
{
    public class EventService : IEventService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEventRepository _eventRepository;

        public EventService(IEmployeeRepository employeeRepository, IEventRepository eventRepository)
        {
            _employeeRepository = employeeRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _eventRepository.ListAsync();
        }

        public async Task<IEnumerable<Event>> ListByEmployeeIdAsync(int employeeId)
        {
            return await _eventRepository.FindByEmployeeId(employeeId);
        }

        public async Task<EventResponse> SaveAsync(Event @event)
        {
            var existingEmployee = _employeeRepository.FindByIdAsync(@event.EmployeeId);

            if (existingEmployee == null)
                return new EventResponse("Invalid Event");
            
            try
            {
                await _eventRepository.AddAsync(@event);

                return new EventResponse(@event);
            }
            catch (Exception e)
            {
                return new EventResponse($"An error occurred while saving the product: {e.Message}");
            }
        }

        public async Task<EventResponse> UpdateAsync(int id, Event @event)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(id);
            if (existingEvent == null)
                return new EventResponse("Event not found");

            var existingEmployee = _employeeRepository.FindByIdAsync(@event.EmployeeId);
            if (existingEmployee == null)
                return new EventResponse("Invalid Employee");

            existingEvent.Name = @event.Name;
            existingEvent.Details = @event.Details;
            existingEvent.Color = @event.Color;
            existingEvent.Start = @event.Start;
            existingEvent.End = @event.End;
            existingEvent.Timed = @event.Timed;
            existingEvent.EmployeeId = @event.EmployeeId;

            try
            {
                _eventRepository.Update(existingEvent);

                return new EventResponse(existingEvent);
            }
            catch (Exception e)
            {
                return new EventResponse($"An error occurred while updating the event:{e.Message}");
            }
        }

        public async Task<EventResponse> DeleteAsync(int id)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(id);
            if (existingEvent == null)
                return new EventResponse("Event not found");

            try
            {
                _eventRepository.Remove(existingEvent);

                return new EventResponse(existingEvent);
            }
            catch (Exception e)
            {
                return new EventResponse($"An error occurred while deleting the product: {e.Message}");
            }

        }
    }
}