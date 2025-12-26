using Api.App.Queries.GetTaskById;
using Api.App.Queries.GetTasks;

namespace Api.App.Interfaces
{
	/// <summary>
	/// Интерфейс для сервиса запросов
	/// </summary>
	public interface ITaskQueryService
	{

		/// <summary>
		/// Получить задачи
		/// </summary>
		/// <param name="query">Данные задач для запроса</param>
		/// <returns></returns>
		Task<List<Objects.TaskDto>> GetTasksAsync(GetTasks taskData);

		/// <summary>
		/// Получить задачу по id
		/// </summary>
		/// <param name="query">Данные задач для запроса</param>
		/// <returns></returns>
		Task<Objects.TaskDto?> GetTaskByIdAsync(GetTaskById taskData);
	}
}
