using Api.App.Commands.CompleteTask;
using Api.App.Commands.CreateTask;
using Api.App.Commands.DeleteTask;
using Api.App.Commands.StartTask;
using Api.App.Commands.UpdateTask;
using Api.App.Interfaces;
using Api.Model.Enums;
using Api.Model.Events;
using Api.Model.Exceptions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.App.Services
{
	/// <summary>
	/// Сервис для работы с задачами 
	/// Содержит бизнес логику
	/// </summary>
	public class TaskCommandService : ITaskService
	{

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


		public async Task<Guid> CreateAsync(CreateTask taskData)
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

			return taskId;
		}

		public async Task UpdateAsync(UpdateTask taskData)
		{
			var task = await _taskRepository.GetByIdAsync(taskData.TaskId);

			if (task.Status == TaskStatusEnum.Completed)
				throw new DomainException("Нельзя редактировать завершённую задачу");

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

		/// <summary>
		/// Асинхронное изменение статуса задачи на начатое
		/// </summary>
		/// <param name="taskData">Данные задачи для команды</param>
		/// <returns></returns>
		public async Task DeleteAsync(DeleteTask taskData)
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
