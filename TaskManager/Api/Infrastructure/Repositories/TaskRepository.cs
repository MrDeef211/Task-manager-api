using Api.App.Interfaces;
using Api.Infrastructure.Data;
using Api.Model.Entity;
using Api.Model.Enums;
using Api.Model.Events;
using Microsoft.EntityFrameworkCore;


namespace Api.Infrastructure.Repositories
{
	/// <summary>
	/// Репозиторий для работы с задачами
	/// </summary>
	public class TaskRepository : ITaskRepository
	{
		/// <summary>
		/// Контекст базы данных
		/// </summary>
		private readonly ApplicationDbContext _context;
		/// <summary>
		/// Репозиторий для работы с задачами
		/// </summary>
		/// <param name="context">База данных</param>
		public TaskRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Создать задачу 
		/// </summary>
		/// <param name="event">Данные из события создания задачи</param>
		/// <returns></returns>
		public async Task ApplyAsync(TaskCreatedEvent @event)
		{
			var task = new TaskEntity
			{
				Id = @event.TaskId,
				Title = @event.Title,
				Description = @event.Description,
				Deadline = @event.Deadline,
				CreatedAt = @event.CreatedAt,
				Status = TaskStatusEnum.New
			};

			_context.Tasks.Add(task);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Обновить задачу
		/// </summary>
		/// <param name="event">Данные из события обновления задачи</param>
		/// <returns></returns>
		public async Task ApplyAsync(TaskUpdatedEvent @event)
		{
			var task = await _context.Tasks.FindAsync(@event.TaskId);
			if (task != null)
			{
				task.Title = @event.Title;
				task.Description = @event.Description;
				task.Deadline = @event.Deadline;
				await _context.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Начать выполнение задачи
		/// </summary>
		/// <param name="event">Данные из события начала выполнения задачи</param>
		/// <returns></returns>
		public async Task ApplyAsync(TaskStartedEvent @event)
		{
			var task = await _context.Tasks.FindAsync(@event.TaskId);
			if (task != null)
			{
				task.Status = TaskStatusEnum.InProgress;
				await _context.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Обновить задачу
		/// </summary>
		/// <param name="event">Данные из события обновления задачи</param>
		/// <returns></returns>
		public async Task ApplyAsync(TaskCompletedEvent @event)
		{
			var task = await _context.Tasks.FindAsync(@event.TaskId);
			if (task != null)
			{
				task.Status = TaskStatusEnum.Completed;
				await _context.SaveChangesAsync();
			}

		}

		/// <summary>
		/// Удалить задачу
		/// </summary>
		/// <param name="event">Данные из события для удаления задачи</param>
		/// <returns></returns>
		public async Task ApplyAsync(TaskDeletedEvent @event)
		{
			var task = await _context.Tasks.FindAsync(@event.TaskId);
			if (task != null)
			{
				_context.Tasks.Remove(task);
				await _context.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Получить задачу по идентификатору
		/// </summary>
		/// <remarks> 
		/// Без этого метода не получится сделать валидацию в service
		/// </remarks>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<TaskEntity?> GetByIdAsync(Guid id)
		{
			return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
