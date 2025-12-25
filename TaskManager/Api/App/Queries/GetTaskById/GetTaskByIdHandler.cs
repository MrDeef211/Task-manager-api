using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.App.Objects;


namespace Api.App.Queries.GetTaskById
{
	/// <summary>
	/// Получить задачу по id
	/// </summary>
	public class GetTaskByIdHandler
	{
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
					Status = t.Status
				})
				.FirstOrDefaultAsync();
		}
	}
}
