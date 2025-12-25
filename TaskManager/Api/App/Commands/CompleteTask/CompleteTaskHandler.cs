using Api.Model.Events;
using Api.App.Interfaces;

namespace Api.App.Commands.CompleteTask
{
	/// <summary>
	/// Изменение статуса задачи на выполненное
	/// </summary>
	public class CompleteTaskHandler
	{
		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		/// <summary>
		/// Изменение статуса задачи на выполненное
		/// </summary>
		/// <param name="eventRepository">База запросов</param>
		/// <param name="taskRepository">База задач</param>
		public CompleteTaskHandler(
			ITaskEventRepository eventRepository,
			ITaskRepository taskRepository)
		{
			_eventRepository = eventRepository;
			_taskRepository = taskRepository;
		}


		/// <summary>
		/// Асинхронное изменение статуса задачи на выполненное
		/// </summary>
		/// <param name="taskData">Данные задачи для команды</param>
		/// <returns></returns>
		public async void HandleAsync(CompleteTask taskData)
		{
			var taskId = Guid.NewGuid();

			var @event = new TaskCompletedEvent
			{
				TaskId = taskData.TaskId,
				CompletedAt = DateTime.UtcNow
			};

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);
		}
	}
}
