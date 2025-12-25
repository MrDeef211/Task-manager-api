using Api.App.Interfaces;
using Api.Infrastructure.Data;
using Api.Model.Entity;
using System.Text.Json;

namespace Api.Infrastructure.Repositories
{
	/// <summary>
	/// Интерфейс для работы с действиями
	/// </summary>
	public class TaskEventRepository : ITaskEventRepository
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// Интерфейс для работы с действиями
		/// </summary>
		/// <param name="context">База данных</param>
		public TaskEventRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Создать запрос
		/// </summary>
		/// <typeparam name="TEvent">Данные для действия</typeparam>
		/// <param name="domainEvent">Данные текущего действия</param>
		/// <returns></returns>
		public async Task AddAsync<TEvent>(TEvent domainEvent)
		{
			var eventEntity = new TaskEventEntity
			{
				Id = Guid.NewGuid(),
				TaskId = (Guid)domainEvent!.GetType().GetProperty("TaskId")!.GetValue(domainEvent)!,
				EventType = typeof(TEvent).Name,
				EventData = JsonSerializer.Serialize(domainEvent),
				CreatedAt = DateTime.UtcNow
			};

			_context.TaskEvents.Add(eventEntity);
			await _context.SaveChangesAsync();
		}
	}
}
