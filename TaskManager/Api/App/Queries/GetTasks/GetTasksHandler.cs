using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.App.Objects;

namespace Api.App.Queries.GetTasks
{
	/// <summary>
	/// Получить задачи
	/// </summary>
	public class GetTasksHandler
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// Получить задачи
		/// </summary>
		/// <param name="context">Таблица задач</param>
		public GetTasksHandler(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Получить задачи
		/// </summary>
		/// <param name="query">Данные задач для запроса</param>
		/// <returns></returns>
		public async Task<List<TaskDto>> HandleAsync(GetTasks taskData)
		{
			// AsQueryable чтобы сначала сформировать запросы, а уже потом получить данные
			var tasks = _context.Tasks.AsQueryable();

			if (!string.IsNullOrWhiteSpace(taskData.Status))
			{
				tasks = tasks.Where(t => t.Status.ToString() == taskData.Status);
			}

			if (taskData.FromDate.HasValue)
			{
				tasks = tasks.Where(t => t.CreatedAt >= taskData.FromDate.Value);
			}

			if (taskData.ToDate.HasValue)
			{
				tasks = tasks.Where(t => t.CreatedAt <= taskData.ToDate.Value);
			}

			// HardSearch в приоритете
			if (!string.IsNullOrWhiteSpace(taskData.HardSearch))
			{
				tasks = tasks.Where(t => t.Title.Contains(taskData.HardSearch));
			}
			else if (!string.IsNullOrWhiteSpace(taskData.Search))
			    {
				    tasks = tasks.Where(t =>
					t.Title.Contains(taskData.Search) ||
					t.Description.Contains(taskData.Search));
			    }

			return await tasks
				.Select(t => new TaskDto
				{
					Id = t.Id,
					Title = t.Title,
					Description = t.Description,
					Deadline = t.Deadline,
					CreatedAt = t.CreatedAt,
					StartedAt = t.StartedAt,
					CompletedAt = t.CompletedAt,
					Status = t.Status
				})
				.ToListAsync();
		}
	}
}
