using Api.App.Interfaces;
using Api.Model.Events;

namespace Api.App.Commands.DeleteTask
{
	/// <summary>
	/// Удаление задачи
	/// </summary>
	public class DeleteTaskHandler
	{
		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		/// <summary>
		/// Изменение статуса задачи на начатое
		/// </summary>
		/// <param name="eventRepository">База запросов</param>
		/// <param name="taskRepository">База задач</param>
		public DeleteTaskHandler(
			ITaskEventRepository eventRepository,
			ITaskRepository taskRepository)
		{
			_eventRepository = eventRepository;
			_taskRepository = taskRepository;
		}

		/// <summary>
		/// Асинхронное изменение статуса задачи на начатое
		/// </summary>
		/// <param name="taskData">Данные задачи для команды</param>
		/// <returns></returns>
		public async void HandleAsync(DeleteTask taskData)
		{
			var @event = new TaskDeletedEvent
			{
				TaskId = taskData.TaskId,
			};

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);
		}
	}
}
