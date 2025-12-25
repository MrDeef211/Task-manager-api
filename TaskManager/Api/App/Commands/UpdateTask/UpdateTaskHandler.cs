using Api.Model.Events;
using Api.App.Interfaces;

namespace Api.App.Commands.UpdateTask
{
	/// <summary>
	/// Обновление задачи
	/// </summary>
	public class UpdateTaskHandler
	{
		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		/// <summary>
		/// Обновление задачи
		/// </summary>
		/// <param name="eventRepository">База событий</param>
		/// <param name="taskRepository">База задач</param>
		public UpdateTaskHandler(
			ITaskEventRepository eventRepository,
			ITaskRepository taskRepository)
		{
			_eventRepository = eventRepository;
			_taskRepository = taskRepository;
		}

		/// <summary>
		/// Асинхронное обновление задачи
		/// </summary>
		/// <param name="taskData">Данные задачи для команды</param>
		/// <returns></returns>
		public async void HandleAsync(UpdateTask taskData)
		{

			var @event = new TaskUpdatedEvent
			{
				TaskId = taskData.TaskId,
				Title = taskData.Title,
				Description = taskData.Description,
				Deadline = taskData.Deadline
			};

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);
		}
	}
}
