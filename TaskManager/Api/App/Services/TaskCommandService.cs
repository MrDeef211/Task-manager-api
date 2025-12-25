using Api.App.Interfaces;
using Api.Model.Events;
using Api.App.Commands.CreateTask;
using Api.App.Commands.UpdateTask;
using Api.App.Commands.StartTask;
using Api.App.Commands.CompleteTask;

namespace Api.App.Services
{
	/// <summary>
	/// Сервис для работы с задачами 
	/// </summary>
	public class TaskCommandService : ITaskService
	{
		// Я оставил и обработчики команд, и сервисы для работы с задачами,
		// Сюда можно ещё добавить какую-то бизнес-логику, если потребуется
		// А обработчики для парса команд
		// Главное не забыть это дописать потом в redme.txt  

		private readonly ITaskEventRepository _eventRepository;
		private readonly ITaskRepository _taskRepository;

		/// <summary>
		/// Сервис для работы с задачами
		/// </summary>
		/// <param name="eventRepository">База </param>
		/// <param name="taskRepository"></param>
		public TaskCommandService(
			ITaskEventRepository eventRepository,
			ITaskRepository taskRepository)
		{
			_eventRepository = eventRepository;
			_taskRepository = taskRepository;
		}


		public async Task CreateAsync(CreateTask taskData)
		{
			//Конструкторы решил пока не делать
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
		}

		public async Task UpdateAsync(UpdateTask taskData)
		{
			//Конструкторы решил пока не делать
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

		public async Task StartAsync(StartTask taskData)
		{
			//Конструкторы решил пока не делать
			var @event = new TaskStartedEvent
			{
				TaskId = taskData.TaskId,
				StartedAt = DateTime.UtcNow
			};

			await _eventRepository.AddAsync(@event);
			await _taskRepository.ApplyAsync(@event);
		}

		public async Task CompleteAsync(CompleteTask taskData)
		{
			//Конструкторы решил пока не делать
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
