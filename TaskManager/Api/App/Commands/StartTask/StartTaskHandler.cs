using Api.Model.Events;
using Api.App.Interfaces;

namespace Api.App.Commands.StartTask
{
	/// <summary>
	/// Изменение статуса задачи на начатое
	/// </summary>
	public class StartTaskHandler
	{
		// Я оставил и обработчики команд, и сервис для работы с задачами,
		// В сервис можно ещё добавить какую-то бизнес-логику, если потребуется
		// А обработчики для парса команд

		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		/// <summary>
		/// Изменение статуса задачи на начатое
		/// </summary>
		/// <param name="eventRepository">База запросов</param>
		/// <param name="taskRepository">База задач</param>
		public StartTaskHandler(
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
		public async void HandleAsync(StartTask taskData)
		{
			var @event = new TaskStartedEvent
			{
				TaskId = taskData.TaskId,
				StartedAt = DateTime.UtcNow
			};

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);
		}
	}
}
