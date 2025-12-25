using Api.Model.Events;
using Api.App.Interfaces;

namespace Api.App.Commands.CreateTask
{
	/// <summary>
	/// Создание задачи
	/// </summary>
	public class CreateTaskHandler
	{
		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		/// <summary>
		/// Создание задачи
		/// </summary>
		/// <param name="eventRepository">База запросов</param>
		/// <param name="taskRepository">База задач</param>
		public CreateTaskHandler(
			ITaskEventRepository eventRepository,
			ITaskRepository taskRepository )
		{
			_eventRepository = eventRepository;
			_taskRepository = taskRepository;
		}

		/// <summary>
		/// Асинхронное создание задачи
		/// </summary>
		/// <param name="taskData">Данные задачи для команды</param>
		/// <returns></returns>
		public async Task<Guid> HandleAsync(CreateTask taskData)
		{
			var taskId = Guid.NewGuid();

			var @event = new TaskCreatedEvent
			{
				TaskId = taskId,
				Title = taskData.Title,
				Description = taskData.Description,
				Deadline = taskData.Deadline,
				CreatedAt = DateTime.UtcNow
			};

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);

			return taskId;
		}
	}
}
