using Api.App.Interfaces;
using Api.Model.Events;

namespace Api.App.Services
{
	/// <summary>
	/// Сервис для работы с задачами
	/// </summary>
	public class TaskService : ITaskService
	{
		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		public TaskService(
			ITaskEventRepository eventRepository,
			ITaskRepository taskRepository)
		{
			_eventRepository = eventRepository;
			_taskRepository = taskRepository;
		}

		public async Task CreateAsync(CreateTask command)
		{
			var @event = new TaskCreatedEvent(
				Guid.NewGuid(),
				command.Title,
				command.Description,
				command.Deadline
			);

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);
		}


	}
}
