using Microsoft.EntityFrameworkCore;
using Api.App.Objects;
using Api.Infrastructure.Data;


namespace Api.App.Queries.GetTaskById
{
	/// <summary>
	/// Получить задачу по id
	/// </summary>
	public class GetTaskByIdHandler
	{
		// Я оставил и обработчики запросов, и сервисы для работы с задачами,
		// В сервис можно ещё добавить какую-то бизнес-логику, если потребуется
		// А обработчики для парса запросов

		private readonly ApplicationDbContext _context;

		/// <summary>
		/// Получить задачу по id
		/// </summary>
		/// <param name="context">Таблица задач</param>
		public GetTaskByIdHandler(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Получить задачу по id асинхронно
		/// </summary>
		/// <param name="taskData">Данные задачи для запроса</param>
		/// <returns></returns>
		public async Task<TaskDto?> HandleAsync(GetTaskById taskData)
		{
			return await _context.Tasks
				.Where(t => t.Id == taskData.TaskId)
				.Select(t => new TaskDto
				{
					Id = t.Id,
					Title = t.Title,
					Description = t.Description,
					Deadline = t.Deadline,
					Status = t.Status.ToString(),
				})
				.FirstOrDefaultAsync();
		}
	}
}
